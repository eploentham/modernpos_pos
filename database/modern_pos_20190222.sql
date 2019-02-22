-- MySQL dump 10.13  Distrib 8.0.13, for Win64 (x86_64)
--
-- Host: localhost    Database: modern_pos
-- ------------------------------------------------------
-- Server version	8.0.13

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `b_area`
--

DROP TABLE IF EXISTS `b_area`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_area` (
  `area_id` int(11) NOT NULL AUTO_INCREMENT,
  `area_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `area_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `host_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`area_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_area`
--

LOCK TABLES `b_area` WRITE;
/*!40000 ALTER TABLE `b_area` DISABLE KEYS */;
/*!40000 ALTER TABLE `b_area` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_company`
--

DROP TABLE IF EXISTS `b_company`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_company` (
  `comp_id` int(11) NOT NULL AUTO_INCREMENT,
  `comp_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `comp_name_t` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `comp_name_e` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `comp_address_e` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `comp_address_t` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `addr1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `addr2` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `amphur_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `district_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `province_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `zipcode` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `tele` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `fax` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `email` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `website` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `logo` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `tax_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `vat` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `spec1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `qu_line1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `qu_line2` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `qu_line3` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `qu_line4` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `qu_line5` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `qu_line6` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `inv_line1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `inv_line2` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `inv_line3` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `inv_line4` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `inv_line5` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `inv_line6` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `po_line1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `po_due_period` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `taddr1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `taddr2` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `taddr3` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `taddr4` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `eaddr1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `eaddr2` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `eaddr3` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `eaddr4` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `cash_draw_doc` int(11) DEFAULT NULL COMMENT 'running ใบเบิกเงิน',
  `year_curr` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `amount_reserve` decimal(17,2) DEFAULT NULL COMMENT 'ยอดเงิน เบิกสำรองจ่าย คงเหลือ',
  `billing_doc` int(11) DEFAULT NULL COMMENT 'running invoice ใบแจ้งหนี้',
  `tax1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT 'อัตราภาษี หัก ณ ที่จ่าย',
  `tax3` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT 'อัตราภาษี หัก ณ ที่จ่าย',
  `tax53` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT 'อัตราภาษี หัก ณ ที่จ่าย',
  `receipt_doc` int(11) DEFAULT NULL COMMENT 'running ใบเสร็จรับเงิน',
  `vat_doc` int(11) DEFAULT NULL COMMENT 'running ใบกำกับภาษี',
  `billing_cover_doc` int(11) DEFAULT NULL COMMENT 'running ใบวางบิล ใบปะหน้า',
  `req_doc` int(11) DEFAULT NULL COMMENT 'running ใบภาษีหัก ณ ที่จ่าย',
  `month_curr` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `prefix_billing_doc` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `prefix_receipt_doc` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `prefix_billing_cover_doc` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `prefix_req_doc` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `opu_doc` int(11) DEFAULT NULL COMMENT 'expense clear cash \\nเลขที่ ของ หน้าจอ ป้อน clear เงินสด ที่เบิกไป\\nใช้เป็น table header ของ table t_expense_clear_cash',
  `prefix_opu_doc` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `hn_doc` int(11) DEFAULT NULL COMMENT 'หน้าจอ การเงิน เคลีย์เงินสด',
  `prefix_hn_doc` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `vn_doc` int(11) DEFAULT NULL,
  `prefix_vn_doc` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `queue_doc` int(11) DEFAULT NULL,
  `current_date1` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `form_a_doc` int(11) DEFAULT NULL,
  `prefix_form_a` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `fet_doc` int(11) DEFAULT NULL,
  `prefix_fet_doc` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`comp_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1020000003 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=102';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_company`
--

LOCK TABLES `b_company` WRITE;
/*!40000 ALTER TABLE `b_company` DISABLE KEYS */;
/*!40000 ALTER TABLE `b_company` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_department`
--

DROP TABLE IF EXISTS `b_department`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_department` (
  `dept_id` int(11) NOT NULL AUTO_INCREMENT,
  `dept_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `dept_name_t` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `comp_id` int(11) DEFAULT NULL,
  `dept_parent_id` int(11) DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`dept_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1090000006 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=109';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_department`
--

LOCK TABLES `b_department` WRITE;
/*!40000 ALTER TABLE `b_department` DISABLE KEYS */;
/*!40000 ALTER TABLE `b_department` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_foods`
--

DROP TABLE IF EXISTS `b_foods`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_foods` (
  `foods_id` int(11) NOT NULL AUTO_INCREMENT,
  `foods_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `foods_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `foods_price` decimal(17,2) DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `foods_type_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `res_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `res_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_foods` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '0=default,1=foods,2=drink',
  `printer_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `host_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`foods_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_foods`
--

LOCK TABLES `b_foods` WRITE;
/*!40000 ALTER TABLE `b_foods` DISABLE KEYS */;
/*!40000 ALTER TABLE `b_foods` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_foods_type`
--

DROP TABLE IF EXISTS `b_foods_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_foods_type` (
  `foods_type_id` int(11) NOT NULL AUTO_INCREMENT,
  `foods_type_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `foods_type_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `host_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`foods_type_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_foods_type`
--

LOCK TABLES `b_foods_type` WRITE;
/*!40000 ALTER TABLE `b_foods_type` DISABLE KEYS */;
/*!40000 ALTER TABLE `b_foods_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_position`
--

DROP TABLE IF EXISTS `b_position`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_position` (
  `posi_id` int(11) NOT NULL AUTO_INCREMENT,
  `posi_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `posi_name_t` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `posi_name_e` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `dept_id` int(11) DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_doctor` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_embryologist` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`posi_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1400000004 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=140';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_position`
--

LOCK TABLES `b_position` WRITE;
/*!40000 ALTER TABLE `b_position` DISABLE KEYS */;
/*!40000 ALTER TABLE `b_position` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_prefix`
--

DROP TABLE IF EXISTS `b_prefix`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_prefix` (
  `prefix_id` int(11) NOT NULL AUTO_INCREMENT,
  `prefix_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `prefix_name_t` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `prefix_name_e` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_doctor` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`prefix_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1200000003 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=120';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_prefix`
--

LOCK TABLES `b_prefix` WRITE;
/*!40000 ALTER TABLE `b_prefix` DISABLE KEYS */;
/*!40000 ALTER TABLE `b_prefix` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_printername`
--

DROP TABLE IF EXISTS `b_printername`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_printername` (
  `printer_id` int(11) NOT NULL AUTO_INCREMENT,
  `printer_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `printer_ip` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `host_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`printer_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_printername`
--

LOCK TABLES `b_printername` WRITE;
/*!40000 ALTER TABLE `b_printername` DISABLE KEYS */;
/*!40000 ALTER TABLE `b_printername` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_restaurant`
--

DROP TABLE IF EXISTS `b_restaurant`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_restaurant` (
  `res_id` int(11) NOT NULL AUTO_INCREMENT,
  `res_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `res_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `default_res` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `receipt_footer1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `receipt_header1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `receipt_footer2` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `receipt_header2` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `bill_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `bill_month` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `tax_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `printer_foods1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `printer_foods2` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `printer_foods3` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `printer_waterbar1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `printer_waterbar2` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `printer_waterbar3` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `host_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`res_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='ชื่อร้านอาหาร';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_restaurant`
--

LOCK TABLES `b_restaurant` WRITE;
/*!40000 ALTER TABLE `b_restaurant` DISABLE KEYS */;
/*!40000 ALTER TABLE `b_restaurant` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_staff`
--

DROP TABLE IF EXISTS `b_staff`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_staff` (
  `staff_id` int(11) NOT NULL AUTO_INCREMENT,
  `staff_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `username` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `password1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `prefix_id` int(11) DEFAULT NULL,
  `staff_fname_t` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `staff_fname_e` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `staff_lname_t` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `staff_lname_e` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `priority` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `tele` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `mobile` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `fax` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `email` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `posi_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `posi_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `dept_id` int(11) DEFAULT NULL,
  `dept_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `pid` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `logo` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_admin` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '0=default; 1=user;2=admin',
  `status_module_reception` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '0=default;1=import job;',
  `status_module_nurse` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_module_doctor` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_expense_draw` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT 'หน้าจอเบิกเงิน',
  `status_expense_appv` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT 'หน้าจอ อนุมัติ เบิกเงิน',
  `status_expense_pay` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT 'หน้าจอ จ่ายเงิน',
  `password_confirm` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_module_pharmacy` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_module_lab` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`staff_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1220000039 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=122';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_staff`
--

LOCK TABLES `b_staff` WRITE;
/*!40000 ALTER TABLE `b_staff` DISABLE KEYS */;
/*!40000 ALTER TABLE `b_staff` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_table`
--

DROP TABLE IF EXISTS `b_table`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_table` (
  `table_id` int(11) NOT NULL AUTO_INCREMENT,
  `area_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `table_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `table_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_use` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '0=default;1=use;',
  `status_togo` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '0=default;1=togo;2=inres',
  `date_use` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `host_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`table_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_table`
--

LOCK TABLES `b_table` WRITE;
/*!40000 ALTER TABLE `b_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `b_table` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_user`
--

DROP TABLE IF EXISTS `b_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_user` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_login` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `password1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `privilege` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '1=all privilege,2=order,3=order bill,4=order bill closeday',
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `host_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `permission_void_bill` varchar(155) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `permission_void_closeday` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `ttttt` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_user`
--

LOCK TABLES `b_user` WRITE;
/*!40000 ALTER TABLE `b_user` DISABLE KEYS */;
/*!40000 ALTER TABLE `b_user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `f_doc_type`
--

DROP TABLE IF EXISTS `f_doc_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `f_doc_type` (
  `doc_type_id` int(11) NOT NULL AUTO_INCREMENT,
  `doc_type_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `doc_type_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_combo` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`doc_type_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1430000050 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=143';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `f_doc_type`
--

LOCK TABLES `f_doc_type` WRITE;
/*!40000 ALTER TABLE `f_doc_type` DISABLE KEYS */;
/*!40000 ALTER TABLE `f_doc_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `f_sex`
--

DROP TABLE IF EXISTS `f_sex`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `f_sex` (
  `f_sex_id` int(11) NOT NULL AUTO_INCREMENT,
  `sex_description` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`f_sex_id`)
) ENGINE=MyISAM AUTO_INCREMENT=2100000003 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=210';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `f_sex`
--

LOCK TABLES `f_sex` WRITE;
/*!40000 ALTER TABLE `f_sex` DISABLE KEYS */;
/*!40000 ALTER TABLE `f_sex` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_bill`
--

DROP TABLE IF EXISTS `t_bill`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `t_bill` (
  `bill_id` int(11) NOT NULL AUTO_INCREMENT,
  `bill_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `bill_date` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `lot_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(25) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_void` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `void_date` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `void_user` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `table_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `res_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `area_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `amount` decimal(17,2) DEFAULT NULL,
  `discount` decimal(17,2) DEFAULT NULL,
  `service_charge` decimal(17,2) DEFAULT NULL,
  `vat` decimal(17,2) DEFAULT NULL,
  `total` decimal(17,2) DEFAULT NULL,
  `nettotal` decimal(17,2) DEFAULT NULL,
  `cash_receive` decimal(17,2) DEFAULT NULL,
  `cash_ton` decimal(17,2) DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `bill_user` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_closeday` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `closeday_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `host_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`bill_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_bill`
--

LOCK TABLES `t_bill` WRITE;
/*!40000 ALTER TABLE `t_bill` DISABLE KEYS */;
/*!40000 ALTER TABLE `t_bill` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_bill_detail`
--

DROP TABLE IF EXISTS `t_bill_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `t_bill_detail` (
  `bill_detail_id` int(11) NOT NULL AUTO_INCREMENT,
  `bill_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `order_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `lot_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_void` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `row1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `foods_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `foods_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `price` decimal(17,2) DEFAULT NULL,
  `qty` decimal(17,2) DEFAULT NULL,
  `amount` decimal(17,2) DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `host_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`bill_detail_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_bill_detail`
--

LOCK TABLES `t_bill_detail` WRITE;
/*!40000 ALTER TABLE `t_bill_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `t_bill_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_closeday`
--

DROP TABLE IF EXISTS `t_closeday`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `t_closeday` (
  `closeday_id` int(11) NOT NULL AUTO_INCREMENT,
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
  `date_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `weather` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '0=default;1=sun;2=',
  PRIMARY KEY (`closeday_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_closeday`
--

LOCK TABLES `t_closeday` WRITE;
/*!40000 ALTER TABLE `t_closeday` DISABLE KEYS */;
/*!40000 ALTER TABLE `t_closeday` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_order`
--

DROP TABLE IF EXISTS `t_order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `t_order` (
  `order_id` int(11) NOT NULL AUTO_INCREMENT,
  `lot_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `row1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `foods_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `foods_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `foods_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `order_date` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `price` decimal(10,0) DEFAULT NULL,
  `qty` decimal(10,0) DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `table_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `res_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `area_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_foods_1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_foods_2` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_foods_3` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_bill` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '0=default,1=bill check ,2=check complete',
  `bill_check_date` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_cook` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '0=default,1=cook receive,2=cook finish',
  `cook_receive_date` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `cook_finish_date` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `void_date` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_void` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `printer_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_to_go` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '0=default,1=in restaurant,2=to go',
  `bill_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `order_user` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_closeday` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `closeday_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `host_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `cnt_cust` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`order_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_order`
--

LOCK TABLES `t_order` WRITE;
/*!40000 ALTER TABLE `t_order` DISABLE KEYS */;
/*!40000 ALTER TABLE `t_order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vne_close_day`
--

DROP TABLE IF EXISTS `vne_close_day`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `vne_close_day` (
  `close_day_id` int(11) NOT NULL AUTO_INCREMENT,
  `close_day_date` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `req_status` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date1` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_start` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `total_in` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `total_out` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `total_payments` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `total_operator_in` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `total_operaor_out` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `total_content` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`close_day_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vne_close_day`
--

LOCK TABLES `vne_close_day` WRITE;
/*!40000 ALTER TABLE `vne_close_day` DISABLE KEYS */;
/*!40000 ALTER TABLE `vne_close_day` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vne_request_payment`
--

DROP TABLE IF EXISTS `vne_request_payment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `vne_request_payment` (
  `request_payment_id` int(11) NOT NULL AUTO_INCREMENT,
  `tipo` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `importo` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `opname` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `operatore` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`request_payment_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vne_request_payment`
--

LOCK TABLES `vne_request_payment` WRITE;
/*!40000 ALTER TABLE `vne_request_payment` DISABLE KEYS */;
/*!40000 ALTER TABLE `vne_request_payment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vne_response_payemnt`
--

DROP TABLE IF EXISTS `vne_response_payemnt`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `vne_response_payemnt` (
  `response_payemnt_id` int(11) NOT NULL AUTO_INCREMENT,
  `id` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `importo` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `tipo` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `req_status` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`response_payemnt_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vne_response_payemnt`
--

LOCK TABLES `vne_response_payemnt` WRITE;
/*!40000 ALTER TABLE `vne_response_payemnt` DISABLE KEYS */;
/*!40000 ALTER TABLE `vne_response_payemnt` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-02-22  7:15:19
