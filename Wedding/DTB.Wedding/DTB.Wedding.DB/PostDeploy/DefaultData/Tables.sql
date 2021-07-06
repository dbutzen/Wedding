BEGIN
INSERT INTO [dbo].[tblTable]
	(Id, Name, NumberChairs)
VALUES
	(NEWID(), 'Float', 500),
	(NEWID(), 'Head', 12),
	(NEWID(), 'Table1', 20),
	(NEWID(), 'Table2', 20),
	(NEWID(), 'Table3', 20),
	(NEWID(), 'Table4', 20),
	(NEWID(), 'Table5', 20)
END