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
    public partial class HomePage : System.Web.UI.MasterPage
    {
        private void GetUserName()
        {
            DbConnection.ConnectDb();

            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Select Name,LastName from Users Where UserId = @UserId";
            sc.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"]));
            sc.Connection = DbConnection.connection;

            SqlDataReader dr = sc.ExecuteReader();
            if(dr.Read())
            {
                LabelName.Text = dr[0].ToString();
                LabelNameLast.Text = dr[0].ToString() + " " + dr[1].ToString();
                ImageUser.ImageUrl = "images/avatar_empty.png";
            }

            DbConnection.DisconnectDb();
        }

        private void getLanguage()
        {
            DbConnection.ConnectDb();

            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Select Language From UserLanguage Where UserId = @UserId";
            sc.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"]));
            sc.Connection = DbConnection.connection;

            SqlDataReader dr = sc.ExecuteReader();
            while (dr.Read())
            {
                BulletedList.Items.Add(dr[0].ToString()); //dr[0] = UserLanguage    
            }
            dr.Close();

            DbConnection.DisconnectDb();
        }

        private void getTopics()
        {
            DbConnection.ConnectDb();

            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Select Topic from Topic";
            sc.Connection = DbConnection.connection;

            SqlDataReader dr = sc.ExecuteReader();
            while (dr.Read())
            {
                DropDownListTopics.Items.Add(dr[0].ToString());
            }

            DbConnection.DisconnectDb();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                GetUserName(); //Giriş yapan kişinin adını yukarıda yaz.
                getLanguage(); //Giriş yapan kişinin bildiği diller.
                getTopics();
            }
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();                  //Bütün sessionları sil
            Response.Redirect("Login.aspx");      //Giriş sayfasına dön
        }

        protected void BulletedList_Click(object sender, BulletedListEventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        private void askQuestion()
        {
            DbConnection.ConnectDb();

            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Insert into Question Values (@Question)";
            sc.Parameters.AddWithValue("@Question",TextBoxQuestion.Text);
            sc.Connection = DbConnection.connection;
            sc.ExecuteNonQuery();

            SqlCommand hasTopic = new SqlCommand();
            hasTopic.CommandText = "Insert into QuestionHasTopic " +
            " Values ((Select TOP 1 QuestionId From Question Where Question=@Question ORDER BY QuestionId DESC),(Select TopicId From Topic Where Topic = @Topic))";
            hasTopic.Parameters.AddWithValue("@Question",TextBoxQuestion.Text);
            hasTopic.Parameters.AddWithValue("@Topic", DropDownListTopics.SelectedItem.Text);
            hasTopic.Connection = DbConnection.connection;
            hasTopic.ExecuteNonQuery();

            SqlCommand userAsk = new SqlCommand();
            userAsk.CommandText = "Insert into UserAskQuestion " +
            " Values ((Select TOP 1 QuestionId From Question Where Question=@Question ORDER BY QuestionId DESC),@UserId,(Select getdate()))";
            userAsk.Parameters.AddWithValue("@Question", TextBoxQuestion.Text);
            userAsk.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"]));
            userAsk.Connection = DbConnection.connection;
            userAsk.ExecuteNonQuery();

            DbConnection.DisconnectDb();


        }

        protected void ButtonAddQuestion_Click(object sender, EventArgs e)
        {
            if(TextBoxQuestion.Text!=null)
            {
                askQuestion();
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}