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
            sc.CommandText = "Select Name from Users Where UserId = @UserId";
            sc.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"]));
            sc.Connection = DbConnection.connection;

            SqlDataReader dr = sc.ExecuteReader();
            if(dr.Read())
            {
                LabelName.Text = dr[0].ToString();
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
    }
}