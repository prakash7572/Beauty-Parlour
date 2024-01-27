using System.Data.SqlClient;
using System.Data;
using Beauty.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Beauty.Admin.Models.Helpher;

namespace Beauty.Admin
{
    public class ManageAccount
    {
        #region------Connection-Variables-------

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataSet ds;
        DataTable dt;
        MessageManager manager;

        private readonly IConfiguration _configuration;
        public ManageAccount(IConfiguration configuration)
        {
            _configuration = configuration;
            con = new SqlConnection();
            cmd = new SqlCommand();
            adt = new SqlDataAdapter();
            ds = new DataSet();
            dt = new DataTable();
            manager = new MessageManager();
        }

        
        public string ConnectionString()
        {
            return _configuration.GetConnectionString("ConnectionString");
        }

        public void GetConnection(out SqlCommand cmd, out SqlConnection con)
        {
            con = new SqlConnection(ConnectionString());
            cmd = new SqlCommand("Beauty_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;

        }
        #endregion

        #region--------Login---------   
        public async Task<IEnumerable<dynamic>> Login(Login log)
          {
            try
            {
                List<dynamic> list = new List<dynamic>();
                GetConnection(out cmd, out con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("Email", log.Email);
                cmd.Parameters.AddWithValue("Password", log.Password);
                cmd.Parameters.AddWithValue("QueryType", "USER_LOGIN");
                await Task.Run(() =>{adt = new SqlDataAdapter(cmd);adt.Fill(ds);});
                if (ds.Tables[0].Rows.Count > 0)
                {
                    var statusCode = ds.Tables[0].Rows[0]["StatusCode"].ToString();
                    if(statusCode == "SUCCESS")
                    {
                        GetConnection(out cmd, out con);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("Email", log.Email);
                        cmd.Parameters.AddWithValue("Password", log.Password);
                        cmd.Parameters.AddWithValue("QueryType", "GET_LOGIN_INFO");
                        SqlDataAdapter adt = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adt.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                             SessionManager.UserId  = Convert.ToInt32(dt.Rows[i]["UserId"]);
                             SessionManager.UserName = dt.Rows[i]["UserName"].ToString();
                             SessionManager.Title = dt.Rows[i]["Title"].ToString();
                             SessionManager.Phone = dt.Rows[i]["Phone"].ToString();
                             SessionManager.FirstName = dt.Rows[i]["FirstName"].ToString();
                             SessionManager.LastName = dt.Rows[i]["LastName"].ToString();
                             SessionManager.Image = dt.Rows[i]["Image"].ToString();
                             SessionManager.Email = dt.Rows[i]["Email"].ToString();
                        }
                    }
                    list.Add(manager);
                    if (statusCode == "SUCCESS")
                    {
                        manager.OperationMessage = ds.Tables[0].Rows[0]["OperationMessage"].ToString();
                        manager.StatusCode = ds.Tables[0].Rows[0]["StatusCode"].ToString();
                    }
                    else if (statusCode == "ERROR")
                    {
                        manager.OperationMessage = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                        manager.StatusCode = ds.Tables[0].Rows[0]["StatusCode"].ToString();
                    }
                    return list;
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

    }
}
