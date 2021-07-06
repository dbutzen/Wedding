CREATE TABLE [dbo].[tblGuest]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [FamilyId] UNIQUEIDENTIFIER NOT NULL, 
    [TableId] UNIQUEIDENTIFIER NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL,
    [PlusOne] BIT NOT NULL, 
    [Attendance] BIT NOT NULL, 
    [PlusOneAttendance] BIT NOT NULL, 
    [Responded] BIT NOT NULL
)
