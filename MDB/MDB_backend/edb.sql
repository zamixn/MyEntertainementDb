-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 23, 2020 at 02:17 PM
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
-- Database: `edb`
--

-- --------------------------------------------------------

--
-- Table structure for table `creator`
--

CREATE TABLE `creator` (
  `Name` varchar(255) DEFAULT NULL,
  `Info` varchar(255) DEFAULT NULL,
  `id` int(11) NOT NULL,
  `CreatorType` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `creator`
--

INSERT INTO `creator` (`Name`, `Info`, `id`, `CreatorType`) VALUES
('Bethesda', 'affg', 1, 1),
('Bethesda', 'sg', 2, 2),
('Christopher Nolan', 'asdgg', 3, 3),
('Sony', 'interactive entertaiment', 5, 1);

-- --------------------------------------------------------

--
-- Table structure for table `creatortype`
--

CREATE TABLE `creatortype` (
  `id_CreatorType` int(11) NOT NULL,
  `name` char(9) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `creatortype`
--

INSERT INTO `creatortype` (`id_CreatorType`, `name`) VALUES
(1, 'Developer'),
(2, 'Publisher'),
(3, 'Director');

-- --------------------------------------------------------

--
-- Table structure for table `entry`
--

CREATE TABLE `entry` (
  `Title` varchar(255) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `id` int(11) NOT NULL,
  `fk_Userid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `entry`
--

INSERT INTO `entry` (`Title`, `Description`, `id`, `fk_Userid`) VALUES
('cool game', 'asd', 1, 1),
('cool movie', 'asf', 2, 1),
('cool tv show', 'asd', 3, 1);

-- --------------------------------------------------------

--
-- Table structure for table `entryrating`
--

CREATE TABLE `entryrating` (
  `Rating` decimal(10,0) DEFAULT NULL,
  `id_EntryRating` int(11) NOT NULL,
  `fk_Entryid` int(11) NOT NULL,
  `fk_Userid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `entry_creator`
--

CREATE TABLE `entry_creator` (
  `fk_Entryid` int(11) NOT NULL,
  `fk_Creatorid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `entry_tag`
--

CREATE TABLE `entry_tag` (
  `fk_Entryid` int(11) NOT NULL,
  `fk_Tagid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `externalsource`
--

CREATE TABLE `externalsource` (
  `Rating` decimal(10,0) DEFAULT NULL,
  `Link` varchar(255) DEFAULT NULL,
  `RatingCount` int(11) DEFAULT NULL,
  `id` int(11) NOT NULL,
  `fk_Entryid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `game`
--

CREATE TABLE `game` (
  `TimesPlayed` int(11) DEFAULT NULL,
  `LastPlayed` date DEFAULT NULL,
  `ReleaseDate` date DEFAULT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `game`
--

INSERT INTO `game` (`TimesPlayed`, `LastPlayed`, `ReleaseDate`, `id`) VALUES
(1, '2020-09-04', '2020-09-04', 1);

-- --------------------------------------------------------

--
-- Table structure for table `gamegenre`
--

CREATE TABLE `gamegenre` (
  `id` int(11) NOT NULL,
  `Type` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `gamegenretype`
--

CREATE TABLE `gamegenretype` (
  `id_GameGenreType` int(11) NOT NULL,
  `name` char(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `gamegenretype`
--

INSERT INTO `gamegenretype` (`id_GameGenreType`, `name`) VALUES
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
  `fk_Gameid` int(11) NOT NULL,
  `fk_GameGenreid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `game_platform`
--

CREATE TABLE `game_platform` (
  `fk_Gameid` int(11) NOT NULL,
  `fk_Platformid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `platform`
--

CREATE TABLE `platform` (
  `id` int(11) NOT NULL,
  `Type` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `platformtype`
--

CREATE TABLE `platformtype` (
  `id_PlatformType` int(11) NOT NULL,
  `name` char(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `platformtype`
--

INSERT INTO `platformtype` (`id_PlatformType`, `name`) VALUES
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
-- Table structure for table `systemuser`
--

CREATE TABLE `systemuser` (
  `Username` varchar(255) DEFAULT NULL,
  `PasswordHash` varchar(255) DEFAULT NULL,
  `id` int(11) NOT NULL,
  `Role` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `systemuser`
--

INSERT INTO `systemuser` (`Username`, `PasswordHash`, `id`, `Role`) VALUES
('admin', NULL, 1, 1);

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
-- Table structure for table `userrole`
--

CREATE TABLE `userrole` (
  `id_UserRole` int(11) NOT NULL,
  `name` char(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `userrole`
--

INSERT INTO `userrole` (`id_UserRole`, `name`) VALUES
(1, 'Admin'),
(2, 'LoggedInUser'),
(3, 'Guest');

-- --------------------------------------------------------

--
-- Table structure for table `watchable`
--

CREATE TABLE `watchable` (
  `TimesSeen` int(11) DEFAULT NULL,
  `LastSeen` date DEFAULT NULL,
  `ReleaseDate` date DEFAULT NULL,
  `Type` int(11) DEFAULT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `watchable`
--

INSERT INTO `watchable` (`TimesSeen`, `LastSeen`, `ReleaseDate`, `Type`, `id`) VALUES
(4, '2020-09-03', '2020-09-03', 1, 2),
(6, '2020-09-03', '2020-09-03', 2, 3);

-- --------------------------------------------------------

--
-- Table structure for table `watchablegenre`
--

CREATE TABLE `watchablegenre` (
  `id` int(11) NOT NULL,
  `Type` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `watchablegenretype`
--

CREATE TABLE `watchablegenretype` (
  `id_WatchableGenreType` int(11) NOT NULL,
  `name` char(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `watchablegenretype`
--

INSERT INTO `watchablegenretype` (`id_WatchableGenreType`, `name`) VALUES
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

-- --------------------------------------------------------

--
-- Table structure for table `watchabletype`
--

CREATE TABLE `watchabletype` (
  `id_WatchableType` int(11) NOT NULL,
  `name` char(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `watchabletype`
--

INSERT INTO `watchabletype` (`id_WatchableType`, `name`) VALUES
(1, 'Movie'),
(2, 'TvSeries'),
(3, 'Anime');

-- --------------------------------------------------------

--
-- Table structure for table `watchable_watchablegenre`
--

CREATE TABLE `watchable_watchablegenre` (
  `fk_Watchableid` int(11) NOT NULL,
  `fk_WatchableGenreid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
  ADD PRIMARY KEY (`id_CreatorType`);

--
-- Indexes for table `entry`
--
ALTER TABLE `entry`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Adds` (`fk_Userid`);

--
-- Indexes for table `entryrating`
--
ALTER TABLE `entryrating`
  ADD PRIMARY KEY (`id_EntryRating`),
  ADD KEY `fk_Entryid` (`fk_Entryid`),
  ADD KEY `fk_Userid` (`fk_Userid`);

--
-- Indexes for table `entry_creator`
--
ALTER TABLE `entry_creator`
  ADD PRIMARY KEY (`fk_Entryid`,`fk_Creatorid`),
  ADD KEY `fk_Creatorid` (`fk_Creatorid`);

--
-- Indexes for table `entry_tag`
--
ALTER TABLE `entry_tag`
  ADD PRIMARY KEY (`fk_Entryid`,`fk_Tagid`),
  ADD KEY `fk_Tagid` (`fk_Tagid`);

--
-- Indexes for table `externalsource`
--
ALTER TABLE `externalsource`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_Entryid` (`fk_Entryid`);

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
  ADD PRIMARY KEY (`id_GameGenreType`);

--
-- Indexes for table `game_gamegenre`
--
ALTER TABLE `game_gamegenre`
  ADD PRIMARY KEY (`fk_Gameid`,`fk_GameGenreid`),
  ADD KEY `fk_GameGenreid` (`fk_GameGenreid`);

--
-- Indexes for table `game_platform`
--
ALTER TABLE `game_platform`
  ADD PRIMARY KEY (`fk_Gameid`,`fk_Platformid`),
  ADD KEY `fk_Platformid` (`fk_Platformid`);

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
  ADD PRIMARY KEY (`id_PlatformType`);

--
-- Indexes for table `systemuser`
--
ALTER TABLE `systemuser`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Role` (`Role`);

--
-- Indexes for table `tag`
--
ALTER TABLE `tag`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `userrole`
--
ALTER TABLE `userrole`
  ADD PRIMARY KEY (`id_UserRole`);

--
-- Indexes for table `watchable`
--
ALTER TABLE `watchable`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Type` (`Type`);

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
  ADD PRIMARY KEY (`id_WatchableGenreType`);

--
-- Indexes for table `watchabletype`
--
ALTER TABLE `watchabletype`
  ADD PRIMARY KEY (`id_WatchableType`);

--
-- Indexes for table `watchable_watchablegenre`
--
ALTER TABLE `watchable_watchablegenre`
  ADD PRIMARY KEY (`fk_Watchableid`,`fk_WatchableGenreid`),
  ADD KEY `fk_WatchableGenreid` (`fk_WatchableGenreid`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `creator`
--
ALTER TABLE `creator`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `creatortype`
--
ALTER TABLE `creatortype`
  MODIFY `id_CreatorType` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `entry`
--
ALTER TABLE `entry`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT for table `entryrating`
--
ALTER TABLE `entryrating`
  MODIFY `id_EntryRating` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `externalsource`
--
ALTER TABLE `externalsource`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `game`
--
ALTER TABLE `game`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT for table `gamegenre`
--
ALTER TABLE `gamegenre`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `gamegenretype`
--
ALTER TABLE `gamegenretype`
  MODIFY `id_GameGenreType` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `platform`
--
ALTER TABLE `platform`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `platformtype`
--
ALTER TABLE `platformtype`
  MODIFY `id_PlatformType` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT for table `systemuser`
--
ALTER TABLE `systemuser`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `tag`
--
ALTER TABLE `tag`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `userrole`
--
ALTER TABLE `userrole`
  MODIFY `id_UserRole` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `watchable`
--
ALTER TABLE `watchable`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT for table `watchablegenre`
--
ALTER TABLE `watchablegenre`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `watchablegenretype`
--
ALTER TABLE `watchablegenretype`
  MODIFY `id_WatchableGenreType` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT for table `watchabletype`
--
ALTER TABLE `watchabletype`
  MODIFY `id_WatchableType` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `creator`
--
ALTER TABLE `creator`
  ADD CONSTRAINT `creator_ibfk_1` FOREIGN KEY (`CreatorType`) REFERENCES `creatortype` (`id_CreatorType`);

--
-- Constraints for table `entry`
--
ALTER TABLE `entry`
  ADD CONSTRAINT `Adds` FOREIGN KEY (`fk_Userid`) REFERENCES `systemuser` (`id`);

--
-- Constraints for table `entryrating`
--
ALTER TABLE `entryrating`
  ADD CONSTRAINT `entryrating_ibfk_1` FOREIGN KEY (`fk_Entryid`) REFERENCES `entry` (`id`),
  ADD CONSTRAINT `entryrating_ibfk_2` FOREIGN KEY (`fk_Userid`) REFERENCES `systemuser` (`id`);

--
-- Constraints for table `entry_creator`
--
ALTER TABLE `entry_creator`
  ADD CONSTRAINT `entry_creator_ibfk_1` FOREIGN KEY (`fk_Entryid`) REFERENCES `entry` (`id`),
  ADD CONSTRAINT `entry_creator_ibfk_2` FOREIGN KEY (`fk_Creatorid`) REFERENCES `creator` (`id`);

--
-- Constraints for table `entry_tag`
--
ALTER TABLE `entry_tag`
  ADD CONSTRAINT `entry_tag_ibfk_1` FOREIGN KEY (`fk_Entryid`) REFERENCES `entry` (`id`),
  ADD CONSTRAINT `entry_tag_ibfk_2` FOREIGN KEY (`fk_Tagid`) REFERENCES `tag` (`id`);

--
-- Constraints for table `externalsource`
--
ALTER TABLE `externalsource`
  ADD CONSTRAINT `externalsource_ibfk_1` FOREIGN KEY (`fk_Entryid`) REFERENCES `entry` (`id`);

--
-- Constraints for table `game`
--
ALTER TABLE `game`
  ADD CONSTRAINT `game_ibfk_1` FOREIGN KEY (`id`) REFERENCES `entry` (`id`);

--
-- Constraints for table `gamegenre`
--
ALTER TABLE `gamegenre`
  ADD CONSTRAINT `gamegenre_ibfk_1` FOREIGN KEY (`Type`) REFERENCES `gamegenretype` (`id_GameGenreType`);

--
-- Constraints for table `game_gamegenre`
--
ALTER TABLE `game_gamegenre`
  ADD CONSTRAINT `game_gamegenre_ibfk_1` FOREIGN KEY (`fk_Gameid`) REFERENCES `game` (`id`),
  ADD CONSTRAINT `game_gamegenre_ibfk_2` FOREIGN KEY (`fk_GameGenreid`) REFERENCES `gamegenre` (`id`);

--
-- Constraints for table `game_platform`
--
ALTER TABLE `game_platform`
  ADD CONSTRAINT `game_platform_ibfk_1` FOREIGN KEY (`fk_Gameid`) REFERENCES `game` (`id`),
  ADD CONSTRAINT `game_platform_ibfk_2` FOREIGN KEY (`fk_Platformid`) REFERENCES `platform` (`id`);

--
-- Constraints for table `platform`
--
ALTER TABLE `platform`
  ADD CONSTRAINT `platform_ibfk_1` FOREIGN KEY (`Type`) REFERENCES `platformtype` (`id_PlatformType`);

--
-- Constraints for table `systemuser`
--
ALTER TABLE `systemuser`
  ADD CONSTRAINT `systemuser_ibfk_1` FOREIGN KEY (`Role`) REFERENCES `userrole` (`id_UserRole`);

--
-- Constraints for table `watchable`
--
ALTER TABLE `watchable`
  ADD CONSTRAINT `watchable_ibfk_1` FOREIGN KEY (`Type`) REFERENCES `watchabletype` (`id_WatchableType`),
  ADD CONSTRAINT `watchable_ibfk_2` FOREIGN KEY (`id`) REFERENCES `entry` (`id`);

--
-- Constraints for table `watchablegenre`
--
ALTER TABLE `watchablegenre`
  ADD CONSTRAINT `watchablegenre_ibfk_1` FOREIGN KEY (`Type`) REFERENCES `watchablegenretype` (`id_WatchableGenreType`);

--
-- Constraints for table `watchable_watchablegenre`
--
ALTER TABLE `watchable_watchablegenre`
  ADD CONSTRAINT `watchable_watchablegenre_ibfk_1` FOREIGN KEY (`fk_Watchableid`) REFERENCES `watchable` (`id`),
  ADD CONSTRAINT `watchable_watchablegenre_ibfk_2` FOREIGN KEY (`fk_WatchableGenreid`) REFERENCES `watchablegenre` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
