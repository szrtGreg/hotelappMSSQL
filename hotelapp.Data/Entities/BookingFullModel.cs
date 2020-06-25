﻿using System;
using System.Collections.Generic;
using System.Text;

namespace hotelapp.Data.Entities
{
    public class BookingFullModel
    {
        public int Id { get; set; }
        public int RommId { get; set; }
        public int GuestId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CheckedId { get; set; }
        public decimal TotalCost { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RoomNumber { get; set; }
        public int RoomTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }


    }
}
