namespace Reservation.Models
{
    public class PaientViewModel
    {
        public PaientViewModel()
        {
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Geneder { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
    }
}