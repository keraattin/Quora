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

        private void getQuestions()
        {
            try
            {
                DbConnection.ConnectDb();

                SqlCommand sc = new SqlCommand();
                sc.CommandText = "Select Question.QuestionId, Question.Question, Users.Name, Users.LastName,  UserAskQuestion.Date " +
                " From Question,QuestionHasTopic,Topic,UserAskQuestion,Users " +
                " Where Topic.TopicId = @TopicId And Question.QuestionId = QuestionHasTopic.QuestionId " +
                " AND Topic.TopicId = QuestionHasTopic.TopicId AND Question.QuestionId = UserAskQuestion.QuestionId AND Users.UserId = UserAskQuestion.UserId ORDER BY UserAskQuestion.Date DESC";
                sc.Parameters.AddWithValue("@TopicId", Convert.ToInt32(Request.QueryString["TopicId"]));
                sc.Connection = DbConnection.connection;

                SqlDataReader rd = sc.ExecuteReader();

                RepeaterQuestions.DataSource = rd;
                RepeaterQuestions.DataBind();

                DbConnection.DisconnectDb();
            }
            catch (Exception)
            {
                DbConnection.DisconnectDb();
                Response.Redirect("Index.aspx");
            }
        }

        private void getFollows()
        {
            DbConnection.ConnectDb();

            //Giriş yapan kişinin takip edip etmediği kontrol ediliyor.
            SqlCommand checkFollow = new SqlCommand();
            checkFollow.CommandText = "Select UserId,TopicId From UserFollowTopic " +
            " Where UserId = @UserId AND TopicId = @TopicId ";
            checkFollow.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"]));
            checkFollow.Parameters.AddWithValue("@TopicId", Convert.ToInt32(Request.QueryString["TopicId"]));
            checkFollow.Connection = DbConnection.connection;

            SqlDataReader rd = checkFollow.ExecuteReader();
            if (rd.Read())
            {
                ButtonFollow.Enabled = false;
                ButtonFollow.Visible = false;
                ButtonUnFollow.Enabled = true;
                ButtonUnFollow.Visible = true;
            }
            else
            {
                ButtonFollow.Enabled = true;
                ButtonFollow.Visible = true;
                ButtonUnFollow.Enabled = false;
                ButtonUnFollow.Visible = false;
            }

            DbConnection.DisconnectDb();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["TopicId"] != null)
            {
                getTopics();
                getQuestions();
                getFollows();
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
        }

        protected void ButtonFollow_Click(object sender, EventArgs e)
        {
            DbConnection.ConnectDb();

            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Insert into UserFollowTopic Values (@UserId,@TopicId)";
            sc.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"]));
            sc.Parameters.AddWithValue("@TopicId", Convert.ToInt32(Request.QueryString["TopicId"]));
            sc.Connection = DbConnection.connection;
            sc.ExecuteNonQuery();

            DbConnection.DisconnectDb();
            Response.Redirect(Request.RawUrl);
        }

        protected void ButtonUnFollow_Click(object sender, EventArgs e)
        {
            DbConnection.ConnectDb();

            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Delete from UserFollowTopic Where UserId = @UserId AND TopicId = @TopicId";
            sc.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"]));
            sc.Parameters.AddWithValue("@TopicId", Convert.ToInt32(Request.QueryString["TopicId"]));
            sc.Connection = DbConnection.connection;
            sc.ExecuteNonQuery();

            DbConnection.DisconnectDb();
            Response.Redirect(Request.RawUrl);
        }
    }
}