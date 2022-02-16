using DBNewQuery.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using PartialViewCrudDemo.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PartialViewCrudDemo.Controllers
{
    public class SpecialityController : Controller
    {
        private readonly DataContext _dataContext;

        public SpecialityController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllSpecialitys()
        {
            return Json(_dataContext.Especialidad.ToList(), new Newtonsoft.Json.JsonSerializerSettings());
        }
        public ActionResult LoadEditSpecialityPopup(int TeacherId)
        {
            try
            {
                var model = _dataContext.Especialidad.Where(a => a.EspecialidadId == TeacherId).FirstOrDefault();
                return PartialView("_UpdateSpeciality", model);
            }
            catch (Exception ex)
            {
                return PartialView("_UpdateSpeciality");
            }
        }

        public ActionResult LoadaddSpecialityPopup()
        {
            try
            {
                return PartialView("_AddSpeciality");
            }
            catch (Exception ex)
            {
                return PartialView("_AddSpeciality");
            }
        }

        [HttpPost]
        public async Task<JsonResult> AddSpeciality([FromBody] JObject dataObj)
        {
            string status = "success";
            try
            {
                Especialidad ojb = new Especialidad {
                    EspecialidadNombre = dataObj["EspecialidadNombre"].Value<string>()
                };
                _dataContext.Especialidad.Add(ojb);
               await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                status = ex.Message;
            }
            return Json(status);

        }
        public async Task<JsonResult> UpdateSpeciality([FromBody] JObject dataObj)
        {

            string status = "success";
            try
            {
                //var property1 = data.GetProperty("property1").GetString();
                //var property2 = data.GetProperty("property2").GetGuid();
                //var property3 = data.GetProperty("property3").GetDecimal();
                //var property4 = data.GetProperty("property4").GetDateTime();

                Especialidad ojb = new Especialidad{
                    EspecialidadId = dataObj["EspecialidadId"].Value<int>(),
                    EspecialidadNombre = dataObj["EspecialidadNombre"].Value<string>(),
                };
                _dataContext.Especialidad.Update(ojb);
                await _dataContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                status = ex.Message;

            }
            return Json(dataObj, new Newtonsoft.Json.JsonSerializerSettings());
        }
        public async Task<JsonResult> DeleteSpeciality(int TeacherId)
        {
            string status = "success";
            try
            {

                var pateint = await _dataContext.Especialidad.FindAsync(TeacherId);
                _dataContext.Especialidad.Remove(pateint);
                await _dataContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                status = ex.Message;

            }
            return Json(status, new Newtonsoft.Json.JsonSerializerSettings());
        }
        public async Task<JsonResult> List()
        {
            await _dataContext.SaveChangesAsync();
            return Json(123456, new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}
