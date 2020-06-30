CREATE PROCEDURE [dbo].[spBookings_Insert]
	@startDate date,
	@endDate date,
	@roomId int,
	@guestId int,
	@totalCost money
AS
begin
	set nocount on;

	insert into dbo.Bookings(RoomId, GuestId, StartDate, EndDate, TotalCost)
	values (@roomId, @guestId, @startDate, @endDate, @totalCost);

end