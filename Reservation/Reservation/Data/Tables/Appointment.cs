namespace Reservation.Data.Tables
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
        public int PaientId { get; set; }
        public int Period { get; set; }
    }
}
