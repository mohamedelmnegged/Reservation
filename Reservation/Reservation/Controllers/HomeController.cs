using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Reservation.Data.DataAccess;
using Reservation.Models;
using System.Diagnostics;

namespace Reservation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public AppointmentDataAccess _appointmentData { get; }
        private readonly IMapper _mapper;
        public HomeController(ILogger<HomeController> logger,
            AppointmentDataAccess appointmentData,
            IMapper mapper
            )
        {
            _logger = logger;
            _appointmentData = appointmentData;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var appointments = _mapper.Map<IEnumerable<AppointmentViewModel>>( _appointmentData.GetAllAppointment());
           

            return View();
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
    }
}