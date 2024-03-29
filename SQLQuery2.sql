﻿
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



declare @startDate date;
declare @endDate date;

set @startDate = '2020-07-02';
set @endDate = '2020-06-03';

	SELECT [b].[Id], [b].[RoomId], [b].[GuestId], [b].[StartDate], [b].[EndDate],
	[b].[CheckedIn], [b].[TotalCost], [g].[FirstName], [g].[LastName], [r].[RoomNumber], 
	[r].[RoomTypeId], [rt].[Title], [rt].[Description], [rt].[Price] 
	FROM dbo.Bookings b
	inner join dbo.Guests g ON b.GuestId = g.Id
	inner join dbo.Rooms r ON b.RoomId = r.Id
	inner join dbo.RoomTypes rt ON r.RoomTypeId = rt.Id
	where b.StartDate = @startDate and g.LastName  LIKE @lastname + '%';



	select * from RoomTypes


declare @id int;

set @id = 4

SELECT r.Id, r.RoomNumber, r.RoomTypeId, rt.Title, rt.Description, rt.Price  FROM dbo.Rooms r
		inner join dbo.RoomTypes rt ON r.RoomTypeId = rt.Id
		where r.Id = @id

select * FROM dbo.Rooms
select * FROM dbo.RoomTypes

declare @id int;
declare @roomNumber varchar(10);
declare @roomTypeId int;

set @id = 4;
set @roomNumber = 22222;
set @roomTypeId = 2;

update dbo.Rooms 
set RoomNumber = @roomNumber, RoomTypeId = @roomTypeId
where Id = @id





update dbo.Rooms
	set CheckedIn = 1
	where Id = @id;



declare @startDate date;
declare @endDate date;
declare @lastname nvarchar;

set @startDate = '2021-01-13';
set @endDate = '2021-01-14';

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