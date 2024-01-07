using Beauty.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Beauty.Admin.Controllers
{
    [Route("Beauty")]
    public class BeautyController : Controller
    {
        #region---Reference-----
        private readonly ManageBeauty _manageBeauty;
        public BeautyController(ManageBeauty manageBeauty)
        {
            _manageBeauty = manageBeauty;
        }

        #endregion

        #region--------Aboutus------
        [Route("BeautyAboutus")]
        public IActionResult Aboutus()
        {
            return View("/views/beauty/aboutus.cshtml");
        }
        [Route("Aboutus")]
        public async Task<IActionResult> AboutUs(int id = 0)
        {
            try
            {
                IEnumerable<Aboutus> aboutus = await _manageBeauty.Aboutus(id);
                return Content(JsonConvert.SerializeObject(aboutus));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [Route("Aboutus")]
        public async Task<IActionResult> Aboutus([FromBody] Aboutus aboutus)
        {
            try
            {
                if (aboutus != null)
                {
                    await _manageBeauty.Aboutus(aboutus);
                    return Ok(aboutus.ID == 0 ? new { Message = "Aboutus Added succesfully !!!" } : new { Message = "Aboutus Updated succesfully !!!" });

                }
                else
                {
                    return Ok(new { Message = "Data not found  !!!" });

                }

            }
            catch (Exception ex)
            {
                return View("/views/shared/error.cshtml", ex);
            }
        }
        [HttpGet]
        [Route("DeleteAbout")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            try
            {
                await _manageBeauty.DelAboutus(id);
                return Ok(new { Message = "Aboutus Deleted succesfully !!!" });

            }
            catch (Exception ex)
            {
                return View("/views/shared/error.cshtml", ex);
            }
        }


        #endregion

        #region--------Contactus------
        [Route("BeautyContactus")]
        public IActionResult Contactus()
        {
            return View("/views/beauty/contactus.cshtml");
        }
        [Route("Contactus")]
        public async Task<IActionResult> Contactus(int id = 0)
        {
            try
            {
                IEnumerable<Contactus> aboutus = await _manageBeauty.Contactus(id);
                return Content(JsonConvert.SerializeObject(aboutus));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [Route("Contactus")]
        public async Task<IActionResult> Contactus([FromBody] Contactus contactus)
        {
            try
            {
                if (contactus != null)
                {
                    await _manageBeauty.Contactus(contactus);
                    return Ok(contactus.ID == 0 ? new { Message = "Contactus Added succesfully !!!" } : new { Message = "Contactus Updated succesfully !!!" });

                }
                else
                {
                    return Ok(new { Message = "Data not found  !!!" });

                }

            }
            catch (Exception ex)
            {
                return View("/views/shared/error.cshtml", ex);
            }
        }
        [HttpGet]
        [Route("DeleteContactus")]
        public async Task<IActionResult> DelContactus(int id)
        {
            try
            {
                await _manageBeauty.DelContactus(id);
                return Ok(new { Message = "Contactus Deleted succesfully !!!" });

            }
            catch (Exception ex)
            {
                return View("/views/shared/error.cshtml", ex);
            }
        }


        #endregion

        #region--------Service------
        [Route("BeautyService")]
        public IActionResult Service()
        {
            return View("/views/beauty/service.cshtml");
        }
        [Route("Service")]
        public async Task<IActionResult> Service(int? id = 0)
        {
            try
            {
                IEnumerable<Service> services = await _manageBeauty.Service(id);
                return Content(JsonConvert.SerializeObject(services));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [Route("Service")]
        public async Task<IActionResult> Service([FromBody] Service service)
        {
            try
            {
                if (service != null)
                {
                    await _manageBeauty.Service(service);
                    return Ok(service.ID == 0 ? new { Message = "Service Added succesfully !!!" } : new { Message = "Service Updated succesfully !!!" });

                }
                else
                {
                    return Ok(new { Message = "Data not found  !!!" });

                }

            }
            catch (Exception ex)
            {
                return View("/views/shared/error.cshtml", ex);
            }
        }
        [HttpGet]
        [Route("DeleteService")]
        public async Task<IActionResult> DelService(int id)
        {
            try
            {
                await _manageBeauty.DelService(id);
                return Ok(new { Message = "Service Deleted succesfully !!!" });

            }
            catch (Exception ex)
            {
                return View("/views/shared/error.cshtml", ex);
            }
        }


        #endregion


    
    }
}
