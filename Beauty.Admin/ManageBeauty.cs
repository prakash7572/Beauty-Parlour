using Beauty.Admin.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Beauty.Admin
{
    public class ManageBeauty
    {
        #region------Connection-Variables-------

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataSet ds;
        DataTable dt;
        
        private readonly IConfiguration _configuration;
        public ManageBeauty(IConfiguration configuration)
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

        #endregion

        #region------Aboutus---------
        public async Task<IEnumerable<Aboutus>> Aboutus(int? id)
        {
            try
            {
                List<Aboutus> list = new List<Aboutus>();
                con = new SqlConnection(ConnectionString());
                cmd = new SqlCommand("Beauty_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", id);
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
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Aboutus> Aboutus(Aboutus aboutus)
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
                return aboutus;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int?> DelAboutus(int? id)
        {
            try
            {
                con = new SqlConnection(ConnectionString());
                await con.OpenAsync();
                cmd = new SqlCommand("Beauty_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", id);
                cmd.Parameters.AddWithValue("QueryType","DELETE_ABOUTUS");
                cmd.ExecuteNonQuery();
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        #endregion

        #region------Contactus------
        public async Task<IEnumerable<Contactus>> Contactus(int? id)
        {
            try
            {
                List<Contactus> list = new List<Contactus>();
                con = new SqlConnection(ConnectionString());
                cmd = new SqlCommand("Beauty_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", id);
                cmd.Parameters.AddWithValue("QueryType", id == 0 ? "GET_ALL_CONTACTS" : "GET_CONTACTS");
                adt = new SqlDataAdapter(cmd);
                adt.Fill(ds);
                dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Contactus contactus = new Contactus();
                    contactus.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    contactus.Phone = dt.Rows[i]["Phone"].ToString();
                    contactus.SubTitle = dt.Rows[i]["SubTitle"].ToString();
                    contactus.Address = dt.Rows[i]["Address"].ToString();
                    contactus.Email = dt.Rows[i]["Email"].ToString();
                    list.Add(contactus);
                }
                await con.OpenAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Contactus> Contactus(Contactus contactus)
        {
            try
            {
                con = new SqlConnection(ConnectionString());
                await con.OpenAsync();
                cmd = new SqlCommand("Beauty_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", contactus.ID);
                cmd.Parameters.AddWithValue("Phone", contactus.Phone);
                cmd.Parameters.AddWithValue("SubTitle", contactus.SubTitle);
                cmd.Parameters.AddWithValue("Email", contactus.Email);
                cmd.Parameters.AddWithValue("Address", contactus.Address);
                cmd.Parameters.AddWithValue("QueryType", contactus.ID == 0 ? "ADD_CONTACTS" : "UPDATE_CONTACTS");
                cmd.ExecuteNonQuery();
                return contactus;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int?> DelContactus(int? id)
        {
            try
            {
                con = new SqlConnection(ConnectionString());
                await con.OpenAsync();
                cmd = new SqlCommand("Beauty_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", id);
                cmd.Parameters.AddWithValue("QueryType", "DELETE_CONTACTS");
                cmd.ExecuteNonQuery();
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region------Service------
        public async Task<IEnumerable<Service>> Service(int? id)
        {
            try
            {
                List<Service> list = new List<Service>();
                con = new SqlConnection(ConnectionString());
                cmd = new SqlCommand("Beauty_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", id);
                cmd.Parameters.AddWithValue("QueryType", id == 0 ? "GET_ALL_SERVICES" : "GET_SERVICES");
                adt = new SqlDataAdapter(cmd);
                adt.Fill(ds);
                dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Service service = new Service();
                    service.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    service.Title = dt.Rows[i]["Title"].ToString();
                    service.SubTitle = dt.Rows[i]["SubTitle"].ToString();
                    service.Description = dt.Rows[i]["Description"].ToString();
                    service.Image = dt.Rows[i]["Image"].ToString();
                    list.Add(service);
                }
                await con.OpenAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Service> Service(Service service)
        {
            try
            {
                con = new SqlConnection(ConnectionString());
                await con.OpenAsync();
                cmd = new SqlCommand("Beauty_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", service.ID);
                cmd.Parameters.AddWithValue("Title", service.Title);
                cmd.Parameters.AddWithValue("SubTitle", service.SubTitle);
                cmd.Parameters.AddWithValue("Image", service.Image);
                cmd.Parameters.AddWithValue("Description", service.Description);
                cmd.Parameters.AddWithValue("QueryType", service.ID == 0 ? "ADD_SERVICES" : "UPDATE_SERVICES");
                cmd.ExecuteNonQuery();
                return service;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int?> DelService(int? id)
        {
            try
            {
                con = new SqlConnection(ConnectionString());
                await con.OpenAsync();
                cmd = new SqlCommand("Beauty_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", id);
                cmd.Parameters.AddWithValue("QueryType", "DELETE_SERVICES");
                cmd.ExecuteNonQuery();
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion


    }
}
