CREATE PROCEDURE [dbo].[spBookings_Search]
	@lastName nvarchar(50),
	@startDate date
AS
begin
	set nocount on;

	SELECT [b].[Id], [b].[RoomId], [b].[GuestId], [b].[StartDate], [b].[EndDate],
	[b].[CheckedIn], [b].[TotalCost], [g].[FirstName], [g].[LastName], [r].[RoomNumber], 
	[r].[RoomTypeId], [rt].[Title], [rt].[Description], [rt].[Price] 
	FROM dbo.Bookings b
	inner join dbo.Guests g ON b.GuestId = g.Id
	inner join dbo.Rooms r ON b.RoomId = r.Id
	inner join dbo.RoomTypes rt ON r.RoomTypeId = rt.Id
	where b.StartDate = @startDate   and g.LastName  LIKE @lastname + '%' 
	or (b.EndDate > @startDate and CheckedIn = 1 and g.LastName  LIKE @lastname + '%')

end
