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