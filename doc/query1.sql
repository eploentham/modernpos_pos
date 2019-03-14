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


ALTER TABLE `modern_pos`.`b_foods_special` 
ADD COLUMN `host_id` VARCHAR(45) NULL AFTER `user_cancel`,
ADD COLUMN `branch_id` VARCHAR(45) NULL AFTER `host_id`,
ADD COLUMN `device_id` VARCHAR(45) NULL AFTER `branch_id`;

ALTER TABLE `modern_pos`.`b_foods_topping` 
ADD COLUMN `host_id` VARCHAR(45) NULL AFTER `user_cancel`,
ADD COLUMN `branch_id` VARCHAR(45) NULL AFTER `host_id`,
ADD COLUMN `device_id` VARCHAR(45) NULL AFTER `branch_id`;





