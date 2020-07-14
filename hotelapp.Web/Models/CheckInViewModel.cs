using hotelapp.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotelapp.Web.Models
{
    public class CheckInViewModel
    {
        public string LastName { get; set; }

        public List<BookingFullModel> Bookings { get; set; }

    }
}
