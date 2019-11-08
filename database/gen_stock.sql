/*
    step การสร้าง stock card
    1.  จะทำการ ลบ table t_stock  เพื่อทำการคำนวณใหม่ เพราะถ้ามีการ  รับเข้า หรือ เบิกอก ตัดจ่าย หรือ ขายไป ไม่ถูกต้อง ก็เข้าไปยกเลิก บิลนั้นๆ ในหน้าจอ รายการนั้นๆ
        พอ เข้ามาดู หน้ารายการ stock card จะได้ gen stock ใหม่
        ถ้าไม่ถูกต้อง ก็ เข้าไป เพิ่ม หรือ ยกเลิก แล้วกลับมาดูหน้า stock card 
        หน้าจอ stock card ก็จะ gen stock ใหม่
    2.  การ gen stock จะเป็น store procedure 
        เพราะ 2.1 เพิ่มความเร็วในการทำงาน เพราะ ให้ database เป็นคนทำงาน ก็น่าจะเร็วที่สุด ขึ้นอยู่กับ spec ของเครื่องคอม
        2.2 User สามารถ ทำงานได้ ได้ทั้ง web Mobile Windows หรืออื่นๆ ได้ เพียงแค่ ทำหน้าจอ ส่วน function การทำงาน อยู่ใน database
    3.  ขั้นตอนการ gen stock ประกอบไปด้วย
        3.1  ลบ table t_stock
        3.2  ดึง ข้อมูล รับเข้า แล้ว insert ลง t_stock status เป็น 1
        3.3  ดึง ข้อมูล เบิกออก ตัดจ่าย แล้ว insert ลง t_stock status เป็น 2
        3.4  ดึง ข้อมูล ขาย โดยดึงจาก order แต่เป็น status ที่ชำระเงินแล้ว แล้ว insert ลง t_stock status เป็น 3
        3.4  ดึง ยอด onhand ของปีก่อน แล้ว insert ลง t_stock status เป็น 0
        3.5  คำนวณ onhand โดย ยึดสูตร  price * weight * qty
        3.6  ลำดับการแสดง sort(t_stock status) 0 -> 1 -> 2 -> 3


    จำนวนbill/วัน             3000
    จำนวน รายการ/bill         20           60,000
    จำนวน material/รายการนั้นๆ  20        1,200,000
    จำนวนวันใน 1 ปี             365  438,000,000.00 

*/
drop procedure  IF EXISTS gen_stock;
DELIMITER //	
CREATE DEFINER=`root`@`localhost` PROCEDURE `gen_stock`()
BEGIN
	DECLARE yearid VARCHAR(4) DEFAULT "";
	DECLARE yearCur INT;
	DECLARE yearPart INT;

	DECLARE curmaterial CURSOR FOR Select material_id,material_name from modern_pos.b_material where active = '1';	
	DECLARE curRec CURSOR FOR
		Select matr.matr_id,matr.matr_code, matr.matr_date ,matrd.matr_detail_id,matrd.material_id, matrd.price, matrd.qty, matrd.weight
		From t_material_rec matr 
		left join t_material_rec_detail matrd on matr.matr_id = matrd.matr_id and matr.active = '1'
		where matr.active = '1' and year(matr.matr_date) = yearCur;
	DECLARE curDraw CURSOR FOR
		Select matd.matd_id, matd.matd_code, matd.matd_date , matdd.matd_detail_id,matdd.material_id, matdd.price, matdd.qty, matdd.weight
		From t_material_draw matd
		left join t_material_draw_detail matdd on matd.matd_id = matdd.matd_id and matd.active = '1'
		where matd.active = '1' and year(matd.matd_date) = yearCur;
	DECLARE curOrd CURSOR FOR 
		Select ord.order_id, ord.foods_code, ord.order_date, ordm.order_material_id, ordm.material_id, ordm.price, ordm.qty, ordm.weight
		From t_order ord
        Left Join t_order_material ordm on ord.order_id = ordm.order_id and ordm.active = '1'
        Where ord.active = '1' and year(ord.order_date) = yearCur and ord.status_bill = '2';
	DECLARE curCal CURSOR FOR
		Select stock_id, material_id, price, qty, weight, rec_draw_matr_id, status_rec_draw, rec_draw_date, onhand
		From t_stock
        Order By rec_draw_date, status_rec_draw;
        
	Delete From t_stock;
	SET yearCur = (SELECT YEAR(CURRENT_DATE()));
	set yearPart = yearCur-1;
    
	/* OPEN curmaterial;
	BEGIN
		-- DECLARE exit_flag INT DEFAULT 0;
		-- DECLARE CONTINUE HANDLER NOT FOUND SET exit_flag = 1;
		DECLARE materialid bigint DEFAULT 0;
		DECLARE materialname VARCHAR(255) DEFAULT "";
		DECLARE nameYear VARCHAR(11) DEFAULT "";
		DECLARE matrid bigint DEFAULT 0;
		DECLARE matrcode VARCHAR(45) DEFAULT "";
		DECLARE matrdetailid bigint DEFAULT 0;
		DECLARE price1 DECIMAL(17,4) DEFAULT 0;
		DECLARE qty1 DECIMAL(17,4) DEFAULT 0;
		DECLARE weight1 DECIMAL(17,4) DEFAULT 0;
		DECLARE recdrawdate VARCHAR(45) DEFAULT "";
		DECLARE finished INT DEFAULT false;
		DECLARE CONTINUE HANDLER FOR NOT FOUND SET finished = true;

		mat_loop: LOOP
        FETCH  curmaterial INTO materialid, materialname;
            IF finished THEN LEAVE mat_loop; 
            END IF;
            insert into t_stock 
				set material_id = materialid
				;
        
      END LOOP;
	END;
	CLOSE curmaterial; */
	OPEN curRec;
	BEGIN
		DECLARE materialid bigint DEFAULT 0;
		DECLARE materialname VARCHAR(255) DEFAULT "";
		DECLARE matrid bigint DEFAULT 0;
		DECLARE matrcode VARCHAR(45) DEFAULT "";
		DECLARE matrdetailid bigint DEFAULT 0;
		DECLARE price1 DECIMAL(17,4) DEFAULT 0;
		DECLARE qty1 DECIMAL(17,4) DEFAULT 0;
		DECLARE weight1 DECIMAL(17,4) DEFAULT 0;
		DECLARE recdrawdate VARCHAR(45) DEFAULT "";
		DECLARE finished INT DEFAULT false;
		DECLARE CONTINUE HANDLER FOR NOT FOUND SET finished = true;

		rec_loop: LOOP
			FETCH curRec INTO matrid, matrcode, recdrawdate, matrdetailid, materialid, price1, qty1, weight1;
            IF finished THEN LEAVE rec_loop; 
            END IF;
            insert into t_stock set
				material_id = matrdetailid
				,price = price1
				,qty = qty1
				,weight = weight1
				,rec_draw_matr_id = matrdetailid
				,rec_draw_date = recdrawdate
				,status_rec_draw = '1'	-- rec
				,remark = matrcode
                ,onhand = 0
				;
		END LOOP;
	END;
	CLOSE curRec;

	OPEN curDraw;
	BEGIN
		DECLARE materialid bigint DEFAULT 0;
		DECLARE materialname VARCHAR(255) DEFAULT "";
		DECLARE matrid bigint DEFAULT 0;
		DECLARE matrcode VARCHAR(45) DEFAULT "";
		DECLARE matrdetailid bigint DEFAULT 0;
		DECLARE price1 DECIMAL(17,4) DEFAULT 0;
		DECLARE qty1 DECIMAL(17,4) DEFAULT 0;
		DECLARE weight1 DECIMAL(17,4) DEFAULT 0;
		DECLARE recdrawdate VARCHAR(45) DEFAULT "";
		DECLARE finished INT DEFAULT false;
		DECLARE CONTINUE HANDLER FOR NOT FOUND SET finished = true;

		draw_loop: LOOP
			FETCH curDraw INTO matrid, matrcode, recdrawdate, matrdetailid, materialid, price1, qty1, weight1;
            IF finished THEN LEAVE draw_loop; 
            END IF;
            insert into t_stock set
				material_id = matrdetailid
				,price = price1
				,qty = qty1
				,weight = weight1
				,rec_draw_matr_id = matrdetailid
				,rec_draw_date = recdrawdate
				,status_rec_draw = '2'	-- draw
				,remark = matrcode
                ,onhand = 0
				;
		END LOOP;
	END;
	CLOSE curDraw;
    
    OPEN curOrd;
	BEGIN
		DECLARE materialid bigint DEFAULT 0;
		DECLARE statusrecdraw VARCHAR(1) DEFAULT "";
		DECLARE stockid bigint DEFAULT 0;
		DECLARE matrcode VARCHAR(45) DEFAULT "";
		DECLARE recdrawmatrid bigint DEFAULT 0;
		DECLARE price1 DECIMAL(17,4) DEFAULT 0;
		DECLARE qty1 DECIMAL(17,4) DEFAULT 0;
		DECLARE weight1 DECIMAL(17,4) DEFAULT 0;
		DECLARE recdrawdate VARCHAR(45) DEFAULT "";
		DECLARE finished INT DEFAULT false;
		DECLARE CONTINUE HANDLER FOR NOT FOUND SET finished = true;

		ord_loop: LOOP
			-- 					ord.order_id, ord.foods_code, ord.order_date, ordm.order_material_id, ordm.material_id, ordm.price, ordm.qty, ordm.weight
			FETCH curOrd INTO materialid, matrcode, recdrawdate, recdrawmatrid, materialid, price1, qty1, weight1;
            IF finished THEN LEAVE ord_loop; 
            END IF;
            insert into t_stock set
				material_id = materialid
				,price = price1
				,qty = qty1
				,weight = weight1
				,rec_draw_matr_id = recdrawmatrid
				,rec_draw_date = recdrawdate
				,status_rec_draw = '3'	-- order
				,remark = matrcode
				;
		END LOOP;
	END;
	CLOSE curOrd;
    
    OPEN curCal;
	BEGIN
		DECLARE materialid bigint DEFAULT 0;
		DECLARE statusrecdraw VARCHAR(1) DEFAULT "";
		DECLARE stockid bigint DEFAULT 0;
		DECLARE onhand1 DECIMAL(17,4) DEFAULT 0;
		DECLARE recdrawmatrid bigint DEFAULT 0;
		DECLARE price1 DECIMAL(17,4) DEFAULT 0;
		DECLARE qty1 DECIMAL(17,4) DEFAULT 0;
		DECLARE weight1 DECIMAL(17,4) DEFAULT 0;
		DECLARE recdrawdate VARCHAR(45) DEFAULT "";
		DECLARE finished INT DEFAULT false;
        DECLARE total DECIMAL(17,4) DEFAULT 0;
		DECLARE CONTINUE HANDLER FOR NOT FOUND SET finished = true;

		cal_loop: LOOP
			FETCH curCal INTO stockid, materialid, price1, qty1, weight1, recdrawmatrid, statusrecdraw, recdrawdate, onhand1;
            IF finished THEN LEAVE cal_loop; 
            END IF;
            set total = (price1 * qty1) * weight1;
            Update t_stock set
				onhand = total
				,remark = ""
			Where stock_id = stockid
				;
		END LOOP;
	END;
	CLOSE curCal;
END

DELIMITER ;