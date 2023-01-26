using System.Data;
using System.Data.SqlClient;
using Reservation.Data.Tables; 

namespace Reservation.Data.DataAccess
{
    public class PaientDataAccess
    {
        public IConfiguration _configuration { get; set; }
        public string connectionString { get; set; }
        public PaientDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString =  configuration.GetConnectionString("db");
        }
        
        public IEnumerable<Paient> GetAllPaient()
        {
            List<Paient> lstPaient = new List<Paient>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("getPaients", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Paient Paient = new Paient();
                    Paient.Id = Convert.ToInt32(rdr["Id"]);
                    Paient.FullName = rdr["FullName"].ToString();
                    Paient.Address = rdr["Address"].ToString();
                    Paient.Phone = rdr["Phone"].ToString();
                    Paient.Geneder = Convert.ToInt32( rdr["Geneder"]);
                    Paient.BirthDate = Convert.ToDateTime( rdr["BirthDate"]);
                    Paient.Country = rdr["Country"].ToString();
                    
                    lstPaient.Add(Paient);
                }
                con.Close();
            }
            return lstPaient;
        }
        public Result AddOrUpdatePaient(Paient Paient)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("addOrEditPaient", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@fullName", Paient.FullName);
                cmd.Parameters.AddWithValue("@address", Paient.Address);
                cmd.Parameters.AddWithValue("@phone", Paient.Phone);
                cmd.Parameters.AddWithValue("@country", Paient.Country);
                cmd.Parameters.AddWithValue("@gender", Paient.Geneder);
                cmd.Parameters.AddWithValue("@birthDate", Paient.BirthDate);
                cmd.Parameters.AddWithValue("@id", Paient.Id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                Result Result = new Result();
                while (rdr.Read())
                {
                    Result.NewId = Convert.ToInt32(rdr["ID"]);
                    Result.Msg = rdr["ReturnedMsg"].ToString();
                }
                con.Close();
                return Result;
            }
        }

        public Paient GetPaientDataById(int? id)
        {
            Paient Paient = new Paient();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("getPaientById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    Paient.Id = Convert.ToInt32(rdr["Id"]);
                    Paient.FullName = rdr["FullName"].ToString();
                    Paient.Address = rdr["Address"].ToString();
                    Paient.Phone = rdr["Phone"].ToString();
                    Paient.Geneder = Convert.ToInt32(rdr["Geneder"]);
                    Paient.BirthDate = Convert.ToDateTime(rdr["BirthDate"]);
                    Paient.Country = rdr["Country"].ToString();
                }
            }
            return Paient;
        }

        public Result DeletePaient(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("deletePaient", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                Result Result = new Result();
                while (rdr.Read())
                {
                    Result.NewId = Convert.ToInt32(rdr["ID"]);
                    Result.Msg = rdr["ReturnedMsg"].ToString();
                }
                con.Close();
                return Result;
            }
        }
    }
}
