CREATE TABLE [dbo].[tblUser]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Username] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(64) NOT NULL, 
    [UniqueKey] UNIQUEIDENTIFIER NOT NULL, 
    [SessionKey] UNIQUEIDENTIFIER NULL
)
