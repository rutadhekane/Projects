-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 16, 2017 at 06:12 AM
-- Server version: 10.1.21-MariaDB
-- PHP Version: 5.6.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `objectcomponents`
--

-- --------------------------------------------------------

--
-- Table structure for table `objcomponent`
--

CREATE TABLE `objcomponent` (
  `sourcePos` varchar(50) NOT NULL,
  `targetPos` varchar(50) NOT NULL,
  `sourceRot` varchar(50) NOT NULL,
  `targetRot` varchar(50) NOT NULL,
  `meshName` varchar(50) NOT NULL,
  `objId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `objcomponent`
--

INSERT INTO `objcomponent` (`sourcePos`, `targetPos`, `sourceRot`, `targetRot`, `meshName`, `objId`) VALUES
('1.006,0.598,15.434', '0.922,0.87,15.647', '89.266,0.001,0.001', '89.266,0.001,0.001', 'Tabletop', 4),
('1.061,0.56,15.525', '0.909,0.631,15.8', '0.0,-94.243,0.0', '0.0,-94.243,0.0', 'Tablelegs', 4),
('0.996,0.677,15.56', '0.498,0.631,15.794', '0.0,-94.243,0.0', '0.0,-94.243,0.0', 'Tableleg2', 4),
('1.07,0.60,15.580', '0.8,0.631,15.84', '0.0,0.0,0.0', '0.0,0.0,0.0', 'Democube', 10),
('1.007,0.692,15.419', '1.022,0.742,15.649', '91.330,0.0,0.0', '91.330,0.0,0.0', 'bedbase', 5),
('0.905,0.63,15.474', '0.5731,0.7269,15.8651', '-88.955,-27.825,-61.491', '-88.955,-27.825,-61.491', 'bedrest', 5);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `objcomponent`
--
ALTER TABLE `objcomponent`
  ADD KEY `objId` (`objId`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
