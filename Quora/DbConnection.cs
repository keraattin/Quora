using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Quora
{
    public class DbConnection
    {
        /*Veritabanı bağlantısının tanımlandığı bölüm.*/
        public static SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DbConnectionSt"].ConnectionString);

        /*Constructor*/
        DbConnection()
        {

        }

        /*Destructor*/
        ~DbConnection()
        {
            /*Bağlantının kapalı olup olmadığı kontrol ediliyor.*/
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();  //Bağlantı kapatılıyor.
            }
        }

        /*Veritabanına bağlantı için kullanılan method.*/
        public static void ConnectDb()
        {
            try
            {
                /*Bağlantının önceden açık olup olmadığı kontrol ediliyor.*/
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open(); //Bağlantı açılıyor.
                }
            }
            catch (Exception error)
            {
                throw;
            }
        }

        /*Veritabanı bağlantısnı kapatmak için kullanılan method.*/
        public static void DisconnectDb()
        {
            try
            {
                //Bağlantının önceden kapatılıp kapatılmadığı kontrol ediliyor.
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();  //Bağlantı Kapatılıyor.
                }
            }
            catch (Exception error)
            {
                throw;
            }
        }
    }
}