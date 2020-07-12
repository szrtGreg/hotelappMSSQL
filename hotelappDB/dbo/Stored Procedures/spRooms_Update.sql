CREATE PROCEDURE [dbo].[spRooms_Update]
	@roomId int,
	@roomTypeId int,
	@roomNumber nvarchar(10)
AS
begin
	set nocount on;

	update dbo.Rooms 
		set RoomNumber = @roomNumber, RoomTypeId = @roomTypeId
		where Id = @roomId

end
