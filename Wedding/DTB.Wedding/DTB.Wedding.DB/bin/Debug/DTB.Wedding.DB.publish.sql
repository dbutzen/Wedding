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
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                CURSOR_DEFAULT LOCAL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE,
                DISABLE_BROKER 
            WITH ROLLBACK IMMEDIATE;
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367)) 
            WITH ROLLBACK IMMEDIATE;
    END


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
PRINT N'Rename refactoring operation with key 71debc87-a7d7-452c-a758-7c2c237c895c is skipped, element [dbo].[tblTable].[FamilyName] (SqlSimpleColumn) will not be renamed to TableName';


GO
PRINT N'Rename refactoring operation with key 69131b40-c649-4093-a2d5-d469f54bb888 is skipped, element [dbo].[tblFamily].[LoginId] (SqlSimpleColumn) will not be renamed to Code';


GO
PRINT N'Creating [dbo].[tblFamily]...';


GO
CREATE TABLE [dbo].[tblFamily] (
    [Id]    UNIQUEIDENTIFIER NOT NULL,
    [Name]  NVARCHAR (50)    NOT NULL,
    [Code]  NVARCHAR (50)    NOT NULL,
    [Email] NVARCHAR (50)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[tblGuest]...';


GO
CREATE TABLE [dbo].[tblGuest] (
    [Id]             UNIQUEIDENTIFIER NOT NULL,
    [FamilyId]       UNIQUEIDENTIFIER NOT NULL,
    [TableId]        UNIQUEIDENTIFIER NULL,
    [Name]           NVARCHAR (50)    NOT NULL,
    [NumberPlusOnes] INT              NOT NULL,
    [Attendance]     BIT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[tblTable]...';


GO
CREATE TABLE [dbo].[tblTable] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [TableName]    NVARCHAR (50)    NOT NULL,
    [NumberChairs] INT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[tblUser]...';


GO
CREATE TABLE [dbo].[tblUser] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [Login]    NVARCHAR (50)    NOT NULL,
    [Password] NVARCHAR (64)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '71debc87-a7d7-452c-a758-7c2c237c895c')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('71debc87-a7d7-452c-a758-7c2c237c895c')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '69131b40-c649-4093-a2d5-d469f54bb888')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('69131b40-c649-4093-a2d5-d469f54bb888')

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