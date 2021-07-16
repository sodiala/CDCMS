using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web.Services;
using System.Runtime.Serialization;

using System.Net;
//using RESTFulWCFService;
using System.IO;//repeated
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["MID"] != null)
        //{
        //    txtmobilenumber.Text = Session["MID"].ToString();
        //}
        //else
        //    txtmobilenumber.Text = "9440283640";
        //{ Response.Redirect("login.aspx"); }
    }

    public string JsonDataTabletoString()
    {
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection("Server=162.217.144.45;Database=sankarhitech_TML;User Id=dwaraka;Password =Sachin@S@ntosI-I123;"))
        {

            using (SqlCommand cmd = new SqlCommand("USP_Get_D_MyProperties", con))
            // using(SqlCommand cmd = new SqlCommand("select '(' + convert(varchar(20),lat) + ' , '+ convert(varchar(20),lng)+')' as 'latlang',title=City,description=sitedescription,id=sid from D_SiteDetails",con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Mobile", "9440283640");
                //con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row;
                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    rows.Add(row);
                }
                return serializer.Serialize(rows);
            }
        }
        //StringBuilder sb = new StringBuilder();
        //WebClient proxy = new WebClient();
        //string serviceURL = string.Format("http://service.hitechsoft.co.in/Maps.svc/LandPlace/GetMyPropertys/{0}", txtmobilenumber.Text);
        //byte[] data = proxy.DownloadData(serviceURL);
        //Stream stream = new MemoryStream(data);
        //DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(String));
        //String order = obj.ReadObject(stream) as String;
        //return order;
    }
}
