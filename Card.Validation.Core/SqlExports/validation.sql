CREATE DATABASE  IF NOT EXISTS `validation` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `validation`;
-- MySQL dump 10.13  Distrib 8.0.29, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: validation
-- ------------------------------------------------------
-- Server version	8.0.29

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `card`
--

DROP TABLE IF EXISTS `card`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `card` (
  `CardRefNo` varchar(36) NOT NULL,
  `CardNumber` varchar(45) DEFAULT NULL,
  `CardCreateDate` varchar(45) DEFAULT NULL,
  `CardTypeRefNo` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`CardRefNo`),
  KEY `fk_cardtyperefno_idx` (`CardTypeRefNo`),
  CONSTRAINT `fk_cardtyperefno` FOREIGN KEY (`CardTypeRefNo`) REFERENCES `cardtype` (`CardTypeRefNo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `card`
--

LOCK TABLES `card` WRITE;
/*!40000 ALTER TABLE `card` DISABLE KEYS */;
INSERT INTO `card` VALUES ('5cd9ad18-5477-4bde-a91f-b734f8259bec','4000000000000002','2022-06-12 23:09:00','9ff306ac-97b1-4877-ad3f-ce3bf6f00ecc'),('6e16d639-1c10-4004-be2a-169ecc9e13c1','5328926163959315','2022-13-06 10:21:28','7763244f-807d-421c-be00-c9d92fc2c2d1'),('80b5df4a-e1ac-4eec-8710-183abc85fa31','371463020237948','2022-13-06 10:21:00','a7293315-eebb-41f5-b6b3-64cb98225dd1'),('8fbf1a7f-ab55-44b7-899a-5699d5afdb13','4556249301959782','2022-06-13 09:45:16','9ff306ac-97b1-4877-ad3f-ce3bf6f00ecc'),('d1340213-6986-4899-a7a0-3e21acd1fc9e','4539640491518788','2022-13-06 10:22:02','9ff306ac-97b1-4877-ad3f-ce3bf6f00ecc'),('ddf64cc9-44e6-424d-b2ab-c0293a9720de','371770223149872','2022-13-06 10:21:58','a7293315-eebb-41f5-b6b3-64cb98225dd1'),('f877d2df-f406-44cb-95da-1d6efb477744','6011860494292858','2022-13-06 10:21:22','c4e6fcf8-f79b-40d4-bca4-24827d1dbf8e');
/*!40000 ALTER TABLE `card` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cardtype`
--

DROP TABLE IF EXISTS `cardtype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cardtype` (
  `CardTypeRefNo` varchar(36) NOT NULL,
  `CardType` varchar(45) DEFAULT NULL,
  `CardCode` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`CardTypeRefNo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cardtype`
--

LOCK TABLES `cardtype` WRITE;
/*!40000 ALTER TABLE `cardtype` DISABLE KEYS */;
INSERT INTO `cardtype` VALUES ('642a791f-c5cb-4d36-934d-4f1d2a316fe7','Other','OT'),('7763244f-807d-421c-be00-c9d92fc2c2d1','MasterCard','MC'),('9ff306ac-97b1-4877-ad3f-ce3bf6f00ecc','Visa','VI'),('a7293315-eebb-41f5-b6b3-64cb98225dd1','AmericanExpress','AE'),('c4e6fcf8-f79b-40d4-bca4-24827d1dbf8e','Discover','DC');
/*!40000 ALTER TABLE `cardtype` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-06-13 10:45:53
