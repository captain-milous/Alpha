-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 05, 2023 at 11:00 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `alphadb`
--

-- --------------------------------------------------------

--
-- Table structure for table `mistnost`
--

CREATE TABLE `mistnost` (
  `id` int(11) NOT NULL,
  `nazev` varchar(5) NOT NULL,
  `patro` int(11) NOT NULL,
  `typ` varchar(3) NOT NULL,
  `kmenova_uc` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `mistnost`
--

INSERT INTO `mistnost` (`id`, `nazev`, `patro`, `typ`, `kmenova_uc`) VALUES
(1, 'Uč 1', 1, 'TE', 'A1'),
(2, 'Uč 2', 1, 'TE', 'C1a'),
(3, 'Uč 3', 1, 'TE', 'C1b'),
(4, 'Uč 4', 1, 'TE', 'A3a'),
(5, 'Uč 5', 1, 'TE', 'None'),
(6, 'Uč 6', 2, 'TE', 'C1c'),
(7, 'Uč 7', 2, 'TE', 'E1'),
(8, 'Uč 8', 2, 'CV', 'None'),
(9, 'Uč 9', 2, 'TE', 'A2a'),
(10, 'Uč 10', 2, 'TE', 'A2b'),
(11, 'Uč 11', 2, 'TE', 'A3b'),
(12, 'Uč 12', 2, 'TE', 'C3a'),
(13, 'Uč 13', 2, 'TE', 'C2c'),
(14, 'Uč 14', 3, 'TE', 'E2'),
(15, 'Uč 15', 3, 'TE', 'C2a'),
(16, 'Uč 16', 3, 'TE', 'C2b'),
(17, 'Uč 17', 3, 'CV', 'None'),
(18, 'Uč 18', 3, 'CV', 'None'),
(19, 'Uč 19', 3, 'CV', 'None'),
(20, 'Uč 20', 4, 'TE', 'None'),
(21, 'Uč 21', 4, 'TE', 'A4'),
(22, 'Uč 22', 4, 'TE', 'E4'),
(23, 'Uč 23', 4, 'CV', 'C4a'),
(24, 'Uč 24', 4, 'TE', 'C4b'),
(25, 'Uč 25', 4, 'TE', 'C4c'),
(26, 'Uč 26', 4, 'TE', 'E3'),
(27, 'Uč 27', 4, 'TE', 'C3b'),
(28, 'Uč 28', 4, 'TE', 'C3c'),
(29, 'Uč 29', 4, 'TE', 'None'),
(30, 'TV', 0, 'CV', 'None');

-- --------------------------------------------------------

--
-- Table structure for table `predmet`
--

CREATE TABLE `predmet` (
  `id` int(11) NOT NULL,
  `nazev` varchar(100) NOT NULL,
  `zkratka` varchar(5) NOT NULL,
  `typ` varchar(2) NOT NULL,
  `hodin_tydne` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `predmet`
--

INSERT INTO `predmet` (`id`, `nazev`, `zkratka`, `typ`, `hodin_tydne`) VALUES
(1, 'Anglický Jazyk', 'A', 'TE', 4),
(2, 'Aplikovaná matematika', 'AM', 'TE', 2),
(3, 'Český jazyk a literatura', 'C', 'TE', 3),
(4, 'Cvičení ze správy IT (Cvičení)', 'CIT', 'CV', 2),
(5, 'Databázové systémy (Teorie)', 'DS', 'TE', 1),
(6, 'Databázové systémy (Cvičení)', 'DS', 'CV', 2),
(7, 'Matematika', 'M', 'TE', 4),
(8, 'Podnikové informační systémy (Teorie)', 'PIS', 'TE', 2),
(9, 'Podnikové informační systémy (Cvičení)', 'PIS', 'CV', 2),
(10, 'Počítačové systémy a sítě (Teorie)', 'PSS', 'TE', 1),
(11, 'Počítačové systémy a sítě (Cvičení)', 'PSS', 'CV', 2),
(12, 'Programové vybavení (Teorie)', 'PV', 'TE', 1),
(13, 'Programové vybavení (Cvičení)', 'PV', 'CV', 2),
(14, 'Technický projekt', 'TP', 'TE', 1),
(15, 'Webové aplikace (Teorie)', 'WA', 'TE', 1),
(16, 'Webové aplikace (Cvičení)', 'WA', 'CV', 2),
(17, 'Tělesná Výchova', 'TV', 'CV', 2);

-- --------------------------------------------------------

--
-- Table structure for table `ucebna`
--

CREATE TABLE `ucebna` (
  `id` int(11) NOT NULL,
  `mistnost_id` int(11) NOT NULL,
  `predmet_id` int(11) NOT NULL,
  `hodnoceni` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ucebna`
--

INSERT INTO `ucebna` (`id`, `mistnost_id`, `predmet_id`, `hodnoceni`) VALUES
(1, 30, 17, 5),
(2, 8, 11, 8),
(3, 19, 4, 6),
(4, 18, 4, 6),
(5, 17, 4, 6),
(6, 19, 6, -2),
(7, 18, 6, -2),
(8, 17, 6, 10),
(9, 19, 9, 6),
(10, 18, 9, 6),
(11, 17, 9, 2),
(12, 19, 13, 10),
(13, 18, 13, 8),
(14, 17, 13, -2),
(15, 19, 16, 2),
(16, 18, 16, 6),
(17, 17, 16, 10),
(35, 5, 1, 10),
(36, 29, 1, 10),
(37, 25, 1, 0),
(38, 24, 1, 0),
(39, 23, 1, 0),
(40, 8, 2, 20),
(41, 14, 2, -5),
(42, 25, 2, 0),
(43, 24, 2, 0),
(44, 23, 2, 0),
(45, 23, 3, 0),
(46, 24, 3, 0),
(47, 25, 3, 0),
(48, 23, 5, 0),
(49, 24, 5, 0),
(50, 25, 5, 0),
(51, 23, 7, 0),
(52, 24, 7, 0),
(53, 25, 7, 0),
(54, 20, 8, 20),
(55, 23, 8, 0),
(56, 24, 8, 0),
(57, 25, 8, 0),
(58, 8, 10, 100),
(59, 23, 10, 0),
(60, 24, 10, 0),
(61, 25, 10, 0),
(62, 23, 12, 0),
(63, 24, 12, 0),
(64, 25, 12, 0),
(65, 23, 14, 0),
(66, 24, 14, 0),
(67, 25, 14, 0),
(68, 23, 15, 0),
(69, 24, 15, 0),
(70, 25, 15, 0);

-- --------------------------------------------------------

--
-- Table structure for table `ucitel`
--

CREATE TABLE `ucitel` (
  `id` int(11) NOT NULL,
  `jmeno` varchar(20) NOT NULL,
  `zkratka` varchar(3) NOT NULL,
  `tridnictvi` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ucitel`
--

INSERT INTO `ucitel` (`id`, `jmeno`, `zkratka`, `tridnictvi`) VALUES
(1, 'Jaroslav Benda', 'Bd', 'None'),
(2, 'Lucie Brčáková', 'Bc', 'C4c'),
(3, 'Jan Hehl', 'He', 'C1c'),
(4, 'Simona Hemžalová', 'Hs', 'C2b'),
(5, 'Tomáš Juchelka', 'Ju', 'None'),
(6, 'Filip Kallmünzer', 'Kl', 'A2a'),
(7, 'Ivana Kantnerová', 'Ka', 'None'),
(8, 'Dušan Kuchařík', 'Ku', 'A3b'),
(9, 'Pavel Lopocha', 'A2b', 'A2b'),
(10, 'Ondřej Mandík', 'Ma', 'None'),
(11, 'Lukáš Masopust', 'Ms', 'C3c'),
(12, 'Jan Molič', 'Mo', 'None'),
(13, 'Mykyta Narusevych', 'Na', 'None'),
(14, 'Eva Neugebauerová', 'Ng', 'C4b'),
(15, 'Vít Nohejl', 'No', 'None'),
(16, 'Šárka Páltiková', 'Pa', 'None'),
(17, 'Jan Pavlát', 'Pv', 'None'),
(18, 'Luboš Rašek', 'Rk', 'None'),
(19, 'Alenka Reichlová', 'Re', 'C3b'),
(20, 'Martina Mušecová', 'Mu', 'None'),
(21, 'Zbyněk Ježek', 'Jz', 'None'),
(22, 'Libuše Hrabalová', 'Hr', 'A1'),
(23, 'Martin Janečka', 'Ja', 'A3a'),
(24, 'Kristina Studénková', 'Su', 'C2a'),
(25, 'Jan Šváb', 'Sv', 'C4a'),
(26, 'Vladimír Váňa', 'Vd', 'None'),
(27, 'Antonín Vobecký', 'Vc', 'None');

-- --------------------------------------------------------

--
-- Table structure for table `vyucovany_predmet`
--

CREATE TABLE `vyucovany_predmet` (
  `id` int(11) NOT NULL,
  `ucitel_id` int(11) NOT NULL,
  `predmet_id` int(11) NOT NULL,
  `hodnoceni` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `vyucovany_predmet`
--

INSERT INTO `vyucovany_predmet` (`id`, `ucitel_id`, `predmet_id`, `hodnoceni`) VALUES
(1, 19, 13, 690),
(2, 19, 12, 100),
(3, 10, 13, 1000),
(4, 10, 12, 100),
(5, 8, 17, 69),
(6, 9, 17, 90),
(32, 5, 1, 100),
(33, 16, 1, -10),
(34, 21, 1, 10),
(35, 4, 1, 50),
(36, 4, 16, 20),
(37, 6, 2, 69),
(38, 18, 2, 69),
(39, 3, 3, 100),
(40, 23, 3, 70),
(41, 24, 3, 120),
(42, 1, 4, 100),
(43, 25, 4, 69),
(44, 26, 4, 70),
(45, 7, 6, 100),
(46, 7, 5, 0),
(47, 27, 6, 50),
(48, 14, 7, 100),
(49, 20, 7, 90),
(50, 22, 7, 100),
(51, 2, 8, 0),
(52, 2, 11, 100),
(53, 15, 9, 50),
(54, 11, 10, 100),
(55, 11, 9, 90),
(56, 12, 11, 120),
(57, 17, 15, 100),
(58, 17, 16, 100),
(59, 17, 13, 100),
(60, 13, 16, 100);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `mistnost`
--
ALTER TABLE `mistnost`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `predmet`
--
ALTER TABLE `predmet`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `ucebna`
--
ALTER TABLE `ucebna`
  ADD PRIMARY KEY (`id`),
  ADD KEY `mistnost_id` (`mistnost_id`),
  ADD KEY `predmet_id2` (`predmet_id`);

--
-- Indexes for table `ucitel`
--
ALTER TABLE `ucitel`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `vyucovany_predmet`
--
ALTER TABLE `vyucovany_predmet`
  ADD PRIMARY KEY (`id`),
  ADD KEY `predmet_id` (`predmet_id`),
  ADD KEY `ucitel_id` (`ucitel_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `mistnost`
--
ALTER TABLE `mistnost`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT for table `predmet`
--
ALTER TABLE `predmet`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT for table `ucebna`
--
ALTER TABLE `ucebna`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=71;

--
-- AUTO_INCREMENT for table `ucitel`
--
ALTER TABLE `ucitel`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT for table `vyucovany_predmet`
--
ALTER TABLE `vyucovany_predmet`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=61;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `ucebna`
--
ALTER TABLE `ucebna`
  ADD CONSTRAINT `mistnost_id` FOREIGN KEY (`mistnost_id`) REFERENCES `mistnost` (`id`),
  ADD CONSTRAINT `predmet_id2` FOREIGN KEY (`predmet_id`) REFERENCES `predmet` (`id`);

--
-- Constraints for table `vyucovany_predmet`
--
ALTER TABLE `vyucovany_predmet`
  ADD CONSTRAINT `predmet_id` FOREIGN KEY (`predmet_id`) REFERENCES `predmet` (`id`),
  ADD CONSTRAINT `ucitel_id` FOREIGN KEY (`ucitel_id`) REFERENCES `ucitel` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
