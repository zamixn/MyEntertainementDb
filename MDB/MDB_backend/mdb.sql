-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 16, 2020 at 10:24 PM
-- Server version: 10.1.38-MariaDB
-- PHP Version: 5.6.40

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `mdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `creator`
--

CREATE TABLE `creator` (
  `Name` varchar(255) DEFAULT NULL,
  `Info` varchar(255) DEFAULT NULL,
  `CreatorType` int(11) DEFAULT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `creatortype`
--

CREATE TABLE `creatortype` (
  `id` int(11) NOT NULL,
  `name` char(9) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `creatortype`
--

INSERT INTO `creatortype` (`id`, `name`) VALUES
(1, 'Developer'),
(2, 'Publisher'),
(3, 'Director');

-- --------------------------------------------------------

--
-- Table structure for table `entry`
--

CREATE TABLE `entry` (
  `Title` varchar(255) DEFAULT NULL,
  `Rating` double DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `entry`
--

INSERT INTO `entry` (`Title`, `Rating`, `Description`, `id`) VALUES
('very cool game', 5.12, 'coo desc', 2),
('very cool game', 2.12, 'coo desc', 3);

-- --------------------------------------------------------

--
-- Table structure for table `entry_creator`
--

CREATE TABLE `entry_creator` (
  `fk_entry` int(11) NOT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `entry_tag`
--

CREATE TABLE `entry_tag` (
  `fk_entry` int(11) NOT NULL,
  `fk_tag` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `externalsource`
--

CREATE TABLE `externalsource` (
  `Rating` double DEFAULT NULL,
  `Link` varchar(255) DEFAULT NULL,
  `RatingCount` int(11) DEFAULT NULL,
  `id` int(11) NOT NULL,
  `fk_entry` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `game`
--

CREATE TABLE `game` (
  `TimesPlayed` int(11) DEFAULT NULL,
  `LastPlayed` date DEFAULT NULL,
  `id` int(11) NOT NULL,
  `ReleaseDate` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `game`
--

INSERT INTO `game` (`TimesPlayed`, `LastPlayed`, `id`, `ReleaseDate`) VALUES
(1, '2020-09-15', 2, '2020-09-03'),
(1, '2020-09-15', 3, '2020-09-03');

-- --------------------------------------------------------

--
-- Table structure for table `gamegenre`
--

CREATE TABLE `gamegenre` (
  `Type` int(11) DEFAULT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `gamegenretype`
--

CREATE TABLE `gamegenretype` (
  `id` int(11) NOT NULL,
  `name` char(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `gamegenretype`
--

INSERT INTO `gamegenretype` (`id`, `name`) VALUES
(1, 'Action'),
(2, 'Adventure'),
(3, 'FPS'),
(4, 'Fighting'),
(5, 'Platformer'),
(6, 'Puzzle'),
(7, 'Racing'),
(8, 'RealTime'),
(9, 'RolePlaying'),
(10, 'Simulation'),
(11, 'Sports'),
(12, 'Strategy'),
(13, 'ThirdPerson'),
(14, 'TurnBased'),
(15, 'War');

-- --------------------------------------------------------

--
-- Table structure for table `game_gamegenre`
--

CREATE TABLE `game_gamegenre` (
  `fk_game` int(11) NOT NULL,
  `fk_gameGenre` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `game_platform`
--

CREATE TABLE `game_platform` (
  `fk_game` int(11) NOT NULL,
  `fk_Platformid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `movie`
--

CREATE TABLE `movie` (
  `ReleaseDate` date DEFAULT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `platform`
--

CREATE TABLE `platform` (
  `Type` int(11) DEFAULT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `platformtype`
--

CREATE TABLE `platformtype` (
  `id` int(11) NOT NULL,
  `name` char(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `platformtype`
--

INSERT INTO `platformtype` (`id`, `name`) VALUES
(1, '3DS'),
(2, 'DC'),
(3, 'GBA'),
(4, 'GC'),
(5, 'N64'),
(6, 'PC'),
(7, 'PS'),
(8, 'PS2'),
(9, 'PS3'),
(10, 'PS4'),
(11, 'PSP'),
(12, 'Switch'),
(13, 'VITA'),
(14, 'WII'),
(15, 'WIIU'),
(16, 'X360'),
(17, 'XBox'),
(18, 'XOne');

-- --------------------------------------------------------

--
-- Table structure for table `series`
--

CREATE TABLE `series` (
  `EpisodesSeen` int(11) DEFAULT NULL,
  `EpisodeCount` int(11) DEFAULT NULL,
  `ReleaseDate` date DEFAULT NULL,
  `FinishDate` date DEFAULT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `tag`
--

CREATE TABLE `tag` (
  `Name` varchar(255) DEFAULT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `watchableentry`
--

CREATE TABLE `watchableentry` (
  `TimesSeen` int(11) DEFAULT NULL,
  `LastSeen` date DEFAULT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `watchableentry_watchablegenre`
--

CREATE TABLE `watchableentry_watchablegenre` (
  `fk_watchableEntry` int(11) NOT NULL,
  `fk_watchableGenre` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `watchablegenre`
--

CREATE TABLE `watchablegenre` (
  `Type` int(11) DEFAULT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `watchablegenretype`
--

CREATE TABLE `watchablegenretype` (
  `id` int(11) NOT NULL,
  `name` char(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `watchablegenretype`
--

INSERT INTO `watchablegenretype` (`id`, `name`) VALUES
(1, 'FilmNoir'),
(2, 'Comedy'),
(3, 'Family'),
(4, 'Drama'),
(5, 'Romance'),
(6, 'Mystery'),
(7, 'Crime'),
(8, 'Documentary'),
(9, 'History'),
(10, 'Musical'),
(11, 'Western'),
(12, 'War'),
(13, 'News'),
(14, 'Action'),
(15, 'Animation'),
(16, 'Fantasy'),
(17, 'SciFi'),
(18, 'Short'),
(19, 'Thriller'),
(20, 'RealityTv'),
(21, 'Horror'),
(22, 'GameShow'),
(23, 'Music'),
(24, 'Sport'),
(25, 'Biography'),
(26, 'TalkShow'),
(27, 'Adult');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `creator`
--
ALTER TABLE `creator`
  ADD PRIMARY KEY (`id`),
  ADD KEY `CreatorType` (`CreatorType`);

--
-- Indexes for table `creatortype`
--
ALTER TABLE `creatortype`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `entry`
--
ALTER TABLE `entry`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `entry_creator`
--
ALTER TABLE `entry_creator`
  ADD PRIMARY KEY (`fk_entry`,`id`),
  ADD KEY `id` (`id`);

--
-- Indexes for table `entry_tag`
--
ALTER TABLE `entry_tag`
  ADD PRIMARY KEY (`fk_entry`,`fk_tag`),
  ADD KEY `fk_tag` (`fk_tag`);

--
-- Indexes for table `externalsource`
--
ALTER TABLE `externalsource`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_entry` (`fk_entry`);

--
-- Indexes for table `game`
--
ALTER TABLE `game`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `gamegenre`
--
ALTER TABLE `gamegenre`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Type` (`Type`);

--
-- Indexes for table `gamegenretype`
--
ALTER TABLE `gamegenretype`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `game_gamegenre`
--
ALTER TABLE `game_gamegenre`
  ADD PRIMARY KEY (`fk_game`,`fk_gameGenre`),
  ADD KEY `fk_gameGenre` (`fk_gameGenre`);

--
-- Indexes for table `game_platform`
--
ALTER TABLE `game_platform`
  ADD PRIMARY KEY (`fk_game`,`fk_Platformid`),
  ADD KEY `fk_Platformid` (`fk_Platformid`);

--
-- Indexes for table `movie`
--
ALTER TABLE `movie`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `platform`
--
ALTER TABLE `platform`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Type` (`Type`);

--
-- Indexes for table `platformtype`
--
ALTER TABLE `platformtype`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `series`
--
ALTER TABLE `series`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tag`
--
ALTER TABLE `tag`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `watchableentry`
--
ALTER TABLE `watchableentry`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `watchableentry_watchablegenre`
--
ALTER TABLE `watchableentry_watchablegenre`
  ADD PRIMARY KEY (`fk_watchableEntry`,`fk_watchableGenre`),
  ADD KEY `fk_watchableGenre` (`fk_watchableGenre`);

--
-- Indexes for table `watchablegenre`
--
ALTER TABLE `watchablegenre`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Type` (`Type`);

--
-- Indexes for table `watchablegenretype`
--
ALTER TABLE `watchablegenretype`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `creator`
--
ALTER TABLE `creator`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `creatortype`
--
ALTER TABLE `creatortype`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `entry`
--
ALTER TABLE `entry`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `entry_creator`
--
ALTER TABLE `entry_creator`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `externalsource`
--
ALTER TABLE `externalsource`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `game`
--
ALTER TABLE `game`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `gamegenre`
--
ALTER TABLE `gamegenre`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `gamegenretype`
--
ALTER TABLE `gamegenretype`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `movie`
--
ALTER TABLE `movie`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `platform`
--
ALTER TABLE `platform`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `platformtype`
--
ALTER TABLE `platformtype`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT for table `series`
--
ALTER TABLE `series`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tag`
--
ALTER TABLE `tag`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `watchableentry`
--
ALTER TABLE `watchableentry`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `watchablegenre`
--
ALTER TABLE `watchablegenre`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `watchablegenretype`
--
ALTER TABLE `watchablegenretype`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `creator`
--
ALTER TABLE `creator`
  ADD CONSTRAINT `creator_ibfk_1` FOREIGN KEY (`CreatorType`) REFERENCES `creatortype` (`id`);

--
-- Constraints for table `entry_creator`
--
ALTER TABLE `entry_creator`
  ADD CONSTRAINT `entry_creator_ibfk_1` FOREIGN KEY (`fk_entry`) REFERENCES `entry` (`id`),
  ADD CONSTRAINT `entry_creator_ibfk_2` FOREIGN KEY (`id`) REFERENCES `creator` (`id`);

--
-- Constraints for table `entry_tag`
--
ALTER TABLE `entry_tag`
  ADD CONSTRAINT `entry_tag_ibfk_1` FOREIGN KEY (`fk_entry`) REFERENCES `entry` (`id`),
  ADD CONSTRAINT `entry_tag_ibfk_2` FOREIGN KEY (`fk_tag`) REFERENCES `tag` (`id`);

--
-- Constraints for table `externalsource`
--
ALTER TABLE `externalsource`
  ADD CONSTRAINT `externalsource_ibfk_1` FOREIGN KEY (`fk_entry`) REFERENCES `entry` (`id`);

--
-- Constraints for table `game`
--
ALTER TABLE `game`
  ADD CONSTRAINT `game_ibfk_1` FOREIGN KEY (`id`) REFERENCES `entry` (`id`);

--
-- Constraints for table `gamegenre`
--
ALTER TABLE `gamegenre`
  ADD CONSTRAINT `gamegenre_ibfk_1` FOREIGN KEY (`Type`) REFERENCES `gamegenretype` (`id`);

--
-- Constraints for table `game_gamegenre`
--
ALTER TABLE `game_gamegenre`
  ADD CONSTRAINT `game_gamegenre_ibfk_1` FOREIGN KEY (`fk_game`) REFERENCES `game` (`id`),
  ADD CONSTRAINT `game_gamegenre_ibfk_2` FOREIGN KEY (`fk_gameGenre`) REFERENCES `gamegenre` (`id`);

--
-- Constraints for table `game_platform`
--
ALTER TABLE `game_platform`
  ADD CONSTRAINT `game_platform_ibfk_1` FOREIGN KEY (`fk_game`) REFERENCES `game` (`id`),
  ADD CONSTRAINT `game_platform_ibfk_2` FOREIGN KEY (`fk_Platformid`) REFERENCES `platform` (`id`);

--
-- Constraints for table `movie`
--
ALTER TABLE `movie`
  ADD CONSTRAINT `movie_ibfk_1` FOREIGN KEY (`id`) REFERENCES `watchableentry` (`id`);

--
-- Constraints for table `platform`
--
ALTER TABLE `platform`
  ADD CONSTRAINT `platform_ibfk_1` FOREIGN KEY (`Type`) REFERENCES `platformtype` (`id`);

--
-- Constraints for table `series`
--
ALTER TABLE `series`
  ADD CONSTRAINT `series_ibfk_1` FOREIGN KEY (`id`) REFERENCES `watchableentry` (`id`);

--
-- Constraints for table `watchableentry`
--
ALTER TABLE `watchableentry`
  ADD CONSTRAINT `watchableentry_ibfk_1` FOREIGN KEY (`id`) REFERENCES `entry` (`id`);

--
-- Constraints for table `watchableentry_watchablegenre`
--
ALTER TABLE `watchableentry_watchablegenre`
  ADD CONSTRAINT `watchableentry_watchablegenre_ibfk_1` FOREIGN KEY (`fk_watchableEntry`) REFERENCES `watchableentry` (`id`),
  ADD CONSTRAINT `watchableentry_watchablegenre_ibfk_2` FOREIGN KEY (`fk_watchableGenre`) REFERENCES `watchablegenre` (`id`);

--
-- Constraints for table `watchablegenre`
--
ALTER TABLE `watchablegenre`
  ADD CONSTRAINT `watchablegenre_ibfk_1` FOREIGN KEY (`Type`) REFERENCES `watchablegenretype` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
