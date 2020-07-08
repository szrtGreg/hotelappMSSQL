CREATE PROCEDURE [dbo].[spRooms_GetRoom]
	@roomId int

AS
begin
		set nocount on;
		SELECT r.Id, r.RoomNumber, r.RoomTypeId, rt.Title, rt.Description, rt.Price  FROM dbo.Rooms r
		inner join dbo.RoomTypes rt ON r.RoomTypeId = rt.Id
		where r.Id = @roomId
end
