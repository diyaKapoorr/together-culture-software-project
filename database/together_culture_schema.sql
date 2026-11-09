-- Together Culture - GitHub-safe database
-- Compatible with the current C# Windows Forms project.
-- Contains schema + fictional demo data only.
--
-- IMPORTANT:
-- The application currently stores passwords as plain text because that is
-- how the original coursework prototype was implemented. Do not use this
-- pattern in a production application.

CREATE DATABASE IF NOT EXISTS `together_culture`
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_general_ci;

USE `together_culture`;

SET FOREIGN_KEY_CHECKS = 0;

DROP TABLE IF EXISTS `billings`;
DROP TABLE IF EXISTS `feedback`;
DROP TABLE IF EXISTS `PinboardMessages`;
DROP TABLE IF EXISTS `eventactivity`;
DROP TABLE IF EXISTS `staff`;
DROP TABLE IF EXISTS `logindetails`;
DROP TABLE IF EXISTS `nonmember`;
DROP TABLE IF EXISTS `member`;
DROP TABLE IF EXISTS `administrator`;

SET FOREIGN_KEY_CHECKS = 1;

-- --------------------------------------------------------
-- Administrators
-- --------------------------------------------------------
CREATE TABLE `administrator` (
    `AdminID` INT NOT NULL AUTO_INCREMENT,
    `Email` VARCHAR(100) NOT NULL,
    `FirstName` VARCHAR(50) NOT NULL,
    `LastName` VARCHAR(50) NOT NULL,
    `DOB` DATE NULL,
    PRIMARY KEY (`AdminID`),
    UNIQUE KEY `uq_administrator_email` (`Email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------
-- Members
-- --------------------------------------------------------
CREATE TABLE `member` (
    `MemberID` INT NOT NULL AUTO_INCREMENT,
    `Email` VARCHAR(100) NOT NULL,
    `FirstName` VARCHAR(50) NOT NULL,
    `LastName` VARCHAR(50) NOT NULL,
    `DOB` DATE NULL,
    `RegistrationDate` DATE NOT NULL DEFAULT (CURRENT_DATE),
    `Membership` VARCHAR(50) NOT NULL DEFAULT 'Standard',
    PRIMARY KEY (`MemberID`),
    UNIQUE KEY `uq_member_email` (`Email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------
-- Non-members
-- Interests and Intentions default to blank strings so the existing
-- registration code can insert only Email/FirstName/LastName/DOB.
-- --------------------------------------------------------
CREATE TABLE `nonmember` (
    `Email` VARCHAR(100) NOT NULL,
    `FirstName` VARCHAR(50) NOT NULL,
    `LastName` VARCHAR(50) NOT NULL,
    `DOB` DATE NULL,
    `Interests` VARCHAR(100) NOT NULL DEFAULT '',
    `Intentions` VARCHAR(100) NOT NULL DEFAULT '',
    PRIMARY KEY (`Email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------
-- Login details
-- Matches signUp.cs, Login.cs, ForgetPassword.cs and updateAdminCred.cs
-- --------------------------------------------------------
CREATE TABLE `logindetails` (
    `Email` VARCHAR(100) NOT NULL,
    `Password` VARCHAR(255) NOT NULL,
    `Security_questions` VARCHAR(150) NOT NULL,
    `Security_questions_answers` VARCHAR(150) NOT NULL,
    PRIMARY KEY (`Email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------
-- Staff
-- --------------------------------------------------------
CREATE TABLE `staff` (
    `StaffID` INT NOT NULL AUTO_INCREMENT,
    `FirstName` VARCHAR(50) NOT NULL,
    `LastName` VARCHAR(50) NOT NULL,
    `JoiningDate` DATE NULL,
    `Department` VARCHAR(50) NOT NULL,
    `Email` VARCHAR(100) NOT NULL,
    PRIMARY KEY (`StaffID`),
    UNIQUE KEY `uq_staff_email` (`Email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------
-- Events
-- EventName is included because EventMethods.cs explicitly selects it.
-- Duration is INT because EventMethods.cs reads it with GetInt32().
-- --------------------------------------------------------
CREATE TABLE `eventactivity` (
    `EventActivityID` INT NOT NULL AUTO_INCREMENT,
    `AdminID` INT NULL,
    `Address` VARCHAR(150) NOT NULL,
    `Postcode` VARCHAR(20) NOT NULL,
    `BuildingName` VARCHAR(100) NOT NULL,
    `Type` VARCHAR(50) NOT NULL,
    `Description` TEXT NOT NULL,
    `EventDate` DATE NOT NULL,
    `Duration` INT NOT NULL,
    `MaxCapacity` INT NOT NULL,
    `EventName` VARCHAR(120) NOT NULL,
    PRIMARY KEY (`EventActivityID`),
    KEY `idx_event_admin` (`AdminID`),
    CONSTRAINT `fk_event_admin`
        FOREIGN KEY (`AdminID`) REFERENCES `administrator` (`AdminID`)
        ON UPDATE CASCADE
        ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------
-- Billing history
-- --------------------------------------------------------
CREATE TABLE `billings` (
    `PaymentID` INT NOT NULL AUTO_INCREMENT,
    `MemberID` INT NOT NULL,
    `Payment_Date` DATE NOT NULL,
    `PaymentType` VARCHAR(30) NOT NULL DEFAULT 'Online',
    `Pay_for` VARCHAR(50) NOT NULL,
    PRIMARY KEY (`PaymentID`),
    KEY `idx_billings_member` (`MemberID`),
    CONSTRAINT `fk_billings_member`
        FOREIGN KEY (`MemberID`) REFERENCES `member` (`MemberID`)
        ON UPDATE CASCADE
        ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------
-- Feedback
-- --------------------------------------------------------
CREATE TABLE `feedback` (
    `ID` INT NOT NULL AUTO_INCREMENT,
    `Type` VARCHAR(50) NULL,
    `Message` TEXT NULL,
    PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------
-- Pinboard
-- Uses ID (not MessageID) because AdminPinboardForm.cs selects/deletes by ID.
-- --------------------------------------------------------
CREATE TABLE `PinboardMessages` (
    `ID` INT NOT NULL AUTO_INCREMENT,
    `MemberName` VARCHAR(255) NOT NULL,
    `Content` TEXT NOT NULL,
    `Timestamp` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ========================================================
-- Fictional demo data
-- ========================================================

INSERT INTO `administrator`
    (`Email`, `FirstName`, `LastName`, `DOB`)
VALUES
    ('admin.demo@example.com', 'Alex', 'Admin', '1990-01-01');

INSERT INTO `member`
    (`Email`, `FirstName`, `LastName`, `DOB`, `RegistrationDate`, `Membership`)
VALUES
    ('member.demo@example.com', 'Morgan', 'Member', '1998-06-15', '2026-01-10', 'Standard');

INSERT INTO `nonmember`
    (`Email`, `FirstName`, `LastName`, `DOB`)
VALUES
    ('guest.demo@example.com', 'Taylor', 'Guest', '2000-03-20');

-- Demo-only credentials.
-- Current project compares passwords directly as text.
INSERT INTO `logindetails`
    (`Email`, `Password`, `Security_questions`, `Security_questions_answers`)
VALUES
    ('admin.demo@example.com', 'DemoAdmin123!', 'Name of your first pet?', 'demo'),
    ('member.demo@example.com', 'DemoMember123!', 'Name of your first pet?', 'demo'),
    ('guest.demo@example.com', 'DemoGuest123!', 'Name of your first pet?', 'demo');

INSERT INTO `staff`
    (`FirstName`, `LastName`, `JoiningDate`, `Department`, `Email`)
VALUES
    ('Jamie', 'Taylor', '2025-01-15', 'Community', 'staff.demo@example.com');

INSERT INTO `eventactivity`
    (`AdminID`, `Address`, `Postcode`, `BuildingName`, `Type`,
     `Description`, `EventDate`, `Duration`, `MaxCapacity`, `EventName`)
VALUES
    (1, '5 Fitzroy Street', 'CB1 1ER', 'Together Culture',
     'Workshop', 'A fictional demo workshop for testing the application.',
     '2026-12-12', 2, 40, 'Community Creativity Workshop');

INSERT INTO `billings`
    (`MemberID`, `Payment_Date`, `PaymentType`, `Pay_for`)
VALUES
    (1, '2026-10-20', 'Online', 'event');

INSERT INTO `feedback`
    (`Type`, `Message`)
VALUES
    ('General', 'Demo feedback record for the portfolio database.');

INSERT INTO `PinboardMessages`
    (`MemberName`, `Content`)
VALUES
    ('Morgan Member', 'Welcome to the Together Culture demo pinboard.');

-- End of GitHub-safe demo database
