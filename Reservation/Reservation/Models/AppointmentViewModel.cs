using System.ComponentModel.DataAnnotations;

namespace Reservation.Models
{
    public class AppointmentViewModel
    {
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
        public int Period { get; set; }
    }
}