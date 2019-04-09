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
INSERT INTO `b_company` VALUES (1020000003,'001',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'1',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2019',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'03',NULL,NULL,NULL,NULL,8,'A',NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,NULL,NULL,'04');
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
  `foods_id` int(11) NOT NULL AUTO_INCREMENT,
  `foods_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `foods_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `foods_price` decimal(17,2) DEFAULT NULL,
  `active` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `foods_type_id` int(11) DEFAULT NULL,
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
  `foods_cat_id` int(11) DEFAULT NULL,
  `status_to_go` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '0=default;1=to go',
  `status_dine_in` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL COMMENT '0=default; 1= dine in',
  `filename` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status_recommend` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`foods_id`)
) ENGINE=MyISAM AUTO_INCREMENT=104000145 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=104';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_foods`
--

LOCK TABLES `b_foods` WRITE;
/*!40000 ALTER TABLE `b_foods` DISABLE KEYS */;
INSERT INTO `b_foods` VALUES (104000000,'10100','เส้นเล็กพริกสด',55.00,'1',102000002,'aaa','1','','1','BIXOLON SRP-330II','2019-02-25 22:05:12','2019-04-01 09:21:33','0','0','0',NULL,'','',NULL,NULL,103000001,'0','0','104000000.jpg','0'),(104000001,'10101','เส้นเล็กต้มยำ',60.00,'1',102000002,'bbb','1','','1','BIXOLON SRP-330II','2019-02-26 09:23:09','2019-04-01 09:21:26','0','0','0',NULL,'','',NULL,NULL,103000000,'1','1','104000001.jpg','1'),(104000002,'10001','ข้าวหน้าเป็ดย่าง',50.00,'1',102000007,'','0','','1','BIXOLON SRP-330II','2019-03-11 16:31:04','2019-04-01 09:21:40','0','0','0',NULL,'','',NULL,NULL,103000000,'1','1','104000002.jpg','0'),(104000003,'10002','ข้าวหมูแดง',50.00,'1',0,'','0','','1','POS80 PRO','2019-03-11 16:32:40','2019-03-18 15:34:03','0','0','0',NULL,'','',NULL,NULL,103000000,'1','1','104000003.jpg','0'),(104000004,'10003','ข้าวหน้าเป็ดย่างปนหมูกรอบ',65.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-11 16:33:39','2019-03-12 14:32:09','0','0','0',NULL,'','',NULL,NULL,103000000,'1','1','104000004.jpg',NULL),(104000005,'10004','ข้าวหน้าไก่เห็ดหอม',50.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-11 16:34:13','2019-03-12 14:32:46','0','0','0',NULL,'','',NULL,NULL,103000000,'1','1','104000005.jpg',NULL),(104000006,'10005','ข้าวหน้าไก่+หมูกรอบ',65.00,'1',102000007,'','1','','1','Microsoft Print to PDF','2019-03-11 16:34:50','2019-04-04 11:28:42','0','0','0',NULL,'','',NULL,NULL,103000000,'1','1','104000006.jpg','0'),(104000007,'10006','ข้าวหน้าเป็ด+หมูแดง+หมูกรอบ',80.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-11 16:35:40','2019-03-12 14:33:15','0','0','0',NULL,'','',NULL,NULL,103000000,'1','1','104000007.jpg',NULL),(104000008,'10007','ข้าวหน้าเป็ด+หน้าไก่',75.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 16:36:23',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000000,'1','1','104000008.jpg',NULL),(104000009,'20001','หน้าไก่',70.00,'1',102000000,'','1','','1','POS80 PRO','2019-03-11 16:37:15','2019-03-11 16:38:37','0','0','0',NULL,'','',NULL,NULL,103000002,'1','1','104000009.jpg',NULL),(104000010,'20002','เป็ดย่าง',480.00,'1',102000000,'','1','','1','POS80 PRO','2019-03-11 16:38:12','2019-03-12 14:37:08','0','0','0',NULL,'','',NULL,NULL,103000002,'1','1','104000010.jpg',NULL),(104000011,'20003','เป็ดย่างไหว้เจ้า+เครื่องใน',500.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 16:39:49',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000002,'1','1','104000011.jpg',NULL),(104000012,'20004','หมูแดง(ขีดละ)',50.00,'1',102000000,'','1','','1','POS80 PRO','2019-03-11 16:40:32','2019-03-12 14:37:23','0','0','0',NULL,'','',NULL,NULL,103000002,'1','1','104000012.jpg',NULL),(104000013,'20005','กุนเชียง(ขีดละ)',50.00,'1',0,'','0','','1','POS80 PRO','2019-03-11 16:41:01','2019-03-11 16:54:57','0','0','0',NULL,'','',NULL,NULL,103000002,'1','1','104000013.jpg',NULL),(104000014,'20006','หมูกรอบ(ขีดละ)',60.00,'1',102000000,'','1','','1','POS80 PRO','2019-03-11 16:41:29','2019-03-12 14:37:56','0','0','0',NULL,'','',NULL,NULL,103000002,'1','1','104000014.jpg',NULL),(104000015,'20007','เป็ดย่างจานเดียว',120.00,'1',102000000,'','0','','1','POS80 PRO','2019-03-11 16:42:06','2019-03-12 14:38:17','0','0','0',NULL,'','',NULL,NULL,103000002,'1','1','104000015.jpg',NULL),(104000016,'20008','เป็ดย่างจานเดียว(พิเศษ)',240.00,'1',102000000,'','1','','1','POS80 PRO','2019-03-11 16:42:37','2019-03-12 14:38:32','0','0','0',NULL,'','',NULL,NULL,103000002,'1','1','104000016.jpg',NULL),(104000017,'20009','หมูแดง+หมูกรอบ',100.00,'1',102000000,'','1','','1','POS80 PRO','2019-03-11 16:43:06','2019-03-12 14:38:47','0','0','0',NULL,'','',NULL,NULL,103000002,'1','1','104000017.jpg',NULL),(104000018,'20010','เป็ดย่าง+หมูแดง',160.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 16:43:42',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000002,'1','1','104000018.jpg',NULL),(104000019,'20011','เป็ดย่าง+หมูกรอบ',160.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 16:44:22',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000002,'1','1','104000019.jpg',NULL),(104000020,'20012','เป็ดย่าง+หมูแดง+หมูกรอบ',240.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 16:45:03',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000002,'1','1','104000020.jpg',NULL),(104000021,'20013','น้ำราดหมูแดง(ขีดละ)',10.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 16:52:09',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000002,'1','1','104000021.jpg',NULL),(104000022,'20014','น้ำราดเป็ด(ขีดละ)',10.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 16:52:53',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000002,'1','1','104000022.jpg',NULL),(104000023,'20015','ไข่ต้ม(ขีดละ)',10.00,'1',0,'','1','','1','POS80 PRO','2019-03-11 16:53:21','2019-03-13 10:27:19','0','0','0',NULL,'','',NULL,NULL,103000002,'1','1','104000023.jpg',NULL),(104000024,'20016','ข้าวเปล่า(ขีดละ)',10.00,'1',102000002,'','0','','1','POS80 PRO','2019-03-11 16:53:48','2019-03-13 10:27:49','0','0','0',NULL,'','',NULL,NULL,103000002,'1','1','104000024.jpg',NULL),(104000025,'20017','ขิงดอง(ขีดละ)',10.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 16:54:18',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000002,'1','1','104000025.jpg',NULL),(104000026,'10008','ข้าวหน้าไก่เห็ดหอม(พิเศษ)',65.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 16:56:36',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000000,'1','1','104000026.jpg',NULL),(104000027,'10009','ข้าวหน้าเป็ดย่าง(พิเศษ)',75.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-11 16:57:32','2019-03-12 14:41:09','0','0','0',NULL,'','',NULL,NULL,103000000,'1','1','104000027.jpg',NULL),(104000028,'10010','ข้าวหน้าหมูแดง(พิเศษ)',65.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 16:58:30',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000000,'1','1','104000028.jpg',NULL),(104000029,'10011','ข้าวหน้าหมูกรอบ',50.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-11 16:59:06','2019-03-12 14:39:43','0','0','0',NULL,'','',NULL,NULL,103000000,'1','1','104000029.jpg',NULL),(104000030,'10012','ข้าวหน้าหมูกรอบ(พิเศษ)',65.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-11 16:59:32','2019-03-12 14:40:05','0','0','0',NULL,'','',NULL,NULL,103000000,'1','1','104000030.jpg',NULL),(104000031,'30001','บะหมี่เกี๊ยวปูพริกไทยดำ',65.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 17:03:47',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000031.jpg',NULL),(104000032,'30002','บะหมี่หมูแดง',55.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 17:04:16',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000032.jpg',NULL),(104000033,'30003','บะหมี่หมูกรอบ',55.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 17:04:37',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000033.jpg',NULL),(104000034,'30004','บะหมี่เป็ดย่าง',60.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 17:05:18',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000034.jpg',NULL),(104000035,'30005','บะหมี่หน้าไก่เห็ดหอม',60.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 17:05:54',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000035.jpg',NULL),(104000036,'30006','บะหมี่เป็ดย่าง+หมูกรอบ',75.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 17:07:47',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000036.jpg',NULL),(104000037,'30007','บะหมี่งาดำเต้าหุ้แคะทอด',65.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 17:08:41',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000037.jpg',NULL),(104000038,'30008','บะหมี่เกี๊ยวล้วน',65.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 17:09:08',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000038.jpg',NULL),(104000039,'30009','บะหมี่เกี๊ยวหมูแดง',70.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 17:09:58',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000039.jpg',NULL),(104000040,'30010','บะหมี่เกี๊ยวหมูกรอบ',70.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 17:10:47',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000040.jpg',NULL),(104000041,'30011','บะหมี่เกี๊ยวเป็ดย่าง',75.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 17:11:18',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000041.jpg',NULL),(104000042,'30012','บะหมี่เกี๊ยวหน้าไก่เห็ดหอม',75.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 17:12:03',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000042.jpg',NULL),(104000043,'30013','บะหมี่เกี๊ยวลูกชิ้นปลา',70.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 17:12:52',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000043.jpg',NULL),(104000044,'30014','บะหมี่เกี๊ยวลูกชิ้นปลาต้มยำมะนาว',80.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 17:13:27',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000044.jpg',NULL),(104000045,'30015','บะหมี่เกี๊ยวเย็นตาโฟ',80.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 17:13:54',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000045.jpg',NULL),(104000046,'30016','บะหมี่เกี๊ยวเป็ดย่าง+หมูกรอบ',90.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 17:15:03',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000046.jpg',NULL),(104000047,'30017','บะหมี่เกี๊ยวต้มยำน้ำข้นปลา',80.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 17:15:47',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000047.jpg',NULL),(104000048,'30018','บะหมี่เกี๊ยวต้มยำน้ำข้นทะเล',95.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 17:16:29',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000048.jpg',NULL),(104000049,'30019','บะหมี่เกี๊ยวต้มยำน้ำข้นกุ้ง',105.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 17:17:02',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000049.jpg',NULL),(104000050,'30020','บะหมี่เกี๊ยวต้มยำน้ำข้นเกี๊ยวปลา',90.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-11 17:17:37',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000003,'1','1','104000050.jpg',NULL),(104000051,'40001','ก๋วยเตี๋ยวพริกสดลูกชิ้นปลา+เนื้อปลา',65.00,'1',102000011,'','1','','1','POS80 PRO','2019-03-12 08:46:45','2019-03-12 14:43:37','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000051.jpg',NULL),(104000052,'40002','ก๋วยเตี๋ยวพริกสดหมูกรอบ',65.00,'1',102000011,'','1','','1','POS80 PRO','2019-03-12 08:48:17','2019-03-12 14:43:31','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000052.jpg',NULL),(104000053,'40003','ก๋วยเตี๋ยวพริกสดหมูก้อน',75.00,'1',102000011,'','1','','1','POS80 PRO','2019-03-12 08:48:54','2019-03-12 14:43:23','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000053.jpg',NULL),(104000054,'40004','ก๋วยเตี๋ยวทะเลพริกสด',80.00,'1',102000011,'','1','','1','POS80 PRO','2019-03-12 08:51:46','2019-03-12 14:43:14','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000054.jpg',NULL),(104000055,'40005','ก๋วยเตี๋ยวเนื้อปลาน้ำใส',65.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 08:55:14','2019-03-12 14:43:50','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000055.jpg',NULL),(104000056,'40006','ก๋วยเตี๋ยวต้มยำน้ำข้นปลา',65.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 08:57:16','2019-03-12 08:57:59','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000056.jpg',NULL),(104000057,'40007','ก๋วยเตี๋ยวต้มยำน้ำข้นหมูก้อน',75.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 08:58:51','2019-03-12 08:59:08','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000057.jpg',NULL),(104000058,'40008','ก๋วยเตี๋ยวต้มยำน้ำข้นเกี๊ยวปลา',75.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 09:00:26','2019-03-12 09:00:39','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000058.jpg',NULL),(104000059,'40009','ก๋วยเตี๋ยวต้มยำน้ำข้นชิ้นกุ้ง',75.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 09:01:17','2019-03-12 09:01:28','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000059.jpg',NULL),(104000060,'40010','ก๋วยเตี๋ยวต้มยำน้ำข้นทะเล',80.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 09:06:41','2019-03-12 09:06:55','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000060.jpg',NULL),(104000061,'40011','ก๋วยเตี๋ยวต้มยำน้ำข้นกุ้ง',90.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-12 09:07:24',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000001,'1','1','104000061.jpg',NULL),(104000062,'40012','ก๋วยเตี๋ยวต้มยำน้ำข้นหมูกรอบ',65.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 09:08:34','2019-03-12 09:08:44','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000062.jpg',NULL),(104000063,'40013','ก๋วยเตี๋ยวลูกชิ้นปลา',55.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 09:09:13','2019-03-12 09:09:31','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000063.jpg',NULL),(104000064,'40014','ก๋วยเตี๋ยวหมูสับ',55.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 09:10:23','2019-03-12 09:10:49','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000064.jpg',NULL),(104000065,'40015','ก๋วยเตี๋ยวลูกชิ้นกุ้งทอด',65.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 09:11:32','2019-03-12 09:11:47','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000065.jpg',NULL),(104000066,'40016','ก๋วยเตี๋ยวเกี๊ยวปลา',65.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 09:12:30','2019-03-12 09:12:49','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000066.jpg',NULL),(104000067,'40017','ก๋วยเตี๋ยวต้มยำสูตรมะนาว',65.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 09:13:25','2019-03-12 09:13:36','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000067.jpg',NULL),(104000068,'40018','ก๋วยเตี๋ยวเย็นตาโฟ',65.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 09:14:04','2019-03-12 09:14:18','0','0','0',NULL,'','',NULL,NULL,103000001,'1','1','104000068.jpg',NULL),(104000069,'50001','ข้ามต้มปลา',65.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 09:15:05','2019-03-12 09:15:21','0','0','0',NULL,'','',NULL,NULL,103000004,'1','1','104000069.jpg',NULL),(104000070,'50002','ข้ามต้มปลาหมึก',65.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 09:15:40','2019-03-12 09:15:56','0','0','0',NULL,'','',NULL,NULL,103000004,'1','1','104000070.jpg',NULL),(104000071,'50003','ข้ามต้มหมูสับ',65.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 09:16:11','2019-03-12 09:16:43','0','0','0',NULL,'','',NULL,NULL,103000004,'1','1','104000071.jpg',NULL),(104000072,'50004','ข้ามต้มหมูก้อน',75.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 09:17:05','2019-03-12 09:17:18','0','0','0',NULL,'','',NULL,NULL,103000004,'1','1','104000072.jpg',NULL),(104000073,'50005','ข้าวต้มกุ้ง',90.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 09:17:37','2019-03-12 14:48:13','0','0','0',NULL,'','',NULL,NULL,103000004,'1','1','104000073.jpg',NULL),(104000074,'50006','ข้ามต้มทะเล',80.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 09:18:02','2019-03-12 09:18:19','0','0','0',NULL,'','',NULL,NULL,103000004,'1','1','104000074.jpg',NULL),(104000075,'60001','ต้มยำน้ำข้น',15.00,'1',102000000,'','1','','1','POS80 PRO','2019-03-12 09:20:10','2019-03-12 09:21:11','0','0','0',NULL,'','',NULL,NULL,103000010,'1','1','104000075.jpg',NULL),(104000076,'60002','เส้นก๋วยเตี๋ยว',15.00,'1',102000000,'','1','','1','POS80 PRO','2019-03-12 09:22:40','2019-03-12 09:22:51','0','0','0',NULL,'','',NULL,NULL,103000011,'1','1','104000076.jpg',NULL),(104000077,'60003','บะหมี่ลวก',15.00,'1',102000000,'','1','','1','POS80 PRO','2019-03-12 09:24:00','2019-03-12 09:24:42','0','0','0',NULL,'','',NULL,NULL,103000011,'1','1','104000077.jpg',NULL),(104000078,'60004','เกี๊ยวทอดกรอบ',15.00,'1',102000000,'','1','','1','POS80 PRO','2019-03-12 09:25:16','2019-03-12 09:25:40','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000078.jpg',NULL),(104000079,'60005','บะหมี่สาหร่าย',25.00,'1',102000000,'','1','','1','POS80 PRO','2019-03-12 09:32:48','2019-03-12 09:33:10','0','0','0',NULL,'','',NULL,NULL,103000011,'1','1','104000079.jpg',NULL),(104000080,'60006','น้ำจิ้มพริกสด',10.00,'1',102000000,'','1','','1','POS80 PRO','2019-03-12 09:34:02','2019-03-12 09:35:29','0','0','0',NULL,'','',NULL,NULL,103000012,'1','1','104000080.jpg',NULL),(104000081,'70001','รวมมิตรปลาลวก',80.00,'1',102000000,'','1','','1','POS80 PRO','2019-03-12 09:52:07','2019-03-12 09:52:23','0','0','0',NULL,'','',NULL,NULL,103000005,'1','1','104000081.jpg',NULL),(104000082,'70002','เนื้อปลาลวก',80.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-12 09:52:47',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000005,'1','1','104000082.jpg',NULL),(104000083,'70003','รวมมิตรทะเลลวก',80.00,'1',102000000,'','1','','1','POS80 PRO','2019-03-12 09:53:44','2019-03-12 09:54:00','0','0','0',NULL,'','',NULL,NULL,103000005,'1','1','104000083.jpg',NULL),(104000084,'70004','เกี๊ยวปลาลวกจิ้ม',80.00,'1',102000000,'','1','','1','POS80 PRO','2019-03-12 09:55:02','2019-03-12 09:55:12','0','0','0',NULL,'','',NULL,NULL,103000005,'1','1','104000084.jpg',NULL),(104000085,'70005','เกี๊ยวกุ้งลวกจิ้ม',80.00,'1',102000000,'','1','','1','POS80 PRO','2019-03-12 09:55:36','2019-03-12 09:55:53','0','0','0',NULL,'','',NULL,NULL,103000005,'1','1','104000085.jpg',NULL),(104000086,'70006','ลูกชิ้นกุ้งทอด',80.00,'1',102000009,'','1','','1','POS80 PRO','2019-03-12 09:56:17','2019-03-12 14:49:35','0','0','0',NULL,'','',NULL,NULL,103000005,'1','1','104000086.jpg',NULL),(104000087,'80001','เกาเหลาน้ำใสลูกชิ้นปลา',60.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:05:08','2019-03-12 10:05:24','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000087.jpg',NULL),(104000088,'80002','เกาเหลาเย็นตาโฟลูกชิ้นปลา',70.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:05:51','2019-03-12 10:06:01','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000088.jpg',NULL),(104000089,'80003','เกาเหลาน้ำใสเนื้อปลา',70.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:07:05','2019-03-12 10:07:18','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000089.jpg',NULL),(104000090,'80004','เกาเหลาน้ำใสเป็ดย่าง',65.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:08:25','2019-03-12 10:08:39','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000090.jpg',NULL),(104000091,'80005','เกาเหลาน้ำใสเกี๊ยวปลา',70.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:10:44','2019-03-12 10:10:57','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000091.jpg',NULL),(104000092,'80006','เกาเหลาน้ำใสลูกชิ้นกุ้งทอด',70.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:16:56','2019-03-12 10:17:07','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000092.jpg',NULL),(104000093,'80007','เกาเหลาพริกสด(สูตรแห้ง)',70.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:17:39','2019-03-12 10:17:51','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000093.jpg',NULL),(104000094,'80008','เกาเหลายำมะนาว',70.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:18:12','2019-03-12 10:18:24','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000094.jpg',NULL),(104000095,'80009','เกาเหลาต้มยำปลาน้ำข้น',70.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:19:49','2019-03-12 10:21:30','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000095.jpg',NULL),(104000096,'80010','เกาเหลาต้มยำทะเล',85.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:21:18','2019-03-12 10:21:38','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000096.jpg',NULL),(104000097,'80011','เกาเหลาต้มยำกุ้งน้ำข้น',95.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:23:30','2019-03-12 10:23:40','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000097.jpg',NULL),(104000098,'80012','เกาเหลาต้มยำน้ำข้นเกี๊ยวปลา',80.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:24:08','2019-03-12 10:24:21','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000098.jpg',NULL),(104000099,'80013','เกาเหลาต้มยำน้ำข้นลูกชิ้นกุ้งทอด',80.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:24:46','2019-03-12 10:24:54','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000099.jpg',NULL),(104000100,'80014','เกาเหลาต้มยำน้ำข้นหมูก้อน',80.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:26:22','2019-03-12 10:26:35','0','0','0',NULL,'','',NULL,NULL,103000006,'1','1','104000100.jpg',NULL),(104000101,'90001','เกี๊ยวกุ้งน้ำใสเนื้อปลา',75.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:28:02','2019-03-12 10:28:13','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000101.jpg',NULL),(104000102,'90002','เกี๊ยวกุ้งน้ำใสหมูสับ',65.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:28:59','2019-03-12 10:29:40','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000102.jpg',NULL),(104000103,'90003','เกี๊ยวกุ้งน้ำใสหมูแดง',65.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:30:04','2019-03-12 10:30:17','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000103.jpg',NULL),(104000104,'90004','เกี๊ยวกุ้งน้ำใสหมูกรอบ',65.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:48:45','2019-03-12 10:49:04','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000104.jpg',NULL),(104000105,'90005','เกี๊ยวกุ้งน้ำใสหมูก้อน',75.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:49:26','2019-03-12 10:49:41','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000105.jpg',NULL),(104000106,'90006','เกี๊ยวกุ้งน้ำใสลูกชิ้นปลา',65.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:50:18','2019-03-12 10:50:30','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000106.jpg',NULL),(104000107,'90007','เกี๊ยวกุ้งต้มยำมะนาวหมูกรอบ',75.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:50:53','2019-03-12 10:51:03','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000107.jpg',NULL),(104000108,'90008','เกี๊ยวกุ้งเย็นตาโฟ',75.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:51:21','2019-03-12 10:51:31','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000108.jpg',NULL),(104000109,'90009','เกี๊ยวกุ้งหน้าไก่เห็ดหอม',70.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:51:52','2019-03-12 10:52:11','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000109.jpg',NULL),(104000110,'90010','เกี๊ยวกุ้งเป็ดย่าง',70.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:53:53','2019-03-12 10:54:02','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000110.jpg',NULL),(104000111,'90011','เกี๊ยวกุ้งเป็ดย่างหมูกรอบ',85.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:55:12','2019-03-12 10:55:24','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000111.jpg',NULL),(104000112,'90012','เกี๊ยวกุ้งเป็ดย่างหมูแดง',85.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:55:42','2019-03-12 10:55:52','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000112.jpg',NULL),(104000113,'90013','เกี๊ยวกุ้งต้มยำน้ำข้นเนื้อปลา',75.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:56:35','2019-03-12 10:56:46','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000113.jpg',NULL),(104000114,'90014','เกี๊ยวกุ้งต้มยำน้ำข้นปลาหมึก',75.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:57:10','2019-03-12 10:57:23','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000114.jpg',NULL),(104000115,'90015','เกี๊ยวกุ้งต้มยำน้ำข้นเนื้อปลา+ลูกชิ้นปลา',75.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 10:59:35','2019-03-12 11:00:16','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000115.jpg',NULL),(104000116,'90016','เกี๊ยวกุ้งต้มยำน้ำข้นทะเล',90.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 11:00:04','2019-03-12 12:56:51','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000116.jpg',NULL),(104000117,'90017','เกี๊ยวกุ้งต้มยำน้ำข้นกุ้ง',100.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 11:01:29','2019-03-12 12:57:05','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000117.jpg',NULL),(104000118,'90018','เกี๊ยวกุ้งพริกสดลูกชิ้นปลาปนเนื้อปลา',75.00,'1',102000011,'','1','','1','POS80 PRO','2019-03-12 12:55:48','2019-03-12 14:10:29','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000118.jpg',NULL),(104000119,'90019','เกี๊ยวกุ้งทะเลพริกสดลูกชิ้นปลาปนเนื้อปลา',90.00,'1',102000011,'','1','','1','POS80 PRO','2019-03-12 12:57:44','2019-03-12 14:10:39','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000119.jpg',NULL),(104000120,'90020','เกี๊ยวกุ้งต้มยำน้ำข้นเป็ดย่าง',80.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 12:59:38','2019-03-12 12:59:54','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000120.jpg',NULL),(104000121,'90021','เกี๊ยวกุ้งต้มยำน้ำข้นหมูกรอบ',75.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 13:11:22','2019-03-12 13:11:44','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000121.jpg',NULL),(104000122,'90022','เกี๊ยวกุ้งต้มยำน้ำข้นลูกชิ้นกุ้งทอด',85.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 13:14:59','2019-03-12 13:15:12','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000122.jpg',NULL),(104000123,'90023','เกี๊ยวกุ้งต้มยำน้ำข้น+เกี๊ยวปลา',85.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 13:15:49','2019-03-12 13:17:27','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000123.jpg',NULL),(104000124,'90024','เกี๊ยวกุ้งต้มยำน้ำข้นหมูก้อน',85.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 13:16:26','2019-03-12 13:16:40','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000124.jpg',NULL),(104000125,'90025','เกี๊ยวปูพริกไทยดำ',70.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 13:19:29','2019-03-12 13:19:41','0','0','0',NULL,'','',NULL,NULL,103000008,'1','1','104000125.jpg',NULL),(104000126,'11001','เต้าฮวยนมสด',20.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 13:20:29','2019-03-12 13:20:40','0','0','0',NULL,'','',NULL,NULL,103000007,'1','1','104000126.jpg',NULL),(104000127,'11002','เต้าฮวยฟรุ๊ตสลัด',20.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 13:21:08','2019-03-12 13:21:21','0','0','0',NULL,'','',NULL,NULL,103000007,'1','1','104000127.jpg',NULL),(104000128,'11003','เต้าทึง',25.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 13:21:41','2019-03-12 15:00:59','0','0','0',NULL,'','',NULL,NULL,103000007,'1','1','104000128.jpg',NULL),(104000129,'11004','สละ',25.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 13:22:30','2019-03-12 13:22:45','0','0','0',NULL,'','',NULL,NULL,103000007,'1','1','104000129.jpg',NULL),(104000130,'11005','กระท้อน',25.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 13:23:05','2019-03-12 13:23:15','0','0','0',NULL,'','',NULL,NULL,103000007,'1','1','104000130.jpg',NULL),(104000131,'11006','ลูกตาลใบเตย',25.00,'1',102000007,'','1','','1','POS80 PRO','2019-03-12 13:23:41','2019-03-12 13:24:03','0','0','0',NULL,'','',NULL,NULL,103000007,'1','1','104000131.jpg',NULL),(104000132,'11007','เปียกปูนกะทิสด',25.00,'1',102000010,'','1','','1','POS80 PRO','2019-03-12 13:25:25','2019-03-12 14:08:01','0','0','0',NULL,'','',NULL,NULL,103000007,'1','1','104000132.jpg',NULL),(104000133,'11008','ครองแครงมะพร้าวอ่อน',30.00,'1',102000010,'','1','','1','POS80 PRO','2019-03-12 13:25:58','2019-03-12 14:07:48','0','0','0',NULL,'','',NULL,NULL,103000007,'1','1','104000133.jpg',NULL),(104000134,'11009','มะม่วงน้ำดอกไม้ลอยแก้ว',40.00,'1',102000010,'','1','','1','POS80 PRO','2019-03-12 13:26:46','2019-03-12 14:07:39','0','0','0',NULL,'','',NULL,NULL,103000007,'1','1','104000134.jpg',NULL),(104000135,'12001','มะตูม',20.00,'1',102000001,'','1','','1','POS80 PRO','2019-03-12 13:29:46','2019-03-12 14:06:53','0','0','0',NULL,'','',NULL,NULL,103000009,'1','1','104000135.jpg',NULL),(104000136,'12002','ชาดำเย็น',20.00,'1',102000002,'','1','','1','POS80 PRO','2019-03-12 13:30:26','2019-03-12 13:30:43','0','0','0',NULL,'','',NULL,NULL,103000009,'1','1','104000136.jpg',NULL),(104000137,'12003','โอเลี้ยง',20.00,'1',102000001,'','1','','1','POS80 PRO','2019-03-12 14:06:28','2019-03-12 14:06:42','0','0','0',NULL,'','',NULL,NULL,103000009,'1','1','104000137.jpg',NULL),(104000138,'12004','เก๊กฮวย',20.00,'1',102000001,'','1','','1','POS80 PRO','2019-03-12 14:08:29','2019-03-12 14:08:51','0','0','0',NULL,'','',NULL,NULL,103000009,'1','1','104000138.jpg',NULL),(104000139,'12005','ชาเย็นโบราณ',25.00,'1',102000001,'','1','','1','POS80 PRO','2019-03-12 14:09:16','2019-03-12 14:09:33','0','0','0',NULL,'','',NULL,NULL,103000009,'1','1','104000139.jpg',NULL),(104000140,'12006','กาแฟโบราณ',25.00,'1',102000011,'','1','','1','POS80 PRO','2019-03-12 14:09:48','2019-03-12 14:10:13','0','0','0',NULL,'','',NULL,NULL,103000009,'1','1','104000140.jpg',NULL),(104000141,'12007','ชามะนาว',25.00,'1',NULL,'',NULL,'','1','POS80 PRO','2019-03-12 14:11:17',NULL,'0','0','0',NULL,'',NULL,NULL,NULL,103000009,'1','1','104000141.jpg',NULL),(104000142,'12008','น้ำจับเลี้ยง',25.00,'1',102000001,'','1','','1','POS80 PRO','2019-03-12 14:11:39','2019-03-12 14:11:59','0','0','0',NULL,'','',NULL,NULL,103000009,'1','1','104000142.jpg',NULL),(104000143,'12009','น้ำมะนาว',25.00,'1',102000001,'','1','','1','POS80 PRO','2019-03-12 14:12:26','2019-03-12 14:12:52','0','0','0',NULL,'','',NULL,NULL,103000009,'1','1','104000143.jpg',NULL),(104000144,'12010','น้ำส้ม',25.00,'1',102000001,'','1','','1','POS80 PRO','2019-03-12 14:13:03','2019-03-12 14:13:31','0','0','0',NULL,'','',NULL,NULL,103000009,'1','1','104000144.jpg',NULL);
/*!40000 ALTER TABLE `b_foods` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_foods_category`
--

DROP TABLE IF EXISTS `b_foods_category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_foods_category` (
  `foods_cat_id` int(11) NOT NULL AUTO_INCREMENT,
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
  PRIMARY KEY (`foods_cat_id`)
) ENGINE=MyISAM AUTO_INCREMENT=103000013 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=103';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_foods_category`
--

LOCK TABLES `b_foods_category` WRITE;
/*!40000 ALTER TABLE `b_foods_category` DISABLE KEYS */;
INSERT INTO `b_foods_category` VALUES (103000000,'C100','ข้าวราด จานเดียว','1','',NULL,'2019-02-25 17:01:37','2019-02-26 17:49:45','0','0','0',NULL,'','',NULL,NULL),(103000001,'C101','ก๋วยเตี่ยว','1','',NULL,'2019-02-26 17:49:20',NULL,'0','0','0',NULL,'',NULL,NULL,NULL),(103000002,'C102','กับข้าว เป็นอย่างๆ','1','',NULL,'2019-02-26 17:50:08',NULL,'0','0','0',NULL,'',NULL,NULL,NULL),(103000003,'C103','บะหมี่','1','',NULL,'2019-02-26 17:50:26',NULL,'0','0','0',NULL,'',NULL,NULL,NULL),(103000004,'C104','ข้าวต้ม','1','',NULL,'2019-02-26 17:50:42',NULL,'0','0','0',NULL,'',NULL,NULL,NULL),(103000005,'C105','ลวกจิ้ม','1','',NULL,'2019-02-26 17:51:03',NULL,'0','0','0',NULL,'',NULL,NULL,NULL),(103000006,'C106','เกาเหลา','1','',NULL,'2019-02-26 17:51:16',NULL,'0','0','0',NULL,'',NULL,NULL,NULL),(103000007,'C107','ของหวาน','1','',NULL,'2019-02-26 17:51:30',NULL,'0','0','0',NULL,'',NULL,NULL,NULL),(103000008,'C108','เกี๊ยว','1','',NULL,'2019-03-11 16:24:52','2019-03-11 16:25:37','0','0','0',NULL,'','',NULL,NULL),(103000009,'C109','เครื่องดื่ม','1','',NULL,'2019-03-11 16:26:13',NULL,'0','0','0',NULL,'',NULL,NULL,NULL),(103000010,'C110','ซุป','1','',NULL,'2019-03-12 09:20:48',NULL,'0','0','0',NULL,'',NULL,NULL,NULL),(103000011,'C111','เส้นลวก','1','',NULL,'2019-03-12 09:22:11',NULL,'0','0','0',NULL,'',NULL,NULL,NULL),(103000012,'C112','น้ำจิ้ม','1','',NULL,'2019-03-12 09:34:44',NULL,'0','0','0',NULL,'',NULL,NULL,NULL);
/*!40000 ALTER TABLE `b_foods_category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_foods_category_sub`
--

DROP TABLE IF EXISTS `b_foods_category_sub`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_foods_category_sub` (
  `foods_cat_sub_id` int(11) NOT NULL AUTO_INCREMENT,
  `foods_cat_sub_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `foods_cat_sub_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `foods_cat_id` int(11) DEFAULT NULL,
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
-- Table structure for table `b_foods_recommend`
--

DROP TABLE IF EXISTS `b_foods_recommend`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_foods_recommend` (
  `recom_id` int(11) NOT NULL AUTO_INCREMENT,
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
  `foods_spec_id` int(11) NOT NULL AUTO_INCREMENT,
  `foods_id` int(11) DEFAULT NULL,
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
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=110';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_foods_special`
--

LOCK TABLES `b_foods_special` WRITE;
/*!40000 ALTER TABLE `b_foods_special` DISABLE KEYS */;
INSERT INTO `b_foods_special` VALUES (1,104000001,'ไม่งอก','1','','2019-03-15 11:57:37',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD'),(2,104000001,'หมูแอย่างเดียว','1','','2019-03-15 11:58:06',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD'),(3,104000001,'ไม่ใส่ผงชูรส','1','','2019-03-15 11:58:28',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD'),(4,104000006,'ไม่ราดน้ำ','1','','2019-04-04 11:00:08',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD'),(5,104000006,'','1','','2019-04-04 11:20:22',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD'),(6,104000006,'ไม่หวาน','1','','2019-04-04 11:21:23',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD');
/*!40000 ALTER TABLE `b_foods_special` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `b_foods_topping`
--

DROP TABLE IF EXISTS `b_foods_topping`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `b_foods_topping` (
  `foods_topping_id` int(11) NOT NULL AUTO_INCREMENT,
  `foods_id` int(11) DEFAULT NULL,
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
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=111';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `b_foods_topping`
--

LOCK TABLES `b_foods_topping` WRITE;
/*!40000 ALTER TABLE `b_foods_topping` DISABLE KEYS */;
INSERT INTO `b_foods_topping` VALUES (1,104000001,'เพิ่มลูกชิ้นหมู',10.00,'1','','2019-03-15 11:58:52',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD'),(2,104000001,'เพิ่มเกี้ยวทอด',5.00,'1','','2019-03-15 11:59:08',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD'),(3,104000001,'เพิ่มลูกชิ้นปลา',20.00,'1','','2019-03-15 11:59:29',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD'),(4,104000006,'พิเศษ',10.00,'1','','2019-04-04 11:21:53',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD'),(5,104000006,'พิเศษหมูกรอบ',10.00,'1','','2019-04-04 11:22:15',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD'),(6,104000006,'พิเศษไก่',10.00,'1','','2019-04-04 11:22:45',NULL,NULL,'',NULL,NULL,'','','9C305B23F7CD');
/*!40000 ALTER TABLE `b_foods_topping` ENABLE KEYS */;
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
  `printer_id` int(11) NOT NULL AUTO_INCREMENT,
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
INSERT INTO `b_restaurant` VALUES (1,'100','ร้านพริกสด','1','','2019-02-25 15:33:57',NULL,'1','THank You na ka','RECEIPT','http://www.counterplus.com','TAX :','','','','','','','','','',NULL,'0','0',NULL,'',NULL,NULL,'0',NULL,NULL,NULL,NULL,NULL,0,0,300,5,5,300,NULL,NULL);
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
-- Table structure for table `f_prefix`
--

DROP TABLE IF EXISTS `f_prefix`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `f_prefix` (
  `f_prefix_id` int(11) NOT NULL AUTO_INCREMENT,
  `prefix_description` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `f_sex_id` int(11) DEFAULT NULL,
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
  `f_sex_id` int(11) NOT NULL AUTO_INCREMENT,
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
  `date_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`bill_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1070000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=107';
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
  `date_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `device_id` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`bill_detail_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1080000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=108';
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
-- Table structure for table `t_order`
--

DROP TABLE IF EXISTS `t_order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `t_order` (
  `order_id` int(11) NOT NULL,
  `lot_id` int(11) DEFAULT NULL,
  `row1` int(11) DEFAULT NULL,
  `foods_id` int(11) DEFAULT NULL,
  `foods_code` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `foods_name` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `order_date` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `price` decimal(10,0) DEFAULT NULL,
  `qty` decimal(10,0) DEFAULT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `table_id` int(11) DEFAULT NULL,
  `res_id` int(11) DEFAULT NULL,
  `area_id` int(11) DEFAULT NULL,
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
  `closeday_id` int(11) DEFAULT NULL,
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
  PRIMARY KEY (`order_id`)
) ENGINE=MyISAM AUTO_INCREMENT=1060000000 DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='id=106';
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

--
-- Table structure for table `vne_response_payment`
--

DROP TABLE IF EXISTS `vne_response_payment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `vne_response_payment` (
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
) ENGINE=MyISAM AUTO_INCREMENT=136 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vne_response_payment`
--

LOCK TABLES `vne_response_payment` WRITE;
/*!40000 ALTER TABLE `vne_response_payment` DISABLE KEYS */;
INSERT INTO `vne_response_payment` VALUES (1,'1544051528142','2000','1','2000','1',NULL,'2018-12-06 06:12:09',NULL,NULL,'admin',NULL,NULL),(2,'1544062108143','2000','1','2000','1',NULL,'2018-12-06 09:08:31',NULL,NULL,'admin',NULL,NULL),(3,'1544062144144','2000','1','2000','1',NULL,'2018-12-06 09:09:06',NULL,NULL,'admin',NULL,NULL),(4,'1544062244145','2000','1','2000','1',NULL,'2018-12-06 09:10:46',NULL,NULL,'admin',NULL,NULL),(5,'1544062349146','1000','1','1000','1',NULL,'2018-12-06 09:12:30',NULL,NULL,'admin',NULL,NULL),(6,'1544062636147','1200','1','1200','1',NULL,'2018-12-06 09:17:17',NULL,NULL,'admin',NULL,NULL),(7,'1544062713148','12000','1','12000','1',NULL,'2018-12-06 09:18:35',NULL,NULL,'admin',NULL,NULL),(8,'1544062810149','1200','1','1200','1',NULL,'2018-12-06 09:20:11',NULL,NULL,'admin',NULL,NULL),(9,'1544063901150','200','1','200','1',NULL,'2018-12-06 09:38:23',NULL,NULL,'admin',NULL,NULL),(10,'1544064144151','20000','1','20000','1',NULL,'2018-12-06 09:42:26',NULL,NULL,'admin',NULL,NULL),(11,'1544141069152','1200','1','1200','1',NULL,'2018-12-07 07:04:32',NULL,NULL,'admin',NULL,NULL),(12,'1544141080153','1300','1','1300','1',NULL,'2018-12-07 07:04:41',NULL,NULL,'admin',NULL,NULL),(13,'1544146531154','1400','1','1400','1',NULL,'2018-12-07 08:35:34',NULL,NULL,'admin',NULL,NULL),(14,'1544146750155','1500','1','1500','1',NULL,'2018-12-07 08:39:13',NULL,NULL,'admin',NULL,NULL),(15,'1544148300156','1600','1','1600','1',NULL,'2018-12-07 09:05:02',NULL,NULL,'admin',NULL,NULL),(16,'1544148480157','1700','1','1700','1',NULL,'2018-12-07 09:08:02',NULL,NULL,'admin',NULL,NULL),(17,'1544151715158','200','1','200','1',NULL,'2018-12-07 10:01:59',NULL,NULL,'admin',NULL,NULL),(18,'1544270440159','100000','1','100000','1',NULL,'2018-12-08 19:00:43',NULL,NULL,'admin',NULL,NULL),(19,'1544270460160','110000','1','110000','1',NULL,'2018-12-08 19:01:02',NULL,NULL,'admin',NULL,NULL),(20,'1544270477161','120000','1','120000','1',NULL,'2018-12-08 19:01:19',NULL,NULL,'admin',NULL,NULL),(21,'','','','','1',NULL,'2018-12-11 09:29:58',NULL,NULL,'admin',NULL,NULL),(22,'1544495665162','20','1','20','1',NULL,'2018-12-11 09:34:28',NULL,NULL,'admin',NULL,NULL),(23,'1544495693163','2000','1','2000','1',NULL,'2018-12-11 09:34:56',NULL,NULL,'admin',NULL,NULL),(24,'1544495717164','2000','1','2000','1',NULL,'2018-12-11 09:35:20',NULL,NULL,'admin',NULL,NULL),(25,'1544495724165','2000','1','2000','1',NULL,'2018-12-11 09:35:26',NULL,NULL,'admin',NULL,NULL),(26,'1544496813166','2000','1','2000','1',NULL,'2018-12-11 09:53:36',NULL,NULL,'admin',NULL,NULL),(27,'1544499811167','200000','1','200000','1',NULL,'2018-12-11 10:43:33',NULL,NULL,'admin',NULL,NULL),(28,'1544500132168','130000','1','130000','1',NULL,'2018-12-11 10:48:55',NULL,NULL,'admin',NULL,NULL),(29,'1544510075169','140000','1','140000','1',NULL,'2018-12-11 13:34:38',NULL,NULL,'admin',NULL,NULL),(30,'1544510371170','150000','1','150000','1',NULL,'2018-12-11 13:39:34',NULL,NULL,'admin',NULL,NULL),(31,'1544510723171','160000','1','160000','1',NULL,'2018-12-11 13:45:26',NULL,NULL,'admin',NULL,NULL),(32,'1544511621172','191200','1','191200','1',NULL,'2018-12-11 14:00:25',NULL,NULL,'admin',NULL,NULL),(33,'1544515601176','211200','1','211200','1',NULL,'2018-12-11 15:06:44',NULL,NULL,'admin',NULL,NULL),(34,'1544845017177','123400','1','123400','1',NULL,'2018-12-15 10:37:05',NULL,NULL,'admin',NULL,NULL),(35,'1544845493178','123000','1','123000','1',NULL,'2018-12-15 10:44:58',NULL,NULL,'admin',NULL,NULL),(36,'1544845544179','169900','1','169900','1',NULL,'2018-12-15 10:45:49',NULL,NULL,'admin',NULL,NULL),(37,'1544845640180','2000','1','2000','1',NULL,'2018-12-15 10:47:24',NULL,NULL,'admin',NULL,NULL),(38,'1545026746186','123000','1','123000','1',NULL,'2018-12-17 13:05:52',NULL,NULL,'admin',NULL,NULL),(39,'1545027217187','123000','1','123000','1',NULL,'2018-12-17 13:13:43',NULL,NULL,'admin',NULL,NULL),(40,'1545027268188','123000','1','123000','1',NULL,'2018-12-17 13:14:52',NULL,NULL,'admin',NULL,NULL),(41,'1545029511189','123000','1','123000','1',NULL,'2018-12-17 13:51:56',NULL,NULL,'admin',NULL,NULL),(42,'1545029671190','1230000','1','1230000','1',NULL,'2018-12-17 13:54:36',NULL,NULL,'admin',NULL,NULL),(43,'1545030307191','500','1','500','1',NULL,'2018-12-17 14:05:12',NULL,NULL,'admin',NULL,NULL),(44,'1545030702192','500','1','500','1',NULL,'2018-12-17 14:11:47',NULL,NULL,'admin',NULL,NULL),(45,'1545050280193','123000','1','123000','1',NULL,'2018-12-17 19:38:06',NULL,NULL,'admin',NULL,NULL),(46,'','','','','1',NULL,'2019-01-05 09:35:03',NULL,NULL,'admin',NULL,NULL),(47,'','','','','1',NULL,'2019-01-05 09:35:03',NULL,NULL,'admin',NULL,NULL),(48,'','','','','1',NULL,'2019-01-05 09:35:03',NULL,NULL,'admin',NULL,NULL),(49,'','','','','1',NULL,'2019-01-05 09:35:03',NULL,NULL,'admin',NULL,NULL),(50,'','','','','1',NULL,'2019-01-05 09:35:03',NULL,NULL,'admin',NULL,NULL),(51,'','','','','1',NULL,'2019-01-05 09:35:03',NULL,NULL,'admin',NULL,NULL),(52,'','','','','1',NULL,'2019-01-05 09:35:04',NULL,NULL,'admin',NULL,NULL),(53,'1546656332235','1200','1','1200','1',NULL,'2019-01-05 09:45:32',NULL,NULL,'admin',NULL,NULL),(54,'1546656403236','1200','1','1200','1',NULL,'2019-01-05 09:46:41',NULL,NULL,'admin',NULL,NULL),(55,'1546656405237','1200','1','1200','1',NULL,'2019-01-05 09:46:44',NULL,NULL,'admin',NULL,NULL),(56,'1546942091238','20000','1','20000','1',NULL,'2019-01-08 17:08:08',NULL,NULL,'admin',NULL,NULL),(57,'1546942783239','50000','1','50000','1',NULL,'2019-01-08 17:19:44',NULL,NULL,'admin',NULL,NULL),(58,'1546942847240','80000','1','80000','1',NULL,'2019-01-08 17:20:48',NULL,NULL,'admin',NULL,NULL),(59,'1547105917242','53','1','53','1',NULL,'2019-01-10 14:38:39',NULL,NULL,'admin',NULL,NULL),(60,'1547105920243','53','1','53','1',NULL,'2019-01-10 14:38:40',NULL,NULL,'admin',NULL,NULL),(61,'1547105920244','53','1','53','1',NULL,'2019-01-10 14:38:40',NULL,NULL,'admin',NULL,NULL),(62,'1547105934245','534','1','534','1',NULL,'2019-01-10 14:38:54',NULL,NULL,'admin',NULL,NULL),(63,'1547105968246','53400','1','53400','1',NULL,'2019-01-10 14:39:28',NULL,NULL,'admin',NULL,NULL),(64,'1547105970247','53400','1','53400','1',NULL,'2019-01-10 14:39:30',NULL,NULL,'admin',NULL,NULL),(65,'1551326147273','16500','1','16500','1',NULL,'2019-02-28 10:55:13',NULL,NULL,'admin',NULL,NULL),(66,'1551326950274','16500','1','16500','1',NULL,'2019-02-28 11:08:35',NULL,NULL,'admin',NULL,NULL),(67,'1551327092275','5500','1','5500','1',NULL,'2019-02-28 11:10:58',NULL,NULL,'admin',NULL,NULL),(68,'1551327279276','11000','1','11000','1',NULL,'2019-02-28 11:14:05',NULL,NULL,'admin',NULL,NULL),(69,'1551327586277','5500','1','5500','1',NULL,'2019-02-28 11:19:12',NULL,NULL,'admin',NULL,NULL),(70,'1551327892278','5500','1','5500','1',NULL,'2019-02-28 11:24:18',NULL,NULL,'admin',NULL,NULL),(71,'','','','','1',NULL,'2019-02-28 11:26:54',NULL,NULL,'admin',NULL,NULL),(72,'1551328192279','5500','1','5500','1',NULL,'2019-02-28 11:29:18',NULL,NULL,'admin',NULL,NULL),(73,'1551328603280','5500','1','5500','1',NULL,'2019-02-28 11:36:09',NULL,NULL,'admin',NULL,NULL),(74,'1551328764281','5500','1','5500','1',NULL,'2019-02-28 11:38:50',NULL,NULL,'admin',NULL,NULL),(75,'1551328975282','5500','1','5500','1',NULL,'2019-02-28 11:42:21',NULL,NULL,'admin',NULL,NULL),(76,'1551331497283','5500','1','5500','1',NULL,'2019-02-28 12:24:22',NULL,NULL,'admin',NULL,NULL),(77,'1551337467284','5500','1','5500','1',NULL,'2019-02-28 14:03:53',NULL,NULL,'admin',NULL,NULL),(78,'1551337601285','27500','1','27500','1',NULL,'2019-02-28 14:06:07',NULL,NULL,'admin',NULL,NULL),(79,'1551406850286','27500','1','27500','1',NULL,'2019-03-01 09:20:16',NULL,NULL,'admin',NULL,NULL),(80,'1551840892287','22500','1','22500','1',NULL,'2019-03-06 09:54:23',NULL,NULL,'admin',NULL,NULL),(81,'1551840893288','22500','1','22500','1',NULL,'2019-03-06 09:54:23',NULL,NULL,'admin',NULL,NULL),(82,'1551845191289','22500','1','22500','1',NULL,'2019-03-06 11:06:01',NULL,NULL,'admin',NULL,NULL),(83,'1551845192290','22500','1','22500','1',NULL,'2019-03-06 11:06:02',NULL,NULL,'admin',NULL,NULL),(84,'1552294833291','50000','1','50000','1',NULL,'2019-03-11 16:00:06',NULL,NULL,'admin',NULL,NULL),(85,'1552373119292','10000','1','10000','1',NULL,'2019-03-12 13:44:52',NULL,NULL,'admin',NULL,NULL),(86,'1552459629293','50000','1','50000','1',NULL,'2019-03-13 13:46:44',NULL,NULL,'admin',NULL,NULL),(87,'1552466725294','50000','1','50000','1',NULL,'2019-03-13 15:44:43',NULL,NULL,'admin',NULL,NULL),(88,'1552471560295','10000','1','10000','1',NULL,'2019-03-13 17:05:36',NULL,NULL,'admin',NULL,NULL),(89,'1552471589296','20000','1','20000','1',NULL,'2019-03-13 17:05:45',NULL,NULL,'admin',NULL,NULL),(90,'1552558805297','10000','1','10000','1',NULL,'2019-03-14 17:19:28',NULL,NULL,'admin',NULL,NULL),(91,'1552640453298','139500','1','139500','1',NULL,'2019-03-15 16:00:27',NULL,NULL,'admin',NULL,NULL),(92,'1552640659299','33500','1','33500','1',NULL,'2019-03-15 16:03:52',NULL,NULL,'admin',NULL,NULL),(93,'1552640907300','18000','1','18000','1',NULL,'2019-03-15 16:08:01',NULL,NULL,'admin',NULL,NULL),(94,'1552884462301','2000','1','2000','1',NULL,'2019-03-18 11:47:17',NULL,NULL,'admin',NULL,NULL),(95,'1552884563302','5000','1','5000','1',NULL,'2019-03-18 11:48:58',NULL,NULL,'admin',NULL,NULL),(96,'1552890638303','500000000','1','500000000','1',NULL,'2019-03-18 13:30:12',NULL,NULL,'admin',NULL,NULL),(97,'1552890745304','50000000000','1','50000000000','1',NULL,'2019-03-18 13:32:00',NULL,NULL,'admin',NULL,NULL),(98,'1552890779305','50000000000','1','50000000000','1',NULL,'2019-03-18 13:32:33',NULL,NULL,'admin',NULL,NULL),(99,'1552894420307','120500','1','120500','1',NULL,'2019-03-18 14:33:15',NULL,NULL,'admin',NULL,NULL),(100,'1552894425308','120500','1','120500','1',NULL,'2019-03-18 14:33:19',NULL,NULL,'admin',NULL,NULL),(101,'1552895297309','7000','1','7000','1',NULL,'2019-03-18 14:47:51',NULL,NULL,'admin',NULL,NULL),(102,'1552903059312','117000','1','117000','1',NULL,'2019-03-18 16:57:13',NULL,NULL,'admin',NULL,NULL),(103,'1552967998313','24000','1','24000','1',NULL,'2019-03-19 10:59:33',NULL,NULL,'admin',NULL,NULL),(104,'1552968002314','24000','1','24000','1',NULL,'2019-03-19 10:59:37',NULL,NULL,'admin',NULL,NULL),(105,'1553057053315','12000','1','12000','1',NULL,'2019-03-20 11:43:48',NULL,NULL,'admin',NULL,NULL),(106,'1553057808316','12500','1','12500','1',NULL,'2019-03-20 11:56:23',NULL,NULL,'admin',NULL,NULL),(107,'1553058158317','25500','1','25500','1',NULL,'2019-03-20 12:02:13',NULL,NULL,'admin',NULL,NULL),(108,'1553058515318','11500','1','11500','1',NULL,'2019-03-20 12:08:10',NULL,NULL,'admin',NULL,NULL),(109,'1553065935319','11500','1','11500','1',NULL,'2019-03-20 14:11:51',NULL,NULL,'admin',NULL,NULL),(110,'1553065972320','11500','1','11500','1',NULL,'2019-03-20 14:12:28',NULL,NULL,'admin',NULL,NULL),(111,'1553066023321','11500','1','11500','1',NULL,'2019-03-20 14:13:18',NULL,NULL,'admin',NULL,NULL),(112,'1553066028322','11500','1','11500','1',NULL,'2019-03-20 14:13:24',NULL,NULL,'admin',NULL,NULL),(113,'1553066052323','11500','1','11500','1',NULL,'2019-03-20 14:13:47',NULL,NULL,'admin',NULL,NULL),(114,'1553066127324','11500','1','11500','1',NULL,'2019-03-20 14:15:02',NULL,NULL,'admin',NULL,NULL),(115,'1553066165325','11500','1','11500','1',NULL,'2019-03-20 14:15:40',NULL,NULL,'admin',NULL,NULL),(116,'1553066208326','50500','1','50500','1',NULL,'2019-03-20 14:16:23',NULL,NULL,'admin',NULL,NULL),(117,'1553152568331','24000','1','24000','1',NULL,'2019-03-21 14:15:45',NULL,NULL,'admin',NULL,NULL),(118,'1553153188332','42000','1','42000','1',NULL,'2019-03-21 14:26:04',NULL,NULL,'admin',NULL,NULL),(119,'1553157992333','16500','1','16500','1',NULL,'2019-03-21 15:46:08',NULL,NULL,'admin',NULL,NULL),(120,'1553158171334','21500','1','21500','1',NULL,'2019-03-21 15:49:07',NULL,NULL,'admin',NULL,NULL),(121,'1553158277335','14500','1','14500','1',NULL,'2019-03-21 15:50:53',NULL,NULL,'admin',NULL,NULL),(122,'1553159285336','24500','1','24500','1',NULL,'2019-03-21 16:07:41',NULL,NULL,'admin',NULL,NULL),(123,'1553221107338','26500','1','26500','1',NULL,'2019-03-22 09:18:03',NULL,NULL,'admin',NULL,NULL),(124,'1553222276339','6000','1','6000','1',NULL,'2019-03-22 09:37:32',NULL,NULL,'admin',NULL,NULL),(125,'1553234443340','19000','1','19000','1',NULL,'2019-03-22 13:00:19',NULL,NULL,'admin',NULL,NULL),(126,'1553234595341','18000','1','18000','1',NULL,'2019-03-22 13:02:51',NULL,NULL,'admin',NULL,NULL),(127,'1553482584343','52200','1','52200','1',NULL,'2019-03-25 09:56:01',NULL,NULL,'admin',NULL,NULL),(128,'1553650270344','6000','1','6000','1',NULL,'2019-03-27 08:30:47',NULL,NULL,'admin',NULL,NULL),(129,'1553650709345','6000','1','6000','1',NULL,'2019-03-27 08:38:06',NULL,NULL,'admin',NULL,NULL),(130,'1553650937346','5000','1','5000','1',NULL,'2019-03-27 08:41:54',NULL,NULL,'admin',NULL,NULL),(131,'1553655052347','11500','1','11500','1',NULL,'2019-03-27 09:50:29',NULL,NULL,'admin',NULL,NULL),(132,'1553655825348','11500','1','11500','1',NULL,'2019-03-27 10:03:22',NULL,NULL,'admin',NULL,NULL),(133,'1553656217349','11500','1','11500','1',NULL,'2019-03-27 10:09:53',NULL,NULL,'admin',NULL,NULL),(134,'1553741381350','10000','1','10000','1',NULL,'2019-03-28 09:49:18',NULL,NULL,'admin',NULL,NULL),(135,'1553762040351','12500','1','12500','1',NULL,'2019-03-28 15:33:39',NULL,NULL,'admin',NULL,NULL);
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

-- Dump completed on 2019-04-09  9:23:59
