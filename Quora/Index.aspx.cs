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
    public partial class Index : System.Web.UI.Page
    {
        private void getNameSurname()
        {
            DbConnection.ConnectDb();

            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Select Name,LastName From Users Where UserId=@UserId";
            sc.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"]));
            sc.Connection = DbConnection.connection;

            SqlDataReader rd = sc.ExecuteReader();
            if(rd.Read())
            {
                LabelNameSurname.Text = rd[0].ToString() + " " + rd[1].ToString();
            }
            rd.Close();
            DbConnection.DisconnectDb();
        }

        private void getTopics()
        {
            DbConnection.ConnectDb();

            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Select Topic.TopicId,Topic.Topic,Topic.Description From UserFollowTopic,Topic,Users " +
            " Where Users.UserId = @UserId AND Users.UserId = UserFollowTopic.UserId AND Topic.TopicId = UserFollowTopic.TopicId";
            sc.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"]));
            sc.Connection = DbConnection.connection;

            SqlDataReader readTopic = sc.ExecuteReader();

            RepeaterTopic.DataSource = readTopic;
            RepeaterTopic.DataBind();
            readTopic.Close();
            
            DbConnection.DisconnectDb();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            getNameSurname(); //Kulanıcının adı soyadı alınıyor.
            getTopics();
        }
    }
}