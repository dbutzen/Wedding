BEGIN

-- Admin Account
DECLARE @UniqueKey uniqueidentifier = NEWID();
DECLARE @Password NVARCHAR(50) = 'admin';
DECLARE @HashedPassword NVARCHAR(64) = CONVERT(NVARCHAR(MAX), HASHBYTES('SHA2_256', @Password+UPPER(CAST(@UniqueKey AS NVARCHAR(36)))), 2);

INSERT INTO dbo.tblUser
	(Id, Username, Password, UniqueKey)
VALUES
	(NEWID(), 'Admin', @HashedPassword, @UniqueKey)

END