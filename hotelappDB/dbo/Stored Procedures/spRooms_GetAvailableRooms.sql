CREATE PROCEDURE [dbo].[spRooms_GetAvailableRooms]
	@startDate date,
	@endDate date,
	@roomTypeId int
AS
begin
	set nocount on;

	SELECT r.* FROM dbo.Rooms r
		INNER JOIN dbo.RoomTypes rt
		ON RoomTypeId = rt.Id
		WHERE r.RoomTypeId = @roomTypeId 
		and r.Id not in (
		SELECT b.RoomId FROM dbo.Bookings b
		WHERE @startDate < b.StartDate and @endDate > b.EndDate
		 or (b.StartDate <= @endDate and @endDate < b.EndDate)
		 or (b.StartDate <= @startDate and @startDate < b.EndDate)
	)

end