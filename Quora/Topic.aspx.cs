using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Quora
{
    public partial class Topic : System.Web.UI.Page
    {

        private void getTopics()
        {
            try
            {
                DbConnection.ConnectDb();

                SqlCommand sc = new SqlCommand();
                sc.CommandText = "Select TopicId,Topic,Description From Topic Where TopicId = @TopicId";
                sc.Parameters.AddWithValue("@TopicId", Convert.ToInt32(Request.QueryString["TopicId"]));
                sc.Connection = DbConnection.connection;

                SqlDataReader rd = sc.ExecuteReader();

                RepeaterTopic.DataSource = rd;
                RepeaterTopic.DataBind();

                DbConnection.DisconnectDb();
            }
            catch (Exception)
            {
                DbConnection.DisconnectDb();
                Response.Redirect("Index.aspx");
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString != null)
            {
                getTopics();
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
        }
    }
}