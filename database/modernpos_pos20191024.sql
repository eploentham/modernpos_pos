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
use modern_pos;

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
  `date_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_aircondition` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT 'ห้องแอร์',
  PRIMARY KEY (`area_id`)
) ENGINE=MyISAM AUTO_INCREMENT=100000001 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=100';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_area`
--

LOCK TABLES `b_area` WRITE;
/*!40000 ALTER TABLE `b_area` DISABLE KEYS */;
INSERT INTO `b_area` VALUES (1,'100','ในร้าน','1','',NULL,'2019-02-25 09:47:13',NULL,'0','0','0',NULL,'',NULL,NULL,'0'),(100000000,'101','นอกร้าน','1','',NULL,'2019-02-25 09:50:23',NULL,'0','0','0',NULL,'',NULL,NULL,'0');
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
  `queue_1_doc` int(11) DEFAULT NULL,
  `prefix_queue_1_doc` varchar(55) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
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
  `day_curr` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`comp_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1020000004 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=102';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_company`
--

LOCK TABLES `b_company` WRITE;
/*!40000 ALTER TABLE `b_company` DISABLE KEYS */;
INSERT INTO `b_company` VALUES (1020000003,'001',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'1',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2019',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'03',NULL,NULL,NULL,NULL,3,'A',NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL,'17');
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
) ENGINE=MyISAM AUTO_INCREMENT=1090000007 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=109';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_department`
--

LOCK TABLES `b_department` WRITE;
/*!40000 ALTER TABLE `b_department` DISABLE KEYS */;
INSERT INTO `b_department` VALUES (1090000006,'100','admin',0,0,'','2019-02-25 07:19:37','','','','','','1',NULL);
/*!40000 ALTER TABLE `b_department` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_foods`
--

DROP TABLE IF EXISTS `b_foods`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_foods` (
  `foods_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `foods_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `foods_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `foods_price` decimal(17,2) DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `foods_type_id` bigint(20) DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `res_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `res_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_foods` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '0=default,1=Foods,2=Beverages',
  `printer_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `host_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `foods_cat_id` bigint(20) DEFAULT NULL,
  `status_to_go` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '0=default;1=to go',
  `status_dine_in` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '0=default; 1= dine in',
  `filename` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_recommend` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `status_create` varchar(45) COLLATE utf8_bin DEFAULT '0' COMMENT '0=default;1=สร้างรายการเอง เป็นก๋วยเตี่ยว',
  PRIMARY KEY (`foods_id`)
) ENGINE=MyISAM AUTO_INCREMENT=104000151 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=104';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_foods`
--

LOCK TABLES `b_foods` WRITE;
/*!40000 ALTER TABLE `b_foods` DISABLE KEYS */;
INSERT INTO `b_foods` VALUES (104000000,'10100','เส้นเล็กพริกสด',55.00,'1',102000002,'aaa','1','','1','POS80 PRO','2019-02-25 22:05:12','2019-09-26 16:05:45','0','0','0',NULL,'','',NULL,NULL,103000001,'0','0','104000000.jpg','0','0'),(104000001,'10101','เส้นเล็กต้มยำ',60.00,'1',102000002,'bbb','1','','1','BIXOLON SRP-330II','2019-02-26 09:23:09','2019-04-29 16:40:55','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000001.jpg','1','0'),(104000002,'10001','ข้าวหน้าเป็ดย่าง',50.00,'1',102000007,'','0','','1','POS80 PRO','2019-03-11 16:31:04','2019-09-26 16:06:08','0','0','0',NULL,'','',NULL,NULL,103000000,'1','1','104000002.jpg','0','0'),(104000003,'10002','ข้าวหมูแดง',50.00,'1',0,'','0','','1','POS80 PRO','2019-03-11 16:32:40','2019-09-26 16:06:14','0','0','0',NULL,'','',NULL,NULL,103000000,'1','1','104000003.jpg','0','0'),(104000004,'10003','ข้าวหน้าเป็ดย่างปนหมูกรอบ',65.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-11 16:33:39','2019-03-12 14:32:09','0','0','0',NULL,'','',NULL,NULL,103000000,'1','1','104000004.jpg',NULL,'0'),(104000005,'10004','ข้าวหน้าไก่เห็ดหอม',50.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-11 16:34:13','2019-03-12 14:32:46','0','0','0',NULL,'','',NULL,NULL,103000000,'1','1','104000005.jpg',NULL,'0'),(104000006,'10005','ข้าวหน้าไก่+หมูกรอบ',65.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-11 16:34:50','2019-04-04 11:28:42','0','0','0',NULL,'','',NULL,NULL,103000000,'1','1','104000006.jpg','0','0'),(104000007,'10006','ข้าวหน้าเป็ด+หมูแดง+หมูกรอบ',80.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-11 16:35:40','2019-03-12 14:33:15','0','0','0',NULL,'','',NULL,NULL,103000000,'1','1','104000007.jpg',NULL,'0'),(104000008,'10007','ข้าวหน้าเป็ด+หน้าไก่',75.00,'1',NULL,'',NULL,'','1','BIXOLON SRP-330II','2019-03-11 16:36:23',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000000,'1','1','104000008.jpg',NULL,'0'),(104000009,'20001','หน้าไก่',70.00,'1',102000000,'','1','','1','BIXOLON SRP-330II','2019-03-11 16:37:15','2019-03-11 16:38:37','0','0','0',NULL,'','',NULL,NULL,103000002,'1','1','104000009.jpg',NULL,'0'),(104000010,'20002','เป็ดย่าง',480.00,'1',102000000,'','1','','1','BIXOLON SRP-330II','2019-03-11 16:38:12','2019-03-12 14:37:08','0','0','0',NULL,'','',NULL,NULL,103000002,'1','1','104000010.jpg',NULL,'0'),(104000011,'20003','เป็ดย่างไหว้เจ้า+เครื่องใน',500.00,'1',NULL,'',NULL,'','1','BIXOLON SRP-330II','2019-03-11 16:39:49',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000002,'1','1','104000011.jpg',NULL,'0'),(104000012,'20004','หมูแดง(ขีดละ)',50.00,'1',102000000,'','1','','1','BIXOLON SRP-330II','2019-03-11 16:40:32','2019-03-12 14:37:23','0','0','0',NULL,'','',NULL,NULL,103000002,'1','1','104000012.jpg',NULL,'0'),(104000013,'20005','กุนเชียง(ขีดละ)',50.00,'1',0,'','0','','1','BIXOLON SRP-330II','2019-03-11 16:41:01','2019-03-11 16:54:57','0','0','0',NULL,'','',NULL,NULL,103000002,'1','1','104000013.jpg',NULL,'0'),(104000014,'20006','หมูกรอบ(ขีดละ)',60.00,'1',102000000,'','1','','1','BIXOLON SRP-330II','2019-03-11 16:41:29','2019-03-12 14:37:56','0','0','0',NULL,'','',NULL,NULL,103000002,'1','1','104000014.jpg',NULL,'0'),(104000015,'20007','เป็ดย่างจานเดียว',120.00,'1',102000000,'','0','','1','BIXOLON SRP-330II','2019-03-11 16:42:06','2019-03-12 14:38:17','0','0','0',NULL,'','',NULL,NULL,103000002,'1','1','104000015.jpg',NULL,'0'),(104000016,'20008','เป็ดย่างจานเดียว(พิเศษ)',240.00,'1',102000000,'','1','','1','BIXOLON SRP-330II','2019-03-11 16:42:37','2019-03-12 14:38:32','0','0','0',NULL,'','',NULL,NULL,103000002,'1','1','104000016.jpg',NULL,'0'),(104000017,'20009','หมูแดง+หมูกรอบ',100.00,'1',102000000,'','1','','1','BIXOLON SRP-330II','2019-03-11 16:43:06','2019-03-12 14:38:47','0','0','0',NULL,'','',NULL,NULL,103000002,'1','1','104000017.jpg',NULL,'0'),(104000018,'20010','เป็ดย่าง+หมูแดง',160.00,'1',NULL,'',NULL,'','1','BIXOLON SRP-330II','2019-03-11 16:43:42',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000002,'1','1','104000018.jpg',NULL,'0'),(104000019,'20011','เป็ดย่าง+หมูกรอบ',160.00,'1',NULL,'',NULL,'','1','BIXOLON SRP-330II','2019-03-11 16:44:22',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000002,'1','1','104000019.jpg',NULL,'0'),(104000020,'20012','เป็ดย่าง+หมูแดง+หมูกรอบ',240.00,'1',NULL,'',NULL,'','1','BIXOLON SRP-330II','2019-03-11 16:45:03',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000002,'1','1','104000020.jpg',NULL,'0'),(104000021,'20013','น้ำราดหมูแดง(ขีดละ)',10.00,'1',NULL,'',NULL,'','1','BIXOLON SRP-330II','2019-03-11 16:52:09',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000002,'1','1','104000021.jpg',NULL,'0'),(104000022,'20014','น้ำราดเป็ด(ขีดละ)',10.00,'1',NULL,'',NULL,'','1','BIXOLON SRP-330II','2019-03-11 16:52:53',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000002,'1','1','104000022.jpg',NULL,'0'),(104000023,'20015','ไข่ต้ม(ฟองละ)',10.00,'1',0,'','1','','1','BIXOLON SRP-330II','2019-03-11 16:53:21','2019-05-15 13:03:48','0','0','0',NULL,'','',NULL,NULL,103000002,'1','1','104000023.jpg','0','0'),(104000024,'20016','ข้าวเปล่า(จานละ)',10.00,'1',102000002,'','0','','1','BIXOLON SRP-330II','2019-03-11 16:53:48','2019-05-15 13:04:19','0','0','0',NULL,'','',NULL,NULL,103000002,'1','1','104000024.jpg','0','0'),(104000025,'20017','ขิงดอง(ขีดละ)',10.00,'1',NULL,'',NULL,'','1','BIXOLON SRP-330II','2019-03-11 16:54:18',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000002,'1','1','104000025.jpg',NULL,'0'),(104000026,'10008','ข้าวหน้าไก่เห็ดหอม(พิเศษ)',65.00,'1',NULL,'',NULL,'','1','BIXOLON SRP-330II','2019-03-11 16:56:36',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000000,'1','1','104000026.jpg',NULL,'0'),(104000027,'10009','ข้าวหน้าเป็ดย่าง(พิเศษ)',75.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-11 16:57:32','2019-03-12 14:41:09','0','0','0',NULL,'','',NULL,NULL,103000000,'1','1','104000027.jpg',NULL,'0'),(104000028,'10010','ข้าวหน้าหมูแดง(พิเศษ)',65.00,'1',NULL,'',NULL,'','1','BIXOLON SRP-330II','2019-03-11 16:58:30',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000000,'1','1','104000028.jpg',NULL,'0'),(104000029,'10011','ข้าวหน้าหมูกรอบ',50.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-11 16:59:06','2019-03-12 14:39:43','0','0','0',NULL,'','',NULL,NULL,103000000,'1','1','104000029.jpg',NULL,'0'),(104000030,'10012','ข้าวหน้าหมูกรอบ(พิเศษ)',65.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-11 16:59:32','2019-03-12 14:40:05','0','0','0',NULL,'','',NULL,NULL,103000000,'1','1','104000030.jpg',NULL,'0'),(104000031,'30001','บะหมี่เกี๊ยวปูพริกไทยดำ',65.00,'1',NULL,'',NULL,'','1','BIXOLON SRP-330II','2019-03-11 17:03:47',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000031.jpg',NULL,'0'),(104000032,'30002','บะหมี่หมูแดง',55.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-11 17:04:16','2019-05-15 11:19:10','0','0','0',NULL,'','',NULL,NULL,103000003,'1','1','104000032.jpg','0','0'),(104000033,'30003','บะหมี่หมูกรอบ',55.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-11 17:04:37','2019-05-15 11:19:24','0','0','0',NULL,'','',NULL,NULL,103000003,'1','1','104000033.jpg','0','0'),(104000034,'30004','บะหมี่เป็ดย่าง',60.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-11 17:05:18','2019-05-15 11:18:47','0','0','0',NULL,'','',NULL,NULL,103000003,'1','1','104000034.jpg','0','0'),(104000035,'30005','บะหมี่หน้าไก่เห็ดหอม',60.00,'1',102000007,'','0','','1','BIXOLON SRP-330II','2019-03-11 17:05:54','2019-05-15 11:44:19','0','0','0',NULL,'','',NULL,NULL,103000003,'1','1','104000035.jpg','0','0'),(104000036,'30006','บะหมี่เป็ดย่าง+หมูกรอบ',75.00,'1',NULL,'',NULL,'','1','BIXOLON SRP-330II','2019-03-11 17:07:47',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000036.jpg',NULL,'0'),(104000037,'30007','บะหมี่งาดำเต้าหุ้แคะทอด',65.00,'1',NULL,'',NULL,'','1','BIXOLON SRP-330II','2019-03-11 17:08:41',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000037.jpg',NULL,'0'),(104000038,'30008','บะหมี่เกี๊ยวกุ้งล้วน',65.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-11 17:09:08','2019-05-15 11:17:10','0','0','0',NULL,'','',NULL,NULL,103000003,'1','1','104000038.jpg','0','0'),(104000039,'30009','บะหมี่เกี๊ยวกุ้งหมูแดง',70.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-11 17:09:58','2019-05-15 11:17:34','0','0','0',NULL,'','',NULL,NULL,103000003,'1','1','104000039.jpg','0','0'),(104000040,'30010','บะหมี่เกี๊ยวกุ้งหมูกรอบ',70.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-11 17:10:47','2019-05-15 11:18:11','0','0','0',NULL,'','',NULL,NULL,103000003,'1','1','104000040.jpg','0','0'),(104000041,'30011','บะหมี่เกี๊ยวเป็ดย่าง',75.00,'1',NULL,'',NULL,'','1','BIXOLON SRP-330II','2019-03-11 17:11:18',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000041.jpg',NULL,'0'),(104000042,'30012','บะหมี่เกี๊ยวหน้าไก่เห็ดหอม',75.00,'1',NULL,'',NULL,'','1','BIXOLON SRP-330II','2019-03-11 17:12:03',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000042.jpg',NULL,'0'),(104000043,'30013','บะหมี่เกี๊ยวกุ้งลูกชิ้นปลา',70.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-11 17:12:52','2019-05-15 11:15:53','0','0','0',NULL,'','',NULL,NULL,103000003,'1','1','104000043.jpg','0','0'),(104000044,'30014','บะหมี่เกี๊ยวลูกชิ้นปลาต้มยำมะนาว',80.00,'1',NULL,'',NULL,'','1','BIXOLON SRP-330II','2019-03-11 17:13:27',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000044.jpg',NULL,'0'),(104000045,'30015','บะหมี่เกี๊ยวเย็นตาโฟ',80.00,'1',NULL,'',NULL,'','1','BIXOLON SRP-330II','2019-03-11 17:13:54',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000045.jpg',NULL,'0'),(104000046,'30016','บะหมี่เกี๊ยวเป็ดย่าง+หมูกรอบ',90.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-11 17:15:03','2019-05-15 11:16:31','0','0','0',NULL,'','',NULL,NULL,103000003,'1','1','104000046.jpg','0','0'),(104000047,'30017','บะหมี่เกี๊ยวต้มยำน้ำข้นปลา',80.00,'1',NULL,'',NULL,'','1','BIXOLON SRP-330II','2019-03-11 17:15:47',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000047.jpg',NULL,'0'),(104000048,'30018','บะหมี่เกี๊ยวต้มยำน้ำข้นทะเล',95.00,'1',NULL,'',NULL,'','1','BIXOLON SRP-330II','2019-03-11 17:16:29',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000048.jpg',NULL,'0'),(104000049,'30019','บะหมี่เกี๊ยวต้มยำน้ำข้นกุ้ง',105.00,'1',NULL,'',NULL,'','1','BIXOLON SRP-330II','2019-03-11 17:17:02',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000049.jpg',NULL,'0'),(104000050,'30020','บะหมี่เกี๊ยวต้มยำน้ำข้นเกี๊ยวปลา',90.00,'1',NULL,'',NULL,'','1','BIXOLON SRP-330II','2019-03-11 17:17:37',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000050.jpg',NULL,'0'),(104000051,'40001','ก๋วยเตี๋ยวพริกสดลูกชิ้นปลา+เนื้อปลา',65.00,'1',102000011,'','1','','1','BIXOLON SRP-330II','2019-03-12 08:46:45','2019-03-12 14:43:37','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000051.jpg',NULL,'0'),(104000052,'40002','ก๋วยเตี๋ยวพริกสดหมูกรอบ',65.00,'1',102000011,'','1','','1','BIXOLON SRP-330II','2019-03-12 08:48:17','2019-03-12 14:43:31','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000052.jpg',NULL,'0'),(104000053,'40003','ก๋วยเตี๋ยวพริกสดหมูก้อน',75.00,'1',102000011,'','1','','1','BIXOLON SRP-330II','2019-03-12 08:48:54','2019-03-12 14:43:23','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000053.jpg',NULL,'0'),(104000054,'40004','ก๋วยเตี๋ยวทะเลพริกสด',80.00,'1',102000011,'','1','','1','BIXOLON SRP-330II','2019-03-12 08:51:46','2019-03-12 14:43:14','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000054.jpg',NULL,'0'),(104000055,'40005','ก๋วยเตี๋ยวเนื้อปลาน้ำใส',65.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 08:55:14','2019-03-12 14:43:50','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000055.jpg',NULL,'0'),(104000056,'40006','ก๋วยเตี๋ยวต้มยำน้ำข้นปลา',65.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 08:57:16','2019-03-12 08:57:59','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000056.jpg',NULL,'0'),(104000057,'40007','ก๋วยเตี๋ยวต้มยำน้ำข้นหมูก้อน',75.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 08:58:51','2019-03-12 08:59:08','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000057.jpg',NULL,'0'),(104000058,'40008','ก๋วยเตี๋ยวต้มยำน้ำข้นเกี๊ยวปลา',75.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:00:26','2019-03-12 09:00:39','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000058.jpg',NULL,'0'),(104000059,'40009','ก๋วยเตี๋ยวต้มยำน้ำข้นชิ้นกุ้ง',75.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:01:17','2019-03-12 09:01:28','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000059.jpg',NULL,'0'),(104000060,'40010','ก๋วยเตี๋ยวต้มยำน้ำข้นทะเล',80.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:06:41','2019-03-12 09:06:55','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000060.jpg',NULL,'0'),(104000061,'40011','ก๋วยเตี๋ยวต้มยำน้ำข้นกุ้ง',90.00,'1',NULL,'',NULL,'','1','BIXOLON SRP-330II','2019-03-12 09:07:24',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000001,'1','1','104000061.jpg',NULL,'0'),(104000062,'40012','ก๋วยเตี๋ยวต้มยำน้ำข้นหมูกรอบ',65.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:08:34','2019-03-12 09:08:44','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000062.jpg',NULL,'0'),(104000063,'40013','ก๋วยเตี๋ยวลูกชิ้นปลา',55.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:09:13','2019-03-12 09:09:31','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000063.jpg',NULL,'0'),(104000064,'40014','ก๋วยเตี๋ยวหมูสับ',55.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:10:23','2019-03-12 09:10:49','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000064.jpg',NULL,'0'),(104000065,'40015','ก๋วยเตี๋ยวลูกชิ้นกุ้งทอด',65.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:11:32','2019-04-29 15:56:15','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000065.jpg','0','0'),(104000066,'40016','ก๋วยเตี๋ยวเกี๊ยวปลา',65.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:12:30','2019-03-12 09:12:49','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000066.jpg',NULL,'0'),(104000067,'40017','ก๋วยเตี๋ยวต้มยำสูตรมะนาว',65.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:13:25','2019-03-12 09:13:36','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000067.jpg',NULL,'0'),(104000068,'40018','ก๋วยเตี๋ยวเย็นตาโฟ',65.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:14:04','2019-03-12 09:14:18','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000068.jpg',NULL,'0'),(104000069,'50001','ข้าวต้มปลา',65.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:15:05','2019-05-09 11:45:54','0','0','0',NULL,'','',NULL,NULL,103000004,'1','1','104000069.jpg','0','0'),(104000070,'50002','ข้าวต้มปลาหมึก',65.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:15:40','2019-05-09 11:45:48','0','0','0',NULL,'','',NULL,NULL,103000004,'1','1','104000070.jpg','0','0'),(104000071,'50003','ข้าวต้มหมูสับ',65.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:16:11','2019-05-09 11:45:40','0','0','0',NULL,'','',NULL,NULL,103000004,'1','1','104000071.jpg','0','0'),(104000072,'50004','ข้าวต้มหมูก้อน',75.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:17:05','2019-05-09 11:45:31','0','0','0',NULL,'','',NULL,NULL,103000004,'1','1','104000072.jpg','0','0'),(104000073,'50005','ข้าวต้มกุ้ง',90.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:17:37','2019-03-12 14:48:13','0','0','0',NULL,'','',NULL,NULL,103000004,'1','1','104000073.jpg',NULL,'0'),(104000074,'50006','ข้าวต้มทะเล',80.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:18:02','2019-05-09 11:45:20','0','0','0',NULL,'','',NULL,NULL,103000004,'1','1','104000074.jpg','0','0'),(104000075,'60001','ต้มยำน้ำข้น',15.00,'1',102000000,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:20:10','2019-03-12 09:21:11','0','0','0',NULL,'','',NULL,NULL,103000010,'1','1','104000075.jpg',NULL,'0'),(104000076,'60002','เส้นก๋วยเตี๋ยว',15.00,'1',102000000,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:22:40','2019-03-12 09:22:51','0','0','0',NULL,'','',NULL,NULL,103000011,'1','1','104000076.jpg',NULL,'0'),(104000077,'60003','บะหมี่ลวก',15.00,'1',102000000,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:24:00','2019-03-12 09:24:42','0','0','0',NULL,'','',NULL,NULL,103000011,'1','1','104000077.jpg',NULL,'0'),(104000078,'60004','เกี๊ยวทอดกรอบ',15.00,'1',102000000,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:25:16','2019-03-12 09:25:40','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000078.jpg',NULL,'0'),(104000079,'60005','บะหมี่สาหร่าย',25.00,'1',102000000,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:32:48','2019-04-29 15:55:04','0','0','0',NULL,'','',NULL,NULL,103000011,'1','1','104000079.jpg','0','0'),(104000080,'60006','น้ำจิ้มพริกสด',10.00,'1',102000000,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:34:02','2019-03-12 09:35:29','0','0','0',NULL,'','',NULL,NULL,103000012,'1','1','104000080.jpg',NULL,'0'),(104000081,'70001','รวมมิตรปลาลวก',80.00,'1',102000000,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:52:07','2019-03-12 09:52:23','0','0','0',NULL,'','',NULL,NULL,103000005,'1','1','104000081.jpg',NULL,'0'),(104000082,'70002','เนื้อปลาลวก',80.00,'1',NULL,'',NULL,'','1','BIXOLON SRP-330II','2019-03-12 09:52:47',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000005,'1','1','104000082.jpg',NULL,'0'),(104000083,'70003','รวมมิตรทะเลลวก',80.00,'1',102000000,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:53:44','2019-03-12 09:54:00','0','0','0',NULL,'','',NULL,NULL,103000005,'1','1','104000083.jpg',NULL,'0'),(104000084,'70004','เกี๊ยวปลาลวกจิ้ม',80.00,'1',102000000,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:55:02','2019-03-12 09:55:12','0','0','0',NULL,'','',NULL,NULL,103000005,'1','1','104000084.jpg',NULL,'0'),(104000085,'70005','เกี๊ยวกุ้งลวกจิ้ม',80.00,'1',102000000,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:55:36','2019-03-12 09:55:53','0','0','0',NULL,'','',NULL,NULL,103000005,'1','1','104000085.jpg',NULL,'0'),(104000086,'70006','ลูกชิ้นกุ้งทอด',80.00,'1',102000009,'','1','','1','BIXOLON SRP-330II','2019-03-12 09:56:17','2019-03-12 14:49:35','0','0','0',NULL,'','',NULL,NULL,103000005,'1','1','104000086.jpg',NULL,'0'),(104000087,'80001','เกาเหลาน้ำใสลูกชิ้นปลา',60.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:05:08','2019-03-12 10:05:24','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000087.jpg',NULL,'0'),(104000088,'80002','เกาเหลาเย็นตาโฟลูกชิ้นปลา',70.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:05:51','2019-03-12 10:06:01','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000088.jpg',NULL,'0'),(104000089,'80003','เกาเหลาน้ำใสเนื้อปลา',70.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:07:05','2019-03-12 10:07:18','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000089.jpg',NULL,'0'),(104000090,'80004','เกาเหลาน้ำใสเป็ดย่าง',65.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:08:25','2019-03-12 10:08:39','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000090.jpg',NULL,'0'),(104000091,'80005','เกาเหลาน้ำใสเกี๊ยวปลา',70.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:10:44','2019-03-12 10:10:57','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000091.jpg',NULL,'0'),(104000092,'80006','เกาเหลาน้ำใสลูกชิ้นกุ้งทอด',70.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:16:56','2019-03-12 10:17:07','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000092.jpg',NULL,'0'),(104000093,'80007','เกาเหลาพริกสด(สูตรแห้ง)',70.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:17:39','2019-03-12 10:17:51','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000093.jpg',NULL,'0'),(104000094,'80008','เกาเหลาต้มยำมะนาว',70.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:18:12','2019-06-28 15:41:10','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000094.jpg','0','0'),(104000095,'80009','เกาเหลาต้มยำปลาน้ำข้น',70.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:19:49','2019-03-12 10:21:30','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000095.jpg',NULL,'0'),(104000096,'80010','เกาเหลาต้มยำทะเล',85.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:21:18','2019-03-12 10:21:38','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000096.jpg',NULL,'0'),(104000097,'80011','เกาเหลาต้มยำกุ้งน้ำข้น',95.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:23:30','2019-03-12 10:23:40','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000097.jpg',NULL,'0'),(104000098,'80012','เกาเหลาต้มยำน้ำข้นเกี๊ยวปลา',80.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:24:08','2019-03-12 10:24:21','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000098.jpg',NULL,'0'),(104000099,'80013','เกาเหลาต้มยำน้ำข้นลูกชิ้นกุ้งทอด',80.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:24:46','2019-03-12 10:24:54','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000099.jpg',NULL,'0'),(104000100,'80014','เกาเหลาต้มยำน้ำข้นหมูก้อน',80.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:26:22','2019-03-12 10:26:35','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000100.jpg',NULL,'0'),(104000101,'90001','เกี๊ยวกุ้งน้ำใสเนื้อปลา',75.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:28:02','2019-03-12 10:28:13','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000101.jpg',NULL,'0'),(104000102,'90002','เกี๊ยวกุ้งน้ำใสหมูสับ',65.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:28:59','2019-03-12 10:29:40','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000102.jpg',NULL,'0'),(104000103,'90003','เกี๊ยวกุ้งน้ำใสหมูแดง',65.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:30:04','2019-03-12 10:30:17','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000103.jpg',NULL,'0'),(104000104,'90004','เกี๊ยวกุ้งน้ำใสหมูกรอบ',65.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:48:45','2019-03-12 10:49:04','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000104.jpg',NULL,'0'),(104000105,'90005','เกี๊ยวกุ้งน้ำใสหมูก้อน',75.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:49:26','2019-03-12 10:49:41','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000105.jpg',NULL,'0'),(104000106,'90006','เกี๊ยวกุ้งน้ำใสลูกชิ้นปลา',65.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:50:18','2019-03-12 10:50:30','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000106.jpg',NULL,'0'),(104000107,'90007','เกี๊ยวกุ้งต้มยำมะนาวหมูกรอบ',75.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:50:53','2019-03-12 10:51:03','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000107.jpg',NULL,'0'),(104000108,'90008','เกี๊ยวกุ้งเย็นตาโฟ',75.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:51:21','2019-03-12 10:51:31','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000108.jpg',NULL,'0'),(104000109,'90009','เกี๊ยวกุ้งหน้าไก่เห็ดหอม',70.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:51:52','2019-03-12 10:52:11','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000109.jpg',NULL,'0'),(104000110,'90010','เกี๊ยวกุ้งเป็ดย่าง',70.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:53:53','2019-03-12 10:54:02','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000110.jpg',NULL,'0'),(104000111,'90011','เกี๊ยวกุ้งเป็ดย่างหมูกรอบ',85.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:55:12','2019-03-12 10:55:24','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000111.jpg',NULL,'0'),(104000112,'90012','เกี๊ยวกุ้งเป็ดย่างหมูแดง',85.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:55:42','2019-03-12 10:55:52','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000112.jpg',NULL,'0'),(104000113,'90013','เกี๊ยวกุ้งต้มยำน้ำข้นเนื้อปลา',75.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:56:35','2019-03-12 10:56:46','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000113.jpg',NULL,'0'),(104000114,'90014','เกี๊ยวกุ้งต้มยำน้ำข้นปลาหมึก',75.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:57:10','2019-03-12 10:57:23','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000114.jpg',NULL,'0'),(104000115,'90015','เกี๊ยวกุ้งต้มยำน้ำข้นเนื้อปลา+ลูกชิ้นปลา',75.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 10:59:35','2019-03-12 11:00:16','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000115.jpg',NULL,'0'),(104000116,'90016','เกี๊ยวกุ้งต้มยำน้ำข้นทะเล',90.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 11:00:04','2019-03-12 12:56:51','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000116.jpg',NULL,'0'),(104000117,'90017','เกี๊ยวกุ้งต้มยำน้ำข้นกุ้ง',100.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 11:01:29','2019-03-12 12:57:05','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000117.jpg',NULL,'0'),(104000118,'90018','เกี๊ยวกุ้งพริกสดลูกชิ้นปลาปนเนื้อปลา',75.00,'1',102000011,'','1','','1','BIXOLON SRP-330II','2019-03-12 12:55:48','2019-03-12 14:10:29','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000118.jpg',NULL,'0'),(104000119,'90019','เกี๊ยวกุ้งทะเลพริกสดลูกชิ้นปลาปนเนื้อปลา',90.00,'1',102000011,'','1','','1','BIXOLON SRP-330II','2019-03-12 12:57:44','2019-03-12 14:10:39','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000119.jpg',NULL,'0'),(104000120,'90020','เกี๊ยวกุ้งต้มยำน้ำข้นเป็ดย่าง',80.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 12:59:38','2019-03-12 12:59:54','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000120.jpg',NULL,'0'),(104000121,'90021','เกี๊ยวกุ้งต้มยำน้ำข้นหมูกรอบ',75.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 13:11:22','2019-03-12 13:11:44','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000121.jpg',NULL,'0'),(104000122,'90022','เกี๊ยวกุ้งต้มยำน้ำข้นลูกชิ้นกุ้งทอด',85.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 13:14:59','2019-03-12 13:15:12','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000122.jpg',NULL,'0'),(104000123,'90023','เกี๊ยวกุ้งต้มยำน้ำข้น+เกี๊ยวปลา',85.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 13:15:49','2019-03-12 13:17:27','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000123.jpg',NULL,'0'),(104000124,'90024','เกี๊ยวกุ้งต้มยำน้ำข้นหมูก้อน',85.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 13:16:26','2019-03-12 13:16:40','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000124.jpg',NULL,'0'),(104000125,'90025','เกี๊ยวปูพริกไทยดำ',70.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 13:19:29','2019-03-12 13:19:41','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000125.jpg',NULL,'0'),(104000126,'11001','เต้าฮวยนมสด',20.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 13:20:29','2019-03-12 13:20:40','0','0','0',NULL,'','',NULL,NULL,103000007,'1','1','104000126.jpg',NULL,'0'),(104000127,'11002','เต้าฮวยฟรุ๊ตสลัด',20.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 13:21:08','2019-03-12 13:21:21','0','0','0',NULL,'','',NULL,NULL,103000007,'1','1','104000127.jpg',NULL,'0'),(104000128,'11003','เต้าทึง',25.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 13:21:41','2019-03-12 15:00:59','0','0','0',NULL,'','',NULL,NULL,103000007,'1','1','104000128.jpg',NULL,'0'),(104000129,'11004','สละลอยแก้ว',25.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 13:22:30','2019-04-29 16:13:01','0','0','0',NULL,'','',NULL,NULL,103000007,'1','1','104000129.jpg','0','0'),(104000130,'11005','กระท้อนลอยแก้ว',25.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 13:23:05','2019-04-29 16:12:23','0','0','0',NULL,'','',NULL,NULL,103000007,'1','1','104000130.jpg','0','0'),(104000131,'11006','ลูกตาลใบเตย',25.00,'1',102000007,'','1','','1','BIXOLON SRP-330II','2019-03-12 13:23:41','2019-03-12 13:24:03','0','0','0',NULL,'','',NULL,NULL,103000007,'1','1','104000131.jpg',NULL,'0'),(104000132,'11007','เปียกปูนกะทิสด',25.00,'1',102000010,'','1','','1','BIXOLON SRP-330II','2019-03-12 13:25:25','2019-03-12 14:08:01','0','0','0',NULL,'','',NULL,NULL,103000007,'1','1','104000132.jpg',NULL,'0'),(104000133,'11008','ครองแครงมะพร้าวอ่อน',30.00,'1',102000010,'','1','','1','BIXOLON SRP-330II','2019-03-12 13:25:58','2019-03-12 14:07:48','0','0','0',NULL,'','',NULL,NULL,103000007,'1','1','104000133.jpg',NULL,'0'),(104000134,'11009','มะม่วงน้ำดอกไม้ลอยแก้ว',40.00,'1',102000010,'','1','','1','BIXOLON SRP-330II','2019-03-12 13:26:46','2019-03-12 14:07:39','0','0','0',NULL,'','',NULL,NULL,103000007,'1','1','104000134.jpg',NULL,'0'),(104000135,'12001','มะตูม',20.00,'1',102000001,'','1','','1','BIXOLON SRP-330II','2019-03-12 13:29:46','2019-03-12 14:06:53','0','0','0',NULL,'','',NULL,NULL,103000009,'1','1','104000135.jpg',NULL,'0'),(104000136,'12002','ชาดำเย็น',20.00,'1',102000002,'','1','','1','BIXOLON SRP-330II','2019-03-12 13:30:26','2019-03-12 13:30:43','0','0','0',NULL,'','',NULL,NULL,103000009,'1','1','104000136.jpg',NULL,'0'),(104000137,'12003','โอเลี้ยง',20.00,'1',102000001,'','1','','1','BIXOLON SRP-330II','2019-03-12 14:06:28','2019-03-12 14:06:42','0','0','0',NULL,'','',NULL,NULL,103000009,'1','1','104000137.jpg',NULL,'0'),(104000138,'12004','เก๊กฮวย',20.00,'1',102000001,'','1','','1','BIXOLON SRP-330II','2019-03-12 14:08:29','2019-03-12 14:08:51','0','0','0',NULL,'','',NULL,NULL,103000009,'1','1','104000138.jpg',NULL,'0'),(104000139,'12005','ชาเย็นโบราณ',25.00,'1',102000001,'','1','','1','BIXOLON SRP-330II','2019-03-12 14:09:16','2019-03-12 14:09:33','0','0','0',NULL,'','',NULL,NULL,103000009,'1','1','104000139.jpg',NULL,'0'),(104000140,'12006','กาแฟโบราณ',25.00,'1',102000011,'','1','','1','BIXOLON SRP-330II','2019-03-12 14:09:48','2019-03-12 14:10:13','0','0','0',NULL,'','',NULL,NULL,103000009,'1','1','104000140.jpg',NULL,'0'),(104000141,'12007','ชามะนาว',25.00,'1',NULL,'',NULL,'','1','BIXOLON SRP-330II','2019-03-12 14:11:17',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000009,'1','1','104000141.jpg',NULL,'0'),(104000142,'12008','น้ำจับเลี้ยง',25.00,'1',102000001,'','1','','1','BIXOLON SRP-330II','2019-03-12 14:11:39','2019-03-12 14:11:59','0','0','0',NULL,'','',NULL,NULL,103000009,'1','1','104000142.jpg',NULL,'0'),(104000143,'12009','น้ำมะนาว',25.00,'1',102000001,'','1','','1','BIXOLON SRP-330II','2019-03-12 14:12:26','2019-03-12 14:12:52','0','0','0',NULL,'','',NULL,NULL,103000009,'1','1','104000143.jpg',NULL,'0'),(104000144,'12010','น้ำส้ม',25.00,'1',102000001,'','1','','1','BIXOLON SRP-330II','2019-03-12 14:13:03','2019-03-12 14:13:31','0','0','0',NULL,'','',NULL,NULL,103000009,'1','1','104000144.jpg',NULL,'0'),(104000145,'70007','ไข่ต้ม ฟองละ',10.00,'1',102000000,'','0','','1','BIXOLON SRP-330II','2019-05-15 11:02:27','2019-05-15 11:33:41','0','0','0',NULL,'','',NULL,NULL,103000002,'1','1','104000145.jpg','0','0'),(104000146,'70008','กุนเชียง ขีดละ',50.00,'1',102000000,'','0','','1','BIXOLON SRP-330II','2019-05-15 11:12:29','2019-05-15 11:33:55','0','0','0',NULL,'','',NULL,NULL,103000002,'1','1','104000145.jpg','0','0'),(104000147,'60007','ขิงดอง ขีดละ',10.00,'1',NULL,'',NULL,'','1','BIXOLON SRP-330II','2019-05-15 11:32:51',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,0,'1','1','104000147.jpg','0','0'),(104000148,'80015','เกาเหลาต้มยำน้ำข้นหมูกรอบ',0.00,'1',NULL,'',NULL,'','1','BIXOLON SRP-330II','2019-06-28 15:40:20',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000006,'1','1','104000148.jpg','0','0'),(104000149,'12011','สั่งพิเศษ',50.00,'1',102000011,NULL,'1',NULL,'1','BIXOLON SRP-330II',NULL,NULL,'0','0','0',NULL,NULL,NULL,NULL,NULL,NULL,'1','0',NULL,'1','1'),(104000150,'13000','แกงเผ็ดเป็ดย่าง',55.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-10-23 13:10:51',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000002,'1','1','104000000.jpg','0','0');
/*!40000 ALTER TABLE `b_foods` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_foods_category`
--

DROP TABLE IF EXISTS `b_foods_category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_foods_category` (
  `foods_cat_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `foods_cat_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `foods_cat_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `host_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_foods` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '0=default,1=Foods,2=Beverages',
  `filename` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `status_recommend` varchar(45) COLLATE utf8_bin DEFAULT '0',
  PRIMARY KEY (`foods_cat_id`)
) ENGINE=MyISAM AUTO_INCREMENT=103000014 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=103';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_foods_category`
--

LOCK TABLES `b_foods_category` WRITE;
/*!40000 ALTER TABLE `b_foods_category` DISABLE KEYS */;
INSERT INTO `b_foods_category` VALUES (103000000,'C100','ข้าวราด จานเดียว','1','','1100','2019-02-25 17:01:37','2019-09-04 14:43:29','0','0','0',NULL,'','',NULL,NULL,'103000000.jpg','0'),(103000001,'C101','ก๋วยเตี่ยว','1','','1101','2019-02-26 17:49:20','2019-09-04 14:43:35','0','0','0',NULL,'','',NULL,NULL,'103000001.jpg','0'),(103000002,'C102','กับข้าว เป็นอย่างๆ','1','','1102','2019-02-26 17:50:08','2019-09-04 14:44:08','0','0','0',NULL,'','',NULL,NULL,'103000002.jpg','0'),(103000003,'C103','บะหมี่','1','','1103','2019-02-26 17:50:26','2019-09-04 14:44:16','0','0','0',NULL,'','',NULL,NULL,NULL,'0'),(103000004,'C104','ข้าวต้ม','1','','1104','2019-02-26 17:50:42','2019-09-04 14:44:22','0','0','0',NULL,'','',NULL,NULL,NULL,'0'),(103000005,'C105','ลวกจิ้ม','1','','1105','2019-02-26 17:51:03','2019-09-04 14:44:27','0','0','0',NULL,'','',NULL,NULL,NULL,'0'),(103000006,'C106','เกาเหลา','1','','1106','2019-02-26 17:51:16','2019-09-04 14:44:32','0','0','0',NULL,'','',NULL,NULL,NULL,'0'),(103000007,'C107','ของหวาน','1','','1107','2019-02-26 17:51:30','2019-09-04 14:44:36','0','0','0',NULL,'','',NULL,NULL,NULL,'0'),(103000008,'C108','เกี๊ยว','1','','1108','2019-03-11 16:24:52','2019-09-04 14:44:40','0','0','0',NULL,'','',NULL,NULL,NULL,'0'),(103000009,'C109','เครื่องดื่ม','1','','1109','2019-03-11 16:26:13','2019-09-04 14:44:44','0','0','0',NULL,'','',NULL,NULL,NULL,'0'),(103000010,'C110','ซุป','1','','1110','2019-03-12 09:20:48','2019-09-04 14:44:49','0','0','0',NULL,'','',NULL,NULL,NULL,'0'),(103000011,'C111','เส้นลวก','1','','1111','2019-03-12 09:22:11','2019-09-04 14:44:53','0','0','0',NULL,'','',NULL,NULL,NULL,'0'),(103000012,'C112','น้ำจิ้ม','1','','1112','2019-03-12 09:34:44','2019-09-04 14:44:58','0','0','0',NULL,'','',NULL,NULL,NULL,'0'),(103000013,'C000','เมนูแนะนำ','1','','1000','2019-09-04 14:43:02',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,'103000013.jpg','1');
/*!40000 ALTER TABLE `b_foods_category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_foods_category_sub`
--

DROP TABLE IF EXISTS `b_foods_category_sub`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_foods_category_sub` (
  `foods_cat_sub_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `foods_cat_sub_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `foods_cat_sub_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `foods_cat_id` bigint(20) DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `host_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`foods_cat_sub_id`)
) ENGINE=MyISAM AUTO_INCREMENT=105000001 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=105';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_foods_category_sub`
--

LOCK TABLES `b_foods_category_sub` WRITE;
/*!40000 ALTER TABLE `b_foods_category_sub` DISABLE KEYS */;
INSERT INTO `b_foods_category_sub` VALUES (105000000,'CS100','ข้าวราด ข้าวหน้า',103000000,'1','',NULL,'2019-02-26 18:05:11',NULL,'0','0','0',NULL,'',NULL,NULL);
/*!40000 ALTER TABLE `b_foods_category_sub` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_foods_material`
--

DROP TABLE IF EXISTS `b_foods_material`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_foods_material` (
  `foods_material_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `foods_id` bigint(20) DEFAULT NULL,
  `material_id` bigint(20) DEFAULT NULL,
  `material_name` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `price` decimal(17,2) DEFAULT NULL,
  `weight` decimal(17,4) DEFAULT NULL,
  `active` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `host_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `qty` decimal(17,4) DEFAULT NULL COMMENT 'จำนวน คือ weight เท่าไร',
  `sort1` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `unit_id` bigint(20) DEFAULT NULL,
  `unit_cal_id` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`foods_material_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1410000091 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=141';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_foods_material`
--

LOCK TABLES `b_foods_material` WRITE;
/*!40000 ALTER TABLE `b_foods_material` DISABLE KEYS */;
INSERT INTO `b_foods_material` VALUES (1410000000,104000001,1400000000,'เส้นใหญ่',5.00,0.0000,'1','','2019-10-10 16:10:35',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD',1.0000,'999999999',NULL,NULL),(1,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:19:53','','2019-10-11 09:15:47','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(2,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:20:51','','2019-10-10 15:45:16','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(3,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:23:36','','2019-10-10 15:45:04','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(4,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:23:38','','2019-10-10 15:44:58','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(5,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:23:38','','2019-10-10 15:44:57','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(6,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:23:38','','2019-10-10 15:44:56','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(7,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:23:46','','2019-10-10 15:45:00','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(8,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:23:46','','2019-10-10 15:44:55','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(9,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:23:46','','2019-10-10 15:44:59','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(10,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:23:46','','2019-10-10 15:45:01','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(11,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:23:48','','2019-10-10 15:44:51','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(12,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:23:48','','2019-10-10 15:44:50','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(13,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:23:48','','2019-10-10 15:44:49','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(14,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:23:48','','2019-10-10 15:44:46','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(15,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:23:50','','2019-10-10 15:44:45','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(16,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:23:50','','2019-10-10 15:44:44','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(17,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:23:50','','2019-10-10 15:44:52','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(18,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:23:50','','2019-10-10 15:44:40','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(19,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:25:04','','2019-10-10 15:44:42','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(20,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:25:04','','2019-10-10 15:44:39','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(21,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:25:19','','2019-10-10 15:44:38','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(22,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:25:23','','2019-10-10 15:44:37','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(23,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:26:11','','2019-10-10 15:45:03','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(24,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:26:11','','2019-10-10 15:44:43','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(25,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:26:11','','2019-10-10 15:44:53','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(26,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:26:16','','2019-10-10 15:44:54','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(27,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:26:16','','2019-10-10 15:44:34','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(28,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:26:16','','2019-10-10 15:44:23','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(29,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:26:22','','2019-10-10 15:44:32','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(30,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:26:22','','2019-10-10 15:44:35','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(31,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:26:22','','2019-10-10 15:45:08','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(32,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:29:04','','2019-10-10 15:45:04','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(33,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:29:04','','2019-10-10 15:45:07','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(34,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:29:06','','2019-10-10 15:45:05','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(35,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:29:06','','2019-10-10 15:45:11','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(36,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:29:09','','2019-10-10 15:45:09','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(37,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:29:09','','2019-10-10 15:45:12','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(38,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:29:16','','2019-10-10 15:45:10','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(39,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:29:16','','2019-10-10 15:45:13','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(40,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:40:27','','2019-10-10 15:45:17','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(41,104000001,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-10 15:40:29','','2019-10-10 15:45:14','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(42,104000000,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-11 08:31:33','','2019-10-11 08:31:37','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(43,104000000,1,'เส้นใหญ่',0.00,0.0000,'3','','2019-10-11 08:36:03','','2019-10-11 17:35:20','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(44,104000001,1,'เส้นใหญ่',5.00,0.0000,'3','','2019-10-11 09:15:49','','2019-10-11 09:16:06','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(45,104000001,1,'เส้นใหญ่',5.00,0.0000,'3','','2019-10-11 09:18:19','','2019-10-11 09:18:23','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(46,104000001,1,'เส้นใหญ่',5.00,200.0000,'3','','2019-10-11 09:19:22','','2019-10-11 17:36:10','','','','','','503EAA041AD6',1.0000,'999999999',NULL,NULL),(47,104000001,2,'เส้นเล็ก',5.00,200.0000,'1','','2019-10-11 17:37:26','','','','','','','','1C1B0D989A0D',1.0000,'999999999',NULL,NULL),(48,104000001,2,'เส้นเล็ก',5.00,200.0000,'3','','2019-10-11 17:46:22','','2019-10-11 17:48:16','','','','','','1C1B0D989A0D',1.0000,'999999999',NULL,NULL),(49,104000001,12,'Cooking 1',5.00,1.0000,'1','','2019-10-11 17:46:52','','','','','','','','1C1B0D989A0D',1.0000,'999999999',NULL,NULL),(50,104000001,13,'เนื้อหมูชิ้น',10.00,0.1000,'1','','2019-10-11 17:48:06','','','','','','','','1C1B0D989A0D',1.0000,'999999999',NULL,NULL),(51,104000001,10,'ผักใส่ในชาม',2.00,0.0100,'1','','2019-10-11 17:48:30','','','','','','','','1C1B0D989A0D',1.0000,'999999999',NULL,NULL),(52,104000001,16,'เครื่องปรุงต่างๆ ที่โต๊ะทาน',5.00,1.0000,'1','','2019-10-11 17:52:07','','','','','','','','1C1B0D989A0D',1.0000,'999999999',NULL,NULL),(53,104000001,15,'เครื่องปรุงต่างในครัว',5.00,1.0000,'1','','2019-10-11 17:52:09','','','','','','','','1C1B0D989A0D',1.0000,'999999999',NULL,NULL),(54,104000001,14,'res service',5.00,1.0000,'1','','2019-10-11 17:52:11','','','','','','','','1C1B0D989A0D',1.0000,'999999999',NULL,NULL),(55,104000000,2,'เส้นเล็ก',5.00,200.0000,'1','','2019-10-13 06:21:24','','','','','','','','E0D55E2E84BA',1.0000,'999999999',NULL,NULL),(56,104000000,12,'Cooking 1',5.00,1.0000,'1','','2019-10-13 06:21:42','','','','','','','','E0D55E2E84BA',1.0000,'999999999',NULL,NULL),(57,104000000,14,'res service',5.00,1.0000,'1','','2019-10-13 06:21:44','','','','','','','','E0D55E2E84BA',1.0000,'999999999',NULL,NULL),(58,104000000,15,'เครื่องปรุงต่างในครัว',5.00,1.0000,'1','','2019-10-13 06:21:48','','','','','','','','E0D55E2E84BA',1.0000,'999999999',NULL,NULL),(59,104000000,11,'เนื้อปลาลวก',2.00,0.0100,'1','','2019-10-13 06:23:47','','','','','','','','E0D55E2E84BA',1.0000,'999999999',NULL,NULL),(60,104000000,10,'ผักใส่ในชาม',2.00,0.0100,'1','','2019-10-13 06:25:06','','','','','','','','E0D55E2E84BA',1.0000,'999999999',NULL,NULL),(61,104000002,19,'ข้าวเปล่าเป็นจาน',7.00,0.3000,'1','','2019-10-13 06:40:08','','','','','','','','E0D55E2E84BA',1.0000,'999999999',NULL,NULL),(62,104000002,24,'ผักกวางตุ้งลวก',3.00,0.2000,'1','','2019-10-13 06:40:12','','','','','','','','E0D55E2E84BA',1.0000,'999999999',NULL,NULL),(63,104000002,22,'เนื้อเป็ด',15.00,0.2000,'1','','2019-10-13 06:40:15','','','','','','','','E0D55E2E84BA',1.0000,'999999999',NULL,NULL),(64,104000002,18,'ขิงดองใส่ข้าวหน้าเป็ด',3.00,0.1000,'1','','2019-10-13 06:40:18','','','','','','','','E0D55E2E84BA',1.0000,'999999999',NULL,NULL),(65,104000002,12,'Cooking 1',5.00,1.0000,'1','','2019-10-13 06:40:23','','','','','','','','E0D55E2E84BA',1.0000,'999999999',NULL,NULL),(66,104000002,14,'res service',5.00,1.0000,'1','','2019-10-13 06:40:25','','','','','','','','E0D55E2E84BA',1.0000,'999999999',NULL,NULL),(67,104000002,15,'เครื่องปรุงต่างในครัว',5.00,1.0000,'1','','2019-10-13 06:40:30','','','','','','','','E0D55E2E84BA',1.0000,'999999999',NULL,NULL),(68,104000003,19,'ข้าวเปล่าเป็นจาน',7.00,0.3000,'1','','2019-10-13 06:51:23','','','','','','','','E0D55E2E84BA',1.0000,'999999999',NULL,NULL),(69,104000003,12,'Cooking 1',5.00,1.0000,'1','','2019-10-13 06:51:33','','','','','','','','E0D55E2E84BA',1.0000,'999999999',NULL,NULL),(70,104000003,14,'res service',5.00,1.0000,'1','','2019-10-13 06:51:35','','','','','','','','E0D55E2E84BA',1.0000,'999999999',NULL,NULL),(71,104000003,27,'ไข่ต้ม ครึ่งใบ',5.00,0.2000,'1','','2019-10-13 06:51:39','','','','','','','','E0D55E2E84BA',1.0000,'999999999',NULL,NULL),(72,104000003,28,'แตงกวา ประกอบในจาน',3.00,0.2000,'1','','2019-10-13 06:51:41','','','','','','','','E0D55E2E84BA',1.0000,'999999999',NULL,NULL),(73,104000003,29,'หมูแดง',15.00,0.2000,'1','','2019-10-13 06:52:39','','','','','','','','E0D55E2E84BA',1.0000,'999999999',NULL,NULL),(1410000074,104000001,1400000030,'กุ้ง',20.00,0.2000,'3','','2019-10-14 05:08:47',NULL,'2019-10-14 05:09:03','','',NULL,'','','9C305B23F7CD',1.0000,'999999999',NULL,NULL),(1410000075,104000004,19,'ข้าวเปล่าเป็นจาน',7.00,0.3000,'1','','2019-10-15 09:28:54',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD',1.0000,'999999999',NULL,NULL),(1410000076,104000004,1400000031,'หมูกรอบใส่จาน',10.00,0.2000,'1','','2019-10-15 09:28:58',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD',1.0000,'999999999',NULL,NULL),(1410000077,104000004,12,'Cooking 1',5.00,1.0000,'1','','2019-10-15 09:29:02',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD',1.0000,'999999999',NULL,NULL),(1410000078,104000004,14,'res service',5.00,1.0000,'1','','2019-10-15 09:29:06',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD',1.0000,'999999999',NULL,NULL),(1410000079,104000004,28,'แตงกวา ประกอบในจาน',3.00,0.2000,'1','','2019-10-15 09:29:26',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD',1.0000,'999999999',NULL,NULL),(1410000080,104000150,1400000032,'พริกแกง แกงเผ็ด',100.00,45.0000,'1','','2019-10-23 13:11:14',NULL,NULL,'',NULL,NULL,'','','1E305B23F7CD',1.0000,'999999999',NULL,NULL),(1410000081,104000150,1400000033,'เป็ดย่าง',175.00,75.0000,'1','','2019-10-23 13:11:33',NULL,NULL,'',NULL,NULL,'','','1E305B23F7CD',1.0000,'999999999',NULL,NULL),(1410000082,104000150,1400000034,'หัวกระทิ',70.00,240.0000,'1','','2019-10-23 13:11:36',NULL,NULL,'',NULL,NULL,'','','1E305B23F7CD',1.0000,'999999999',NULL,NULL),(1410000083,104000150,1400000035,'มะเขือเทศลูกเล็ก',22.00,5.0000,'1','','2019-10-23 13:14:59',NULL,NULL,'',NULL,NULL,'','','1E305B23F7CD',1.0000,'999999999',NULL,NULL),(1410000084,104000150,1400000036,'มะเขือพวง',50.00,30.0000,'1','','2019-10-23 13:15:01',NULL,NULL,'',NULL,NULL,'','','1E305B23F7CD',1.0000,'999999999',NULL,NULL),(1410000085,104000150,1400000037,'มะเขือเปราะ',20.00,30.0000,'1','','2019-10-23 13:15:03',NULL,NULL,'',NULL,NULL,'','','1E305B23F7CD',1.0000,'999999999',NULL,NULL),(1410000086,104000150,1400000038,'ใบมะกรูด',50.00,1.0000,'1','','2019-10-23 13:15:08',NULL,NULL,'',NULL,NULL,'','','1E305B23F7CD',1.0000,'999999999',NULL,NULL),(1410000087,104000150,1400000039,'ใบโหระพา',50.00,7.5000,'1','','2019-10-23 13:15:11',NULL,NULL,'',NULL,NULL,'','','1E305B23F7CD',1.0000,'999999999',NULL,NULL),(1410000088,104000150,1400000040,'น้ำปลา',26.00,15.0000,'1','','2019-10-23 13:15:13',NULL,NULL,'',NULL,NULL,'','','1E305B23F7CD',1.0000,'999999999',NULL,NULL),(1410000089,104000150,1400000041,'น้ำตาลปีบ',30.00,15.0000,'1','','2019-10-23 13:15:15',NULL,NULL,'',NULL,NULL,'','','1E305B23F7CD',1.0000,'999999999',NULL,NULL),(1410000090,104000150,1400000042,'พริกชี้ฟ้าแดง',50.00,40.0000,'1','','2019-10-23 13:17:24',NULL,NULL,'',NULL,NULL,'','','1E305B23F7CD',1.0000,'999999999',NULL,NULL);
/*!40000 ALTER TABLE `b_foods_material` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_foods_recommend`
--

DROP TABLE IF EXISTS `b_foods_recommend`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_foods_recommend` (
  `recom_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `foods_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `foods_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `host_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`recom_id`)
) ENGINE=MyISAM AUTO_INCREMENT=106000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=106';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_foods_recommend`
--

LOCK TABLES `b_foods_recommend` WRITE;
/*!40000 ALTER TABLE `b_foods_recommend` DISABLE KEYS */;
/*!40000 ALTER TABLE `b_foods_recommend` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_foods_special`
--

DROP TABLE IF EXISTS `b_foods_special`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_foods_special` (
  `foods_spec_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `foods_id` bigint(20) DEFAULT NULL,
  `foods_spec_name` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `host_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`foods_spec_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1280000008 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=128';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_foods_special`
--

LOCK TABLES `b_foods_special` WRITE;
/*!40000 ALTER TABLE `b_foods_special` DISABLE KEYS */;
INSERT INTO `b_foods_special` VALUES (1280000000,104000001,'ไม่งอก','1','','2019-03-15 11:57:37',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD'),(1280000001,104000001,'หมูแอย่างเดียว','1','','2019-03-15 11:58:06',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD'),(1280000002,104000001,'ไม่ใส่ผงชูรส','1','','2019-03-15 11:58:28',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD'),(1280000003,104000006,'ไม่ราดน้ำ','1','','2019-04-04 11:00:08',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD'),(1280000004,104000006,'','1','','2019-04-04 11:20:22',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD'),(1280000005,104000006,'ไม่หวาน','1','','2019-04-04 11:21:23',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD'),(1280000006,104000001,'เส้นเล็ก','1','','2019-04-29 16:55:54',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD'),(1280000007,104000001,'เส้นใหญ่','1','','2019-04-29 16:57:49',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD');
/*!40000 ALTER TABLE `b_foods_special` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_foods_topping`
--

DROP TABLE IF EXISTS `b_foods_topping`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_foods_topping` (
  `foods_topping_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `foods_id` bigint(20) DEFAULT NULL,
  `foods_topping_name` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `price` decimal(17,2) DEFAULT NULL,
  `active` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `host_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`foods_topping_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1290000008 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=129';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_foods_topping`
--

LOCK TABLES `b_foods_topping` WRITE;
/*!40000 ALTER TABLE `b_foods_topping` DISABLE KEYS */;
INSERT INTO `b_foods_topping` VALUES (1290000000,104000001,'เพิ่มลูกชิ้นหมู',10.00,'1','','2019-03-15 11:58:52',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD'),(1290000001,104000001,'เพิ่มเกี้ยวทอด',5.00,'1','','2019-03-15 11:59:08',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD'),(1290000002,104000001,'เพิ่มลูกชิ้นปลา',20.00,'1','','2019-03-15 11:59:29',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD'),(1290000003,104000006,'พิเศษ',10.00,'1','','2019-04-04 11:21:53',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD'),(1290000004,104000006,'พิเศษหมูกรอบ',10.00,'1','','2019-04-04 11:22:15',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD'),(1290000005,104000006,'พิเศษไก่',10.00,'1','','2019-04-04 11:22:45',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD'),(1290000006,104000144,'(ใหญ่)',10.00,'1','','2019-04-29 16:23:29',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD'),(1290000007,104000144,'(ใหญ่)',10.00,'1','','2019-04-29 16:23:55',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD');
/*!40000 ALTER TABLE `b_foods_topping` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_foods_type`
--

DROP TABLE IF EXISTS `b_foods_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_foods_type` (
  `foods_type_id` bigint(20) NOT NULL AUTO_INCREMENT,
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
  `date_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`foods_type_id`)
) ENGINE=MyISAM AUTO_INCREMENT=102000013 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=102';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_foods_type`
--

LOCK TABLES `b_foods_type` WRITE;
/*!40000 ALTER TABLE `b_foods_type` DISABLE KEYS */;
INSERT INTO `b_foods_type` VALUES (102000002,'T100','Foods & Beverages','1','',NULL,'2019-02-25 16:05:36','2019-03-11 16:07:43','0','0','0',NULL,'','',NULL),(102000000,'T101','อาหาร กลางโต๊ะ','1','',NULL,'2019-02-26 16:50:45','2019-02-26 17:54:43','0','0','0',NULL,'','',NULL),(102000001,'T102','Food variety and a healthy','1','',NULL,'2019-02-26 16:51:26','2019-02-26 17:57:25','0','0','0',NULL,'','',NULL),(102000007,'T103','จานเดียว','1','',NULL,'2019-03-11 16:31:36',NULL,'0','0','0',NULL,'',NULL,NULL),(102000008,'T104','Promotion','1','',NULL,'2019-03-12 14:01:37',NULL,'0','0','0',NULL,'',NULL,NULL),(102000009,'T105','กับแกล้ม','1','',NULL,'2019-03-12 14:02:03',NULL,'0','0','0',NULL,'',NULL,NULL),(102000010,'T106','ทานเล่น','1','',NULL,'2019-03-12 14:02:58',NULL,'0','0','0',NULL,'',NULL,NULL),(102000011,'T107','เมนูเด็ดประจำร้าน','1','',NULL,'2019-03-12 14:04:30',NULL,'0','0','0',NULL,'',NULL,NULL),(102000012,'T108','เมนูขายดี','1','',NULL,'2019-03-12 14:04:40','2019-03-12 14:04:52','0','0','0',NULL,'','',NULL);
/*!40000 ALTER TABLE `b_foods_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_material`
--

DROP TABLE IF EXISTS `b_material`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_material` (
  `material_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `material_name` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `price` decimal(17,2) DEFAULT NULL,
  `weight` decimal(17,4) DEFAULT NULL,
  `active` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `host_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `material_code` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `material_type_id` bigint(20) DEFAULT NULL,
  `unit_id` bigint(20) DEFAULT NULL,
  `unit_cal_id` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`material_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1400000043 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=140';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_material`
--

LOCK TABLES `b_material` WRITE;
/*!40000 ALTER TABLE `b_material` DISABLE KEYS */;
INSERT INTO `b_material` VALUES (1400000000,'เส้นใหญ่',5.00,2.0000,'1','','2019-10-10 11:06:57','2019-10-10 11:07:51',NULL,'','',NULL,'','','',NULL,'',NULL,NULL,NULL),(1,'เส้นใหญ่',5.00,200.0000,'1','','2019-10-10 10:39:13','2019-10-13 06:29:26','','','','','','','','100000','100',1420000001,NULL,NULL),(2,'เส้นเล็ก',5.00,200.0000,'1','','2019-10-11 16:43:37','2019-10-13 06:29:39','','','','','','','','100000','101',1420000001,NULL,NULL),(3,'เส้นหมี่',5.00,200.0000,'1','','2019-10-11 16:43:51','2019-10-13 06:31:57','','','','','','','','100000','102',1420000001,NULL,NULL),(4,'บะหมี่เหลือง',5.00,200.0000,'1','','2019-10-11 16:44:17','2019-10-13 06:32:01','','','','','','','','100000','103',1420000001,NULL,NULL),(5,'บะหมี่ผัก',5.00,200.0000,'1','','2019-10-11 16:45:17','2019-10-13 06:32:04','','','','','','','','100000','104',1420000001,NULL,NULL),(6,'เส้นเวียดนาม',5.00,200.0000,'1','','2019-10-11 17:02:31','2019-10-13 06:30:14','','','','','','','','100000','105',1420000001,NULL,NULL),(7,'ลูกชิ้นหมู',5.00,200.0000,'1','','2019-10-11 17:04:16','2019-10-13 06:30:07','','','','','','','','200000','201',1420000002,NULL,NULL),(8,'ลูกชิ้นเนื้อ',5.00,200.0000,'1','','2019-10-11 17:05:28','2019-10-13 06:30:00','','','','','','','','200000','202',1420000002,NULL,NULL),(9,'พริกขี้หนู',2.00,0.0100,'1','','2019-10-11 17:27:22','2019-10-13 06:30:29','','','','','','','','300000','300',1420000006,NULL,NULL),(10,'ผักใส่ในชาม',2.00,0.0100,'1','','2019-10-11 17:28:49','2019-10-13 06:30:43','','','','','','','','300000','301',1420000006,NULL,NULL),(11,'เนื้อปลาลวก',2.00,0.0100,'1','','2019-10-11 17:31:21','2019-10-13 06:30:50','','','','','','','','400000','400',1420000004,NULL,NULL),(12,'Cooking 1',5.00,1.0000,'1','','2019-10-11 17:33:08','2019-10-13 06:29:04','','','','','','','','999999','500',1420000007,NULL,NULL),(13,'เนื้อหมูชิ้น',10.00,0.1000,'1','','2019-10-11 17:47:46','2019-10-13 06:31:00','','','','','','','','600000','600',1420000003,NULL,NULL),(14,'res service',5.00,1.0000,'1','','2019-10-11 17:50:01','2019-10-13 06:28:58','','','','','','','','999999','501',1420000007,NULL,NULL),(15,'เครื่องปรุงต่างในครัว',5.00,1.0000,'1','','2019-10-11 17:50:40','2019-10-13 06:31:27','','','','','','','','999000','502',1420000007,NULL,NULL),(16,'เครื่องปรุงต่างๆ ที่โต๊ะทาน',5.00,1.0000,'1','','2019-10-11 17:51:35','2019-10-13 06:31:36','','','','','','','','999000','503',1420000007,NULL,NULL),(17,'เนื้อหมูสับ',5.00,100.0000,'1','','2019-10-13 06:26:15','2019-10-13 06:28:49','','','','','','','','601000','601',1420000003,NULL,NULL),(18,'ขิงดองใส่ข้าวหน้าเป็ด',3.00,0.1000,'1','','2019-10-13 06:33:52','','','','','','','','','300000','302',1420000006,NULL,NULL),(19,'ข้าวเปล่าเป็นจาน',7.00,0.3000,'1','','2019-10-13 06:35:19','','','','','','','','','700000','700',1420000008,NULL,NULL),(20,'เนื้อชิ้น',10.00,0.2000,'1','','2019-10-13 06:37:30','2019-10-13 06:38:04','','','','','','','','600000','602',1420000003,NULL,NULL),(21,'เนื้อสับ',10.00,0.2000,'1','','2019-10-13 06:37:57','2019-10-13 06:38:07','','','','','','','','600000','603',1420000003,NULL,NULL),(22,'เนื้อเป็ด',15.00,0.2000,'1','','2019-10-13 06:38:26','','','','','','','','','600000','604',1420000003,NULL,NULL),(23,'เนื้อไก่',10.00,0.2000,'1','','2019-10-13 06:38:43','','','','','','','','','600000','605',1420000003,NULL,NULL),(24,'ผักกวางตุ้งลวก',3.00,0.2000,'1','','2019-10-13 06:39:37','','','','','','','','','300000','303',1420000006,NULL,NULL),(25,'น้ำราด ข้าวหน้าเป็ด',5.00,1.0000,'1','','2019-10-13 06:47:28','2019-10-13 06:47:57','','','','','','','','500000','504',1420000007,NULL,NULL),(26,'น้ำราด ข้าวหมูแดง',5.00,1.0000,'1','','2019-10-13 06:47:51','','','','','','','','','500000','505',1420000007,NULL,NULL),(27,'ไข่ต้ม ครึ่งใบ',5.00,0.2000,'1','','2019-10-13 06:49:22','','','','','','','','','800000','800',1420000009,NULL,NULL),(28,'แตงกวา ประกอบในจาน',3.00,0.2000,'1','','2019-10-13 06:50:32','','','','','','','','','300000','304',1420000006,NULL,NULL),(29,'หมูแดง',15.00,0.2000,'1','','2019-10-13 06:52:29','','','','','','','','','600000','606',1420000003,NULL,NULL),(1400000030,'กุ้ง',20.00,0.2000,'1','','2019-10-14 05:08:07',NULL,NULL,'',NULL,NULL,'','','','','900',1420000010,NULL,NULL),(1400000031,'หมูกรอบใส่จาน',10.00,0.2000,'1','','2019-10-15 09:28:20',NULL,NULL,'',NULL,NULL,'','','','600000','606',1420000003,NULL,NULL),(1400000032,'พริกแกง แกงเผ็ด',100.00,45.0000,'1','','2019-10-23 13:03:34',NULL,NULL,'',NULL,NULL,'','','','','130001',1420000011,1440000001,1440000000),(1400000033,'เป็ดย่าง',175.00,75.0000,'1','','2019-10-23 13:04:06',NULL,NULL,'',NULL,NULL,'','','','','606',1420000003,1440000003,1440000000),(1400000034,'หัวกระทิ',70.00,240.0000,'1','','2019-10-23 13:04:28',NULL,NULL,'',NULL,NULL,'','','','','501',1420000007,1440000003,1440000000),(1400000035,'มะเขือเทศลูกเล็ก',22.00,5.0000,'1','','2019-10-23 13:04:54',NULL,NULL,'',NULL,NULL,'','','','','305',1420000006,1440000009,1440000000),(1400000036,'มะเขือพวง',50.00,30.0000,'1','','2019-10-23 13:05:14',NULL,NULL,'',NULL,NULL,'','','','','306',1420000006,1440000003,1440000000),(1400000037,'มะเขือเปราะ',20.00,30.0000,'1','','2019-10-23 13:05:47',NULL,NULL,'',NULL,NULL,'','','','','307',1420000006,1440000003,1440000000),(1400000038,'ใบมะกรูด',50.00,1.0000,'1','','2019-10-23 13:06:08',NULL,NULL,'',NULL,NULL,'','','','','308',1420000006,1440000010,1440000000),(1400000039,'ใบโหระพา',50.00,7.5000,'1','','2019-10-23 13:06:30',NULL,NULL,'',NULL,NULL,'','','','','309',1420000006,1440000003,1440000000),(1400000040,'น้ำปลา',26.00,15.0000,'1','','2019-10-23 13:09:43',NULL,NULL,'',NULL,NULL,'','','','','503',1420000007,1440000001,1440000000),(1400000041,'น้ำตาลปีบ',30.00,15.0000,'1','','2019-10-23 13:10:04',NULL,NULL,'',NULL,NULL,'','','','','504',1420000007,1440000001,1440000000),(1400000042,'พริกชี้ฟ้าแดง',50.00,40.0000,'1','','2019-10-23 13:17:08',NULL,NULL,'',NULL,NULL,'','','','','310',1420000006,1440000003,1440000000);
/*!40000 ALTER TABLE `b_material` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_material_type`
--

DROP TABLE IF EXISTS `b_material_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_material_type` (
  `material_type_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `material_type_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `material_type_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `host_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`material_type_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1420000012 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=142';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_material_type`
--

LOCK TABLES `b_material_type` WRITE;
/*!40000 ALTER TABLE `b_material_type` DISABLE KEYS */;
INSERT INTO `b_material_type` VALUES (1420000001,'100','เส้น','1','','','2019-10-11 15:13:56','2019-10-11 16:32:01','','','','','','',''),(1420000002,'101','ลูกชิ้น','1','','','2019-10-11 15:14:29','','','','','','','',''),(1420000003,'102','เนื้อหมู, เนื้อวัว, เนื้อเป็ด, เนื้อไก่','1','','','2019-10-11 16:32:11','2019-10-13 06:36:39','','','','','','',''),(1420000004,'103','ปลาสด','1','','','2019-10-11 16:32:27','2019-10-11 17:07:13','','','','','','',''),(1420000005,'104','ปลาแห้ง','1','','','2019-10-11 16:32:47','2019-10-11 17:07:27','','','','','','',''),(1420000006,'105','ผัก','1','','','2019-10-11 16:33:04','','','','','','','',''),(1420000007,'106','Cooking','1','','','2019-10-11 17:32:39','','','','','','','',''),(1420000008,'107','ข้าว','1','','','2019-10-13 06:34:39','','','','','','','',''),(1420000009,'108','ไข่','1','','','2019-10-13 06:48:28','2019-10-13 06:48:48','','','','','','',''),(1420000010,'109','อาหารทะเล','1','',NULL,'2019-10-14 05:07:18',NULL,'','','',NULL,'',NULL,NULL),(1420000011,'109','พริกแกง','1','',NULL,'2019-10-23 11:11:17',NULL,'','','',NULL,'',NULL,NULL);
/*!40000 ALTER TABLE `b_material_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_noodle_make`
--

DROP TABLE IF EXISTS `b_noodle_make`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_noodle_make` (
  `noodle_make_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `noodle_make_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `noodle_make_price` decimal(17,2) DEFAULT NULL,
  `noodle_make_where` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `noodle_make_where1` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`noodle_make_id`)
) ENGINE=MyISAM AUTO_INCREMENT=113000025 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=113';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_noodle_make`
--

LOCK TABLES `b_noodle_make` WRITE;
/*!40000 ALTER TABLE `b_noodle_make` DISABLE KEYS */;
INSERT INTO `b_noodle_make` VALUES (113000000,'หมี่ขาว',0.00,'noodle','','1'),(113000001,'เส้นเล็ก',0.00,'noodle','','1'),(113000002,'เส้นใหญ่',0.00,'noodle','','1'),(113000003,'บะหมี่',0.00,'noodle','','1'),(113000004,'แห้ง',0.00,'water','','1'),(113000005,'น้ำ',0.00,'water','','1'),(113000006,'ต้มยำ',0.00,'water','','1'),(113000007,'เย็นตาโฟ',0.00,'water','','1'),(113000008,'ผัก',0.00,'option_noodle','','1'),(113000009,'กระเทียม',0.00,'option_noodle','','1'),(113000010,'เผ็ด',0.00,'option_noodle','','1'),(113000011,'ลูกชิ้นปลา',5.00,'noodle_meat_ball','','1'),(113000012,'ลูกชิ้นกุ้งทอด',10.00,'noodle_meat_ball','','1'),(113000013,'เกี้ยวปลา',8.00,'noodle_meat_ball','','1'),(113000014,'เนื้อปลา',10.00,'noodle_sea','','1'),(113000015,'กุ้ง',10.00,'noodle_sea','','1'),(113000016,'ปลาหมึก',8.00,'noodle_sea','','1'),(113000017,'หมูแดง',30.00,'noodle_meat','','1'),(113000018,'หมูกรอบ',30.00,'noodle_meat','','1'),(113000019,'เป็ดย่าง',30.00,'noodle_meat','','1'),(113000020,'ผักบุ้ง',0.00,'noodle_vagetable','','1'),(113000021,'ถั่วงอก',0.00,'noodle_vagetable','','1'),(113000022,'ต้นหอม',0.00,'noodle_vagetable','','1'),(113000023,'บะหมี่ ผัก',NULL,'noodle',NULL,'1'),(113000024,'บะหมี่ สาหร่าย',NULL,'noodle',NULL,'1');
/*!40000 ALTER TABLE `b_noodle_make` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_position`
--

DROP TABLE IF EXISTS `b_position`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_position` (
  `posi_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `posi_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `posi_name_t` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `posi_name_e` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `dept_id` bigint(20) DEFAULT NULL,
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
) ENGINE=MyISAM AUTO_INCREMENT=1400000005 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=140';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_position`
--

LOCK TABLES `b_position` WRITE;
/*!40000 ALTER TABLE `b_position` DISABLE KEYS */;
INSERT INTO `b_position` VALUES (1400000004,'100','ผู้จัดการร้าน','',NULL,'2019-02-25 09:23:52','','','','','','1','','','0','0');
/*!40000 ALTER TABLE `b_position` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_prefix`
--

DROP TABLE IF EXISTS `b_prefix`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_prefix` (
  `prefix_id` bigint(20) NOT NULL AUTO_INCREMENT,
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
  `f_sex_id` int(11) DEFAULT NULL,
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
  `printer_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `printer_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `printer_ip` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `host_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
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
  `res_id` bigint(20) NOT NULL AUTO_INCREMENT,
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
  `date_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `cop_id` int(11) DEFAULT NULL,
  `receipt_header3` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `receipt_header4` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `receipt_header5` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `receipt_footer3` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `printer_bill_margin_top` int(11) DEFAULT NULL,
  `printer_bill_margin_left` int(11) DEFAULT NULL,
  `printer_bill_margin_right` int(11) DEFAULT NULL,
  `printer_bill_print_top` int(11) DEFAULT NULL,
  `printer_bill_print_left` int(11) DEFAULT NULL,
  `printer_bill_print_right` int(11) DEFAULT NULL,
  `receipt_footer4` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  `receipt_footer5` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`res_id`)
) ENGINE=MyISAM AUTO_INCREMENT=101000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=101 ชื่อร้านอาหาร';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_restaurant`
--

LOCK TABLES `b_restaurant` WRITE;
/*!40000 ALTER TABLE `b_restaurant` DISABLE KEYS */;
INSERT INTO `b_restaurant` VALUES (1,'100','ร้านพริกสด','1','','2019-02-25 15:33:57',NULL,'1','Thank You','RECEIPT','http://www.modernpos.co.th','TAX :','','','','','','','','','',NULL,'0','0',NULL,'',NULL,NULL,'0',NULL,NULL,NULL,NULL,NULL,0,0,300,5,5,300,NULL,NULL);
/*!40000 ALTER TABLE `b_restaurant` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_staff`
--

DROP TABLE IF EXISTS `b_staff`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_staff` (
  `staff_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `staff_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `username` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `password1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `prefix_id` bigint(20) DEFAULT NULL,
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
  `dept_id` bigint(20) DEFAULT NULL,
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
) ENGINE=MyISAM AUTO_INCREMENT=1220000040 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=122';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_staff`
--

LOCK TABLES `b_staff` WRITE;
/*!40000 ALTER TABLE `b_staff` DISABLE KEYS */;
INSERT INTO `b_staff` VALUES (1220000039,'100','pop','pop',2090000019,'ภพ','pop','','','1','','','','','','0','','2019-02-25 09:15:51','2019-02-25 09:22:53','','','','','',0,'','','','2','0','0','0','0','0','0','pop','0','0');
/*!40000 ALTER TABLE `b_staff` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_table`
--

DROP TABLE IF EXISTS `b_table`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_table` (
  `table_id` bigint(20) NOT NULL AUTO_INCREMENT,
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
  `date_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_reser` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT 'status จอง',
  PRIMARY KEY (`table_id`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_table`
--

LOCK TABLES `b_table` WRITE;
/*!40000 ALTER TABLE `b_table` DISABLE KEYS */;
INSERT INTO `b_table` VALUES (1,NULL,'1','1','1','',NULL,'2019-02-25 14:41:46',NULL,'0','0',NULL,'0','0','0',NULL,'',NULL,NULL,'0'),(2,NULL,'2','2','1','',NULL,'2019-02-25 14:41:55',NULL,'0','0',NULL,'0','0','0',NULL,'',NULL,NULL,'0'),(3,NULL,'3','3','1','',NULL,'2019-02-25 14:42:01',NULL,'0','0',NULL,'0','0','0',NULL,'',NULL,NULL,'0'),(4,NULL,'4','4','1','',NULL,'2019-02-25 14:42:06',NULL,'0','0',NULL,'0','0','0',NULL,'',NULL,NULL,'0'),(5,NULL,'5','5','1','',NULL,'2019-02-25 14:42:11',NULL,'0','0',NULL,'0','0','0',NULL,'',NULL,NULL,'0'),(6,NULL,'100','100','1','',NULL,'2019-02-25 14:42:29',NULL,'0','1',NULL,'0','0','0',NULL,'',NULL,NULL,'0'),(7,NULL,'6','6','1','',NULL,'2019-02-25 14:42:34',NULL,'0','0',NULL,'0','0','0',NULL,'',NULL,NULL,'0');
/*!40000 ALTER TABLE `b_table` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_unit`
--

DROP TABLE IF EXISTS `b_unit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_unit` (
  `unit_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `unit_code` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `unit_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_unit` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '0=default, 1= material',
  `sort1` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `host_id` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`unit_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1440000011 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=144';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_unit`
--

LOCK TABLES `b_unit` WRITE;
/*!40000 ALTER TABLE `b_unit` DISABLE KEYS */;
INSERT INTO `b_unit` VALUES (1440000000,'100','กรัม','1','','2019-10-23 06:30:31','','','','','','','','0','0','0'),(1440000001,'101','ช้อนโต๊ะ','1','','2019-10-23 06:39:52','','','','','','','','0','0','0'),(1440000002,'102','แผ่น','1','','2019-10-23 06:40:28','','','','','','','','0','0','0'),(1440000003,'103','ถ้วยตวง','1','','2019-10-23 06:40:44','','','','','','','','0','0','0'),(1440000004,'104','ฟอง','1','','2019-10-23 06:40:55','','','','','','','','0','0','0'),(1440000005,'105','ฝัก','1','','2019-10-23 06:41:13','','','','','','','','0','0','0'),(1440000006,'106','ตัว','1','','2019-10-23 06:41:43','','','','','','','','0','0','0'),(1440000007,'107','ช้อนชา','1','','2019-10-23 06:41:54','','','','','','','','0','0','0'),(1440000008,'108','กำ','1','','2019-10-23 06:42:10','','','','','','','','0','0','0'),(1440000009,'109','ลูก','1','','2019-10-23 06:42:17','','','','','','','','0','0','0'),(1440000010,'110','ใบ','1','','2019-10-23 06:42:27','2019-10-23 09:48:09','','','','','','','0','0','0');
/*!40000 ALTER TABLE `b_unit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_user`
--

DROP TABLE IF EXISTS `b_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_user` (
  `user_id` bigint(20) NOT NULL AUTO_INCREMENT,
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
  `date_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
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
  `doc_type_id` bigint(20) NOT NULL AUTO_INCREMENT,
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
-- Table structure for table `f_prefix`
--

DROP TABLE IF EXISTS `f_prefix`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `f_prefix` (
  `f_prefix_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `prefix_description` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `f_sex_id` bigint(20) DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`f_prefix_id`)
) ENGINE=MyISAM AUTO_INCREMENT=2090000027 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=209';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `f_prefix`
--

LOCK TABLES `f_prefix` WRITE;
/*!40000 ALTER TABLE `f_prefix` DISABLE KEYS */;
INSERT INTO `f_prefix` VALUES (2090000019,'นาย',2100000003,'1'),(2090000020,'นางสาว',2100000004,'1'),(2090000021,'นาง',2100000004,'1'),(2090000022,'ด.ช.',2100000003,'1'),(2090000023,'ด.ญ.',2100000004,'1'),(2090000024,'Mr.',2100000003,'1'),(2090000025,'Mrs.',2100000004,'1'),(2090000026,'Miss',2100000004,'1');
/*!40000 ALTER TABLE `f_prefix` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `f_sex`
--

DROP TABLE IF EXISTS `f_sex`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `f_sex` (
  `f_sex_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `sex_description` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`f_sex_id`)
) ENGINE=MyISAM AUTO_INCREMENT=2100000005 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=210';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `f_sex`
--

LOCK TABLES `f_sex` WRITE;
/*!40000 ALTER TABLE `f_sex` DISABLE KEYS */;
INSERT INTO `f_sex` VALUES (2100000003,'ชาย','1'),(2100000004,'หญิง','1');
/*!40000 ALTER TABLE `f_sex` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sequence`
--

DROP TABLE IF EXISTS `sequence`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sequence` (
  `lotid` bigint(20) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`lotid`)
) ENGINE=MyISAM AUTO_INCREMENT=16 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sequence`
--

LOCK TABLES `sequence` WRITE;
/*!40000 ALTER TABLE `sequence` DISABLE KEYS */;
INSERT INTO `sequence` VALUES (15);
/*!40000 ALTER TABLE `sequence` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_bill`
--

DROP TABLE IF EXISTS `t_bill`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `t_bill` (
  `bill_id` bigint(20) NOT NULL AUTO_INCREMENT,
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
  `date_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`bill_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1070000020 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=107';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_bill`
--

LOCK TABLES `t_bill` WRITE;
/*!40000 ALTER TABLE `t_bill` DISABLE KEYS */;
INSERT INTO `t_bill` VALUES (1070000000,'','2019-09-01',NULL,'1','',NULL,'','','6','1','0','0',1215.00,0.00,0.00,0.00,1215.00,1215.00,1215.00,0.00,'2019-09-05 12:06:12','','','0','0','0','0','','','',''),(1070000001,'','2019-09-01',NULL,'1','',NULL,'','','6','1','0','0',1145.00,0.00,0.00,0.00,1145.00,1145.00,1145.00,0.00,'2019-09-05 15:58:42','','','0','0','0','0','','','',''),(1070000002,'','2019-09-01',NULL,'1','',NULL,'','','6','1','0','0',60.00,0.00,0.00,0.00,60.00,60.00,60.00,0.00,'2019-09-05 16:25:28','','','0','0','0','0','','','',''),(1070000003,'','2019-09-01',NULL,'1','',NULL,'','','6','1','0','0',160.00,0.00,0.00,0.00,160.00,160.00,160.00,0.00,'2019-09-18 13:25:43','','','0','0','0','0','','','',''),(1070000004,'','2019-09-02',NULL,'1','',NULL,'','','6','1','0','0',60.00,0.00,0.00,0.00,60.00,60.00,60.00,0.00,'2019-09-18 13:27:53','','','0','0','0','0','','','',''),(1070000005,'','2019-09-02',NULL,'1','',NULL,'','','6','1','0','0',1050.00,0.00,0.00,0.00,1050.00,1050.00,1050.00,0.00,'2019-09-18 13:31:17','','','0','0','0','0','','','',''),(1070000006,'','2019-09-02',NULL,'1','',NULL,'','','6','1','0','0',225.00,0.00,0.00,0.00,225.00,225.00,225.00,0.00,'2019-09-25 21:10:20','','','0','0','0','0','','','',''),(1070000007,'','2019-09-03',NULL,'1','',NULL,'','','6','1','0','0',160.00,0.00,0.00,0.00,160.00,160.00,160.00,0.00,'2019-09-26 16:07:57','','','0','0','0','0','','','',''),(1070000008,'','',NULL,'1','',NULL,'','','6','1','0','0',60.00,0.00,0.00,0.00,60.00,60.00,60.00,0.00,'2019-10-14 05:13:16','','','0','0','0','0','','','',''),(1070000009,'','',NULL,'1','',NULL,'','','6','1','0','0',60.00,0.00,0.00,0.00,60.00,60.00,60.00,0.00,'2019-10-14 05:14:19','','','0','0','0','0','','','',''),(1070000010,'','',NULL,'1','',NULL,'','','6','1','0','0',60.00,0.00,0.00,0.00,60.00,60.00,60.00,0.00,'2019-10-14 05:15:14','','','0','0','0','0','','','',''),(1070000011,'','',NULL,'1','',NULL,'','','6','1','0','0',60.00,0.00,0.00,0.00,60.00,60.00,60.00,0.00,'2019-10-14 06:06:47','','','0','0','0','0','','','',''),(1070000012,'','',NULL,'1','',NULL,'','','6','1','0','0',60.00,0.00,0.00,0.00,60.00,60.00,60.00,0.00,'2019-10-14 06:07:11','','','0','0','0','0','','','',''),(1070000013,'','',NULL,'1','',NULL,'','','6','1','0','0',60.00,0.00,0.00,0.00,60.00,60.00,60.00,0.00,'2019-10-14 06:09:28','','','0','0','0','0','','','',''),(1070000014,'','',NULL,'1','',NULL,'','','6','1','0','0',60.00,0.00,0.00,0.00,60.00,60.00,60.00,0.00,'2019-10-14 06:12:09','','','0','0','0','0','','','',''),(1070000015,'','',NULL,'1','',NULL,'','','6','1','0','0',160.00,0.00,0.00,0.00,160.00,160.00,160.00,0.00,'2019-10-15 08:55:35','','','0','0','0','0','','','',''),(1070000016,'','',NULL,'1','',NULL,'','','6','1','0','0',225.00,0.00,0.00,0.00,225.00,225.00,225.00,0.00,'2019-10-15 09:30:01','','','0','0','0','0','','','',''),(1070000017,'','',NULL,'1','',NULL,'','','6','1','0','0',125.00,0.00,0.00,0.00,125.00,125.00,125.00,0.00,'2019-10-17 16:20:09','','','0','0','0','0','','','',''),(1070000018,'','',NULL,'1','',NULL,'','','6','1','0','0',60.00,0.00,0.00,0.00,60.00,60.00,60.00,0.00,'2019-10-17 17:02:02','','','0','0','0','0','','','',''),(1070000019,'','',NULL,'1','',NULL,'','','6','1','0','0',370.00,0.00,0.00,0.00,370.00,370.00,370.00,0.00,'2019-10-17 17:03:07','','','0','0','0','0','','','','');
/*!40000 ALTER TABLE `t_bill` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_bill_detail`
--

DROP TABLE IF EXISTS `t_bill_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `t_bill_detail` (
  `bill_detail_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `bill_id` bigint(20) DEFAULT NULL,
  `order_id` bigint(20) DEFAULT NULL,
  `lot_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_void` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `row1` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `foods_id` bigint(20) DEFAULT NULL,
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
  `date_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`bill_detail_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1080000046 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=108';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_bill_detail`
--

LOCK TABLES `t_bill_detail` WRITE;
/*!40000 ALTER TABLE `t_bill_detail` DISABLE KEYS */;
INSERT INTO `t_bill_detail` VALUES (1080000000,1070000000,1060000000,NULL,'',NULL,104000009,'',70.00,1.00,70.00,'2019-09-05 12:06:12',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000001,1070000000,1060000001,NULL,'',NULL,104000010,'',480.00,1.00,480.00,'2019-09-05 12:06:12',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000002,1070000000,1060000002,NULL,'',NULL,104000011,'',500.00,1.00,500.00,'2019-09-05 12:06:12',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000003,1070000000,1060000003,NULL,'',NULL,104000002,'',50.00,1.00,50.00,'2019-09-05 12:06:12',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000004,1070000000,1060000004,NULL,'',NULL,104000003,'',50.00,1.00,50.00,'2019-09-05 12:06:12',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000005,1070000000,1060000005,NULL,'',NULL,104000004,'',65.00,1.00,65.00,'2019-09-05 12:06:12',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000006,1070000001,1060000006,NULL,'',NULL,104000009,'',70.00,1.00,70.00,'2019-09-05 15:58:42',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000007,1070000001,1060000007,NULL,'',NULL,104000010,'',480.00,1.00,480.00,'2019-09-05 15:58:42',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000008,1070000001,1060000008,NULL,'',NULL,104000011,'',500.00,1.00,500.00,'2019-09-05 15:58:42',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000009,1070000003,1060000011,NULL,'',NULL,104000001,'',60.00,1.00,190.00,'2019-09-18 13:25:43',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000010,1070000003,1060000012,NULL,'',NULL,104000002,'',50.00,1.00,50.00,'2019-09-18 13:25:44',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000011,1070000003,1060000013,NULL,'',NULL,104000003,'',50.00,1.00,50.00,'2019-09-18 13:25:44',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000012,1070000004,1060000014,NULL,'',NULL,104000001,'',60.00,1.00,95.00,'2019-09-18 13:27:53',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000013,1070000005,1060000015,NULL,'',NULL,104000011,'',500.00,1.00,1000.00,'2019-09-18 13:31:18',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000014,1070000005,1060000016,NULL,'',NULL,104000011,'',500.00,1.00,1000.00,'2019-09-18 13:31:18',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000015,1070000005,1060000017,NULL,'',NULL,104000002,'',50.00,1.00,100.00,'2019-09-18 13:31:18',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000016,1070000006,1060000018,NULL,'',NULL,104000001,'',60.00,1.00,60.00,'2019-09-25 21:10:20',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000017,1070000006,1060000019,NULL,'',NULL,104000004,'',65.00,1.00,65.00,'2019-09-25 21:10:20',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000018,1070000006,1060000020,NULL,'',NULL,104000003,'',50.00,1.00,50.00,'2019-09-25 21:10:20',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000019,1070000006,1060000021,NULL,'',NULL,104000002,'',50.00,1.00,50.00,'2019-09-25 21:10:20',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000020,1070000007,1060000022,NULL,'',NULL,104000001,'',60.00,1.00,190.00,'2019-09-26 16:07:57',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000021,1070000007,1060000023,NULL,'',NULL,104000002,'',50.00,1.00,100.00,'2019-09-26 16:07:57',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000022,1070000007,1060000024,NULL,'',NULL,104000003,'',50.00,1.00,50.00,'2019-09-26 16:07:57',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000023,1070000008,1060000035,NULL,'',NULL,104000001,'',60.00,1.00,60.00,'2019-10-14 05:13:16',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000024,1070000009,1060000036,NULL,'',NULL,104000001,'',60.00,1.00,60.00,'2019-10-14 05:14:19',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000025,1070000010,1060000037,NULL,'',NULL,104000001,'',60.00,1.00,60.00,'2019-10-14 05:15:14',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000026,1070000011,1060000038,NULL,'',NULL,104000001,'',60.00,1.00,60.00,'2019-10-14 06:06:47',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000027,1070000012,1060000039,NULL,'',NULL,104000001,'',60.00,1.00,60.00,'2019-10-14 06:07:11',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000028,1070000013,1060000040,NULL,'',NULL,104000001,'',60.00,1.00,60.00,'2019-10-14 06:09:28',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000029,1070000014,1060000041,NULL,'',NULL,104000001,'',60.00,1.00,60.00,'2019-10-14 06:12:09',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000030,1070000015,1060000042,NULL,'',NULL,104000001,'',60.00,1.00,60.00,'2019-10-15 08:55:35',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000031,1070000015,1060000043,NULL,'',NULL,104000002,'',50.00,1.00,50.00,'2019-10-15 08:55:35',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000032,1070000015,1060000044,NULL,'',NULL,104000003,'',50.00,1.00,50.00,'2019-10-15 08:55:35',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000033,1070000016,1060000045,NULL,'',NULL,104000001,'',60.00,1.00,60.00,'2019-10-15 09:30:01',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000034,1070000016,1060000046,NULL,'',NULL,104000002,'',50.00,1.00,50.00,'2019-10-15 09:30:01',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000035,1070000016,1060000047,NULL,'',NULL,104000003,'',50.00,1.00,50.00,'2019-10-15 09:30:01',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000036,1070000016,1060000048,NULL,'',NULL,104000004,'',65.00,1.00,65.00,'2019-10-15 09:30:01',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000037,1070000017,1060000049,NULL,'',NULL,104000001,'',60.00,1.00,60.00,'2019-10-17 16:20:10',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000038,1070000017,1060000050,NULL,'',NULL,104000051,'',65.00,1.00,65.00,'2019-10-17 16:20:10',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000039,1070000018,1060000051,NULL,'',NULL,104000001,'',60.00,1.00,60.00,'2019-10-17 17:02:03',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000040,1070000019,1060000052,NULL,'',NULL,104000001,'',60.00,1.00,60.00,'2019-10-17 17:03:08',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000041,1070000019,1060000053,NULL,'',NULL,104000003,'',50.00,1.00,50.00,'2019-10-17 17:03:08',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000042,1070000019,1060000054,NULL,'',NULL,104000004,'',65.00,1.00,65.00,'2019-10-17 17:03:08',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000043,1070000019,1060000055,NULL,'',NULL,104000007,'',80.00,1.00,80.00,'2019-10-17 17:03:08',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000044,1070000019,1060000056,NULL,'',NULL,104000006,'',65.00,1.00,65.00,'2019-10-17 17:03:08',NULL,'1','','0','0',NULL,'',NULL,NULL,'0'),(1080000045,1070000019,1060000057,NULL,'',NULL,104000005,'',50.00,1.00,50.00,'2019-10-17 17:03:08',NULL,'1','','0','0',NULL,'',NULL,NULL,'0');
/*!40000 ALTER TABLE `t_bill_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_closeday`
--

DROP TABLE IF EXISTS `t_closeday`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `t_closeday` (
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
  `date_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `weather` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '0=default;1=sun;2=',
  PRIMARY KEY (`closeday_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1090000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=109';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_closeday`
--

LOCK TABLES `t_closeday` WRITE;
/*!40000 ALTER TABLE `t_closeday` DISABLE KEYS */;
/*!40000 ALTER TABLE `t_closeday` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_material_rec`
--

DROP TABLE IF EXISTS `t_material_rec`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `t_material_rec` (
  `matr_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `matr_code` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `matr_date` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
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
  `year_id` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`matr_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1450000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=145';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_material_rec`
--

LOCK TABLES `t_material_rec` WRITE;
/*!40000 ALTER TABLE `t_material_rec` DISABLE KEYS */;
/*!40000 ALTER TABLE `t_material_rec` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_material_rec_detail`
--

DROP TABLE IF EXISTS `t_material_rec_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `t_material_rec_detail` (
  `matr_detail_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `matr_id` bigint(20) DEFAULT NULL,
  `material_id` bigint(20) DEFAULT NULL,
  `row1` int(11) DEFAULT NULL,
  `price` decimal(17,4) DEFAULT NULL,
  `qty` decimal(17,4) DEFAULT NULL,
  `weight` decimal(17,4) DEFAULT NULL,
  `remark` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `sort1` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `host_id` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`matr_detail_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1460000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=146';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_material_rec_detail`
--

LOCK TABLES `t_material_rec_detail` WRITE;
/*!40000 ALTER TABLE `t_material_rec_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `t_material_rec_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_order`
--

DROP TABLE IF EXISTS `t_order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `t_order` (
  `order_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `lot_id` int(11) DEFAULT NULL,
  `row1` int(11) DEFAULT NULL,
  `foods_id` bigint(20) DEFAULT NULL,
  `foods_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `foods_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `order_date` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `price` decimal(10,0) DEFAULT NULL,
  `qty` decimal(10,0) DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `table_id` bigint(20) DEFAULT NULL,
  `res_id` bigint(20) DEFAULT NULL,
  `area_id` bigint(20) DEFAULT NULL,
  `status_foods_1` varchar(55) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_foods_2` varchar(55) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_foods_3` varchar(55) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_bill` varchar(55) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '0=default,1=bill check ,2=check complete',
  `bill_check_date` varchar(55) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_cook` varchar(55) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '0=default,1=cook receive,2=cook finish',
  `cook_receive_date` varchar(55) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `cook_finish_date` varchar(55) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(55) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `void_date` varchar(55) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_void` varchar(55) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `printer_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_to_go` varchar(55) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '0=default,1=in restaurant,2=to go',
  `bill_id` int(11) DEFAULT NULL,
  `order_user` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_closeday` varchar(55) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `closeday_id` bigint(20) DEFAULT NULL,
  `host_id` varchar(55) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(55) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(55) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(55) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(55) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `cnt_cust` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `year_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `month_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `day_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `hour_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`order_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1060000058 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=106';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_order`
--

LOCK TABLES `t_order` WRITE;
/*!40000 ALTER TABLE `t_order` DISABLE KEYS */;
INSERT INTO `t_order` VALUES (1060000000,0,1,NULL,'',NULL,'2019-09-05 12:06:07',70,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-09-05 12:06:07','','','','','','',NULL,NULL,NULL,NULL),(1060000001,0,2,NULL,'',NULL,'2019-09-05 12:06:07',480,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-09-05 12:06:07','','','','','','',NULL,NULL,NULL,NULL),(1060000002,0,3,NULL,'',NULL,'2019-09-05 12:06:07',500,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-09-05 12:06:07','','','','','','',NULL,NULL,NULL,NULL),(1060000003,0,4,NULL,'',NULL,'2019-09-05 12:06:07',50,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-09-05 12:06:07','','','','','','',NULL,NULL,NULL,NULL),(1060000004,0,5,NULL,'',NULL,'2019-09-05 12:06:07',50,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-09-05 12:06:07','','','','','','',NULL,NULL,NULL,NULL),(1060000005,0,6,NULL,'',NULL,'2019-09-05 12:06:07',65,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-09-05 12:06:07','','','','','','',NULL,NULL,NULL,NULL),(1060000006,0,1,NULL,'',NULL,'2019-09-05 15:58:37',70,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-09-05 15:58:37','','','','','','',NULL,NULL,NULL,NULL),(1060000007,0,2,NULL,'',NULL,'2019-09-05 15:58:37',480,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-09-05 15:58:37','','','','','','',NULL,NULL,NULL,NULL),(1060000008,0,3,NULL,'',NULL,'2019-09-05 15:58:37',500,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-09-05 15:58:37','','','','','','',NULL,NULL,NULL,NULL),(1060000009,0,4,NULL,'',NULL,'2019-09-05 15:58:37',95,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-09-05 15:58:37','','','','','','',NULL,NULL,NULL,NULL),(1060000010,0,1,NULL,'',NULL,'2019-09-05 16:25:23',60,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-09-05 16:25:23','','','','','','',NULL,NULL,NULL,NULL),(1060000011,0,1,NULL,'',NULL,'2019-09-18 13:25:38',60,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-09-18 13:25:38','','','','','','',NULL,NULL,NULL,NULL),(1060000012,0,2,NULL,'',NULL,'2019-09-18 13:25:39',50,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-09-18 13:25:39','','','','','','',NULL,NULL,NULL,NULL),(1060000013,0,3,NULL,'',NULL,'2019-09-18 13:25:39',50,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-09-18 13:25:39','','','','','','',NULL,NULL,NULL,NULL),(1060000014,0,1,NULL,'',NULL,'2019-09-18 13:27:48',60,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-09-18 13:27:48','','','','','','',NULL,NULL,NULL,NULL),(1060000015,0,1,NULL,'',NULL,'2019-09-18 13:31:12',500,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-09-18 13:31:12','','','','','','',NULL,NULL,NULL,NULL),(1060000016,0,2,NULL,'',NULL,'2019-09-18 13:31:13',500,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-09-18 13:31:13','','','','','','',NULL,NULL,NULL,NULL),(1060000017,0,3,NULL,'',NULL,'2019-09-18 13:31:13',50,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-09-18 13:31:13','','','','','','',NULL,NULL,NULL,NULL),(1060000018,0,1,NULL,'',NULL,'2019-09-25 21:10:14',60,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-09-25 21:10:14','','','','','','',NULL,NULL,NULL,NULL),(1060000019,0,2,NULL,'',NULL,'2019-09-25 21:10:15',65,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-09-25 21:10:15','','','','','','',NULL,NULL,NULL,NULL),(1060000020,0,3,NULL,'',NULL,'2019-09-25 21:10:15',50,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-09-25 21:10:15','','','','','','',NULL,NULL,NULL,NULL),(1060000021,0,4,NULL,'',NULL,'2019-09-25 21:10:15',50,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-09-25 21:10:15','','','','','','',NULL,NULL,NULL,NULL),(1060000022,0,1,NULL,'',NULL,'2019-09-26 16:07:52',60,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-09-26 16:07:52','','','','','','',NULL,NULL,NULL,NULL),(1060000023,0,2,NULL,'',NULL,'2019-09-26 16:07:52',50,NULL,'',6,1,0,'','','','0','','','','','1','','','POS80 PRO','',0,'','',0,'0','0','0','2019-09-26 16:07:52','','','','','','',NULL,NULL,NULL,NULL),(1060000024,0,3,NULL,'',NULL,'2019-09-26 16:07:52',50,NULL,'',6,1,0,'','','','0','','','','','1','','','POS80 PRO','',0,'','',0,'0','0','0','2019-09-26 16:07:52','','','','','','',NULL,NULL,NULL,NULL),(1060000025,0,1,NULL,'',NULL,'2019-09-26 16:54:35',60,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-09-26 16:54:35','','','','','','',NULL,NULL,NULL,NULL),(1060000026,0,1,NULL,'',NULL,'',60,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-10-09 09:08:38','2019-10-09 09:46:45','','','','','',NULL,NULL,NULL,NULL),(1060000027,0,2,NULL,'',NULL,'',60,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-10-09 09:08:39','2019-10-09 09:46:46','','','','','',NULL,NULL,NULL,NULL),(1060000028,0,3,NULL,'',NULL,'',50,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-10-09 09:08:39','2019-10-09 09:46:46','','','','','',NULL,NULL,NULL,NULL),(1060000029,0,4,NULL,'',NULL,'',60,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-10-09 09:08:39','2019-10-09 09:46:46','','','','','',NULL,NULL,NULL,NULL),(1060000030,0,5,NULL,'',NULL,'',60,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-10-09 09:08:39','2019-10-09 09:46:46','','','','','',NULL,NULL,NULL,NULL),(1060000031,0,6,NULL,'',NULL,'',60,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-10-09 09:08:39','2019-10-09 09:46:46','','','','','',NULL,NULL,NULL,NULL),(1060000032,0,7,NULL,'',NULL,'',60,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-10-09 09:08:39','2019-10-09 09:46:46','','','','','',NULL,NULL,NULL,NULL),(1060000033,0,1,NULL,'',NULL,'2019-10-09 17:11:49',50,NULL,'',6,1,0,'','','','0','','','','','1','','','POS80 PRO','',0,'','',0,'0','0','0','2019-10-09 17:11:49','','','','','','',NULL,NULL,NULL,NULL),(1060000034,0,2,NULL,'',NULL,'2019-10-09 17:11:49',65,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-10-09 17:11:49','','','','','','',NULL,NULL,NULL,NULL),(1060000035,0,1,104000001,'','เส้นเล็กต้มยำ','2019-10-14 05:13:11',60,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-10-14 05:13:11','','','','','','',NULL,NULL,NULL,NULL),(1060000036,5,1,104000001,'','เส้นเล็กต้มยำ','2019-10-14 05:14:14',60,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-10-14 05:14:14','','','','','','',NULL,NULL,NULL,NULL),(1060000037,6,1,104000001,'','เส้นเล็กต้มยำ','2019-10-14 05:15:09',60,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-10-14 05:15:09','','','','','','',NULL,NULL,NULL,NULL),(1060000038,7,1,104000001,'','เส้นเล็กต้มยำ','2019-10-14 06:06:42',60,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-10-14 06:06:42','','','','','','',NULL,NULL,NULL,NULL),(1060000039,8,1,104000001,'','เส้นเล็กต้มยำ','2019-10-14 06:07:06',60,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-10-14 06:07:06','','','','','','',NULL,NULL,NULL,NULL),(1060000040,9,1,104000001,'','เส้นเล็กต้มยำ','2019-10-14 06:09:23',60,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-10-14 06:09:23','','','','','','',NULL,NULL,NULL,NULL),(1060000041,10,1,104000001,'','เส้นเล็กต้มยำ','2019-10-14 06:12:04',60,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-10-14 06:12:04','','','','','','',NULL,NULL,NULL,NULL),(1060000042,11,1,104000001,'','เส้นเล็กต้มยำ','2019-10-15 08:55:30',60,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-10-15 08:55:30','','','','','','',NULL,NULL,NULL,NULL),(1060000043,11,2,104000002,'','ข้าวหน้าเป็ดย่าง','2019-10-15 08:55:30',50,NULL,'',6,1,0,'','','','0','','','','','1','','','POS80 PRO','',0,'','',0,'0','0','0','2019-10-15 08:55:30','','','','','','',NULL,NULL,NULL,NULL),(1060000044,11,3,104000003,'','ข้าวหมูแดง','2019-10-15 08:55:30',50,NULL,'',6,1,0,'','','','0','','','','','1','','','POS80 PRO','',0,'','',0,'0','0','0','2019-10-15 08:55:30','','','','','','',NULL,NULL,NULL,NULL),(1060000045,12,1,104000001,'','เส้นเล็กต้มยำ','2019-10-15 09:29:56',60,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-10-15 09:29:56','','','','','','',NULL,NULL,NULL,NULL),(1060000046,12,2,104000002,'','ข้าวหน้าเป็ดย่าง','2019-10-15 09:29:56',50,NULL,'',6,1,0,'','','','0','','','','','1','','','POS80 PRO','',0,'','',0,'0','0','0','2019-10-15 09:29:56','','','','','','',NULL,NULL,NULL,NULL),(1060000047,12,3,104000003,'','ข้าวหมูแดง','2019-10-15 09:29:56',50,NULL,'',6,1,0,'','','','0','','','','','1','','','POS80 PRO','',0,'','',0,'0','0','0','2019-10-15 09:29:56','','','','','','',NULL,NULL,NULL,NULL),(1060000048,12,4,104000004,'','ข้าวหน้าเป็ดย่างปนหมูกรอบ','2019-10-15 09:29:56',65,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-10-15 09:29:56','','','','','','',NULL,NULL,NULL,NULL),(1060000049,13,12,104000001,'','เส้นเล็กต้มยำ','2019-10-17 16:20:04',60,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-10-17 16:20:04','','','','','','',NULL,NULL,NULL,NULL),(1060000050,13,13,104000051,'','ก๋วยเตี๋ยวพริกสดลูกชิ้นปลา+เนื้อปลา','2019-10-17 16:20:05',65,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-10-17 16:20:05','','','','','','',NULL,NULL,NULL,NULL),(1060000051,14,1,104000001,'','เส้นเล็กต้มยำ','2019-10-17 17:01:57',60,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-10-17 17:01:57','','','','','','',NULL,NULL,NULL,NULL),(1060000052,15,1,104000001,'','เส้นเล็กต้มยำ','2019-10-17 17:03:02',60,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-10-17 17:03:02','','','','','','',NULL,NULL,NULL,NULL),(1060000053,15,2,104000003,'','ข้าวหมูแดง','2019-10-17 17:03:03',50,NULL,'',6,1,0,'','','','0','','','','','1','','','POS80 PRO','',0,'','',0,'0','0','0','2019-10-17 17:03:03','','','','','','',NULL,NULL,NULL,NULL),(1060000054,15,3,104000004,'','ข้าวหน้าเป็ดย่างปนหมูกรอบ','2019-10-17 17:03:03',65,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-10-17 17:03:03','','','','','','',NULL,NULL,NULL,NULL),(1060000055,15,4,104000007,'','ข้าวหน้าเป็ด+หมูแดง+หมูกรอบ','2019-10-17 17:03:03',80,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-10-17 17:03:03','','','','','','',NULL,NULL,NULL,NULL),(1060000056,15,5,104000006,'','ข้าวหน้าไก่+หมูกรอบ','2019-10-17 17:03:03',65,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-10-17 17:03:03','','','','','','',NULL,NULL,NULL,NULL),(1060000057,15,6,104000005,'','ข้าวหน้าไก่เห็ดหอม','2019-10-17 17:03:03',50,NULL,'',6,1,0,'','','','0','','','','','1','','','BIXOLON SRP-330II','',0,'','',0,'0','0','0','2019-10-17 17:03:03','','','','','','',NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `t_order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_order_material`
--

DROP TABLE IF EXISTS `t_order_material`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `t_order_material` (
  `order_material_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `material_id` bigint(20) DEFAULT NULL,
  `foods_id` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `order_id` bigint(20) DEFAULT NULL,
  `foods_material_id` bigint(20) DEFAULT NULL,
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
  `qty` decimal(17,4) DEFAULT NULL,
  `year_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `month_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `day_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `hour_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`order_material_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1430000130 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=143';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_order_material`
--

LOCK TABLES `t_order_material` WRITE;
/*!40000 ALTER TABLE `t_order_material` DISABLE KEYS */;
INSERT INTO `t_order_material` VALUES (1430000016,1400000000,'104000001',NULL,1410000000,'เส้นใหญ่',NULL,5.00,0.0000,NULL,'6','2019-10-14 06:05:47',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000017,2,'104000001',NULL,47,'เส้นเล็ก',NULL,5.00,200.0000,NULL,'6','2019-10-14 06:05:47',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000018,12,'104000001',NULL,49,'Cooking 1',NULL,5.00,1.0000,NULL,'6','2019-10-14 06:05:47',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000019,13,'104000001',NULL,50,'เนื้อหมูชิ้น',NULL,10.00,0.1000,NULL,'6','2019-10-14 06:05:47',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000020,10,'104000001',NULL,51,'ผักใส่ในชาม',NULL,2.00,0.0100,NULL,'6','2019-10-14 06:05:47',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000021,16,'104000001',NULL,52,'เครื่องปรุงต่างๆ ที่โต๊ะทาน',NULL,5.00,1.0000,NULL,'6','2019-10-14 06:05:47',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000022,15,'104000001',NULL,53,'เครื่องปรุงต่างในครัว',NULL,5.00,1.0000,NULL,'6','2019-10-14 06:05:47',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000023,14,'104000001',NULL,54,'res service',NULL,5.00,1.0000,NULL,'6','2019-10-14 06:05:47',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000024,14,'104000001',NULL,54,'res service',NULL,5.00,1.0000,NULL,'6','2019-10-14 06:05:47',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000025,1400000000,'104000001',NULL,1410000000,'เส้นใหญ่',NULL,5.00,0.0000,NULL,'9','2019-10-14 06:09:23',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000026,2,'104000001',NULL,47,'เส้นเล็ก',NULL,5.00,200.0000,NULL,'9','2019-10-14 06:09:23',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000027,12,'104000001',NULL,49,'Cooking 1',NULL,5.00,1.0000,NULL,'9','2019-10-14 06:09:23',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000028,13,'104000001',NULL,50,'เนื้อหมูชิ้น',NULL,10.00,0.1000,NULL,'9','2019-10-14 06:09:23',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000029,10,'104000001',NULL,51,'ผักใส่ในชาม',NULL,2.00,0.0100,NULL,'9','2019-10-14 06:09:23',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000030,16,'104000001',NULL,52,'เครื่องปรุงต่างๆ ที่โต๊ะทาน',NULL,5.00,1.0000,NULL,'9','2019-10-14 06:09:23',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000031,15,'104000001',NULL,53,'เครื่องปรุงต่างในครัว',NULL,5.00,1.0000,NULL,'9','2019-10-14 06:09:23',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000032,14,'104000001',NULL,54,'res service',NULL,5.00,1.0000,NULL,'9','2019-10-14 06:09:23',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000033,14,'104000001',NULL,54,'res service',NULL,5.00,1.0000,NULL,'9','2019-10-14 06:09:23',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000034,1400000000,'104000001',1060000041,1410000000,'เส้นใหญ่',NULL,5.00,0.0000,NULL,'10','2019-10-14 06:12:04',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000035,2,'104000001',1060000041,47,'เส้นเล็ก',NULL,5.00,200.0000,NULL,'10','2019-10-14 06:12:04',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000036,12,'104000001',1060000041,49,'Cooking 1',NULL,5.00,1.0000,NULL,'10','2019-10-14 06:12:04',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000037,13,'104000001',1060000041,50,'เนื้อหมูชิ้น',NULL,10.00,0.1000,NULL,'10','2019-10-14 06:12:04',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000038,10,'104000001',1060000041,51,'ผักใส่ในชาม',NULL,2.00,0.0100,NULL,'10','2019-10-14 06:12:04',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000039,16,'104000001',1060000041,52,'เครื่องปรุงต่างๆ ที่โต๊ะทาน',NULL,5.00,1.0000,NULL,'10','2019-10-14 06:12:04',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000040,15,'104000001',1060000041,53,'เครื่องปรุงต่างในครัว',NULL,5.00,1.0000,NULL,'10','2019-10-14 06:12:04',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000041,14,'104000001',1060000041,54,'res service',NULL,5.00,1.0000,NULL,'10','2019-10-14 06:12:04',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000042,14,'104000001',1060000041,54,'res service',NULL,5.00,1.0000,NULL,'10','2019-10-14 06:12:04',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000043,1400000000,'104000001',1060000042,1410000000,'เส้นใหญ่',NULL,5.00,0.0000,NULL,'11','2019-10-15 08:55:30',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000044,2,'104000001',1060000042,47,'เส้นเล็ก',NULL,5.00,200.0000,NULL,'11','2019-10-15 08:55:30',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000045,12,'104000001',1060000042,49,'Cooking 1',NULL,5.00,1.0000,NULL,'11','2019-10-15 08:55:30',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000046,13,'104000001',1060000042,50,'เนื้อหมูชิ้น',NULL,10.00,0.1000,NULL,'11','2019-10-15 08:55:30',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000047,10,'104000001',1060000042,51,'ผักใส่ในชาม',NULL,2.00,0.0100,NULL,'11','2019-10-15 08:55:30',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000048,16,'104000001',1060000042,52,'เครื่องปรุงต่างๆ ที่โต๊ะทาน',NULL,5.00,1.0000,NULL,'11','2019-10-15 08:55:30',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000049,15,'104000001',1060000042,53,'เครื่องปรุงต่างในครัว',NULL,5.00,1.0000,NULL,'11','2019-10-15 08:55:30',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000050,14,'104000001',1060000042,54,'res service',NULL,5.00,1.0000,NULL,'11','2019-10-15 08:55:30',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000051,19,'104000002',1060000043,61,'ข้าวเปล่าเป็นจาน',NULL,7.00,0.3000,NULL,'11','2019-10-15 08:55:30',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000052,24,'104000002',1060000043,62,'ผักกวางตุ้งลวก',NULL,3.00,0.2000,NULL,'11','2019-10-15 08:55:30',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000053,22,'104000002',1060000043,63,'เนื้อเป็ด',NULL,15.00,0.2000,NULL,'11','2019-10-15 08:55:30',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000054,18,'104000002',1060000043,64,'ขิงดองใส่ข้าวหน้าเป็ด',NULL,3.00,0.1000,NULL,'11','2019-10-15 08:55:30',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000055,12,'104000002',1060000043,65,'Cooking 1',NULL,5.00,1.0000,NULL,'11','2019-10-15 08:55:30',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000056,14,'104000002',1060000043,66,'res service',NULL,5.00,1.0000,NULL,'11','2019-10-15 08:55:30',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000057,15,'104000002',1060000043,67,'เครื่องปรุงต่างในครัว',NULL,5.00,1.0000,NULL,'11','2019-10-15 08:55:30',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000058,19,'104000003',1060000044,68,'ข้าวเปล่าเป็นจาน',NULL,7.00,0.3000,NULL,'11','2019-10-15 08:55:30',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000059,12,'104000003',1060000044,69,'Cooking 1',NULL,5.00,1.0000,NULL,'11','2019-10-15 08:55:30',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000060,14,'104000003',1060000044,70,'res service',NULL,5.00,1.0000,NULL,'11','2019-10-15 08:55:30',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000061,27,'104000003',1060000044,71,'ไข่ต้ม ครึ่งใบ',NULL,5.00,0.2000,NULL,'11','2019-10-15 08:55:30',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000062,28,'104000003',1060000044,72,'แตงกวา ประกอบในจาน',NULL,3.00,0.2000,NULL,'11','2019-10-15 08:55:30',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000063,29,'104000003',1060000044,73,'หมูแดง',NULL,15.00,0.2000,NULL,'11','2019-10-15 08:55:30',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000064,29,'104000003',1060000044,73,'หมูแดง',NULL,15.00,0.2000,NULL,'11','2019-10-15 08:55:30',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000065,1400000000,'104000001',1060000045,1410000000,'เส้นใหญ่',NULL,5.00,0.0000,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000066,2,'104000001',1060000045,47,'เส้นเล็ก',NULL,5.00,200.0000,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000067,12,'104000001',1060000045,49,'Cooking 1',NULL,5.00,1.0000,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000068,13,'104000001',1060000045,50,'เนื้อหมูชิ้น',NULL,10.00,0.1000,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000069,10,'104000001',1060000045,51,'ผักใส่ในชาม',NULL,2.00,0.0100,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000070,16,'104000001',1060000045,52,'เครื่องปรุงต่างๆ ที่โต๊ะทาน',NULL,5.00,1.0000,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000071,15,'104000001',1060000045,53,'เครื่องปรุงต่างในครัว',NULL,5.00,1.0000,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000072,14,'104000001',1060000045,54,'res service',NULL,5.00,1.0000,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000073,19,'104000002',1060000046,61,'ข้าวเปล่าเป็นจาน',NULL,7.00,0.3000,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000074,24,'104000002',1060000046,62,'ผักกวางตุ้งลวก',NULL,3.00,0.2000,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000075,22,'104000002',1060000046,63,'เนื้อเป็ด',NULL,15.00,0.2000,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000076,18,'104000002',1060000046,64,'ขิงดองใส่ข้าวหน้าเป็ด',NULL,3.00,0.1000,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000077,12,'104000002',1060000046,65,'Cooking 1',NULL,5.00,1.0000,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000078,14,'104000002',1060000046,66,'res service',NULL,5.00,1.0000,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000079,15,'104000002',1060000046,67,'เครื่องปรุงต่างในครัว',NULL,5.00,1.0000,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000080,19,'104000003',1060000047,68,'ข้าวเปล่าเป็นจาน',NULL,7.00,0.3000,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000081,12,'104000003',1060000047,69,'Cooking 1',NULL,5.00,1.0000,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000082,14,'104000003',1060000047,70,'res service',NULL,5.00,1.0000,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000083,27,'104000003',1060000047,71,'ไข่ต้ม ครึ่งใบ',NULL,5.00,0.2000,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000084,28,'104000003',1060000047,72,'แตงกวา ประกอบในจาน',NULL,3.00,0.2000,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000085,29,'104000003',1060000047,73,'หมูแดง',NULL,15.00,0.2000,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000086,19,'104000004',1060000048,1410000075,'ข้าวเปล่าเป็นจาน',NULL,7.00,0.3000,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000087,1400000031,'104000004',1060000048,1410000076,'หมูกรอบใส่จาน',NULL,10.00,0.2000,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000088,12,'104000004',1060000048,1410000077,'Cooking 1',NULL,5.00,1.0000,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000089,14,'104000004',1060000048,1410000078,'res service',NULL,5.00,1.0000,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000090,28,'104000004',1060000048,1410000079,'แตงกวา ประกอบในจาน',NULL,3.00,0.2000,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000091,28,'104000004',1060000048,1410000079,'แตงกวา ประกอบในจาน',NULL,3.00,0.2000,NULL,'12','2019-10-15 09:29:56',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000092,1400000000,'104000001',1060000049,1410000000,'เส้นใหญ่',NULL,5.00,0.0000,NULL,'13','2019-10-17 16:20:05',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000093,2,'104000001',1060000049,47,'เส้นเล็ก',NULL,5.00,200.0000,NULL,'13','2019-10-17 16:20:05',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000094,12,'104000001',1060000049,49,'Cooking 1',NULL,5.00,1.0000,NULL,'13','2019-10-17 16:20:05',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000095,13,'104000001',1060000049,50,'เนื้อหมูชิ้น',NULL,10.00,0.1000,NULL,'13','2019-10-17 16:20:05',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000096,10,'104000001',1060000049,51,'ผักใส่ในชาม',NULL,2.00,0.0100,NULL,'13','2019-10-17 16:20:05',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000097,16,'104000001',1060000049,52,'เครื่องปรุงต่างๆ ที่โต๊ะทาน',NULL,5.00,1.0000,NULL,'13','2019-10-17 16:20:05',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000098,15,'104000001',1060000049,53,'เครื่องปรุงต่างในครัว',NULL,5.00,1.0000,NULL,'13','2019-10-17 16:20:05',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000099,14,'104000001',1060000049,54,'res service',NULL,5.00,1.0000,NULL,'13','2019-10-17 16:20:05',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000100,14,'104000001',1060000049,54,'res service',NULL,5.00,1.0000,NULL,'13','2019-10-17 16:20:05',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000101,1400000000,'104000001',1060000051,1410000000,'เส้นใหญ่',NULL,5.00,0.0000,NULL,'14','2019-10-17 17:01:58',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000102,2,'104000001',1060000051,47,'เส้นเล็ก',NULL,5.00,200.0000,NULL,'14','2019-10-17 17:01:58',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000103,12,'104000001',1060000051,49,'Cooking 1',NULL,5.00,1.0000,NULL,'14','2019-10-17 17:01:58',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000104,13,'104000001',1060000051,50,'เนื้อหมูชิ้น',NULL,10.00,0.1000,NULL,'14','2019-10-17 17:01:58',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000105,10,'104000001',1060000051,51,'ผักใส่ในชาม',NULL,2.00,0.0100,NULL,'14','2019-10-17 17:01:58',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000106,16,'104000001',1060000051,52,'เครื่องปรุงต่างๆ ที่โต๊ะทาน',NULL,5.00,1.0000,NULL,'14','2019-10-17 17:01:58',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000107,15,'104000001',1060000051,53,'เครื่องปรุงต่างในครัว',NULL,5.00,1.0000,NULL,'14','2019-10-17 17:01:58',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000108,14,'104000001',1060000051,54,'res service',NULL,5.00,1.0000,NULL,'14','2019-10-17 17:01:58',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000109,14,'104000001',1060000051,54,'res service',NULL,5.00,1.0000,NULL,'14','2019-10-17 17:01:58',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000110,1400000000,'104000001',1060000052,1410000000,'เส้นใหญ่',NULL,5.00,0.0000,NULL,'15','2019-10-17 17:03:03',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000111,2,'104000001',1060000052,47,'เส้นเล็ก',NULL,5.00,200.0000,NULL,'15','2019-10-17 17:03:03',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000112,12,'104000001',1060000052,49,'Cooking 1',NULL,5.00,1.0000,NULL,'15','2019-10-17 17:03:03',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000113,13,'104000001',1060000052,50,'เนื้อหมูชิ้น',NULL,10.00,0.1000,NULL,'15','2019-10-17 17:03:03',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000114,10,'104000001',1060000052,51,'ผักใส่ในชาม',NULL,2.00,0.0100,NULL,'15','2019-10-17 17:03:03',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000115,16,'104000001',1060000052,52,'เครื่องปรุงต่างๆ ที่โต๊ะทาน',NULL,5.00,1.0000,NULL,'15','2019-10-17 17:03:03',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000116,15,'104000001',1060000052,53,'เครื่องปรุงต่างในครัว',NULL,5.00,1.0000,NULL,'15','2019-10-17 17:03:03',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000117,14,'104000001',1060000052,54,'res service',NULL,5.00,1.0000,NULL,'15','2019-10-17 17:03:03',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000118,19,'104000003',1060000053,68,'ข้าวเปล่าเป็นจาน',NULL,7.00,0.3000,NULL,'15','2019-10-17 17:03:03',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000119,12,'104000003',1060000053,69,'Cooking 1',NULL,5.00,1.0000,NULL,'15','2019-10-17 17:03:03',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000120,14,'104000003',1060000053,70,'res service',NULL,5.00,1.0000,NULL,'15','2019-10-17 17:03:03',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000121,27,'104000003',1060000053,71,'ไข่ต้ม ครึ่งใบ',NULL,5.00,0.2000,NULL,'15','2019-10-17 17:03:03',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000122,28,'104000003',1060000053,72,'แตงกวา ประกอบในจาน',NULL,3.00,0.2000,NULL,'15','2019-10-17 17:03:03',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000123,29,'104000003',1060000053,73,'หมูแดง',NULL,15.00,0.2000,NULL,'15','2019-10-17 17:03:03',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000124,19,'104000004',1060000054,1410000075,'ข้าวเปล่าเป็นจาน',NULL,7.00,0.3000,NULL,'15','2019-10-17 17:03:03',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000125,1400000031,'104000004',1060000054,1410000076,'หมูกรอบใส่จาน',NULL,10.00,0.2000,NULL,'15','2019-10-17 17:03:03',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000126,12,'104000004',1060000054,1410000077,'Cooking 1',NULL,5.00,1.0000,NULL,'15','2019-10-17 17:03:03',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000127,14,'104000004',1060000054,1410000078,'res service',NULL,5.00,1.0000,NULL,'15','2019-10-17 17:03:03',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000128,28,'104000004',1060000054,1410000079,'แตงกวา ประกอบในจาน',NULL,3.00,0.2000,NULL,'15','2019-10-17 17:03:03',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL),(1430000129,28,'104000004',1060000054,1410000079,'แตงกวา ประกอบในจาน',NULL,3.00,0.2000,NULL,'15','2019-10-17 17:03:03',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1.0000,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `t_order_material` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_order_special`
--

DROP TABLE IF EXISTS `t_order_special`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `t_order_special` (
  `order_special_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `order_id` bigint(20) DEFAULT NULL,
  `foods_spec_id` bigint(20) DEFAULT NULL,
  `active` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `row1` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `host_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`order_special_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1310000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=132';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_order_special`
--

LOCK TABLES `t_order_special` WRITE;
/*!40000 ALTER TABLE `t_order_special` DISABLE KEYS */;
/*!40000 ALTER TABLE `t_order_special` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_order_topping`
--

DROP TABLE IF EXISTS `t_order_topping`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `t_order_topping` (
  `order_topping_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `order_id` bigint(20) DEFAULT NULL,
  `foods_topping_id` bigint(20) DEFAULT NULL,
  `active` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `row1` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `host_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `branch_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `qty` decimal(17,2) DEFAULT '0.00',
  `price` decimal(17,2) DEFAULT '0.00',
  PRIMARY KEY (`order_topping_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1320000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=131';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_order_topping`
--

LOCK TABLES `t_order_topping` WRITE;
/*!40000 ALTER TABLE `t_order_topping` DISABLE KEYS */;
/*!40000 ALTER TABLE `t_order_topping` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vne_close_day`
--

DROP TABLE IF EXISTS `vne_close_day`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `vne_close_day` (
  `close_day_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `close_day_date` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `req_status` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date1` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_start` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `total_in` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `total_out` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `total_payments` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `total_operator_in` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `total_operaor_out` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `total_content` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
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
  `request_payment_id` bigint(20) NOT NULL AUTO_INCREMENT,
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
  `response_payemnt_id` bigint(20) NOT NULL AUTO_INCREMENT,
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

--
-- Table structure for table `vne_response_payment`
--

DROP TABLE IF EXISTS `vne_response_payment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `vne_response_payment` (
  `response_payemnt_id` bigint(20) NOT NULL AUTO_INCREMENT,
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
) ENGINE=MyISAM AUTO_INCREMENT=204 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vne_response_payment`
--

LOCK TABLES `vne_response_payment` WRITE;
/*!40000 ALTER TABLE `vne_response_payment` DISABLE KEYS */;
INSERT INTO `vne_response_payment` VALUES (1,'1544051528142','2000','1','2000','1',NULL,'2018-12-06 06:12:09',NULL,NULL,'admin',NULL,NULL),(2,'1544062108143','2000','1','2000','1',NULL,'2018-12-06 09:08:31',NULL,NULL,'admin',NULL,NULL),(3,'1544062144144','2000','1','2000','1',NULL,'2018-12-06 09:09:06',NULL,NULL,'admin',NULL,NULL),(4,'1544062244145','2000','1','2000','1',NULL,'2018-12-06 09:10:46',NULL,NULL,'admin',NULL,NULL),(5,'1544062349146','1000','1','1000','1',NULL,'2018-12-06 09:12:30',NULL,NULL,'admin',NULL,NULL),(6,'1544062636147','1200','1','1200','1',NULL,'2018-12-06 09:17:17',NULL,NULL,'admin',NULL,NULL),(7,'1544062713148','12000','1','12000','1',NULL,'2018-12-06 09:18:35',NULL,NULL,'admin',NULL,NULL),(8,'1544062810149','1200','1','1200','1',NULL,'2018-12-06 09:20:11',NULL,NULL,'admin',NULL,NULL),(9,'1544063901150','200','1','200','1',NULL,'2018-12-06 09:38:23',NULL,NULL,'admin',NULL,NULL),(10,'1544064144151','20000','1','20000','1',NULL,'2018-12-06 09:42:26',NULL,NULL,'admin',NULL,NULL),(11,'1544141069152','1200','1','1200','1',NULL,'2018-12-07 07:04:32',NULL,NULL,'admin',NULL,NULL),(12,'1544141080153','1300','1','1300','1',NULL,'2018-12-07 07:04:41',NULL,NULL,'admin',NULL,NULL),(13,'1544146531154','1400','1','1400','1',NULL,'2018-12-07 08:35:34',NULL,NULL,'admin',NULL,NULL),(14,'1544146750155','1500','1','1500','1',NULL,'2018-12-07 08:39:13',NULL,NULL,'admin',NULL,NULL),(15,'1544148300156','1600','1','1600','1',NULL,'2018-12-07 09:05:02',NULL,NULL,'admin',NULL,NULL),(16,'1544148480157','1700','1','1700','1',NULL,'2018-12-07 09:08:02',NULL,NULL,'admin',NULL,NULL),(17,'1544151715158','200','1','200','1',NULL,'2018-12-07 10:01:59',NULL,NULL,'admin',NULL,NULL),(18,'1544270440159','100000','1','100000','1',NULL,'2018-12-08 19:00:43',NULL,NULL,'admin',NULL,NULL),(19,'1544270460160','110000','1','110000','1',NULL,'2018-12-08 19:01:02',NULL,NULL,'admin',NULL,NULL),(20,'1544270477161','120000','1','120000','1',NULL,'2018-12-08 19:01:19',NULL,NULL,'admin',NULL,NULL),(21,'','','','','1',NULL,'2018-12-11 09:29:58',NULL,NULL,'admin',NULL,NULL),(22,'1544495665162','20','1','20','1',NULL,'2018-12-11 09:34:28',NULL,NULL,'admin',NULL,NULL),(23,'1544495693163','2000','1','2000','1',NULL,'2018-12-11 09:34:56',NULL,NULL,'admin',NULL,NULL),(24,'1544495717164','2000','1','2000','1',NULL,'2018-12-11 09:35:20',NULL,NULL,'admin',NULL,NULL),(25,'1544495724165','2000','1','2000','1',NULL,'2018-12-11 09:35:26',NULL,NULL,'admin',NULL,NULL),(26,'1544496813166','2000','1','2000','1',NULL,'2018-12-11 09:53:36',NULL,NULL,'admin',NULL,NULL),(27,'1544499811167','200000','1','200000','1',NULL,'2018-12-11 10:43:33',NULL,NULL,'admin',NULL,NULL),(28,'1544500132168','130000','1','130000','1',NULL,'2018-12-11 10:48:55',NULL,NULL,'admin',NULL,NULL),(29,'1544510075169','140000','1','140000','1',NULL,'2018-12-11 13:34:38',NULL,NULL,'admin',NULL,NULL),(30,'1544510371170','150000','1','150000','1',NULL,'2018-12-11 13:39:34',NULL,NULL,'admin',NULL,NULL),(31,'1544510723171','160000','1','160000','1',NULL,'2018-12-11 13:45:26',NULL,NULL,'admin',NULL,NULL),(32,'1544511621172','191200','1','191200','1',NULL,'2018-12-11 14:00:25',NULL,NULL,'admin',NULL,NULL),(33,'1544515601176','211200','1','211200','1',NULL,'2018-12-11 15:06:44',NULL,NULL,'admin',NULL,NULL),(34,'1544845017177','123400','1','123400','1',NULL,'2018-12-15 10:37:05',NULL,NULL,'admin',NULL,NULL),(35,'1544845493178','123000','1','123000','1',NULL,'2018-12-15 10:44:58',NULL,NULL,'admin',NULL,NULL),(36,'1544845544179','169900','1','169900','1',NULL,'2018-12-15 10:45:49',NULL,NULL,'admin',NULL,NULL),(37,'1544845640180','2000','1','2000','1',NULL,'2018-12-15 10:47:24',NULL,NULL,'admin',NULL,NULL),(38,'1545026746186','123000','1','123000','1',NULL,'2018-12-17 13:05:52',NULL,NULL,'admin',NULL,NULL),(39,'1545027217187','123000','1','123000','1',NULL,'2018-12-17 13:13:43',NULL,NULL,'admin',NULL,NULL),(40,'1545027268188','123000','1','123000','1',NULL,'2018-12-17 13:14:52',NULL,NULL,'admin',NULL,NULL),(41,'1545029511189','123000','1','123000','1',NULL,'2018-12-17 13:51:56',NULL,NULL,'admin',NULL,NULL),(42,'1545029671190','1230000','1','1230000','1',NULL,'2018-12-17 13:54:36',NULL,NULL,'admin',NULL,NULL),(43,'1545030307191','500','1','500','1',NULL,'2018-12-17 14:05:12',NULL,NULL,'admin',NULL,NULL),(44,'1545030702192','500','1','500','1',NULL,'2018-12-17 14:11:47',NULL,NULL,'admin',NULL,NULL),(45,'1545050280193','123000','1','123000','1',NULL,'2018-12-17 19:38:06',NULL,NULL,'admin',NULL,NULL),(46,'','','','','1',NULL,'2019-01-05 09:35:03',NULL,NULL,'admin',NULL,NULL),(47,'','','','','1',NULL,'2019-01-05 09:35:03',NULL,NULL,'admin',NULL,NULL),(48,'','','','','1',NULL,'2019-01-05 09:35:03',NULL,NULL,'admin',NULL,NULL),(49,'','','','','1',NULL,'2019-01-05 09:35:03',NULL,NULL,'admin',NULL,NULL),(50,'','','','','1',NULL,'2019-01-05 09:35:03',NULL,NULL,'admin',NULL,NULL),(51,'','','','','1',NULL,'2019-01-05 09:35:03',NULL,NULL,'admin',NULL,NULL),(52,'','','','','1',NULL,'2019-01-05 09:35:04',NULL,NULL,'admin',NULL,NULL),(53,'1546656332235','1200','1','1200','1',NULL,'2019-01-05 09:45:32',NULL,NULL,'admin',NULL,NULL),(54,'1546656403236','1200','1','1200','1',NULL,'2019-01-05 09:46:41',NULL,NULL,'admin',NULL,NULL),(55,'1546656405237','1200','1','1200','1',NULL,'2019-01-05 09:46:44',NULL,NULL,'admin',NULL,NULL),(56,'1546942091238','20000','1','20000','1',NULL,'2019-01-08 17:08:08',NULL,NULL,'admin',NULL,NULL),(57,'1546942783239','50000','1','50000','1',NULL,'2019-01-08 17:19:44',NULL,NULL,'admin',NULL,NULL),(58,'1546942847240','80000','1','80000','1',NULL,'2019-01-08 17:20:48',NULL,NULL,'admin',NULL,NULL),(59,'1547105917242','53','1','53','1',NULL,'2019-01-10 14:38:39',NULL,NULL,'admin',NULL,NULL),(60,'1547105920243','53','1','53','1',NULL,'2019-01-10 14:38:40',NULL,NULL,'admin',NULL,NULL),(61,'1547105920244','53','1','53','1',NULL,'2019-01-10 14:38:40',NULL,NULL,'admin',NULL,NULL),(62,'1547105934245','534','1','534','1',NULL,'2019-01-10 14:38:54',NULL,NULL,'admin',NULL,NULL),(63,'1547105968246','53400','1','53400','1',NULL,'2019-01-10 14:39:28',NULL,NULL,'admin',NULL,NULL),(64,'1547105970247','53400','1','53400','1',NULL,'2019-01-10 14:39:30',NULL,NULL,'admin',NULL,NULL),(65,'1551326147273','16500','1','16500','1',NULL,'2019-02-28 10:55:13',NULL,NULL,'admin',NULL,NULL),(66,'1551326950274','16500','1','16500','1',NULL,'2019-02-28 11:08:35',NULL,NULL,'admin',NULL,NULL),(67,'1551327092275','5500','1','5500','1',NULL,'2019-02-28 11:10:58',NULL,NULL,'admin',NULL,NULL),(68,'1551327279276','11000','1','11000','1',NULL,'2019-02-28 11:14:05',NULL,NULL,'admin',NULL,NULL),(69,'1551327586277','5500','1','5500','1',NULL,'2019-02-28 11:19:12',NULL,NULL,'admin',NULL,NULL),(70,'1551327892278','5500','1','5500','1',NULL,'2019-02-28 11:24:18',NULL,NULL,'admin',NULL,NULL),(71,'','','','','1',NULL,'2019-02-28 11:26:54',NULL,NULL,'admin',NULL,NULL),(72,'1551328192279','5500','1','5500','1',NULL,'2019-02-28 11:29:18',NULL,NULL,'admin',NULL,NULL),(73,'1551328603280','5500','1','5500','1',NULL,'2019-02-28 11:36:09',NULL,NULL,'admin',NULL,NULL),(74,'1551328764281','5500','1','5500','1',NULL,'2019-02-28 11:38:50',NULL,NULL,'admin',NULL,NULL),(75,'1551328975282','5500','1','5500','1',NULL,'2019-02-28 11:42:21',NULL,NULL,'admin',NULL,NULL),(76,'1551331497283','5500','1','5500','1',NULL,'2019-02-28 12:24:22',NULL,NULL,'admin',NULL,NULL),(77,'1551337467284','5500','1','5500','1',NULL,'2019-02-28 14:03:53',NULL,NULL,'admin',NULL,NULL),(78,'1551337601285','27500','1','27500','1',NULL,'2019-02-28 14:06:07',NULL,NULL,'admin',NULL,NULL),(79,'1551406850286','27500','1','27500','1',NULL,'2019-03-01 09:20:16',NULL,NULL,'admin',NULL,NULL),(80,'1551840892287','22500','1','22500','1',NULL,'2019-03-06 09:54:23',NULL,NULL,'admin',NULL,NULL),(81,'1551840893288','22500','1','22500','1',NULL,'2019-03-06 09:54:23',NULL,NULL,'admin',NULL,NULL),(82,'1551845191289','22500','1','22500','1',NULL,'2019-03-06 11:06:01',NULL,NULL,'admin',NULL,NULL),(83,'1551845192290','22500','1','22500','1',NULL,'2019-03-06 11:06:02',NULL,NULL,'admin',NULL,NULL),(84,'1552294833291','50000','1','50000','1',NULL,'2019-03-11 16:00:06',NULL,NULL,'admin',NULL,NULL),(85,'1552373119292','10000','1','10000','1',NULL,'2019-03-12 13:44:52',NULL,NULL,'admin',NULL,NULL),(86,'1552459629293','50000','1','50000','1',NULL,'2019-03-13 13:46:44',NULL,NULL,'admin',NULL,NULL),(87,'1552466725294','50000','1','50000','1',NULL,'2019-03-13 15:44:43',NULL,NULL,'admin',NULL,NULL),(88,'1552471560295','10000','1','10000','1',NULL,'2019-03-13 17:05:36',NULL,NULL,'admin',NULL,NULL),(89,'1552471589296','20000','1','20000','1',NULL,'2019-03-13 17:05:45',NULL,NULL,'admin',NULL,NULL),(90,'1552558805297','10000','1','10000','1',NULL,'2019-03-14 17:19:28',NULL,NULL,'admin',NULL,NULL),(91,'1552640453298','139500','1','139500','1',NULL,'2019-03-15 16:00:27',NULL,NULL,'admin',NULL,NULL),(92,'1552640659299','33500','1','33500','1',NULL,'2019-03-15 16:03:52',NULL,NULL,'admin',NULL,NULL),(93,'1552640907300','18000','1','18000','1',NULL,'2019-03-15 16:08:01',NULL,NULL,'admin',NULL,NULL),(94,'1552884462301','2000','1','2000','1',NULL,'2019-03-18 11:47:17',NULL,NULL,'admin',NULL,NULL),(95,'1552884563302','5000','1','5000','1',NULL,'2019-03-18 11:48:58',NULL,NULL,'admin',NULL,NULL),(96,'1552890638303','500000000','1','500000000','1',NULL,'2019-03-18 13:30:12',NULL,NULL,'admin',NULL,NULL),(97,'1552890745304','50000000000','1','50000000000','1',NULL,'2019-03-18 13:32:00',NULL,NULL,'admin',NULL,NULL),(98,'1552890779305','50000000000','1','50000000000','1',NULL,'2019-03-18 13:32:33',NULL,NULL,'admin',NULL,NULL),(99,'1552894420307','120500','1','120500','1',NULL,'2019-03-18 14:33:15',NULL,NULL,'admin',NULL,NULL),(100,'1552894425308','120500','1','120500','1',NULL,'2019-03-18 14:33:19',NULL,NULL,'admin',NULL,NULL),(101,'1552895297309','7000','1','7000','1',NULL,'2019-03-18 14:47:51',NULL,NULL,'admin',NULL,NULL),(102,'1552903059312','117000','1','117000','1',NULL,'2019-03-18 16:57:13',NULL,NULL,'admin',NULL,NULL),(103,'1552967998313','24000','1','24000','1',NULL,'2019-03-19 10:59:33',NULL,NULL,'admin',NULL,NULL),(104,'1552968002314','24000','1','24000','1',NULL,'2019-03-19 10:59:37',NULL,NULL,'admin',NULL,NULL),(105,'1553057053315','12000','1','12000','1',NULL,'2019-03-20 11:43:48',NULL,NULL,'admin',NULL,NULL),(106,'1553057808316','12500','1','12500','1',NULL,'2019-03-20 11:56:23',NULL,NULL,'admin',NULL,NULL),(107,'1553058158317','25500','1','25500','1',NULL,'2019-03-20 12:02:13',NULL,NULL,'admin',NULL,NULL),(108,'1553058515318','11500','1','11500','1',NULL,'2019-03-20 12:08:10',NULL,NULL,'admin',NULL,NULL),(109,'1553065935319','11500','1','11500','1',NULL,'2019-03-20 14:11:51',NULL,NULL,'admin',NULL,NULL),(110,'1553065972320','11500','1','11500','1',NULL,'2019-03-20 14:12:28',NULL,NULL,'admin',NULL,NULL),(111,'1553066023321','11500','1','11500','1',NULL,'2019-03-20 14:13:18',NULL,NULL,'admin',NULL,NULL),(112,'1553066028322','11500','1','11500','1',NULL,'2019-03-20 14:13:24',NULL,NULL,'admin',NULL,NULL),(113,'1553066052323','11500','1','11500','1',NULL,'2019-03-20 14:13:47',NULL,NULL,'admin',NULL,NULL),(114,'1553066127324','11500','1','11500','1',NULL,'2019-03-20 14:15:02',NULL,NULL,'admin',NULL,NULL),(115,'1553066165325','11500','1','11500','1',NULL,'2019-03-20 14:15:40',NULL,NULL,'admin',NULL,NULL),(116,'1553066208326','50500','1','50500','1',NULL,'2019-03-20 14:16:23',NULL,NULL,'admin',NULL,NULL),(117,'1553152568331','24000','1','24000','1',NULL,'2019-03-21 14:15:45',NULL,NULL,'admin',NULL,NULL),(118,'1553153188332','42000','1','42000','1',NULL,'2019-03-21 14:26:04',NULL,NULL,'admin',NULL,NULL),(119,'1553157992333','16500','1','16500','1',NULL,'2019-03-21 15:46:08',NULL,NULL,'admin',NULL,NULL),(120,'1553158171334','21500','1','21500','1',NULL,'2019-03-21 15:49:07',NULL,NULL,'admin',NULL,NULL),(121,'1553158277335','14500','1','14500','1',NULL,'2019-03-21 15:50:53',NULL,NULL,'admin',NULL,NULL),(122,'1553159285336','24500','1','24500','1',NULL,'2019-03-21 16:07:41',NULL,NULL,'admin',NULL,NULL),(123,'1553221107338','26500','1','26500','1',NULL,'2019-03-22 09:18:03',NULL,NULL,'admin',NULL,NULL),(124,'1553222276339','6000','1','6000','1',NULL,'2019-03-22 09:37:32',NULL,NULL,'admin',NULL,NULL),(125,'1553234443340','19000','1','19000','1',NULL,'2019-03-22 13:00:19',NULL,NULL,'admin',NULL,NULL),(126,'1553234595341','18000','1','18000','1',NULL,'2019-03-22 13:02:51',NULL,NULL,'admin',NULL,NULL),(127,'1553482584343','52200','1','52200','1',NULL,'2019-03-25 09:56:01',NULL,NULL,'admin',NULL,NULL),(128,'1553650270344','6000','1','6000','1',NULL,'2019-03-27 08:30:47',NULL,NULL,'admin',NULL,NULL),(129,'1553650709345','6000','1','6000','1',NULL,'2019-03-27 08:38:06',NULL,NULL,'admin',NULL,NULL),(130,'1553650937346','5000','1','5000','1',NULL,'2019-03-27 08:41:54',NULL,NULL,'admin',NULL,NULL),(131,'1553655052347','11500','1','11500','1',NULL,'2019-03-27 09:50:29',NULL,NULL,'admin',NULL,NULL),(132,'1553655825348','11500','1','11500','1',NULL,'2019-03-27 10:03:22',NULL,NULL,'admin',NULL,NULL),(133,'1553656217349','11500','1','11500','1',NULL,'2019-03-27 10:09:53',NULL,NULL,'admin',NULL,NULL),(134,'1553741381350','10000','1','10000','1',NULL,'2019-03-28 09:49:18',NULL,NULL,'admin',NULL,NULL),(135,'1553762040351','12500','1','12500','1',NULL,'2019-03-28 15:33:39',NULL,NULL,'admin',NULL,NULL),(136,'1556007115387','5000','1','5000','1',NULL,'2019-04-23 15:11:38',NULL,NULL,'admin',NULL,NULL),(137,'1556077775431','6000','1','6000','1',NULL,'2019-04-24 10:49:14',NULL,NULL,'admin',NULL,NULL),(138,'','','','','1',NULL,'2019-04-24 10:54:38',NULL,NULL,'admin',NULL,NULL),(139,'','','','','1',NULL,'2019-04-24 10:57:59',NULL,NULL,'admin',NULL,NULL),(140,'','','','','1',NULL,'2019-04-24 11:04:49',NULL,NULL,'admin',NULL,NULL),(141,'1556081221449','6000','1','6000','1',NULL,'2019-04-24 11:46:40',NULL,NULL,'admin',NULL,NULL),(142,'1556081286450','6000','1','6000','1',NULL,'2019-04-24 11:47:46',NULL,NULL,'admin',NULL,NULL),(143,'','','','','1',NULL,'2019-04-24 11:47:51',NULL,NULL,'admin',NULL,NULL),(144,'','','','','1',NULL,'2019-04-24 11:48:11',NULL,NULL,'admin',NULL,NULL),(145,'1556161891479','10000','1','10000','1',NULL,'2019-04-25 10:11:12',NULL,NULL,'admin',NULL,NULL),(146,'1556532742480','8500','1','8500','1',NULL,'2019-04-29 17:12:09',NULL,NULL,'admin',NULL,NULL),(147,'1556532800481','8500','1','8500','1',NULL,'2019-04-29 17:13:06',NULL,NULL,'admin',NULL,NULL),(148,'1556610182482','50000','1','50000','1',NULL,'2019-04-30 14:42:49',NULL,NULL,'admin',NULL,NULL),(149,'1556610191483','50000','1','50000','1',NULL,'2019-04-30 14:42:58',NULL,NULL,'admin',NULL,NULL),(150,'','','','','1',NULL,'2019-04-30 14:46:38',NULL,NULL,'admin',NULL,NULL),(151,'1556610491484','50000','1','50000','1',NULL,'2019-04-30 14:47:58',NULL,NULL,'admin',NULL,NULL),(152,'1556610612485','50000','1','50000','1',NULL,'2019-04-30 14:49:58',NULL,NULL,'admin',NULL,NULL),(153,'1556613761486','50000','1','50000','1',NULL,'2019-04-30 15:42:27',NULL,NULL,'admin',NULL,NULL),(154,'1556614617487','50000','1','50000','1',NULL,'2019-04-30 15:56:44',NULL,NULL,'admin',NULL,NULL),(155,'1556615124488','50000','1','50000','1',NULL,'2019-04-30 16:05:11',NULL,NULL,'admin',NULL,NULL),(156,'1556615350489','50000','1','50000','1',NULL,'2019-04-30 16:08:57',NULL,NULL,'admin',NULL,NULL),(157,'1556615688490','50000','1','50000','1',NULL,'2019-04-30 16:14:34',NULL,NULL,'admin',NULL,NULL),(158,'1556616246491','100000','1','100000','1',NULL,'2019-04-30 16:23:53',NULL,NULL,'admin',NULL,NULL),(159,'1556616557492','2000','1','2000','1',NULL,'2019-04-30 16:29:04',NULL,NULL,'admin',NULL,NULL),(160,'1556616671493','4000','1','4000','1',NULL,'2019-04-30 16:30:57',NULL,NULL,'admin',NULL,NULL),(161,'1556616914494','10000','1','10000','1',NULL,'2019-04-30 16:35:01',NULL,NULL,'admin',NULL,NULL),(162,'1556616937495','8000','1','8000','1',NULL,'2019-04-30 16:35:24',NULL,NULL,'admin',NULL,NULL),(163,'1556617593496','20000','1','20000','1',NULL,'2019-04-30 16:46:19',NULL,NULL,'admin',NULL,NULL),(164,'1556618247497','40000','1','40000','1',NULL,'2019-04-30 16:57:14',NULL,NULL,'admin',NULL,NULL),(165,'1556618989498','2000','1','2000','1',NULL,'2019-04-30 17:09:36',NULL,NULL,'admin',NULL,NULL),(166,'1556783415499','10000','1','10000','1',NULL,'2019-05-02 14:50:03',NULL,NULL,'admin',NULL,NULL),(167,'1556783733500','50000','1','50000','1',NULL,'2019-05-02 14:55:21',NULL,NULL,'admin',NULL,NULL),(168,'1556783933501','10000','1','10000','1',NULL,'2019-05-02 14:58:41',NULL,NULL,'admin',NULL,NULL),(169,'1556783973502','95000','1','95000','1',NULL,'2019-05-02 14:59:21',NULL,NULL,'admin',NULL,NULL),(170,'1557456989520','2000','1','2000','1',NULL,'2019-05-10 09:56:05',NULL,NULL,'admin',NULL,NULL),(171,'','','','','1',NULL,'2019-05-21 09:02:56',NULL,NULL,'admin',NULL,NULL),(172,'1558404229521','10000','1','10000','1',NULL,'2019-05-21 09:03:03',NULL,NULL,'admin',NULL,NULL),(173,'1558420354522','500','1','500','1',NULL,'2019-05-21 13:31:54',NULL,NULL,'admin',NULL,NULL),(174,'1558421878523','1000','1','1000','1',NULL,'2019-05-21 13:57:17',NULL,NULL,'admin',NULL,NULL),(175,'1558422922524','1700','1','1700','1',NULL,'2019-05-21 14:14:40',NULL,NULL,'admin',NULL,NULL),(176,'1558423457525','1800','1','1800','1',NULL,'2019-05-21 14:23:35',NULL,NULL,'admin',NULL,NULL),(177,'1558423467526','1800','1','1800','1',NULL,'2019-05-21 14:23:45',NULL,NULL,'admin',NULL,NULL),(178,'1558423725527','5000','1','5000','1',NULL,'2019-05-21 14:28:04',NULL,NULL,'admin',NULL,NULL),(179,'1558424288528','5000','1','5000','1',NULL,'2019-05-21 14:37:27',NULL,NULL,'admin',NULL,NULL),(180,'1558424391529','2500','1','2500','1',NULL,'2019-05-21 14:39:10',NULL,NULL,'admin',NULL,NULL),(181,'1558578157530','2000','1','2000','1',NULL,'2019-05-23 09:21:52',NULL,NULL,'admin',NULL,NULL),(182,'1558578430531','2000','1','2000','1',NULL,'2019-05-23 09:26:24',NULL,NULL,'admin',NULL,NULL),(183,'1558578653532','2000','1','2000','1',NULL,'2019-05-23 09:30:08',NULL,NULL,'admin',NULL,NULL),(184,'1558580869533','2000','1','2000','1',NULL,'2019-05-23 10:07:04',NULL,NULL,'admin',NULL,NULL),(185,'1562816312560','16500','1','16500','1',NULL,'2019-07-11 10:36:37',NULL,NULL,'admin',NULL,NULL),(186,'1562828496561','70500','1','70500','1',NULL,'2019-07-11 13:59:42',NULL,NULL,'admin',NULL,NULL),(187,'1562828745562','11500','1','11500','1',NULL,'2019-07-11 14:03:50',NULL,NULL,'admin',NULL,NULL),(188,'1562828871563','1000','1','1000','1',NULL,'2019-07-11 14:05:56',NULL,NULL,'admin',NULL,NULL),(189,'1567065607600','15500','1','15500','1',NULL,'2019-08-29 14:56:55',NULL,NULL,'admin',NULL,NULL),(190,'1567066145601','23300','1','23300','1',NULL,'2019-08-29 15:05:53',NULL,NULL,'admin',NULL,NULL),(191,'1567066359602','58500','1','58500','1',NULL,'2019-08-29 15:09:26',NULL,NULL,'admin',NULL,NULL),(192,'1567067161603','91500','1','91500','1',NULL,'2019-08-29 15:22:48',NULL,NULL,'admin',NULL,NULL),(193,'1567067783604','37000','1','37000','1',NULL,'2019-08-29 15:33:12',NULL,NULL,'admin',NULL,NULL),(194,'1567068267605','15500','1','15500','1',NULL,'2019-08-29 15:41:15',NULL,NULL,'admin',NULL,NULL),(195,'1567068471606','36000','1','36000','1',NULL,'2019-08-29 15:44:38',NULL,NULL,'admin',NULL,NULL),(196,'1567068744607','27500','1','27500','1',NULL,'2019-08-29 15:49:12',NULL,NULL,'admin',NULL,NULL),(197,'1567069254608','25500','1','25500','1',NULL,'2019-08-29 15:57:42',NULL,NULL,'admin',NULL,NULL),(198,'1567069380609','27500','1','27500','1',NULL,'2019-08-29 15:59:48',NULL,NULL,'admin',NULL,NULL),(199,'1567069474610','13000','1','13000','1',NULL,'2019-08-29 16:01:21',NULL,NULL,'admin',NULL,NULL),(200,'1569491911611','6000','1','6000','1',NULL,'2019-09-26 16:54:35',NULL,NULL,'admin',NULL,NULL),(201,'1570587176612','42500','1','42500','1',NULL,'2019-10-09 09:08:38',NULL,NULL,'admin',NULL,NULL),(202,'1570589464613','42500','1','42500','1',NULL,'2019-10-09 09:46:45',NULL,NULL,'admin',NULL,NULL),(203,'1570616171614','11500','1','11500','1',NULL,'2019-10-09 17:11:49',NULL,NULL,'admin',NULL,NULL);
/*!40000 ALTER TABLE `vne_response_payment` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-24  9:31:34
