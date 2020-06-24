
declare @startDate date;
declare @endDate date;

set @startDate = '2020-06-25';
set @endDate = '2020-06-26';

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