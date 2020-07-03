
declare @startDate date;
declare @endDate date;
declare @lastname nvarchar;

set @startDate = '2020-07-02';
set @endDate = '2020-06-26';
set @lastName = '';


SELECT b.Id, b.RoomId, b.GuestId, b.StartDate, b.EndDate,
b.CheckedIn, b.TotalCost, g.FirstName, g.LastName, r.RoomNumber, 
r.RoomTypeId, rt.Title, rt.Description, rt.Price 
FROM dbo.Bookings b
inner join dbo.Guests g ON b.GuestId = g.Id
inner join dbo.Rooms r ON b.RoomId = r.Id
inner join dbo.RoomTypes rt ON r.RoomTypeId = rt.Id
where b.CheckedIn = 1;


SELECT b.Id, b.RoomId, b.GuestId, b.StartDate, b.EndDate,
b.CheckedIn, b.TotalCost, g.FirstName, g.LastName, r.RoomNumber, 
r.RoomTypeId, rt.Title, rt.Description, rt.Price 
FROM dbo.Bookings b
inner join dbo.Guests g ON b.GuestId = g.Id
inner join dbo.Rooms r ON b.RoomId = r.Id
inner join dbo.RoomTypes rt ON r.RoomTypeId = rt.Id
where b.CheckedIn = 1  and b.EndDate > @startDate
