using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hotelapp.Web.Models
{
    public class SearchViewModel
    {
        [DataType(DataType.Date)]
        [DateNotInPastValidation]
        [Required]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [DateNotInPastValidation]
        [Required]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);

    }
}
