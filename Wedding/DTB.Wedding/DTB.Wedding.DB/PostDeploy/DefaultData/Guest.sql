BEGIN
	
	DECLARE @FamilyId uniqueidentifier;
	DECLARE @TableId uniqueidentifier;
	
	-- Dan's Guests

	-- Maternal Grandparents
	SELECT @FamilyId = Id from dbo.tblFamily where Name = 'Dan Maternal Grandparents'
	SELECT @TableId = Id from dbo.tblTable where Name = 'Float'
	INSERT INTO dbo.tblGuest 
		(Id, FamilyId, TableId, Name, PlusOne, Attendance, PlusOneAttendance, Responded)
	VALUES
		(NEWID(), @FamilyId, @TableId, 'Pat Schneider', 0, 0, 0, 0),
		(NEWID(), @FamilyId, @TableId, 'Bernie Schneider', 0, 0, 0, 0)
	
	-- Paternal Grandpa
	SELECT @FamilyId = Id from dbo.tblFamily where Name = 'Dan Paternal Grandpa'
	INSERT INTO dbo.tblGuest 
		(Id, FamilyId, TableId, Name, PlusOne, Attendance, PlusOneAttendance, Responded)
	VALUES
		(NEWID(), @FamilyId, @TableId, 'Tom Butzen Sr', 0, 0, 0, 0)

	-- Paternal Grandma
	SELECT @FamilyId = Id from dbo.tblFamily where Name = 'Dan Paternal Grandma'
	INSERT INTO dbo.tblGuest 
		(Id, FamilyId, TableId, Name, PlusOne, Attendance, PlusOneAttendance, Responded)
	VALUES
		(NEWID(), @FamilyId, @TableId, 'Amelia Butzen', 1, 0, 0, 0)

	-- Parents
	SELECT @FamilyId = Id from dbo.tblFamily where Name = 'Dan Parents'
	INSERT INTO dbo.tblGuest 
		(Id, FamilyId, TableId, Name, PlusOne, Attendance, PlusOneAttendance, Responded)
	VALUES
		(NEWID(), @FamilyId, @TableId, 'Tom Butzen Jr', 0, 0, 0, 0),
		(NEWID(), @FamilyId, @TableId, 'Jill Butzen', 0, 0, 0, 0),
		(NEWID(), @FamilyId, @TableId, 'Benny Butzen', 0, 0, 0, 0),
		(NEWID(), @FamilyId, @TableId, 'Sofi Butzen', 0, 0, 0, 0)

	
	--Uncle Scott
	SELECT @FamilyId = Id from dbo.tblFamily where Name = 'Dan Uncle Scott'
	INSERT INTO dbo.tblGuest 
		(Id, FamilyId, TableId, Name, PlusOne, Attendance, PlusOneAttendance, Responded)
	VALUES
		(NEWID(), @FamilyId, @TableId, 'Scott Schneider', 1, 0, 0, 0)

	-- Sister
	SELECT @FamilyId = Id from dbo.tblFamily where Name = 'Dan Sister'
	SELECT @TableId = Id from dbo.tblTable where Name = 'Head'
	INSERT INTO dbo.tblGuest 
		(Id, FamilyId, TableId, Name, PlusOne, Attendance, PlusOneAttendance, Responded)
	VALUES
		(NEWID(), @FamilyId, @TableId, 'Maggie Butzen', 0, 0, 0, 0),
		(NEWID(), @FamilyId, @TableId, 'Dakota', 0, 0, 0, 0)

END