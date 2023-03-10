using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Reservation.Models
{
    public class SearchViewModel
    {

        //public string SearchTerm { get; set; }
        public IEnumerable<AppointmentViewModel> Appointments { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; } = DateTime.Now;
        public int Status { get; set; }
        public int Type { get; set; }
        public int Clicked { get; set; }    }
}