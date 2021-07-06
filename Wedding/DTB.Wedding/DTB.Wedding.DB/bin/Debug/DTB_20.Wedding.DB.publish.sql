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
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
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
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


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
    [Id]                UNIQUEIDENTIFIER NOT NULL,
    [FamilyId]          UNIQUEIDENTIFIER NOT NULL,
    [TableId]           UNIQUEIDENTIFIER NULL,
    [Name]              NVARCHAR (50)    NOT NULL,
    [PlusOne]           BIT              NOT NULL,
    [Attendance]        BIT              NULL,
    [PlusOneAttendance] BIT              NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[tblTable]...';


GO
CREATE TABLE [dbo].[tblTable] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Name]         NVARCHAR (50)    NOT NULL,
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
PRINT N'Creating [dbo].[spCalRemainingChairs]...';


GO
CREATE PROCEDURE [dbo].[spCalRemainingChairs]
	@TableId uniqueidentifier
AS
BEGIN
SELECT 
(
	SELECT 
		NumberChairs 
	FROM 
		tblTable 
	WHERE 
		Id = @TableId
) -
(
	SELECT 
		COUNT(*) 
	FROM 
		tblGuest AS g join 
		tblTable AS t on 
		g.TableId = t.Id 
	WHERE 
		t.Id = @TableId
)
AS 'RemainingSeats'

END
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
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '3c674dee-1e3f-4b7e-8864-8d9b9ca3b9da')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('3c674dee-1e3f-4b7e-8864-8d9b9ca3b9da')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'c98aa5a8-299c-4675-8e6c-68f0ea3a2103')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('c98aa5a8-299c-4675-8e6c-68f0ea3a2103')

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
	(NEWID(), 'Dan Parents', 'AngryZebra'),
	(NEWID(), 'Dan Sister', 'GrowlingKoala'),
	(NEWID(), 'Dan Paternal Grandpa', 'HappyBadger'),
	(NEWID(), 'Dan Paternal Grandma', 'RadiantGoldfish'),
	(NEWID(), 'Dan Maternal Grandparents', 'WonderousSalmon'),
	(NEWID(), 'Dan Uncle Scott', 'TastyAnt'),
	(NEWID(), 'Dan Uncle Brian', 'HappyBear'),
	(NEWID(), 'Dan Aunt Jenny', 'UnhappyKing'),
	(NEWID(), 'Dan Uncle Dave', 'GratefulUndead'),
	(NEWID(), 'Dan Uncle Paul', 'BlackCat'),
	(NEWID(), 'Dan Aunt Karie', 'FastCar'),
	(NEWID(), 'Dan Uncle Al', 'RandomRelic'),
	(NEWID(), 'Dan Friend Ross', 'NarutoPikachu')
END
BEGIN
INSERT INTO [dbo].[tblTable]
	(Id, Name, NumberChairs)
VALUES
	(NEWID(), 'Head', 12),
	(NEWID(), 'Table1', 20),
	(NEWID(), 'Table2', 20),
	(NEWID(), 'Table3', 20),
	(NEWID(), 'Table4', 20),
	(NEWID(), 'Table5', 20)
END
BEGIN
	
	DECLARE @FamilyId uniqueidentifier;
	DECLARE @TableId uniqueidentifier;
	
	-- Dan's Guests

	-- Maternal Grandparents
	SELECT @FamilyId = Id from dbo.tblFamily where Name = 'Dan Maternal Grandparents'
	INSERT INTO dbo.tblGuest 
		(Id, FamilyId, TableId, Name, PlusOne, Attendance, PlusOneAttendance)
	VALUES
		(NEWID(), @FamilyId, NULL, 'Pat Schneider', 0, NULL, NULL),
		(NEWID(), @FamilyId, NULL, 'Bernie Schneider', 0, NULL, NULL)
	
	-- Paternal Grandpa
	SELECT @FamilyId = Id from dbo.tblFamily where Name = 'Dan Paternal Grandpa'
	INSERT INTO dbo.tblGuest 
		(Id, FamilyId, TableId, Name, PlusOne, Attendance, PlusOneAttendance)
	VALUES
		(NEWID(), @FamilyId, NULL, 'Tom Butzen Sr', 0, NULL, NULL)

	-- Paternal Grandma
	SELECT @FamilyId = Id from dbo.tblFamily where Name = 'Dan Paternal Grandma'
	INSERT INTO dbo.tblGuest 
		(Id, FamilyId, TableId, Name, PlusOne, Attendance, PlusOneAttendance)
	VALUES
		(NEWID(), @FamilyId, NULL, 'Amelia Butzen', 1, NULL, NULL)

	-- Parents
	SELECT @FamilyId = Id from dbo.tblFamily where Name = 'Dan Parents'
	INSERT INTO dbo.tblGuest 
		(Id, FamilyId, TableId, Name, PlusOne, Attendance, PlusOneAttendance)
	VALUES
		(NEWID(), @FamilyId, NULL, 'Tom Butzen Jr', 0, NULL, NULL),
		(NEWID(), @FamilyId, NULL, 'Jill Butzen', 0, NULL, NULL),
		(NEWID(), @FamilyId, NULL, 'Benny Butzen', 0, NULL, NULL),
		(NEWID(), @FamilyId, NULL, 'Sofi Butzen', 0, NULL, NULL)

	-- Sister
	SELECT @FamilyId = Id from dbo.tblFamily where Name = 'Dan Sister'
	SELECT @TableId = Id from dbo.tblTable where Name = 'Head'
	INSERT INTO dbo.tblGuest 
		(Id, FamilyId, TableId, Name, PlusOne, Attendance, PlusOneAttendance)
	VALUES
		(NEWID(), @FamilyId, @TableId, 'Maggie Butzen', 0, NULL, NULL),
		(NEWID(), @FamilyId, @TableId, 'Dakota', 0, NULL, NULL)

	--Uncle Scott
	SELECT @FamilyId = Id from dbo.tblFamily where Name = 'Dan Uncle Scott'
	INSERT INTO dbo.tblGuest 
		(Id, FamilyId, TableId, Name, PlusOne, Attendance, PlusOneAttendance)
	VALUES
		(NEWID(), @FamilyId, NULL, 'Scott Schneider', 1, NULL, NULL)
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
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO
