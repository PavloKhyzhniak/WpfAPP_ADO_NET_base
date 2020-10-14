using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp_ADO_NET_SQLDataReader.Classes_SqlDataReader
{
    public static partial class SqlDatabase
    {

        static SqlConnection connection;

        public static SqlConnection Connection
        {
            get
            {
                if (connection == null)
                    LazyInitializer.EnsureInitialized(ref connection, CreateSqlConnection_ConfigurationManager);
                return connection;
            }
        }

        static string strDataFilePath = "ADO_DataReader.Properties.Settings.pubsConnectionString";
        public static string DataFilePath
        {
            get { return strDataFilePath; }
            set
            {
                if (strDataFilePath == value) return;
                strDataFilePath = value;
                if (connection != null)
                {
                    connection.Close(); //NB, no checks were added if the connection is being used, but if the value is only set on startup or idle moments, this should be ok for the example.
                    connection.Dispose();
                    connection = null; //conn is reset, and (re)created the next time Connection is called
                }
            }
        }



        // create table t1(id1 int, id2 varchar(20), primary key(id1, id2))
        private static SqlConnection CreateSqlConnection_ConfigurationManager()
        {
            var connection = new SqlConnection();

            string connectionString = ConfigurationManager.ConnectionStrings[strDataFilePath].ConnectionString;

            int portNumber = WpfApp_ADO_NET_SQLDataReader.Properties.Settings.Default.PortNumber;
            string userName = WpfApp_ADO_NET_SQLDataReader.Properties.Settings.Default.UserName;

            connection.ConnectionString = connectionString;
            return connection;
        }

        private static SqlConnection CreateSqlConnection_StringBuilder()
        {
            var connection = new SqlConnection();

            int portNumber = WpfApp_ADO_NET_SQLDataReader.Properties.Settings.Default.PortNumber;
            string userName = WpfApp_ADO_NET_SQLDataReader.Properties.Settings.Default.UserName;

            // Построитель строки соединения с сервером
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.InitialCatalog = "Pubs";
            builder.DataSource = ".\\SQLExpress";
            //builder.Password = "123";
            builder.ConnectTimeout = 30;
            //builder.UserID = "test";
            builder.IntegratedSecurity = true;  // - заходить с правами текущего пользователя Windows

            connection.ConnectionString = builder.ConnectionString;
            return connection;
        }




    }
}
