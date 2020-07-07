CREATE PROCEDURE [dbo].[spRooms_GetAllRooms]

AS
begin
		set nocount on;
		SELECT r.Id, r.RoomNumber, rt.Title, rt.Price  FROM dbo.Rooms r
		inner join dbo.RoomTypes rt ON r.RoomTypeId = rt.Id
end 