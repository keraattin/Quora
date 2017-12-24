using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace Quora
{
    public partial class WebUserControlLogin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GirisYap()
        {
            try
            {
                DbConnection.ConnectDb();

                SqlCommand sc = new SqlCommand();
                sc.CommandText = "Select UserId,Email,Password From Users Where Email=@Email AND Password=@Password";
                sc.Parameters.AddWithValue("@Email", TextBoxEmail.Text);
                sc.Parameters.AddWithValue("@Password", Hashing.MD5Hash(TextBoxPassword.Text));
                sc.Connection = DbConnection.connection;

                SqlDataReader reader = sc.ExecuteReader();
                if (reader.Read())
                {
                    Session.Add("UserId", reader[0]);  //reader[0] = UserId

                    DbConnection.DisconnectDb();//Bağlantı kapatılıyor.
                    
                    Response.Redirect("Index.aspx"); //Anasayafaya yönlendiriliyor.
                }
                else
                {
                    LabelResult.Text = "Hatalı kullanıcı adı veya şifre";
                    DbConnection.DisconnectDb();
                }

                DbConnection.DisconnectDb();
            }
            catch (Exception hata)
            {
                throw;
            }

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            GirisYap();
        }
    }
}