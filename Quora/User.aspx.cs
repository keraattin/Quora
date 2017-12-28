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
    public partial class User : System.Web.UI.Page
    {
        private void fillTheLabels()
        {
            DbConnection.ConnectDb();

            getCredentials();
            getFollowers();
            getFollowings();
            getTopics();
            getQuestions();
            getAnswers();
            getKnowsAbout();
            getLocations();
            getSchools();
            getWork();

            DbConnection.DisconnectDb();
        }

        private void getCredentials()
        {
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Select Name,LastName,ProfileCredential,Description From Users Where UserId = @UserID";
            sc.Parameters.AddWithValue("@UserId", Convert.ToInt32(Request.QueryString["UserId"]));
            sc.Connection = DbConnection.connection;

            SqlDataReader rd = sc.ExecuteReader();

            RepeaterCredentials.DataSource = rd;
            RepeaterCredentials.DataBind();

            rd.Close();
        }

        //Takipciler alııyor.
        private void getFollowers()
        {
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Select Count(UserId) From UserFollow Where FollowingUserId = @UserId";
            sc.Parameters.AddWithValue("@UserId", Convert.ToInt32(Request.QueryString["UserId"]));
            sc.Connection = DbConnection.connection;

            SqlDataReader rd = sc.ExecuteReader();
            if (rd.Read())
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
            sc.Parameters.AddWithValue("@UserId", Convert.ToInt32(Request.QueryString["UserId"]));
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
            sc.Parameters.AddWithValue("@UserId", Convert.ToInt32(Request.QueryString["UserId"]));
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
            sc.Parameters.AddWithValue("@UserId", Convert.ToInt32(Request.QueryString["UserId"]));
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
            sc.Parameters.AddWithValue("@UserId", Convert.ToInt32(Request.QueryString["UserId"]));
            sc.Connection = DbConnection.connection;

            SqlDataReader dr = sc.ExecuteReader();
            if (dr.Read())
            {
                LabelAnswers.Text = dr[0].ToString(); //dr[0] = Count(Answers)
            }
            dr.Close();
        }

        private void getKnowsAbout()
        {
            int counter = 0;
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Select Language From UserLanguage Where UserId = @UserId";
            sc.Parameters.AddWithValue("@UserId", Convert.ToInt32(Request.QueryString["UserId"]));
            sc.Connection = DbConnection.connection;

            SqlDataReader dr = sc.ExecuteReader();
            while (dr.Read())
            {
                if (counter >= 5) break;
                BulletedListKnowsAbout.Items.Add(dr[0].ToString()); //dr[0] = UserLanguage
                counter++;
            }
            dr.Close();
        }

        private void getLocations()
        {
            int counter = 0;
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Select Location,StartYear,EndYear From UserLocation Where UserId = @UserId";
            sc.Parameters.AddWithValue("@UserId", Convert.ToInt32(Request.QueryString["UserId"]));
            sc.Connection = DbConnection.connection;

            SqlDataReader dr = sc.ExecuteReader();
            while (dr.Read())
            {
                if (counter >= 2) break;
                string row = dr[0].ToString() + " " + dr[1].ToString() + "-" + dr[2].ToString();
                BulletedListLocation.Items.Add(row);
                //dr[0] = Location
                //dr[1] = StartYead
                //dr[2] = EndYear
                counter++;
            }
            dr.Close();
        }

        private void getSchools()
        {
            int counter = 0;
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Select Degree,SchoolName,Concentration,GraduationYear From UserStudy Where UserId = @UserId";
            sc.Parameters.AddWithValue("@UserId", Convert.ToInt32(Request.QueryString["UserId"]));
            sc.Connection = DbConnection.connection;

            SqlDataReader dr = sc.ExecuteReader();
            while (dr.Read())
            {
                if (counter >= 2) break;
                string row = dr[0].ToString() + " " + dr[1].ToString() + " " + dr[2].ToString() + " " + dr[3].ToString();
                BulletedListLocation.Items.Add(row);
                //dr[0] = Degree
                //dr[1] = SchoolName
                //dr[2] = GraduationYear
                //dr[3] = GraduationYear
                counter++;
            }
            dr.Close();
        }

        private void getWork()
        {
            int counter = 0;
            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Select Organization,Position,StartYear,EndYear From UserWork Where UserId = @UserId";
            sc.Parameters.AddWithValue("@UserId", Convert.ToInt32(Request.QueryString["UserId"]));
            sc.Connection = DbConnection.connection;

            SqlDataReader dr = sc.ExecuteReader();
            while (dr.Read())
            {
                if (counter >= 2) break;
                string row = dr[0].ToString() + " " + dr[1].ToString() + " " + dr[2].ToString() + "-" + dr[3].ToString();
                BulletedListLocation.Items.Add(row);
                //dr[0] = Organization
                //dr[1] = Position
                //dr[2] = StartYear
                //dr[3] = EndYear
                counter++;
            }
            dr.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["UserId"] != null)
            {
                ImageProfile.ImageUrl = "images/avatar_empty.png";
                fillTheLabels();
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
        }
    }
}