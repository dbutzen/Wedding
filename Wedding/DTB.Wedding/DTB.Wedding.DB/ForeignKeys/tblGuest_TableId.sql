ALTER TABLE [dbo].[tblGuest]
	ADD CONSTRAINT [tblGuest_TableId]
	Foreign Key (TableId)
	REFERENCES [tblTable] (Id) ON DELETE CASCADE