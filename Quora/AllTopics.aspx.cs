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

        private void addTopic()
        {
            DbConnection.ConnectDb();
            /*Soru için girilen topic zaten var mı kontrol ediliyor.*/
            SqlCommand check = new SqlCommand();
            check.CommandText = "Select Topic From Topic" +
            " Where Topic =  @Topic";
            check.Parameters.AddWithValue("@Topic", TextBoxTopic.Text);
            check.Connection = DbConnection.connection;

            SqlDataReader readerCheck = check.ExecuteReader();
            if (readerCheck.Read())
            {
                DbConnection.DisconnectDb();
                return;
            }
            readerCheck.Close();

            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Insert into Topic(Topic,Description)" +
            " Values (@Topic,@Description)";
            sc.Parameters.AddWithValue("@Topic", TextBoxTopic.Text);
            sc.Parameters.AddWithValue("@Description", TextBoxDescription.Text);
            sc.Connection = DbConnection.connection;
            sc.ExecuteNonQuery();

            DbConnection.DisconnectDb();
            Response.Redirect(Request.RawUrl);
        }

        protected void ButtonAddTopic_Click(object sender, EventArgs e)
        {
            if(TextBoxTopic.Text != "" && TextBoxDescription.Text != "")
            {
                addTopic();
            }
        }
    }
}