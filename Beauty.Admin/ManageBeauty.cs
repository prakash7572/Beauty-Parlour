using Beauty.Admin.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Linq;
using NuGet.Protocol.Plugins;


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

        public void GetConnection(out SqlCommand cmd, out SqlConnection con)
        {
            con = new SqlConnection(ConnectionString());
            cmd = new SqlCommand("Beauty_SP", con);
        }

        #endregion

        #region------Aboutus---------
        public async Task<IEnumerable<Aboutus>> Aboutus(int? id)
        {
            try
            {
                List<Aboutus> list = new List<Aboutus>();
                GetConnection(out cmd, out con);
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
                GetConnection(out cmd, out con);
                await con.OpenAsync();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", aboutus.ID);
                cmd.Parameters.AddWithValue("Title", aboutus.Title);
                cmd.Parameters.AddWithValue("SubTitle", aboutus.SubTitle);
                cmd.Parameters.AddWithValue("Image", aboutus.Image);
                cmd.Parameters.AddWithValue("Description", aboutus.Description);
                cmd.Parameters.AddWithValue("QueryType", aboutus.ID == 0 ? "ADD_ABOUTUS" : "UPDATE_ABOUTUS");
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
                await con.OpenAsync();
                GetConnection(out cmd, out con);
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
                GetConnection(out cmd, out con);
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
                GetConnection(out cmd, out con);
                await con.OpenAsync();
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
                GetConnection(out cmd, out con);
                await con.OpenAsync();
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
                GetConnection(out cmd, out con);
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
                GetConnection(out cmd, out con);
                await con.OpenAsync();
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
                GetConnection(out cmd, out con);
                await con.OpenAsync();
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

        #region------Makeup------
        public async Task<IEnumerable<Makeup>> Makeup(int? id)
        {
            try
            {
                List<Makeup> list = new List<Makeup>();
                GetConnection(out cmd, out con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", id);
                cmd.Parameters.AddWithValue("QueryType", id == 0 ? "GET_ALL_MAKEUP" : "GET_MAKEUP");
                adt = new SqlDataAdapter(cmd);
                adt.Fill(ds);
                dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Makeup makeup = new Makeup();
                    makeup.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    makeup.Title = dt.Rows[i]["Title"].ToString();
                    makeup.FaFaImg = dt.Rows[i]["FaFaImg"].ToString();
                    makeup.Description = dt.Rows[i]["Description"].ToString();
                    list.Add(makeup);
                }
                await con.OpenAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Makeup> Makeup(Makeup makeup)
        {
            try
            {
                GetConnection(out cmd, out con);
                await con.OpenAsync();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", makeup.ID);
                cmd.Parameters.AddWithValue("Title", makeup.Title);
                cmd.Parameters.AddWithValue("FaFaImg", makeup.FaFaImg);
                cmd.Parameters.AddWithValue("Description", makeup.Description);
                cmd.Parameters.AddWithValue("QueryType", makeup.ID == 0 ? "ADD_MAKEUP" : "UPDATE_MAKEUP");
                cmd.ExecuteNonQuery();
                return makeup;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int?> DelMakeup(int? id)
        {
            try
            {
                GetConnection(out cmd, out con);
                await con.OpenAsync();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", id);
                cmd.Parameters.AddWithValue("QueryType", "DELETE_MAKEUP");
                cmd.ExecuteNonQuery();
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region-----News------
        public async Task<IEnumerable<News>> News(int? id)
        {
            try
            {
                List<News> list = new List<News>();
                GetConnection(out cmd, out con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", id);
                cmd.Parameters.AddWithValue("QueryType", id == 0 ? "GET_ALL_NEWS" : "GET_NEWS");
                adt = new SqlDataAdapter(cmd);
                adt.Fill(ds);
                dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    News news = new News();
                    news.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    news.SubTitle = dt.Rows[i]["SubTitle"].ToString();
                    news.Image = dt.Rows[i]["Image"].ToString();
                    news.Description = dt.Rows[i]["Description"].ToString();
                    news.MakeupType = Convert.ToBoolean(dt.Rows[i]["MakeupType"]);
                    list.Add(news);
                }
                await con.OpenAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<News> News(News news)
        {
            try
            {
                GetConnection(out cmd, out con);
                await con.OpenAsync();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", news.ID);
                cmd.Parameters.AddWithValue("SubTitle", news.SubTitle);
                cmd.Parameters.AddWithValue("Image", news.Image);
                cmd.Parameters.AddWithValue("Description", news.Description);
                cmd.Parameters.AddWithValue("MakeupType", news.MakeupType);
                cmd.Parameters.AddWithValue("QueryType", news.ID == 0 ? "ADD_NEWS" : "UPDATE_NEWS");
                cmd.ExecuteNonQuery();
                return news;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int?> DelNews(int? id)
        {
            try
            {
                GetConnection(out cmd, out con);
                await con.OpenAsync();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", id);
                cmd.Parameters.AddWithValue("QueryType", "DELETE_NEWS");
                cmd.ExecuteNonQuery();
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

         #region-----Price------
        public async Task<IEnumerable<Price>> Price(int? id)
        {
            try
            {
                List<Price> list = new List<Price>(); 
                GetConnection(out cmd, out con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", id);
                cmd.Parameters.AddWithValue("QueryType", id == 0 ? "GET_ALL_PRICE" : "GET_PRICE");
                adt = new SqlDataAdapter(cmd);
                adt.Fill(ds);
                dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Price price = new Price();
                    price.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    price.SubTitle = dt.Rows[i]["SubTitle"].ToString();
                    price.Makeup = dt.Rows[i]["Makeup"].ToString();
                    price.Description = dt.Rows[i]["Description"].ToString();
                    price.Prices = Convert.ToDecimal(dt.Rows[i]["Price"]);
                    list.Add(price);
                }
                await con.OpenAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Price> Price(Price price)
        {
            try
            {
                GetConnection(out cmd, out con);
                await con.OpenAsync();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", price.ID);
                cmd.Parameters.AddWithValue("SubTitle", price.SubTitle);
                cmd.Parameters.AddWithValue("Makeup", price.Makeup);
                cmd.Parameters.AddWithValue("Description", price.Description);
                cmd.Parameters.AddWithValue("Price", price.Prices);
                cmd.Parameters.AddWithValue("QueryType", price.ID == 0 ? "ADD_PRICE" : "UPDATE_PRICE");
                cmd.ExecuteNonQuery();
                return price;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int?> DelPrice(int? id)
        {
            try
            {
                GetConnection(out cmd, out con);
                await con.OpenAsync();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", id);
                cmd.Parameters.AddWithValue("QueryType", "DELETE_PRICE");
                cmd.ExecuteNonQuery();
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion


        #region-----Banner------
        public async Task<IEnumerable<Banner>> Banner(int? id)
        {
            try
            {
                List<Banner> list = new List<Banner>();
                GetConnection(out cmd, out con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", id);
                cmd.Parameters.AddWithValue("QueryType", id == 0 ? "GET_ALL_BANNER" : "GET_BANNER");
                adt = new SqlDataAdapter(cmd);
                adt.Fill(ds);
                dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Banner banner = new Banner();
                    banner.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    banner.Title = dt.Rows[i]["Title"].ToString();
                    banner.Image = dt.Rows[i]["Image"].ToString();
                    list.Add(banner);
                }
                await con.OpenAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Banner> Banner(Banner banner)
        {
            try
            {
                GetConnection(out cmd, out con);
                await con.OpenAsync();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", banner.ID);
                cmd.Parameters.AddWithValue("Title", banner.Title);
                cmd.Parameters.AddWithValue("Image", banner.Image);
                cmd.Parameters.AddWithValue("QueryType", banner.ID == 0 ? "ADD_BANNER" : "UPDATE_BANNER");
                cmd.ExecuteNonQuery();
                return banner;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int?> DelBanner(int? id)
        {
            try
            {
                GetConnection(out cmd, out con);
                await con.OpenAsync();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", id);
                cmd.Parameters.AddWithValue("QueryType", "DELETE_BANNER");
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
