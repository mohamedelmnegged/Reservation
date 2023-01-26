using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Reservation.Data.DataAccess;
using Reservation.Models;
using System.Diagnostics;
using Reservation.Data.Tables;

namespace Reservation.Controllers
{
    public class PaientController: Controller
    {
        public AppointmentDataAccess _appointmentData { get; }
        public PaientDataAccess _painetData { get; }
        private readonly IMapper _mapper;
        public PaientController(AppointmentDataAccess appointmentData, PaientDataAccess paientDataAccess,
            IMapper mapper
            )
        {
            _appointmentData = appointmentData;
            _painetData = paientDataAccess;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var appointments = _mapper.Map<IEnumerable<PaientViewModel>>( _painetData.GetAllPaient());
           

            return View(appointments);
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

            if(result.NewId > 0) {
                return RedirectToAction("Index"); 
            }
            ViewBag.inserted = result.Msg; 
           // ModelState.AddModelError("inserted", result.Msg); 
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