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
    [Authorize]
    public class HomeController : Controller
    {
        public AppointmentDataAccess _appointmentData { get; }
        public PaientDataAccess _painetData { get; }
        private readonly IMapper _mapper;
        private readonly Validate _validate;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signManager;
        public HomeController(AppointmentDataAccess appointmentData, PaientDataAccess paientDataAccess,
            IMapper mapper, Validate validate, UserManager<User> userManager, SignInManager<User> signManager
            )
        {
            _appointmentData = appointmentData;
            _painetData = paientDataAccess;
            _mapper = mapper;
            _validate = validate;
            _userManager = userManager;
            _signManager = signManager; 
        }

        [Authorize]
        public IActionResult Index(SearchViewModel? q)
        {
            // _signInManager.
            //if (!_validate.CheckValidate())
            //    return View("Login", "Auth");
            //(!_signManager.) 

            var model = new SearchViewModel(); // { SearchTerm = q };
            var appointments = _mapper.Map<IEnumerable<AppointmentViewModel>>(_appointmentData.GetAllAppointment());

            if (q != null && q.Status > 0)
            {
                appointments = appointments.Where(a => a.Status == (Data.Enums.Status)q.Status);
            }
            if (q != null && q.Type > 0)
            {
                appointments = appointments.Where(a => a.Type == (Data.Enums.Type)q.Type);
            }
            //if (q.StartDate != null && q.Clicked == 1)
            //{

            //}
            model.Appointments = appointments;

            //if (!string.IsNullOrEmpty(q))
            //{
            //    // Perform the search and get the results
            //    //var results = Search(q);
            //   // model.Appointments = results;
            //}



            return View(model);
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize]
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