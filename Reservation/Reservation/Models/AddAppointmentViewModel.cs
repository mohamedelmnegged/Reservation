using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Reservation.Models
{
    public class AddAppointmentViewModel
    {
        public AddAppointmentViewModel()
        {
        }
        public int Id { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; } = DateTime.Now;
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; } = DateTime.Now;
        [Required]
        public int Status { get; set; }
        [Required]
        public int Type { get; set; }
        public int PaientId { get; set; }
        public int Period { get; set; }
       // public SelectList Paients { get; set; }
    }
}