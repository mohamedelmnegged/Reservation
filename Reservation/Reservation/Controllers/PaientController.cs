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

      
        [HttpDelete("/paient/{id}")]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                var deleted = _painetData.DeletePaient(id);
                return Ok(deleted.Msg);
            }
            return Ok("Id is not found");
            //  return RedirectToAction("Index");
        }

        public IActionResult AddPaient()
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
        public IActionResult Save(AddPaientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mapped = _mapper.Map<Paient>(model);
                var result = _painetData.AddOrUpdatePaient(mapped);

                if (result.NewId > 0)
                {
                    return RedirectToAction("Index");
                }
                ViewBag.inserted = result.Msg;
                // ModelState.AddModelError("inserted", result.Msg); 
            }
            return View("AddPaient", model);
        }

        public IActionResult Edit(int id)
        {
            var painet = _painetData.GetPaientDataById(id); 
            if(painet != null) {
                if (painet.Id > 0)
                {
                    var model = _mapper.Map<AddPaientViewModel>(painet);

                    return View("AddPaient", model);
                }
            }
            ViewBag.Paient = "This Paient is not found"; 
            return RedirectToAction("Index"); 
        }
    }
}