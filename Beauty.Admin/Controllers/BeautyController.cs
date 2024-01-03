using Beauty.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.Extensions.Logging;

namespace Beauty.Admin.Controllers
{
    [Route("Beauty")]
    public class BeautyController : Controller
    {
        #region------Variable-------

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataSet ds;
        DataTable dt;

        #endregion

        private readonly IConfiguration _configuration;

        public BeautyController(IConfiguration configuration)
        {
            _configuration = configuration;
            con = new SqlConnection();
            cmd = new SqlCommand();
            adt = new SqlDataAdapter();
            ds = new DataSet();
            dt = new DataTable();
        }

        public string ConnectionString()
        {
            return _configuration.GetConnectionString("ConnectionString");
        }

        [Route("BeautyAboutus")]
        public IActionResult Aboutus()
        {
            return View("/views/beauty/aboutus.cshtml");
        }
        [Route("Aboutus")]
        public async Task<IActionResult> Aboutus(int id = 0)
        {
            try
            {
                List<Aboutus> list = new List<Aboutus>();
                con = new SqlConnection(ConnectionString());
                cmd = new SqlCommand("Beauty_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID",id);
                cmd.Parameters.AddWithValue("QueryType", id == 0 ? "GET_ALL_ABOUTUS" : "GET_ABOUTUS");
                adt = new SqlDataAdapter(cmd);
                adt.Fill(ds);
                dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Aboutus about = new Aboutus();
                        about.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                        about.Title = dt.Rows[i]["Title"].ToString();
                        about.SubTitle = dt.Rows[i]["SubTitle"].ToString();
                        about.Description = dt.Rows[i]["Description"].ToString();
                        about.Image = dt.Rows[i]["Image"].ToString();
                        list.Add(about);
                }
                await con.OpenAsync();
                return Json(list);
            }
            catch (Exception ex)
            {
                return View("/views/shared/error.cshtml",ex);
            }
           
        }
        [HttpPost]
        [Route("Aboutus")]
        public async Task<IActionResult> Aboutus([FromBody] Aboutus aboutus)
        {
            try
            {
                
                con = new SqlConnection(ConnectionString());
                await con.OpenAsync();
                cmd = new SqlCommand("Beauty_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", aboutus.ID);
                cmd.Parameters.AddWithValue("Title", aboutus.Title);
                cmd.Parameters.AddWithValue("SubTitle", aboutus.SubTitle);
                cmd.Parameters.AddWithValue("Image", aboutus.Image);
                cmd.Parameters.AddWithValue("Description", aboutus.Description);
                cmd.Parameters.AddWithValue("QueryType", aboutus.ID == 0 ? "ADD_ABOUTUS" : "GET_ABOUTUS");
                cmd.ExecuteNonQuery();
                return Ok(aboutus.ID == 0 ? new { Message = "Aboutus Added succesfully !!!" } : new { Message = "Aboutus Updated succesfully !!!" });

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
                con = new SqlConnection(ConnectionString());
                await con.OpenAsync();
                cmd = new SqlCommand("Beauty_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID",id);
                cmd.Parameters.AddWithValue("QueryType", "DELETE_ABOUTUS");
                cmd.ExecuteNonQuery();
                return Ok(new { Message = "Aboutus Deleted succesfully !!!" });

            }
            catch (Exception ex)
            {
                return View("/views/shared/error.cshtml", ex);
            }
                   }


    }
}
