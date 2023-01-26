using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Reservation.Models
{
    public class AppointmentViewModel
    {
        public AppointmentViewModel()
        {
            Paient = new PaientViewModel();
  
        }
        [Required]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        [Required]
        public Data.Enums.Type Type { get; set; }
        [Required]
        public Data.Enums.Status Status { get; set; }
        [Required]
        public PaientViewModel Paient { get; set; }
        public int PaientId { get; set; }
        public int Period { get; set; }

        public Data.Enums.StatusColors StatusColor { get; set; }
        public Data.Enums.TypeColors TypeColor { get; set; }
    }
}