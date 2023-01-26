using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Reservation.Data.DataAccess;
using Reservation.Models;
using System.Diagnostics;

namespace Reservation.Controllers
{
    public class HomeController : Controller
    {
        public AppointmentDataAccess _appointmentData { get; }
        private readonly IMapper _mapper;
        public HomeController(AppointmentDataAccess appointmentData,
            IMapper mapper
            )
        {
            _appointmentData = appointmentData;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var appointments = _mapper.Map<IEnumerable<AppointmentViewModel>>( _appointmentData.GetAllAppointment());
           

            return View(appointments);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpDelete("/appointment/{id}")]
        public IActionResult Delete(int id)
        {
            // delete the item from the database
            // ...
            _appointmentData.DeleteAppointment(id);
            return Ok(); 
            //  return RedirectToAction("Index");
        }

        public IActionResult AddAppointment()
        {

            return View(); 
        }
    }
}