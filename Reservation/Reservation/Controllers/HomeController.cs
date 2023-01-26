using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Reservation.Data.DataAccess;
using Reservation.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Reservation.Data.Tables;

namespace Reservation.Controllers
{
    public class HomeController : Controller
    {
        public AppointmentDataAccess _appointmentData { get; }
        public PaientDataAccess _painetData { get; }
        private readonly IMapper _mapper;
        public HomeController(AppointmentDataAccess appointmentData, PaientDataAccess paientDataAccess,
            IMapper mapper
            )
        {
            _appointmentData = appointmentData;
            _painetData = paientDataAccess;
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

           // var model = new AddAppointmentViewModel();
           //// model.Paients = new SelectList(_painetData.GetAllPaient());
           // model.Paients = new SelectList(
           //     _painetData.GetAllPaient()
           //     .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.FullName)),
           //     "Key", "Value"
           //     );

            return View(); 
        }
        public IActionResult Save(AddAppointmentViewModel model)
        {
            var mapped = _mapper.Map<Appointment>(model); 
            var result =  _appointmentData.AddOrUpdateAppointment(mapped);


            return View(model);
        }
    }
}