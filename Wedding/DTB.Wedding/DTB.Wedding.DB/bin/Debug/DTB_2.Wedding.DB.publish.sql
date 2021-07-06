﻿/*
Deployment script for DTB.Wedding.DB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DTB.Wedding.DB"
:setvar DefaultFilePrefix "DTB.Wedding.DB"
:setvar DefaultDataPath "C:\Users\Dan\AppData\Local\Microsoft\VisualStudio\SSDT\"
:setvar DefaultLogPath "C:\Users\Dan\AppData\Local\Microsoft\VisualStudio\SSDT\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
DROP TABLE IF EXISTS dbo.tblFamily
DROP TABLE IF EXISTS dbo.tblGuest
DROP TABLE IF EXISTS dbo.tblTable
DROP TABLE IF EXISTS dbo.tblUser
GO

GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
BEGIN
INSERT INTO dbo.tblFamily
	(Id, Name, Code)
VALUES
	(NEWID(), 'Dan''s Parents', 'AngryZebra'),
	(NEWID(), 'Dan''s Sister', 'GrowlingKoala'),
	(NEWID(), 'Dan''s Paternal Grandpa', 'HappyBadger'),
	(NEWID(), 'Dan''s Paternal Grandma', 'RadiantGoldfish'),
	(NEWID(), 'Dan''s Maternal Grandparents', 'WonderousSalmon'),
	(NEWID(), 'Dan''s Uncle Scott', 'TastyAnt'),
	(NEWID(), 'Dan''s Uncle Brian', 'HappyBear'),
	(NEWID(), 'Dan''s Aunt Jenny', 'UnhappyKing'),
	(NEWID(), 'Dan''s Uncle Dave', 'GratefulUndead'),
	(NEWID(), 'Dan''s Uncle Paul', 'BlackCat'),
	(NEWID(), 'Dan''s Aunt Karie', 'FastCar'),
	(NEWID(), 'Dan''s Uncle Al', 'RandomRelic'),
	(NEWID(), 'Dan''s Friend Ross', 'NarutoPikachu')
END
BEGIN
	
	DECLARE @FamilyId uniqueidentifier;
	
	-- Dan's Guests

	-- Maternal Grandparents
	SELECT @FamilyId from tblFamily where Name LIKE 'Dan''s Maternal Grandparents'
	INSERT INTO dbo.tblGuest 
		(Id, FamilyId, TableId, Name, NumberPlusOnes, Attendance)
	VALUES
		(NEWID(), @FamilyId, NULL, 'Pat Schneider', 0, NULL),
		(NEWID(), @FamilyId, NULL, 'Bernie Schneider', 0, NULL)
	
	-- Paternal Grandpa
	SELECT @FamilyId from tblFamily where Name LIKE 'Dan''s Paternal Grandpa'
	INSERT INTO dbo.tblGuest 
		(Id, FamilyId, TableId, Name, NumberPlusOnes, Attendance)
	VALUES
		(NEWID(), @FamilyId, NULL, 'Tom Butzen Sr', 0, NULL)

	-- Paternal Grandma
	SELECT @FamilyId from tblFamily where Name LIKE 'Dan''s Paternal Grandma'
	INSERT INTO dbo.tblGuest 
		(Id, FamilyId, TableId, Name, NumberPlusOnes, Attendance)
	VALUES
		(NEWID(), @FamilyId, NULL, 'Amelia Butzen', 1, NULL)

	-- Parents
	SELECT @FamilyId from tblFamily where Name LIKE 'Dan''s Parents'
	INSERT INTO dbo.tblGuest 
		(Id, FamilyId, TableId, Name, NumberPlusOnes, Attendance)
	VALUES
		(NEWID(), @FamilyId, NULL, 'Tom Butzen Jr', 0, NULL),
		(NEWID(), @FamilyId, NULL, 'Jill Butzen', 0, NULL),
		(NEWID(), @FamilyId, NULL, 'Benny Butzen', 0, NULL),
		(NEWID(), @FamilyId, NULL, 'Sofi Butzen', 0, NULL)
END
BEGIN
INSERT INTO [dbo].[tblTable]
	(Id, TableName, NumberChairs)
VALUES
	(NEWID(), 'Head', 12),
	(NEWID(), 'Table1', 20),
	(NEWID(), 'Table2', 20),
	(NEWID(), 'Table3', 20),
	(NEWID(), 'Table4', 20),
	(NEWID(), 'Table5', 20)
END
BEGIN

-- Admin Account
DECLARE @UniqueKey uniqueidentifier = NEWID();
DECLARE @Password NVARCHAR(50) = 'admin';
DECLARE @HashedPassword NVARCHAR(64) = CONVERT(NVARCHAR(MAX), HASHBYTES('SHA2_256', @Password+UPPER(CAST(@UniqueKey AS NVARCHAR(36)))), 2);

INSERT INTO dbo.tblUser
	(Id, Login, Password)
VALUES
	(NEWID(), 'Admin', @HashedPassword)

END
GO

GO
PRINT N'Update complete.';


GO