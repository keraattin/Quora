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
    public partial class Profile : System.Web.UI.Page
    {
        private void fillTheLabels()
        {
            DbConnection.ConnectDb();

            getProfileInfo();
            getFollowers();
            getFollowings();
            getTopics();
            getQuestions();
            getAnswers();


            DbConnection.DisconnectDb();
        }

        //Kişi bilgileri alınıyor.
        private void getProfileInfo()
        {
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Select Name,LastName,ProfileCredential,Description From Users Where UserId = @UserID";
            sc.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"]));
            sc.Connection = DbConnection.connection;

            SqlDataReader dr = sc.ExecuteReader();
            if (dr.Read())
            {
                LabelNameSurname.Text = dr[0].ToString() + " " + dr[1].ToString(); //dr[0] = Name , dr[1] = LastName
                LabelCredential.Text = dr[2].ToString(); //dr[2] = Credential
                LabelDescription.Text = dr[3].ToString(); //dr[3] = Description
            }
            dr.Close();
        }

        //Takipciler alııyor.
        private void getFollowers()
        {
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Select Count(UserId) From UserFollow Where FollowingUserId = @UserId";
            sc.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"]));
            sc.Connection = DbConnection.connection;

            SqlDataReader rd = sc.ExecuteReader();
            if(rd.Read())
            {
                LabelFollowers.Text = rd[0].ToString();
                LabelButtonFollowers.Text = rd[0].ToString();
            }
            rd.Close();
        }

        //Takip edilenler alınıyor.
        private void getFollowings()
        {
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Select Count(FollowingUserId) From UserFollow Where UserId = @UserId";
            sc.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"]));
            sc.Connection = DbConnection.connection;

            SqlDataReader rd = sc.ExecuteReader();
            if (rd.Read())
            {
                LabelFollowing.Text = rd[0].ToString();
            }
            rd.Close();
        }

        //Takip edilen konular alınıyor.
        private void getTopics()
        {
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Select Count(TopicId) From UserFollowTopic Where UserId = @UserId";
            sc.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"]));
            sc.Connection = DbConnection.connection;

            SqlDataReader dr = sc.ExecuteReader();
            if (dr.Read())
            {
                LabelTopics.Text = dr[0].ToString(); //dr[0] = Count(Topic)
            }
            dr.Close();
        }

        //Sorulan sorular alınıyor.
        private void getQuestions()
        {
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Select Count(QuestionId) From UserAskquestion Where UserId = @UserId";
            sc.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"]));
            sc.Connection = DbConnection.connection;

            SqlDataReader dr = sc.ExecuteReader();
            if (dr.Read())
            {
                LabelQuestions.Text = dr[0].ToString(); //dr[0] = Count(Questions)
            }
            dr.Close();
        }

        //Verilen cevaplar alınıyor.
        private void getAnswers()
        {
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Select Count(AnswerId) From UserAnswer Where UserId = @UserId";
            sc.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"]));
            sc.Connection = DbConnection.connection;

            SqlDataReader dr = sc.ExecuteReader();
            if (dr.Read())
            {
                LabelAnswers.Text = dr[0].ToString(); //dr[0] = Count(Answers)
            }
            dr.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ImageProfile.ImageUrl = "images/avatar_empty.png";
            fillTheLabels(); //Veriler alınıyor.
        }
    }
}