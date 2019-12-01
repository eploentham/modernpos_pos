ALTER TABLE `modern_pos`.`t_order` 
CHANGE COLUMN `order_id` `order_id` INT(11) NOT NULL ,
CHANGE COLUMN `lot_id` `lot_id` INT NULL DEFAULT NULL ,
CHANGE COLUMN `row1` `row1` INT NULL DEFAULT NULL ,
CHANGE COLUMN `area_int` `area_id` INT(11) NULL DEFAULT NULL ;

ALTER TABLE `modern_pos`.`t_order` 
CHANGE COLUMN `status_foods_1` `status_foods_1` VARCHAR(55) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `status_foods_2` `status_foods_2` VARCHAR(55) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `status_foods_3` `status_foods_3` VARCHAR(55) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `status_bill` `status_bill` VARCHAR(55) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL COMMENT '0=default,1=bill check ,2=check complete' ,
CHANGE COLUMN `bill_check_date` `bill_check_date` VARCHAR(55) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `status_cook` `status_cook` VARCHAR(55) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL COMMENT '0=default,1=cook receive,2=cook finish' ,
CHANGE COLUMN `cook_receive_date` `cook_receive_date` VARCHAR(55) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `cook_finish_date` `cook_finish_date` VARCHAR(55) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `active` `active` VARCHAR(55) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `void_date` `void_date` VARCHAR(55) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `status_void` `status_void` VARCHAR(55) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `status_to_go` `status_to_go` VARCHAR(55) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL COMMENT '0=default,1=in restaurant,2=to go' ,
CHANGE COLUMN `bill_id` `bill_id` INT NULL DEFAULT NULL ,
CHANGE COLUMN `status_closeday` `status_closeday` VARCHAR(55) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `closeday_id` `closeday_id` INT NULL DEFAULT NULL ,
CHANGE COLUMN `host_id` `host_id` VARCHAR(55) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `branch_id` `branch_id` VARCHAR(55) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `device_id` `device_id` VARCHAR(55) NULL DEFAULT NULL ,
CHANGE COLUMN `date_create` `date_create` VARCHAR(55) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ,
CHANGE COLUMN `date_modi` `date_modi` VARCHAR(55) CHARACTER SET 'utf8' COLLATE 'utf8_bin' NULL DEFAULT NULL ;


CREATE TABLE sequence (lot_id INT NOT NULL);

INSERT INTO sequence VALUES (0);

UPDATE sequence SET lot_id=LAST_INSERT_ID(lot_id+1);

SELECT LAST_INSERT_ID();

DELIMITER //
CREATE PROCEDURE gen_lot_id
(OUT lot_id VARCHAR(25))
BEGIN
	UPDATE sequence SET lot_id=LAST_INSERT_ID(lot_id+1);
    SELECT LAST_INSERT_ID() INTO lot_id ;
  
END //
DELIMITER ;

ALTER TABLE `modern_pos`.`b_foods` 
ADD COLUMN `status_recommend` VARCHAR(45) NULL AFTER `filename`;

CREATE TABLE `modern_pos`.`b_foods_special` (
  `foods_spec_id` INT NOT NULL AUTO_INCREMENT,
  `foods_id` INT NULL,
  `foods_spec_name` VARCHAR(255) NULL,
  `active` VARCHAR(45) NULL,
  `remark` VARCHAR(255) NULL,
  `date_create` VARCHAR(45) NULL,
  `date_modi` VARCHAR(45) NULL,
  `date_cancel` VARCHAR(45) NULL,
  `user_create` VARCHAR(45) NULL,
  `user_modi` VARCHAR(45) NULL,
  `user_cancel` VARCHAR(45) NULL,
  PRIMARY KEY (`foods_spec_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=110';

CREATE TABLE `modern_pos`.`b_foods_topping` (
  `foods_topping_id` INT NOT NULL AUTO_INCREMENT,
  `foods_id` INT NULL,
  `foods_topping_name` VARCHAR(255) NULL,
  `price` DECIMAL(17,2) NULL,
  `active` VARCHAR(45) NULL,
  `remark` VARCHAR(255) NULL,
  `date_create` VARCHAR(45) NULL,
  `date_modi` VARCHAR(45) NULL,
  `date_cancel` VARCHAR(45) NULL,
  `user_create` VARCHAR(45) NULL,
  `user_modi` VARCHAR(45) NULL,
  `user_cancel` VARCHAR(45) NULL,
  PRIMARY KEY (`foods_topping_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=111';

CREATE TABLE `ivf_101`.`b_item_drug_frequency` (
  `frequency_id` INT NOT NULL AUTO_INCREMENT,
  `frequency_code` VARCHAR(45) NULL,
  `frequency_description_e` VARCHAR(255) NULL,
  `frequency_description_t` VARCHAR(255) NULL,
  `actice` VARCHAR(45) NULL,
  `remark` VARCHAR(45) NULL,
  `date_create` VARCHAR(45) NULL,
  `date_modi` VARCHAR(45) NULL,
  `date_cancel` VARCHAR(45) NULL,
  `user_create` VARCHAR(45) NULL,
  `user_modi` VARCHAR(45) NULL,
  `user_cancel` VARCHAR(45) NULL,
  PRIMARY KEY (`frequency_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=225';


ALTER TABLE `modern_pos`.`b_foods_special` 
ADD COLUMN `host_id` VARCHAR(45) NULL AFTER `user_cancel`,
ADD COLUMN `branch_id` VARCHAR(45) NULL AFTER `host_id`,
ADD COLUMN `device_id` VARCHAR(45) NULL AFTER `branch_id`;

ALTER TABLE `modern_pos`.`b_foods_topping` 
ADD COLUMN `host_id` VARCHAR(45) NULL AFTER `user_cancel`,
ADD COLUMN `branch_id` VARCHAR(45) NULL AFTER `host_id`,
ADD COLUMN `device_id` VARCHAR(45) NULL AFTER `branch_id`;

ALTER TABLE `modern_pos`.`b_restaurant` 
ADD COLUMN `receipt_header4` VARCHAR(255) NULL AFTER `receipt_footer3`,
ADD COLUMN `receipt_header5` VARCHAR(255) NULL AFTER `receipt_header4`,
ADD COLUMN `receipt_footer4` VARCHAR(255) NULL AFTER `receipt_header5`,
ADD COLUMN `receipt_footer5` VARCHAR(255) NULL AFTER `receipt_footer4`;

ALTER TABLE `modern_pos`.`b_restaurant` 
ADD COLUMN `printer_bill_margin_top` INT NULL AFTER `receipt_footer3`,
ADD COLUMN `printer_bill_margin_left` INT NULL AFTER `printer_bill_margin_top`,
ADD COLUMN `printer_bill_margin_right` INT NULL AFTER `printer_bill_margin_left`,
ADD COLUMN `printer_bill_print_top` INT NULL AFTER `printer_bill_margin_right`,
ADD COLUMN `printer_bill_print_left` INT NULL AFTER `printer_bill_print_top`,
ADD COLUMN `printer_bill_print_right` INT NULL AFTER `printer_bill_print_left`;


ALTER TABLE `ivf_101`.`t_stock_rec_detail` 
ADD COLUMN `row1` INT NULL AFTER `user_cancel`;

ALTER TABLE `ivf_101`.`t_stock_draw_detail` 
ADD COLUMN `row1` INT NULL AFTER `user_cancel`;

ALTER TABLE `ivf_101`.`t_stock_return_detail` 
ADD COLUMN `row1` INT NULL AFTER `user_cancel`;

ALTER TABLE `ivf`.`lab_t_opu_embryo_dev` 
ADD COLUMN `desc4` VARCHAR(255) NULL AFTER `embryo_dev_date`;



ALTER TABLE `modern_pos`.`b_foods` 
ADD COLUMN `status_create` VARCHAR(45) NULL DEFAULT 0 COMMENT '0=default;1=สร้างรายการเอง เป็นก๋วยเตี่ยว' AFTER `status_recommend`;


ALTER TABLE ivf_101_donor.CreditCardAccount CHANGE COLUMN CreditCardID CreditCardID INT(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT = 4;



CREATE TABLE `modern_pos`.`t_order_topping` (
  `order_topping_id` BIGINT NOT NULL AUTO_INCREMENT,
  `order_id` BIGINT NULL,
  `foods_topping_id` BIGINT NULL,
  `active` VARCHAR(45) NULL,
  `remark` VARCHAR(45) NULL,
  `row1` VARCHAR(45) NULL,
  `date_create` VARCHAR(45) NULL,
  `date_modi` VARCHAR(45) NULL,
  `date_cancel` VARCHAR(45) NULL,
  `user_create` VARCHAR(45) NULL,
  `user_modi` VARCHAR(45) NULL,
  `user_cancel` VARCHAR(45) NULL,
  `host_id` VARCHAR(45) NULL,
  `branch_id` VARCHAR(45) NULL,
  `device_id` VARCHAR(45) NULL,
  PRIMARY KEY (`order_topping_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=131';

CREATE TABLE `modern_pos`.`t_order_special` (
  `order_special_id` BIGINT NOT NULL AUTO_INCREMENT,
  `order_id` BIGINT NULL,
  `foods_spec_id` BIGINT NULL,  
  `active` VARCHAR(45) NULL,
  `remark` VARCHAR(45) NULL,
  `row1` VARCHAR(45) NULL,
  `date_create` VARCHAR(45) NULL,
  `date_modi` VARCHAR(45) NULL,
  `date_cancel` VARCHAR(45) NULL,
  `user_create` VARCHAR(45) NULL,
  `user_modi` VARCHAR(45) NULL,
  `user_cancel` VARCHAR(45) NULL,
  PRIMARY KEY (`order_special_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=132';

ALTER TABLE `modern_pos`.`t_order_special` 
ADD COLUMN `host_id` VARCHAR(45) NULL AFTER `user_cancel`,
ADD COLUMN `branch_id` VARCHAR(45) NULL AFTER `host_id`,
ADD COLUMN `device_id` VARCHAR(45) NULL AFTER `branch_id`;

ALTER TABLE `modern_pos`.`t_order_topping` 
ADD COLUMN `qty` DECIMAL(17,2) NULL DEFAULT 0 AFTER `device_id`,
ADD COLUMN `price` DECIMAL(17,2) NULL DEFAULT 0 AFTER `qty`;




ALTER TABLE `modern_pos`.`b_foods` 
ADD COLUMN `price_plus_togo` DECIMAL(17,2) NULL AFTER `status_create`;

ALTER TABLE `modern_pos`.`t_order` 
ADD COLUMN `price_plus_togo` DECIMAL(17,2) NULL AFTER `hour_id`;



ALTER TABLE `onsoon`.`t_closeday` 
ADD COLUMN `date_create` VARCHAR(45) NULL AFTER `weather`,
ADD COLUMN `date_modi` VARCHAR(45) NULL AFTER `date_create`;

ALTER TABLE `onsoon`.`t_closeday` 
CHANGE COLUMN `date_create` `date_create` VARCHAR(45) NULL DEFAULT NULL AFTER `branch_id`,
CHANGE COLUMN `date_modi` `date_modi` VARCHAR(45) NULL DEFAULT NULL AFTER `date_create`;

ALTER TABLE `onsoon`.`t_closeday` 
ADD COLUMN `expense_1` DECIMAL(17,2) NULL AFTER `weather`;

ALTER TABLE `onsoon`.`t_closeday` 
ADD COLUMN `expense_2` DECIMAL(17,2) NULL AFTER `expense_1`,
ADD COLUMN `expense_3` DECIMAL(17,2) NULL AFTER `expense_2`,
ADD COLUMN `expense_4` DECIMAL(17,2) NULL AFTER `expense_3`,
ADD COLUMN `expense_5` DECIMAL(17,2) NULL AFTER `expense_4`;

ALTER TABLE `onsoon`.`t_closeday` 
ADD COLUMN `cash_receive` DECIMAL(17,2) NULL AFTER `expense_1`,
ADD COLUMN `cash_ton` DECIMAL(17,2) NULL AFTER `cash_receive`;

drop table if exists onsoon.t_closeday;
CREATE TABLE onsoon.`t_closeday` (
  `closeday_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `closeday_date` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `res_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `amount` decimal(17,2) DEFAULT NULL,
  `discount` decimal(17,2) DEFAULT NULL,
  `total` decimal(17,2) DEFAULT NULL,
  `service_charge` decimal(17,2) DEFAULT NULL,
  `vat` decimal(17,2) DEFAULT NULL,
  `nettotal` decimal(17,2) DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_void` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `void_date` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `void_user` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `cnt_bill` decimal(17,2) DEFAULT NULL,
  `bill_amount` decimal(17,2) DEFAULT NULL,
  `cnt_order` decimal(17,2) DEFAULT NULL,
  `amount_order` decimal(17,2) DEFAULT NULL,
  `closeday_user` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `cash_receive1` decimal(17,2) DEFAULT NULL,
  `cash_receive2` decimal(17,2) DEFAULT NULL,
  `cash_receive3` decimal(17,2) DEFAULT NULL,
  `cash_draw1` decimal(17,2) DEFAULT NULL,
  `cash_draw2` decimal(17,2) DEFAULT NULL,
  `cash_draw3` decimal(17,2) DEFAULT NULL,
  `cash_receive1_remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `cash_receive2_remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `cash_receive3_remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `cash_draw1_remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `cash_draw2_remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `cash_draw3_remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `host_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `weather` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '0=default;1=sun;2=',
  `expense_1` decimal(17,2) DEFAULT NULL,
  `expense_2` decimal(17,2) DEFAULT NULL,
  `expense_3` decimal(17,2) DEFAULT NULL,
  `expense_4` decimal(17,2) DEFAULT NULL,
  `expense_5` decimal(17,2) DEFAULT NULL,
  `cash_receive` decimal(17,2) DEFAULT NULL,
  `cash_ton` decimal(17,2) DEFAULT NULL,
  PRIMARY KEY (`closeday_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1090000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=109';


ALTER TABLE `onsoon`.`t_bill` 
ADD COLUMN `status_payment` VARCHAR(45) NULL DEFAULT 0 COMMENT '0=default, 1=cash,2=' AFTER `user_cancel`;

