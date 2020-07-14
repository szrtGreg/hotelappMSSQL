using hotelapp.Data.Databases;
using hotelapp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hotelapp.Data.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "SqlDb";

        public BookingRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public List<RoomTypeModel> GetAvailableRoomTypes(DateTime startDate, DateTime endDate)
        {
            return _db.LoadData<RoomTypeModel, dynamic>(
                            "dbo.spRoomTypes_GetAvailableRoomTypes",
                            new { StartDate = startDate, EndDate = endDate },
                            connectionStringName,
                            true);
        }

        public void BookGuest(string firstName,
                              string lastName,
                              DateTime startDate,
                              DateTime endDate,
                              int roomTypeId)
        {
            GuestsModel guest = _db.LoadData<GuestsModel, dynamic>(
                            "dbo.spGuests_Insert",
                            new { firstName, lastName },
                            connectionStringName,
                            true).First();

            RoomTypeModel roomType = _db.LoadData<RoomTypeModel, dynamic>(
                            "select * from dbo.RoomTypes where Id = @Id",
                            new { Id = roomTypeId },
                            connectionStringName,
                            false).First();

            TimeSpan timeStaying = endDate.Date.Subtract(startDate.Date);

            List<RoomModel> availableRooms = _db.LoadData<RoomModel, dynamic>("dbo.spRooms_GetAvailableRooms",
                            new { startDate, endDate, roomTypeId },
                            connectionStringName,
                            true);

            _db.SaveData("spBookings_Insert",
                         new
                         {
                             roomId = availableRooms.First().Id,
                             guestId = guest.Id,
                             startDate = startDate,
                             endDate = endDate,
                             totalCost = timeStaying.Days * roomType.Price
                         },
                         connectionStringName,
                         true);

        }


        public List<BookingFullModel> SearchBookings(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                lastName = "";
            }

            return _db.LoadData<BookingFullModel, dynamic>("spBookings_Search",
                                                    new { lastName, startDate = DateTime.Now.Date },
                                                    connectionStringName,
                                                    true);
        }

        public List<RoomsAndRoomType> GetAllRooms()
        {
            return _db.LoadData<RoomsAndRoomType, dynamic>(
                            "dbo.spRooms_GetAllRooms",
                            new { },
                            connectionStringName,
                            true);
        }


        public void CheckInGuest(int bookingId)
        {
            _db.SaveData("spBookings_CheckIn", new { id = bookingId }, connectionStringName, true);
        }

        public RoomsAndRoomType Get(int id)
        {
            return _db.LoadData<RoomsAndRoomType, dynamic>(
                "dbo.spRooms_GetRoom",
                new { roomId = id },
                connectionStringName,
                true).FirstOrDefault();
        }

        public void Update(int roomId, string roomNumber, int roomTypeId)
        {
            _db.SaveData("spRooms_Update", new { roomId, roomNumber, roomTypeId }, connectionStringName, true);
        }
    }
}
