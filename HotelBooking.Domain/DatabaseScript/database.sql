-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         8.0.30 - MySQL Community Server - GPL
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.1.0.6537
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para hotel_booking
DROP DATABASE IF EXISTS `hotel_booking`;
CREATE DATABASE IF NOT EXISTS `hotel_booking` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `hotel_booking`;

-- Volcando estructura para tabla hotel_booking.guests
DROP TABLE IF EXISTS `guests`;
CREATE TABLE IF NOT EXISTS `guests` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FirstName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Gender` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DocumentType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DocumentNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PhoneNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla hotel_booking.guests: ~0 rows (aproximadamente)
DELETE FROM `guests`;
INSERT INTO `guests` (`Id`, `FirstName`, `LastName`, `Gender`, `DocumentType`, `DocumentNumber`, `Email`, `PhoneNumber`) VALUES
	(1, 'Santiago', 'Garcia', 'Masculino', 'CC', '1001725771', 'sasty11234@gmail.com', '3143516714'),
	(6, 'Santiago', 'Garcia', 'Masculino', 'CC', '1001725771', 'sasty11234@gmail.com', '3143516714');

-- Volcando estructura para tabla hotel_booking.hotels
DROP TABLE IF EXISTS `hotels`;
CREATE TABLE IF NOT EXISTS `hotels` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Address` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `City` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CommissionRate` decimal(65,30) NOT NULL,
  `IsActive` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla hotel_booking.hotels: ~2 rows (aproximadamente)
DELETE FROM `hotels`;
INSERT INTO `hotels` (`Id`, `Name`, `Address`, `City`, `CommissionRate`, `IsActive`) VALUES
	(1, 'DUBAI', 'CALLE 30', 'CARTAGENA', 1.000000000000000000000000000000, 1),
	(2, 'SUNRISE', 'Calle 20', 'Cartagena', 1.000000000000000000000000000000, 1);

-- Volcando estructura para tabla hotel_booking.reservationguest
DROP TABLE IF EXISTS `reservationguest`;
CREATE TABLE IF NOT EXISTS `reservationguest` (
  `GuestId` int NOT NULL,
  `ReservationId` int NOT NULL,
  PRIMARY KEY (`GuestId`,`ReservationId`),
  KEY `IX_ReservationGuest_ReservationId` (`ReservationId`),
  CONSTRAINT `FK_ReservationGuest_Guests_GuestId` FOREIGN KEY (`GuestId`) REFERENCES `guests` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_ReservationGuest_Reservations_ReservationId` FOREIGN KEY (`ReservationId`) REFERENCES `reservations` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla hotel_booking.reservationguest: ~1 rows (aproximadamente)
DELETE FROM `reservationguest`;
INSERT INTO `reservationguest` (`GuestId`, `ReservationId`) VALUES
	(6, 1);

-- Volcando estructura para tabla hotel_booking.reservations
DROP TABLE IF EXISTS `reservations`;
CREATE TABLE IF NOT EXISTS `reservations` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `HotelId` int NOT NULL,
  `RoomId` int NOT NULL,
  `CheckInDate` datetime(6) NOT NULL,
  `CheckOutDate` datetime(6) NOT NULL,
  `TotalPrice` decimal(65,30) NOT NULL,
  `Status` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `nameContactEmergency` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `phoneContactEmergency` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Reservations_HotelId` (`HotelId`),
  KEY `IX_Reservations_RoomId` (`RoomId`),
  CONSTRAINT `FK_Reservations_Hotels_HotelId` FOREIGN KEY (`HotelId`) REFERENCES `hotels` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Reservations_Rooms_RoomId` FOREIGN KEY (`RoomId`) REFERENCES `rooms` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla hotel_booking.reservations: ~1 rows (aproximadamente)
DELETE FROM `reservations`;
INSERT INTO `reservations` (`Id`, `HotelId`, `RoomId`, `CheckInDate`, `CheckOutDate`, `TotalPrice`, `Status`, `nameContactEmergency`, `phoneContactEmergency`) VALUES
	(1, 1, 2, '2025-02-17 14:00:00.000000', '2025-02-20 12:00:00.000000', 8000.000000000000000000000000000000, 'Pending', 'algo de aca', 'algo de aca');

-- Volcando estructura para tabla hotel_booking.rooms
DROP TABLE IF EXISTS `rooms`;
CREATE TABLE IF NOT EXISTS `rooms` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `HotelId` int NOT NULL,
  `Type` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `BasePrice` decimal(65,30) NOT NULL,
  `Taxes` decimal(65,30) NOT NULL,
  `IsAvailable` tinyint(1) NOT NULL,
  `Location` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Capacity` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Rooms_HotelId` (`HotelId`),
  CONSTRAINT `FK_Rooms_Hotels_HotelId` FOREIGN KEY (`HotelId`) REFERENCES `hotels` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla hotel_booking.rooms: ~2 rows (aproximadamente)
DELETE FROM `rooms`;
INSERT INTO `rooms` (`Id`, `HotelId`, `Type`, `BasePrice`, `Taxes`, `IsAvailable`, `Location`, `Capacity`) VALUES
	(1, 1, 'lodge', 2000.000000000000000000000000000000, 19.000000000000000000000000000000, 1, '101', 10),
	(2, 1, 'lodgeLarge', 4000.000000000000000000000000000000, 19.000000000000000000000000000000, 1, '102', 20);

-- Volcando estructura para tabla hotel_booking.users
DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Role` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla hotel_booking.users: ~0 rows (aproximadamente)
DELETE FROM `users`;
INSERT INTO `users` (`Id`, `Name`, `Email`, `PasswordHash`, `Role`) VALUES
	(2, 'santiago', 'sasty11234@gmail.com', '$2a$11$y1/JRnKXx4z5U0endnKiheASpxxS846XktWwl9B4f8RY1UKngpoNe', 'Agent');

-- Volcando estructura para tabla hotel_booking.__efmigrationshistory
DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Volcando datos para la tabla hotel_booking.__efmigrationshistory: ~1 rows (aproximadamente)
DELETE FROM `__efmigrationshistory`;
INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
	('20250217031451_InitialCreate', '8.0.13');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
