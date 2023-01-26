using System.Data;
using System.Data.SqlClient;
using Reservation.Data.Tables; 

namespace Reservation.Data.DataAccess
{
    public class AppointmentDataAccess
    {
        public IConfiguration _configuration { get; set; }
        public string connectionString { get; set; }
        public AppointmentDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString =  configuration.GetConnectionString("db");
        }
        
        public IEnumerable<Appointment> GetAllAppointment()
        {
            List<Appointment> lstAppointment = new List<Appointment>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("getAppointments", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Appointment Appointment = new Appointment();
                    Appointment.Id = Convert.ToInt32(rdr["Id"]);
                    Appointment.StartDate = Convert.ToDateTime( rdr["StartDate"]);
                    Appointment.EndDate = Convert.ToDateTime(rdr["EndDate"]);
                    Appointment.Type = Convert.ToInt32( rdr["Type"]);
                    Appointment.Status = Convert.ToInt32(rdr["Status"]);
                    Appointment.PaientId = Convert.ToInt32(rdr["Paient_Id"]);
                    Appointment.Period = Convert.ToInt32(rdr["Period"]);
                    
                    lstAppointment.Add(Appointment);
                }
                con.Close();
            }
            return lstAppointment;
        }
        public Result AddOrUpdateAppointment(Appointment Appointment)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("addOrEditAppointment", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@startDate", Appointment.StartDate);
                cmd.Parameters.AddWithValue("@endDate", Appointment.EndDate);
                cmd.Parameters.AddWithValue("@type", Appointment.Type);
                cmd.Parameters.AddWithValue("@status", Appointment.Status);
                cmd.Parameters.AddWithValue("@paientId", Appointment.PaientId);
                cmd.Parameters.AddWithValue("@id", Appointment.Id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                Result Result = new Result();
                while (rdr.Read())
                {
                    Result.NewId = Convert.ToInt32(rdr["ID"]);
                    Result.Msg = rdr["returnedMsg"].ToString();
                }
                con.Close();
                return Result;
            }
        }

        public Appointment GetAppointmentData(int? id)
        {
            Appointment Appointment = new Appointment();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("getAppointmentById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    Appointment.Id = Convert.ToInt32(rdr["Id"]);
                    Appointment.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    Appointment.EndDate = Convert.ToDateTime(rdr["EndDate"]);
                    Appointment.Type = Convert.ToInt32(rdr["Type"]);
                    Appointment.Status = Convert.ToInt32(rdr["Status"]);
                    Appointment.PaientId = Convert.ToInt32(rdr["Paient_Id"]);
                    Appointment.Period = Convert.ToInt32(rdr["Period"]);
                }
            }
            return Appointment;
        }

        public void DeleteAppointment(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("deleteAppointment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
