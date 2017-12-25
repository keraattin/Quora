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

            SqlCommand sc = new SqlCommand();
            sc.CommandText = "Select Name,LastName,ProfileCredential,Description From Users Where UserId = @UserID";
            sc.Parameters.AddWithValue("@UserId", Convert.ToInt32(Session["UserId"]));
            sc.Connection = DbConnection.connection;

            SqlDataReader dr = sc.ExecuteReader();
            if(dr.Read())
            {
                LabelNameSurname.Text = dr[0].ToString() + " " + dr[1].ToString(); //dr[0] = Name , dr[1] = LastName
                LabelCredential.Text = dr[2].ToString(); //dr[2] = Credential
                LabelDescription.Text = dr[3].ToString(); //dr[3] = Description
            }

            DbConnection.DisconnectDb();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ImageProfile.ImageUrl = "images/avatar_empty.png";
            fillTheLabels(); //Veriler alınıyor.
        }
    }
}