--
-- Table structure for table `aspnetusers`
--

/*
CREATE TABLE IF NOT EXISTS `aspnetusers` (
  `Id` varchar(128) NOT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext,
  `SecurityStamp` longtext,
  `PhoneNumber` longtext,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEndDateUtc` datetime DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `UserName` varchar(256) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
*/


------------

-- Criando o ApplicationUser
CREATE TABLE ApplicationUser
(
    Id INT AUTO_INCREMENT,
    UserName varchar(256) NOT NULL,
    NormalizedUserName varchar(256) NOT NULL,
    Email varchar(256) NULL,
    NormalizedEmail varchar(256) NULL,
    EmailConfirmed tinyint(1) NOT NULL,
    PasswordHash longtext NULL,
    PhoneNumber varchar(50) NULL,
    PhoneNumberConfirmed tinyint(1) NOT NULL,
    TwoFactorEnabled tinyint(1) NOT NULL,
	primary key(Id)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;



-----------------------------------------------------------

--
-- Table structure for table `aspnetroles`
--

/*
CREATE TABLE IF NOT EXISTS `aspnetroles` (
  `Id` varchar(128) NOT NULL,
  `Name` varchar(256) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
*/

-- Criando o ApplicationRole
CREATE TABLE ApplicationRole
(
    Id INT AUTO_INCREMENT,
    Name varchar(256) NOT NULL,
    NormalizedName varchar(256) NOT NULL,
	primary key(Id)
)ENGINE=InnoDB DEFAULT CHARSET=latin1;


----------------------------------------------------------





--
-- Table structure for table `aspnetuserroles`
--
/*
CREATE TABLE IF NOT EXISTS `aspnetuserroles` (
  `UserId` varchar(128) NOT NULL,
  `RoleId` varchar(128) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IdentityRole_Users` (`RoleId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


--
-- Constraints for table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `ApplicationUser_Roles` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  ADD CONSTRAINT `IdentityRole_Users` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION;
*/
  
  
  
  
  
-- Criando o ApplicationUserRole
CREATE TABLE ApplicationUserRole
(
    UserId INT NOT NULL,
    RoleId INT NOT NULL,
    PRIMARY KEY (UserId, RoleId),
	KEY IdentityRole_Users (RoleId)
)ENGINE=InnoDB DEFAULT CHARSET=latin1

ALTER TABLE ApplicationUserRole
  ADD CONSTRAINT ApplicationUser_Roles FOREIGN KEY (UserId) REFERENCES ApplicationUser (Id) ON DELETE CASCADE ON UPDATE NO ACTION,
  ADD CONSTRAINT IdentityRole_Users FOREIGN KEY (RoleId) REFERENCES ApplicationRole (Id) ON DELETE CASCADE ON UPDATE NO ACTION;

-- --------------------------------------------------------




















--
-- Table structure for table `aspnetuserclaims`
--

CREATE TABLE IF NOT EXISTS `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(128) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id` (`Id`),
  KEY `UserId` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;


--
-- Constraints for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `ApplicationUser_Claims` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION;


-- --------------------------------------------------------

--
-- Table structure for table `aspnetuserlogins`
--

CREATE TABLE IF NOT EXISTS `aspnetuserlogins` (
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  `UserId` varchar(128) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`,`UserId`),
  KEY `ApplicationUser_Logins` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `ApplicationUser_Logins` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION;

-- --------------------------------------------------------








