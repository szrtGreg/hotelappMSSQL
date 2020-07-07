using System;
using System.Collections.Generic;
using System.Text;

namespace hotelapp.Data.Entities
{
    public class RoomsAndRoomType
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string  Title { get; set; }
        public decimal Price { get; set; }
    }
}
