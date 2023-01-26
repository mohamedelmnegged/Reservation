using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Reservation.Models
{
    public class AddPaientViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Full Name is Required")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; } 

        [Required(ErrorMessage = "Phone is Required")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Geneder is Required")]
        public int Geneder { get; set; }

        [Required(ErrorMessage = "Birth Date is Required")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Country is Required")]
        public string Country { get; set; }
    }
}