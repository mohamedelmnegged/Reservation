using System.Data;
using System.Data.SqlClient;
using Reservation.Data.Tables; 

namespace Reservation.Data.DataAccess
{
    public class UserDataAccess
    {
        public IConfiguration _configuration { get; set; }
        public string connectionString { get; set; }
        public UserDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString =  configuration.GetConnectionString("db");
        }
        
        public Result AddOrUpdateUser(User User)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("addOrEditUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", User.Name);
                cmd.Parameters.AddWithValue("@email", User.Email);
                cmd.Parameters.AddWithValue("@password", User.Password);
                cmd.Parameters.AddWithValue("@id", User.Id);
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

        public User GetUserDataById(int? id)
        {
            User User = new User();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("getUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    User.Id = Convert.ToInt32(rdr["Id"]);
                    User.Name = rdr["Name"].ToString();
                    User.Email = rdr["Email"].ToString();
                    User.Password = rdr["Password"].ToString();
                }
            }
            return User;
        }
        public User GetUserDataByEmail(string email)
        {
            User User = new User();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("getUserByEmail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", email);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    User.Id = Convert.ToInt32(rdr["Id"]);
                    User.Name = rdr["Name"].ToString();
                    User.Email = rdr["Email"].ToString();
                    User.Password = rdr["Password"].ToString();
                }
            }
            return User;
        }

        public Result DeleteUser(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("deleteUser", con);
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
