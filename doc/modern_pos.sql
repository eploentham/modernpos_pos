-- MySQL dump 10.13  Distrib 8.0.12, for Win64 (x86_64)
--
-- Host: localhost    Database: modern_pos
-- ------------------------------------------------------
-- Server version	8.0.12

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
-- Table structure for table `vne_request_payment`
--
use modern_pos;
DROP TABLE IF EXISTS `vne_request_payment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `vne_request_payment` (
  `request_payment_id` int(11) NOT NULL AUTO_INCREMENT,
  `tipo` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `importo` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `opname` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `operatore` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
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
  `id` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `importo` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `tipo` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `req_status` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `active` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `remark` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `date_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_create` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_modi` varchar(45) COLLATE utf8_bin DEFAULT NULL,
  `user_cancel` varchar(45) COLLATE utf8_bin DEFAULT NULL,
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

-- Dump completed on 2018-12-06  5:38:54
