CREATE TABLE `modern_pos`.`b_foods_material` (
  `material_id` BIGINT NOT NULL AUTO_INCREMENT,
  `material_name` VARCHAR(255) NULL,
  `price` DECIMAL(17,2) NULL,
  `weight` DECIMAL(17,4) NULL,
  `active` VARCHAR(45) NULL,
  `remark` VARCHAR(45) NULL,
  `date_create` VARCHAR(45) NULL,
  `date_modi` VARCHAR(45) NULL,
  `date_cancel` VARCHAR(45) NULL,
  `user_create` VARCHAR(45) NULL,
  `user_modi` VARCHAR(45) NULL,
  `user_cancel` VARCHAR(45) NULL,
  `host_id` VARCHAR(45) NULL,
  `branch_id` VARCHAR(45) NULL,
  `device_id` VARCHAR(45) NULL,
  PRIMARY KEY (`material_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=140';


ALTER TABLE `modern_pos`.`b_foods_material` 
ADD COLUMN `sort1` VARCHAR(45) NULL AFTER `device_id`;

ALTER TABLE `modern_pos`.`b_foods_material` 
RENAME TO  `modern_pos`.`b_material` ;


ALTER TABLE `modern_pos`.`b_material` 
ADD COLUMN `material_code` VARCHAR(45) NULL AFTER `sort1`;


CREATE TABLE `modern_pos`.`b_foods_material` (
  `foods_material_id` BIGINT NOT NULL AUTO_INCREMENT,
  `foods_id` BIGINT ,
  `material_name` VARCHAR(255) NULL,
  `price` DECIMAL(17,2) NULL,
  `weight` DECIMAL(17,4) NULL,
  `active` VARCHAR(45) NULL,
  `remark` VARCHAR(45) NULL,
  `date_create` VARCHAR(45) NULL,
  `date_modi` VARCHAR(45) NULL,
  `date_cancel` VARCHAR(45) NULL,
  `user_create` VARCHAR(45) NULL,
  `user_modi` VARCHAR(45) NULL,
  `user_cancel` VARCHAR(45) NULL,
  `host_id` VARCHAR(45) NULL,
  `branch_id` VARCHAR(45) NULL,
  `device_id` VARCHAR(45) NULL,
  PRIMARY KEY (`foods_material_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=141';



ALTER TABLE `modern_pos`.`b_foods_material` 
ADD COLUMN `material_id` BIGINT NULL AFTER `foods_id`;
ALTER TABLE `modern_pos`.`b_foods_material` 
ADD COLUMN `sort1` VARCHAR(45) NULL AFTER `qty`;


ALTER TABLE `modern_pos`.`b_material` 
ADD COLUMN `material_type_id` BIGINT NULL AFTER `material_code`;


CREATE TABLE `t_order_material` (
  `order_material_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `material_id` bigint(20) ,
  `foods_id` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `order_id` bigint(20) DEFAULT NULL,
  `material_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `foods_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `price` decimal(17,2) DEFAULT NULL,
  `weight` decimal(17,4) DEFAULT NULL,
  `active` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `host_id` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  
  PRIMARY KEY (`order_material_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1430000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=143';
ALTER TABLE `modern_pos`.`t_order_material` 
ADD COLUMN `foods_material_id` BIGINT NULL AFTER `order_id`;




CREATE TABLE `modern_pos`.`b_unit` (
  `unit_id` BIGINT NOT NULL AUTO_INCREMENT,
  `unit_name` VARCHAR(255) NULL,
  `active` VARCHAR(45) NULL,
  `remark` VARCHAR(255) NULL,
  `date_create` VARCHAR(45) NULL,
  `date_modi` VARCHAR(45) NULL,
  `date_cancel` VARCHAR(45) NULL,
  `user_create` VARCHAR(45) NULL,
  `user_modi` VARCHAR(45) NULL,
  `user_cancel` VARCHAR(45) NULL,
  `status_unit` VARCHAR(45) NULL COMMENT '0=default, 1= material',
  `sort1` VARCHAR(45) NULL,
  PRIMARY KEY (`unit_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=144';

ALTER TABLE `modern_pos`.`b_material` 
ADD COLUMN `unit_id` BIGINT NULL AFTER `material_type_id`;

ALTER TABLE `modern_pos`.`b_unit` 
ADD COLUMN `unit_code` VARCHAR(45) NULL AFTER `unit_id`;

ALTER TABLE `modern_pos`.`b_unit` 
ADD COLUMN `host_id` VARCHAR(45) NULL AFTER `sort1`,
ADD COLUMN `branch_id` VARCHAR(45) NULL AFTER `host_id`,
ADD COLUMN `device_id` VARCHAR(45) NULL AFTER `branch_id`;

ALTER TABLE `modern_pos`.`b_foods_material` 
ADD COLUMN `unit_id` BIGINT NULL AFTER `sort1`,
ADD COLUMN `unit_id_cal` BIGINT NULL AFTER `unit_id`;

ALTER TABLE `modern_pos`.`b_material` 
ADD COLUMN `unit_id_cal` BIGINT NULL AFTER `unit_id`;


ALTER TABLE `modern_pos`.`b_material` 
CHANGE COLUMN `unit_id_cal` `unit_cal_id` BIGINT(20) NULL DEFAULT NULL ;



CREATE TABLE `modern_pos`.`t_material` (
  `matrl_id` BIGINT NOT NULL AUTO_INCREMENT,
  `matr_code` VARCHAR(45) NULL,
  `matr_date` VARCHAR(45) NULL,
  `active` VARCHAR(45) NULL,
  `remark` VARCHAR(45) NULL,
  `date_create` VARCHAR(45) NULL,
  `date_modi` VARCHAR(45) NULL,
  `date_cancel` VARCHAR(45) NULL,
  `user_create` VARCHAR(45) NULL,
  `user_modi` VARCHAR(45) NULL,
  `user_cancel` VARCHAR(45) NULL,
  `host_id` VARCHAR(45) NULL,
  `branch_id` VARCHAR(45) NULL,
  `device_id` VARCHAR(45) NULL,
  PRIMARY KEY (`matrl_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=145';

CREATE TABLE `modern_pos`.`t_material_detail` (
  `matr_detail_id` BIGINT NOT NULL AUTO_INCREMENT,
  `matr_id` BIGINT NULL,
  `material_id` BIGINT NULL,
  `row1` INT NULL,
  `price` DECIMAL(17,4) NULL,
  `qty` DECIMAL(17,4) NULL,
  `weight` DECIMAL(17,4) NULL,
  `remark` VARCHAR(45) NULL,
  `active` VARCHAR(45) NULL,
  `sort1` VARCHAR(45) NULL,
  `date_create` VARCHAR(45) NULL,
  `date_modi` VARCHAR(45) NULL,
  `date_cancel` VARCHAR(45) NULL,
  `user_create` VARCHAR(45) NULL,
  `user_modi` VARCHAR(45) NULL,
  `user_cancel` VARCHAR(45) NULL,
  PRIMARY KEY (`matr_detail_id`))
ENGINE = MyISAM
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin
COMMENT = 'id=146';



ALTER TABLE `modern_pos`.`t_material` 
ADD COLUMN `year_id` VARCHAR(45) NULL AFTER `device_id`;

ALTER TABLE `modern_pos`.`t_order_material` 
ADD COLUMN `year_id` VARCHAR(45) NULL AFTER `qty`,
ADD COLUMN `month_id` VARCHAR(45) NULL AFTER `year_id`,
ADD COLUMN `day_id` VARCHAR(45) NULL AFTER `month_id`,
ADD COLUMN `hour_id` VARCHAR(45) NULL AFTER `day_id`;

ALTER TABLE `modern_pos`.`t_order` 
ADD COLUMN `year_id` VARCHAR(45) NULL AFTER `cnt_cust`,
ADD COLUMN `month_id` VARCHAR(45) NULL AFTER `year_id`,
ADD COLUMN `day_id` VARCHAR(45) NULL AFTER `month_id`,
ADD COLUMN `hour_id` VARCHAR(45) NULL AFTER `day_id`;


