using hotelapp.Data.Entities;
using System;
using System.Collections.Generic;

namespace hotelapp.Data.Repositories
{
    public interface IBookingRepository
    {
        void BookGuest(string firstName, string lastName, DateTime startDate, DateTime endDate, int roomTypeId);
        void CheckInGuest(int bookingId);
        List<RoomTypeModel> GetAvailableRoomTypes(DateTime startDate, DateTime endDate);
        List<BookingFullModel> SearchBookings(string lastName);
        RoomsAndRoomType Get(int roomId);
        List<RoomsAndRoomType> GetAllRooms();

        void Update(int roomId, string roomNumber, int roomTypeId);
    }
}