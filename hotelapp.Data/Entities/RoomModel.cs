﻿using System;
using System.Collections.Generic;
using System.Text;

namespace hotelapp.Data.Entities
{
    public class RoomModel
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public int RoomTypeId { get; set; }
    }
}
