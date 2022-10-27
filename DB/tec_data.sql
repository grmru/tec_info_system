-- --------------------------------------------------------
-- Хост:                         127.0.0.1
-- Версия сервера:               10.3.36-MariaDB - mariadb.org binary distribution
-- Операционная система:         Win64
-- HeidiSQL Версия:              11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Дамп структуры базы данных tec_data
DROP DATABASE IF EXISTS `tec_data`;
CREATE DATABASE IF NOT EXISTS `tec_data` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `tec_data`;

-- Дамп структуры для таблица tec_data.clients
DROP TABLE IF EXISTS `clients`;
CREATE TABLE IF NOT EXISTS `clients` (
  `id` int(11) DEFAULT NULL,
  `type` varchar(64) DEFAULT NULL,
  `firstname` varchar(128) DEFAULT NULL,
  `surname` varchar(128) DEFAULT NULL,
  `patronymic` varchar(128) DEFAULT NULL,
  `company_fullname` varchar(256) DEFAULT NULL,
  `company_shortname` varchar(128) DEFAULT NULL,
  `phone` varchar(64) DEFAULT NULL,
  `company_ogrn` varchar(64) DEFAULT NULL,
  `company_inn` varchar(64) DEFAULT NULL,
  `adress` varchar(256) DEFAULT NULL,
  `mail` varchar(128) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Дамп данных таблицы tec_data.clients: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
/*!40000 ALTER TABLE `clients` ENABLE KEYS */;

-- Дамп структуры для таблица tec_data.documents
DROP TABLE IF EXISTS `documents`;
CREATE TABLE IF NOT EXISTS `documents` (
  `id` int(11) DEFAULT NULL,
  `doc_name` varchar(256) DEFAULT NULL,
  `last_modify_date` datetime DEFAULT NULL,
  `id_author` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Для учета всех документов в системе';

-- Дамп данных таблицы tec_data.documents: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `documents` DISABLE KEYS */;
INSERT INTO `documents` (`id`, `doc_name`, `last_modify_date`, `id_author`) VALUES
	(1, 'test_doc', '2022-10-13 12:03:40', 1);
/*!40000 ALTER TABLE `documents` ENABLE KEYS */;

-- Дамп структуры для таблица tec_data.products
DROP TABLE IF EXISTS `products`;
CREATE TABLE IF NOT EXISTS `products` (
  `id` int(11) DEFAULT NULL,
  `name` varchar(128) DEFAULT NULL,
  `code` varchar(128) DEFAULT NULL,
  `type` varchar(128) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Дамп данных таблицы tec_data.products: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
/*!40000 ALTER TABLE `products` ENABLE KEYS */;

-- Дамп структуры для таблица tec_data.services
DROP TABLE IF EXISTS `services`;
CREATE TABLE IF NOT EXISTS `services` (
  `id` int(11) DEFAULT NULL,
  `name` varchar(256) DEFAULT NULL,
  `description` varchar(2048) DEFAULT NULL,
  `cost` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Дамп данных таблицы tec_data.services: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `services` DISABLE KEYS */;
/*!40000 ALTER TABLE `services` ENABLE KEYS */;

-- Дамп структуры для таблица tec_data.users
DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) DEFAULT NULL,
  `login` varchar(50) DEFAULT NULL,
  `password` varchar(64) DEFAULT NULL,
  `firstname` varchar(128) DEFAULT NULL,
  `surname` varchar(128) DEFAULT NULL,
  `patronymic` varchar(128) DEFAULT NULL,
  `position` varchar(128) DEFAULT NULL,
  `phone` varchar(64) DEFAULT NULL,
  `mail` varchar(128) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Дамп данных таблицы tec_data.users: ~0 rows (приблизительно)
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
/*!40000 ALTER TABLE `users` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
