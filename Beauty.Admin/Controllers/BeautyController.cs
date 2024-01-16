using Beauty.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;

namespace Beauty.Admin.Controllers
{
    [Route("Beauty")]
    public class BeautyController : Controller
    {
        #region---Reference-----
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ManageBeauty _manageBeauty;
        public BeautyController(ManageBeauty manageBeauty,IWebHostEnvironment webHostEnvironment)
        {
            _manageBeauty = manageBeauty;
            _webHostEnvironment = webHostEnvironment;
        }

        #endregion

        #region--------Aboutus------
        [Route("BeautyAboutus")]
        public IActionResult Aboutus()
        {
            return View("/views/beauty/aboutus.cshtml");
        }
        [HttpGet]
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
        public async Task<IActionResult> AboutUs([FromForm] Aboutus aboutus)
        {
            try
            {
                if (aboutus != null)
                {
                    //var location = new Uri($"{Request.Scheme}://{Request.Host}");
                    var files = HttpContext.Request.Form.Files;

                    if(files != null)
                    {
                        foreach (var Image in files)
                        {
                            if (Image != null && Image.Length > 0)
                            {
                                var file = Image;
                                var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "Content\\Image\\");
                                if (!Directory.Exists(uploads))
                                {
                                    Directory.CreateDirectory(uploads);
                                }
                                if (file.Length > 0)
                                {
                                    string guid = Guid.NewGuid().ToString("N");
                                    string fixedGuid = guid.Substring(0, 20);
                                    var fileName =  fixedGuid + Path.GetExtension(file.FileName);
                                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                                    {
                                        await file.CopyToAsync(fileStream);
                                        aboutus.Image = fileName;
                                    }
                                }
                            }
                        }

                    }
                    await _manageBeauty.Aboutus(aboutus);
                    return Ok(aboutus.ID == 0 ? new { Message = "Aboutus Added successfully !!!" } : new { Message = "Aboutus Updated successfully !!!" });
                }
                else
                {
                    return Ok(new { Message = "Something went wrong !!!" });
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

        #region--------Makeup------
        [Route("BeautyMakeup")]
        public IActionResult Makeup()
        {
            return View("/views/beauty/makeup.cshtml");
        }
        [Route("Makeup")]
        public async Task<IActionResult> Makeup(int? id = 0)
        {
            try
            {
                IEnumerable<Makeup> makeups = await _manageBeauty.Makeup(id); ;
                return Content(JsonConvert.SerializeObject(makeups));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [Route("Makeup")]
        public async Task<IActionResult> Makeup([FromBody] Makeup makeup)
        {
            try
            {
                if (makeup != null)
                {
                    await _manageBeauty.Makeup(makeup);
                    return Ok(makeup.ID == 0 ? new { Message = "Makeup Added succesfully !!!" } : new { Message = "Makeup Updated succesfully !!!" });

                }
                else
                {
                    return Ok(new { Message = "Something went wrong !!!" });

                }

            }
            catch (Exception ex)
            {
                return View("/views/shared/error.cshtml", ex);
            }
        }
        [HttpGet]
        [Route("DeleteMakeup")]
        public async Task<IActionResult> DelMakeup(int id)
        {
            try
            {
                await _manageBeauty.DelMakeup(id);
                return Ok(new { Message = "Makeup Deleted succesfully !!!" });

            }
            catch (Exception ex)
            {
                return View("/views/shared/error.cshtml", ex);
            }
        }


        #endregion

        #region--------News------
        [Route("BeautyNews")]
        public IActionResult News()
        {
            return View("/views/beauty/news.cshtml");
        }
        [Route("News")]
        public async Task<IActionResult> News(int? id = 0)
        {
            try
            {
                IEnumerable<News> news = await _manageBeauty.News(id); ;
                return Content(JsonConvert.SerializeObject(news));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [Route("News")]
        public async Task<IActionResult> News([FromBody] News news)
        {
            try
            {
                if (news != null)
                {
                    await _manageBeauty.News(news);
                    return Ok(news.ID == 0 ? new { Message = "News Added succesfully !!!" } : new { Message = "News Updated succesfully !!!" });

                }
                else
                {
                    return Ok(new { Message = "Something went wrong !!!" });

                }

            }
            catch (Exception ex)
            {
                return View("/views/shared/error.cshtml", ex);
            }
        }
        [HttpGet]
        [Route("DeleteNews")]
        public async Task<IActionResult> DelNews(int id)
        {
            try
            {
                await _manageBeauty.DelNews(id);
                return Ok(new { Message = "News Deleted succesfully !!!" });

            }
            catch (Exception ex)
            {
                return View("/views/shared/error.cshtml", ex);
            }
        }


        #endregion
    }
}
