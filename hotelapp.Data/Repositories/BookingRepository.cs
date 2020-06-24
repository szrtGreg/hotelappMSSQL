using hotelapp.Data.Databases;
using hotelapp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace hotelapp.Data.Repositories
{
    public class BookingRepository
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
    }
}
