CREATE PROCEDURE [dbo].[spRoomTypes_GetAvailableRoomTypes]
	@startDate date,
	@endDate date
AS
begin
	set nocount on;

	SELECT rt.Id, rt.Title, rt.Description, rt.Price FROM dbo.Rooms r
		INNER JOIN dbo.RoomTypes rt
		ON r.RoomTypeId = rt.Id
		WHERE r.Id not in (
		select b.RoomId 
		FROM dbo.Bookings b
		WHERE (@startDate < b.StartDate and @endDate > b.EndDate)
			or (b.StartDate <= @endDate and @endDate < b.EndDate)
			or (b.StartDate <= @startDate and @startDate < b.EndDate))
		GROUP BY rt.Id, rt.Title, rt.Description, rt.Price

end