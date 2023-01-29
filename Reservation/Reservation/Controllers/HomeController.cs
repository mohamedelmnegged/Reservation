using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Reservation.Data.DataAccess;
using Reservation.Models;
using System.Diagnostics;
using Reservation.Data.Tables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Reservation.Data;

namespace Reservation.Controllers
{
    public class HomeController : Controller
    {
        public AppointmentDataAccess _appointmentData { get; }
        public PaientDataAccess _painetData { get; }
        private readonly IMapper _mapper;
        private readonly Validate _validate;

        public HomeController(AppointmentDataAccess appointmentData, PaientDataAccess paientDataAccess,
            IMapper mapper, Validate validate
            )
        {
            _appointmentData = appointmentData;
            _painetData = paientDataAccess;
            _mapper = mapper;
            _validate = validate;
        }

       // [Authorize]
        public IActionResult Index()
        {
            // _signInManager.
            if (!_validate.CheckValidate())
                return View("Login", "Auth");
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
            if (id > 0)
            {
                var deleted = _appointmentData.DeleteAppointment(id);
                return Ok(deleted.Msg);
            }
            return Ok("Id is not found");
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
            if (ModelState.IsValid)
            {
                var mapped = _mapper.Map<Appointment>(model);
                var result = _appointmentData.AddOrUpdateAppointment(mapped);

                if (result.NewId > 0)
                {
                    return RedirectToAction("Index");
                }
                ViewBag.inserted = result.Msg;
                // ModelState.AddModelError("inserted", result.Msg); 
            }
            return View("AddAppointment", model);
        }

        public IActionResult Edit(int id)
        {
            var appointment = _appointmentData.GetAppointmentData(id); 
            if(appointment != null) {
                if (appointment.Id > 0)
                {
                    var model = _mapper.Map<AddAppointmentViewModel>(appointment);

                    return View("AddAppointment", model);
                }
            }
            ViewBag.Appointment = "This Appointment is not found"; 
            return RedirectToAction("Index"); 
        }
    }
}