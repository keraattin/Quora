﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Quora
{
    public partial class Question : System.Web.UI.Page
    {
        private void getQuestion()
        {
            try
            {
                DbConnection.ConnectDb();

                SqlCommand sc = new SqlCommand();
                sc.CommandText = "Select Question From Question " +
                " Where QuestionId = @QuestionId";
                sc.Parameters.AddWithValue("@QuestionId", Convert.ToInt32(Request.QueryString["QuestionId"]));
                sc.Connection = DbConnection.connection;

                SqlDataReader dr = sc.ExecuteReader();

                RepeaterQuestion.DataSource = dr;
                RepeaterQuestion.DataBind();

                DbConnection.DisconnectDb();
            }
            catch (Exception)
            {
                DbConnection.DisconnectDb();
                Response.Redirect("Index.aspx");
            }
        }

        private void getQuestionTopics()
        {
            try
            {
                DbConnection.ConnectDb();

                SqlCommand sc = new SqlCommand();
                sc.CommandText = "Select Topic.TopicId,Topic.Topic From Topic,QuestionHasTopic,Question " +
                " Where QuestionHasTopic.QuestionId = @QuestionId AND QuestionHasTopic.TopicId = Topic.TopicId " +
                " AND QuestionHasTopic.QuestionId = Question.QuestionId ";
                sc.Parameters.AddWithValue("@QuestionId", Convert.ToInt32(Request.QueryString["QuestionId"]));
                sc.Connection = DbConnection.connection;

                SqlDataReader dr = sc.ExecuteReader();

                RepeaterQuestionTopic.DataSource = dr;
                RepeaterQuestionTopic.DataBind();

                DbConnection.DisconnectDb();
            }
            catch (Exception)
            {
                DbConnection.DisconnectDb();
                Response.Redirect("Index.aspx");
            }
        }

        private void getQuestionUser()
        {
            try
            {
                DbConnection.ConnectDb();

                SqlCommand sc = new SqlCommand();
                sc.CommandText= "Select Users.UserId , Users.Name , Users.LastName " +
                " From Users, UserASkQuestion, Question " +
                " Where Users.UserId = UserAskQuestion.UserId AND Question.QuestionId = UserAskQuestion.QuestionId " +
                " And Question.QuestionId = @QuestionId ";
                sc.Parameters.AddWithValue("@QuestionId", Convert.ToInt32(Request.QueryString["QuestionId"]));
                sc.Connection = DbConnection.connection;

                SqlDataReader dr = sc.ExecuteReader();

                RepeaterQuestionUser.DataSource = dr;
                RepeaterQuestionUser.DataBind();

                DbConnection.DisconnectDb();
            }
            catch (Exception)
            {
                DbConnection.DisconnectDb();
                Response.Redirect("Index.aspx");
            }
        }

        private void getAnswers()
        {
            try
            {
                DbConnection.ConnectDb();

                SqlCommand sc = new SqlCommand();
                sc.CommandText = "Select Users.Name, Users.LastName, Answer.Answer , UserAnswer.Date " +
                " From Users, Answer, UserAnswer, Question " +
                " Where Question.QuestionId = @QuestionId AND UserAnswer.QuestionId = Question.QuestionId " +
                " AND UserAnswer.UserId = Users.UserId AND UserAnswer.AnswerId = Answer.AnswerId ";
                sc.Parameters.AddWithValue("@QuestionId", Convert.ToInt32(Request.QueryString["QuestionId"]));
                sc.Connection = DbConnection.connection;

                SqlDataReader dr = sc.ExecuteReader();

                RepeaterAnswers.DataSource = dr;
                RepeaterAnswers.DataBind();

                DbConnection.DisconnectDb();
            }
            catch (Exception)
            {
                DbConnection.DisconnectDb();
                Response.Redirect("Index.aspx");
            }
        }

        private void getUserName()
        {
            try
            {
                DbConnection.ConnectDb();

                SqlCommand sc = new SqlCommand();
                sc.CommandText = "Select Name,LastName From Users Where UserId=@UserId";
                sc.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"]));
                sc.Connection = DbConnection.connection;

                SqlDataReader rd = sc.ExecuteReader();
                if (rd.Read())
                {
                    LabelUserName.Text = rd[0].ToString() + " " + rd[1].ToString();
                }

                DbConnection.DisconnectDb();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["QuestionId"] != null)
            {
                getQuestion();
                getQuestionTopics();
                getQuestionUser();
                getAnswers();
                getUserName();
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
        }
    }
}