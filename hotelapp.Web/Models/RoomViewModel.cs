using hotelapp.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hotelapp.Web.Models
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public int RoomTypeId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }

        public List<SelectListItem> Categories { get; } = new List<SelectListItem>
        {
            new SelectListItem { Text = "KS1", Value = "1"},
            new SelectListItem { Text = "KS2", Value = "2"},
            new SelectListItem { Text = "KS3", Value = "3"},
        };

        public RoomViewModel()
        {

        }

        public RoomViewModel(RoomsAndRoomType room)
        {
            Id = room.Id;
            RoomNumber = room.RoomNumber;
            RoomTypeId = room.RoomTypeId;
            Description = room.Description;
            Title = room.Title;
            Price = string.Format("{0:C}", room.Price);
        }
    }
}
