
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Reservation.Data.DataAccess;

namespace Reservation.Data
{
    public class Validate : Controller
    {

        private readonly UserDataAccess _userDataAccess;
        public Validate(UserDataAccess userDataAccess)
        {

            _userDataAccess = userDataAccess;

        }
        public bool ValidateLogin(string email, string password)
        {
            var emailSession = HttpContext.Session.GetString("email");
            var passwordSession = HttpContext.Session.GetString("password");
            if (!string.IsNullOrEmpty(emailSession) && emailSession.Equals(email)
                 && !string.IsNullOrEmpty(passwordSession) && passwordSession.Equals(password))
                return true; 
            return false;

        }
        public bool Login(string email, string password)
        {
            if(!string.IsNullOrEmpty(email) && ! string.IsNullOrEmpty(password)) {
                HttpContext.Session.SetString("email", email);
                HttpContext.Session.SetString("password", password);
                return true; 

            }
            return false;

        }

        public bool CheckValidate()
        {
            byte[]? emailSession, passwordSession;
            HttpContext.Session.GetString("email");
            HttpContext.Session.TryGetValue("email", out emailSession);
            HttpContext.Session.TryGetValue("password", out passwordSession);
           
            
            if(emailSession != null && passwordSession != null)
            {
                var user = _userDataAccess.GetUserDataByEmail(emailSession.ToString());
                if(user != null && user.Password.Equals(passwordSession.ToString())) 
                    return true;
            }
            return false;
        }
    }
}
