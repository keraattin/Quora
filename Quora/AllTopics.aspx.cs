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
    public partial class AllTopics : System.Web.UI.Page
    {

        private void getTopics()
        {
            DbConnection.ConnectDb();

            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Select TopicId,Topic,Description From Topic";
            sc.Connection = DbConnection.connection;

            SqlDataReader rd = sc.ExecuteReader();

            RepeaterTopic.DataSource = rd;
            RepeaterTopic.DataBind();

            DbConnection.DisconnectDb();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            getTopics();
        }
    }
}