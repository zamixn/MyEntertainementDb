CREATE TABLE Tag
(
	Name varchar (255),
	id int AUTO_INCREMENT,
	PRIMARY KEY(id)
);

CREATE TABLE CreatorType
(
	id_CreatorType integer AUTO_INCREMENT,
	name char (9) NOT NULL,
	PRIMARY KEY(id_CreatorType)
);
INSERT INTO CreatorType(id_CreatorType, name) VALUES(1, 'Developer');
INSERT INTO CreatorType(id_CreatorType, name) VALUES(2, 'Publisher');
INSERT INTO CreatorType(id_CreatorType, name) VALUES(3, 'Director');

CREATE TABLE GameGenreType
(
	id_GameGenreType integer AUTO_INCREMENT,
	name char (11) NOT NULL,
	PRIMARY KEY(id_GameGenreType)
);
INSERT INTO GameGenreType(id_GameGenreType, name) VALUES(1, 'Action');
INSERT INTO GameGenreType(id_GameGenreType, name) VALUES(2, 'Adventure');
INSERT INTO GameGenreType(id_GameGenreType, name) VALUES(3, 'FPS');
INSERT INTO GameGenreType(id_GameGenreType, name) VALUES(4, 'Fighting');
INSERT INTO GameGenreType(id_GameGenreType, name) VALUES(5, 'Platformer');
INSERT INTO GameGenreType(id_GameGenreType, name) VALUES(6, 'Puzzle');
INSERT INTO GameGenreType(id_GameGenreType, name) VALUES(7, 'Racing');
INSERT INTO GameGenreType(id_GameGenreType, name) VALUES(8, 'RealTime');
INSERT INTO GameGenreType(id_GameGenreType, name) VALUES(9, 'RolePlaying');
INSERT INTO GameGenreType(id_GameGenreType, name) VALUES(10, 'Simulation');
INSERT INTO GameGenreType(id_GameGenreType, name) VALUES(11, 'Sports');
INSERT INTO GameGenreType(id_GameGenreType, name) VALUES(12, 'Strategy');
INSERT INTO GameGenreType(id_GameGenreType, name) VALUES(13, 'ThirdPerson');
INSERT INTO GameGenreType(id_GameGenreType, name) VALUES(14, 'TurnBased');
INSERT INTO GameGenreType(id_GameGenreType, name) VALUES(15, 'War');

CREATE TABLE PlatformType
(
	id_PlatformType integer AUTO_INCREMENT,
	name char (6) NOT NULL,
	PRIMARY KEY(id_PlatformType)
);
INSERT INTO PlatformType(id_PlatformType, name) VALUES(1, '3DS');
INSERT INTO PlatformType(id_PlatformType, name) VALUES(2, 'DC');
INSERT INTO PlatformType(id_PlatformType, name) VALUES(3, 'GBA');
INSERT INTO PlatformType(id_PlatformType, name) VALUES(4, 'GC');
INSERT INTO PlatformType(id_PlatformType, name) VALUES(5, 'N64');
INSERT INTO PlatformType(id_PlatformType, name) VALUES(6, 'PC');
INSERT INTO PlatformType(id_PlatformType, name) VALUES(7, 'PS');
INSERT INTO PlatformType(id_PlatformType, name) VALUES(8, 'PS2');
INSERT INTO PlatformType(id_PlatformType, name) VALUES(9, 'PS3');
INSERT INTO PlatformType(id_PlatformType, name) VALUES(10, 'PS4');
INSERT INTO PlatformType(id_PlatformType, name) VALUES(11, 'PSP');
INSERT INTO PlatformType(id_PlatformType, name) VALUES(12, 'Switch');
INSERT INTO PlatformType(id_PlatformType, name) VALUES(13, 'VITA');
INSERT INTO PlatformType(id_PlatformType, name) VALUES(14, 'WII');
INSERT INTO PlatformType(id_PlatformType, name) VALUES(15, 'WIIU');
INSERT INTO PlatformType(id_PlatformType, name) VALUES(16, 'X360');
INSERT INTO PlatformType(id_PlatformType, name) VALUES(17, 'XBox');
INSERT INTO PlatformType(id_PlatformType, name) VALUES(18, 'XOne');

CREATE TABLE UserRole
(
	id_UserRole integer AUTO_INCREMENT,
	name char (12) NOT NULL,
	PRIMARY KEY(id_UserRole)
);
INSERT INTO UserRole(id_UserRole, name) VALUES(1, 'Admin');
INSERT INTO UserRole(id_UserRole, name) VALUES(2, 'LoggedInUser');
INSERT INTO UserRole(id_UserRole, name) VALUES(3, 'Guest');

CREATE TABLE WatchableGenreType
(
	id_WatchableGenreType integer AUTO_INCREMENT,
	name char (11) NOT NULL,
	PRIMARY KEY(id_WatchableGenreType)
);
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(1, 'FilmNoir');
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(2, 'Comedy');
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(3, 'Family');
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(4, 'Drama');
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(5, 'Romance');
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(6, 'Mystery');
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(7, 'Crime');
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(8, 'Documentary');
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(9, 'History');
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(10, 'Musical');
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(11, 'Western');
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(12, 'War');
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(13, 'News');
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(14, 'Action');
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(15, 'Animation');
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(16, 'Fantasy');
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(17, 'SciFi');
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(18, 'Short');
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(19, 'Thriller');
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(20, 'RealityTv');
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(21, 'Horror');
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(22, 'GameShow');
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(23, 'Music');
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(24, 'Sport');
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(25, 'Biography');
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(26, 'TalkShow');
INSERT INTO WatchableGenreType(id_WatchableGenreType, name) VALUES(27, 'Adult');

CREATE TABLE WatchableType
(
	id_WatchableType integer AUTO_INCREMENT,
	name char (8) NOT NULL,
	PRIMARY KEY(id_WatchableType)
);
INSERT INTO WatchableType(id_WatchableType, name) VALUES(1, 'Movie');
INSERT INTO WatchableType(id_WatchableType, name) VALUES(2, 'TvSeries');
INSERT INTO WatchableType(id_WatchableType, name) VALUES(3, 'Anime');

CREATE TABLE Creator
(
	Name varchar (255),
	Info varchar (255),
	id int AUTO_INCREMENT,
	CreatorType integer,
	PRIMARY KEY(id),
	FOREIGN KEY(CreatorType) REFERENCES CreatorType (id_CreatorType)
);

CREATE TABLE GameGenre
(
	id int AUTO_INCREMENT,
	Type integer,
	PRIMARY KEY(id),
	FOREIGN KEY(Type) REFERENCES GameGenreType (id_GameGenreType)
);

CREATE TABLE Platform
(
	id int AUTO_INCREMENT,
	Type integer,
	PRIMARY KEY(id),
	FOREIGN KEY(Type) REFERENCES PlatformType (id_PlatformType)
);

CREATE TABLE SystemUser
(
	Username varchar (255),
	PasswordHash varchar (255),
	id int AUTO_INCREMENT,
	Role integer,
	PRIMARY KEY(id),
	FOREIGN KEY(Role) REFERENCES UserRole (id_UserRole)
);

CREATE TABLE WatchableGenre
(
	id int AUTO_INCREMENT,
	Type integer,
	PRIMARY KEY(id),
	FOREIGN KEY(Type) REFERENCES WatchableGenreType (id_WatchableGenreType)
);

CREATE TABLE Entry
(
	Title varchar (255),
	Description varchar (255),
	id int AUTO_INCREMENT,
	fk_Userid int NOT NULL,
	PRIMARY KEY(id),
	CONSTRAINT Adds FOREIGN KEY(fk_Userid) REFERENCES SystemUser (id)
);

CREATE TABLE Entry_Creator
(
	fk_Entryid int,
	fk_Creatorid int,
	PRIMARY KEY(fk_Entryid, fk_Creatorid),
	FOREIGN KEY(fk_Entryid) REFERENCES Entry (id),
	FOREIGN KEY(fk_Creatorid) REFERENCES Creator (id)
);

CREATE TABLE Entry_Tag
(
	fk_Entryid int,
	fk_Tagid int,
	PRIMARY KEY(fk_Entryid, fk_Tagid),
	FOREIGN KEY(fk_Entryid) REFERENCES Entry (id),
	FOREIGN KEY(fk_Tagid) REFERENCES Tag (id)
);

CREATE TABLE EntryRating
(
	Rating decimal,
	id_EntryRating integer AUTO_INCREMENT,
	fk_Entryid int NOT NULL,
	fk_Userid int NOT NULL,
	PRIMARY KEY(id_EntryRating),
	FOREIGN KEY(fk_Entryid) REFERENCES Entry (id),
	FOREIGN KEY(fk_Userid) REFERENCES SystemUser (id)
);

CREATE TABLE ExternalSource
(
	Rating decimal,
	Link varchar (255),
	RatingCount int,
	id int AUTO_INCREMENT,
	fk_Entryid int NOT NULL,
	PRIMARY KEY(id),
	FOREIGN KEY(fk_Entryid) REFERENCES Entry (id)
);

CREATE TABLE Game
(
	TimesPlayed int,
	LastPlayed date,
	ReleaseDate date,
	id int AUTO_INCREMENT,
	PRIMARY KEY(id),
	FOREIGN KEY(id) REFERENCES Entry (id)
);

CREATE TABLE Watchable
(
	TimesSeen int,
	LastSeen date,
	ReleaseDate date,
	Type integer,
	id int AUTO_INCREMENT,
	PRIMARY KEY(id),
	FOREIGN KEY(Type) REFERENCES WatchableType (id_WatchableType),
	FOREIGN KEY(id) REFERENCES Entry (id)
);

CREATE TABLE Game_GameGenre
(
	fk_Gameid int,
	fk_GameGenreid int,
	PRIMARY KEY(fk_Gameid, fk_GameGenreid),
	FOREIGN KEY(fk_Gameid) REFERENCES Game (id),
	FOREIGN KEY(fk_GameGenreid) REFERENCES GameGenre (id)
);

CREATE TABLE Game_Platform
(
	fk_Gameid int,
	fk_Platformid int,
	PRIMARY KEY(fk_Gameid, fk_Platformid),
	FOREIGN KEY(fk_Gameid) REFERENCES Game (id),
	FOREIGN KEY(fk_Platformid) REFERENCES Platform (id)
);

CREATE TABLE Watchable_WatchableGenre
(
	fk_Watchableid int,
	fk_WatchableGenreid int,
	PRIMARY KEY(fk_Watchableid, fk_WatchableGenreid),
	FOREIGN KEY(fk_Watchableid) REFERENCES Watchable (id),
	FOREIGN KEY(fk_WatchableGenreid) REFERENCES WatchableGenre (id)
);
