using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp_ADO_NET_SQLDataReader.Classes_SqlDataReader
{
    public static partial class SqlDatabase
    {

        // create table t1(id1 int, id2 varchar(20), primary key(id1, id2))

        public static SqlConnection CreateSqlConnection_ConfigurationManager(string strDataFilePath = "ADO_DataReader.Properties.Settings.pubsConnectionString")
        {
            var connection = new SqlConnection();

            string connectionString = ConfigurationManager.ConnectionStrings[strDataFilePath].ConnectionString;

            int portNumber = WpfApp_ADO_NET_SQLDataReader.Properties.Settings.Default.PortNumber;
            string userName = WpfApp_ADO_NET_SQLDataReader.Properties.Settings.Default.UserName;

            connection.ConnectionString = connectionString;
            return connection;
        }

        public static SqlConnection CreateSqlConnection_StringBuilder(string[] strDataFilePath)
        {
            var connection = new SqlConnection();

            int portNumber = WpfApp_ADO_NET_SQLDataReader.Properties.Settings.Default.PortNumber;
            string userName = WpfApp_ADO_NET_SQLDataReader.Properties.Settings.Default.UserName;

            // Построитель строки соединения с сервером
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.InitialCatalog = strDataFilePath[0];// "Pubs";
            builder.DataSource = strDataFilePath[1];// ".\\SQLExpress";
            //builder.Password = strDataFilePath[2];//"123";
            builder.ConnectTimeout = 30;
            //builder.UserID = strDataFilePath[3];//"test";
            builder.IntegratedSecurity = true;  // - заходить с правами текущего пользователя Windows

            connection.ConnectionString = builder.ConnectionString;
            return connection;
        }

        //  SELECT CONVERT(BIT, COUNT(*))
        //  FROM sys.tables
        //  WHERE name = N'<Имя искомой таблицы>'
        public static bool TableExist(SqlConnection connection, string table_name)
        {
            bool answer = false;
            try
            {
                // Открыть соединение с сервером БД
                connection.Open();

                // Команда SQL для выполнения на сервере
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText = $"SELECT CONVERT(BIT, COUNT(*)) as flag_exist FROM sys.tables WHERE name = N'{table_name}'";
                    //sqlCommand.CommandText = $"SELECT * FROM SYSOBJECTS WHERE NAME = N'{table_name}' AND xtype = 'U'";
                    // Объект, который читает информацию из результатов запроса
                    using (SqlDataReader dr = sqlCommand.ExecuteReader())
                    {
                        // Прочитать одну строку из результатов запроса
                        while (dr.Read())
                        {
                            answer = (bool)dr["flag_exist"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Закрытие соединения
                connection.Close();
            }

            return answer;
        }

        public static void CreateDatabase(SqlConnection connection, string folder_name, string database_name)
        {
            DirectoryInfo dinfo = new DirectoryInfo(folder_name);
            if (!dinfo.Exists)
                Directory.CreateDirectory(folder_name);

            try
            {
                string command = $"CREATE DATABASE {database_name} ON PRIMARY " +
                $"(NAME = {database_name}, " +
                "FILENAME = 'C:\\Work_test\\" + database_name + ".mdf', " +
                "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                "LOG ON (NAME = " + database_name + "_Log, " +
                "FILENAME = 'C:\\Work_test\\" + database_name + ".ldf', " +
                "SIZE = 1MB, " +
                "MAXSIZE = 5MB, " +
                "FILEGROWTH = 10%)";

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    connection.Open();

                    // Исполнение непараметризированного запроса, который не возвращает результатов
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("DataBase is Created Successfully", "MyProgram",MessageBoxButton.OK,MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Закрытие соединения
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        public static bool CheckDatabaseExist(SqlConnection connection, string database_name)
        {
            bool answer = false;

            List<string> databases = GetAllDatabase(connection);

            foreach (var database_info in databases)
                if (database_info.Contains(database_name))
                {
                    answer = true;
                    break;
                }

            return answer;
        }

        public static List<string> GetAllDatabase(SqlConnection connection)
        {
            List<string> QueryAnswer = new List<string>();

            try
            {
                string command = $"USE master SELECT name, database_id, create_date FROM sys.databases";

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    connection.Open();

                    // Объект, который читает информацию из результатов запроса
                    using (SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        StringBuilder str_builder = new StringBuilder(1000);
                        //цикл по числу прочитанных полей
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            //вывести в консольное окно
                            //имена полей
                            str_builder.AppendFormat("{0,30}", dr.GetName(i).ToString() + "\t");
                        }
                        QueryAnswer.Add("".PadRight(100, '*'));
                        QueryAnswer.Add(str_builder.ToString());
                        QueryAnswer.Add("".PadRight(100, '*'));

                        // Прочитать одну строку из результатов запроса
                        while (dr.Read())
                        {
                            str_builder.Clear();
                            //цикл по числу прочитанных полей
                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                //вывести в консольное окно
                                //имена полей
                                str_builder.AppendFormat("{0,30}", dr[i].ToString() + "\t");
                            }
                            QueryAnswer.Add(str_builder.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Закрытие соединения
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return QueryAnswer;
        }

        public static List<string> GetTableColumnsName(SqlConnection connection, string table_name)
        {
            List<string> QueryAnswer = new List<string>();

            try
            {
                string command = $"SELECT name FROM sys.columns WHERE object_id = OBJECT_ID('{table_name}');";

                //select COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH,
                //NUMERIC_PRECISION, DATETIME_PRECISION,
                //IS_NULLABLE
                //from INFORMATION_SCHEMA.COLUMNS
                //where TABLE_NAME = 'TableName'

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    connection.Open();

                    // Объект, который читает информацию из результатов запроса
                    using (SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        StringBuilder str_builder = new StringBuilder(1000);

                        // Прочитать одну строку из результатов запроса
                        while (dr.Read())
                        {
                            str_builder.Clear();
                            if (dr.FieldCount > 0)
                                //имена полей
                                str_builder.AppendFormat("{0}", dr[0].ToString());
                            QueryAnswer.Add(str_builder.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Закрытие соединения
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return QueryAnswer;
        }

        public static List<Dictionary<string, string>> GetTableColumnsInfo(SqlConnection connection, string table_name)
        {
            List<Dictionary<string, string>> QueryAnswer = new List<Dictionary<string, string>>();

            try
            {
                string command = $"select COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH," +
                    $"NUMERIC_PRECISION, DATETIME_PRECISION," +
                    $"IS_NULLABLE " +
                    $"from INFORMATION_SCHEMA.COLUMNS " +
                    $"where TABLE_NAME = N'{table_name}'";

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    connection.Open();

                    // Объект, который читает информацию из результатов запроса
                    using (SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        StringBuilder str_builder = new StringBuilder(1000);
                        Dictionary<string, string> current_dict;

                        // Прочитать одну строку из результатов запроса
                        while (dr.Read())
                        {
                            str_builder.Clear();
                            current_dict = new Dictionary<string, string>();
                            //цикл по числу прочитанных полей
                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                current_dict[dr.GetName(i)] = dr[i].ToString();
                            }
                            QueryAnswer.Add(current_dict);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Закрытие соединения
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return QueryAnswer;
        }

        public static void SelectDatabase(SqlConnection connection, string database_name)
        {
            try
            {
                connection.Open();

                string command = $"USE {database_name}";

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    MessageBox.Show(command);

                    // Исполнение непараметризированного запроса, который не возвращает результатов
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Закрытие соединения
                connection.Close();
            }
        }


        public static Dictionary<string, int> GetTableColumnsMaxSize(SqlConnection connection, string table_name)
        {
            Dictionary<string, int> QueryAnswer = new Dictionary<string, int>();

            List<string> column_names = GetTableColumnsName(connection, table_name);
            //            SELECT MAX(LEN(GSM)) FROM Phones;
            try
            {
                string command = $"SELECT MAX(LEN(";

                int cnt = column_names.Count;
                if (cnt == 1)
                    command += column_names[0] + "))";
                else if (cnt > 0)
                {
                    command += column_names[0] + "))";
                    for (int i = 1; i < cnt; i++)
                        command += ", MAX(LEN(" + column_names[i] + "))";
                }
                command += $" FROM {table_name}";

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    connection.Open();

                    // Объект, который читает информацию из результатов запроса
                    using (SqlDataReader dr = sqlCommand.ExecuteReader())
                    {
                        // Прочитать одну строку из результатов запроса
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                //имена полей
                                QueryAnswer[column_names[i]] = (dr[i] != DBNull.Value) ? (int)dr[i] : 30;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Закрытие соединения
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return QueryAnswer;
        }

        public static List<string> Select_All(SqlConnection connection, string table_name, string separator_str = " | ")
        {
            List<string> QueryAnswer = new List<string>();

            Dictionary<string, int> size_dict = GetTableColumnsMaxSize(connection, table_name);

            try
            {
                // Открыть соединение с сервером БД
                connection.Open();

                // Команда SQL для выполнения на сервере
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText = $"select * from {table_name}";

                    // Объект, который читает информацию из результатов запроса
                    using (SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        StringBuilder str_builder = new StringBuilder(1000);
                        int max_width = 0;
                        int current_width = 0;

                        //string separator_str = " | ";
                        int separator_str_length = separator_str.Length;

                        //цикл по числу прочитанных полей
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            //имена полей
                            current_width = size_dict[dr.GetName(i)];
                            string current_str = dr.GetName(i).ToString();
                            if (current_str.Length > current_width)
                            {
                                current_width = current_str.Length;
                                size_dict[dr.GetName(i)] = current_width;
                            }
                            max_width += current_width;

                            str_builder.AppendFormat("{0}", current_str);

                            if (str_builder.Length < max_width)
                                str_builder.Append(' ', max_width - str_builder.Length - 1);
                            str_builder.Append(separator_str);
                            max_width += separator_str_length;
                        }
                        QueryAnswer.Add("".PadRight(max_width, '*'));
                        QueryAnswer.Add(str_builder.ToString());
                        QueryAnswer.Add("".PadRight(max_width, '*'));

                        // Прочитать одну строку из результатов запроса
                        while (dr.Read())
                        {
                            max_width = 0;
                            current_width = 0;

                            str_builder.Clear();
                            //цикл по числу прочитанных полей
                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                //имена полей
                                current_width = size_dict[dr.GetName(i)];
                                max_width += current_width;
                                string current_str = dr[i].ToString();//.Replace('\t',' ');

                                str_builder.AppendFormat("{0}", current_str);// dr[i].ToString());

                                if (str_builder.Length < max_width)
                                    str_builder.Append(' ', max_width - str_builder.Length - 1);
                                str_builder.Append(separator_str);
                                max_width += separator_str_length;
                            }
                            QueryAnswer.Add(str_builder.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Закрытие соединения
                connection.Close();
            }

            return QueryAnswer;
        }

        public static List<string> Select_Parameter(SqlConnection connection, string table_name, params string[] parameter)
        {
            List<string> QueryAnswer = new List<string>();

            try
            {
                // Открыть соединение с сервером БД
                connection.Open();

                // Команда SQL для выполнения на сервере
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = connection;

                    string command = $"select ";
                    int cnt = parameter.Length;
                    if (cnt == 1)
                        command += parameter[0];
                    else if (cnt > 0)
                    {
                        command += parameter[0];
                        for (int i = 1; i < cnt; i++)
                            command += ", " + parameter[i];
                    }
                    command += $" from {table_name}";

                    sqlCommand.CommandText = command;

                    // Объект, который читает информацию из результатов запроса
                    using (SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        StringBuilder str_builder = new StringBuilder(1000);

                        // Прочитать одну строку из результатов запроса
                        while (dr.Read())
                        {
                            str_builder.Clear();
                            //цикл по числу прочитанных полей
                            if (dr.FieldCount == 1)
                                str_builder.AppendFormat("{0};", dr[0].ToString());
                            else
                                for (int i = 0; i < dr.FieldCount; i++)
                                {
                                    //вывести в консольное окно
                                    //имена полей
                                    str_builder.AppendFormat("{0}", dr[i].ToString() + ";");
                                }
                            QueryAnswer.Add(str_builder.ToString());
                            //string str = dr["id"].ToString( + "\t" + dr["name"] + "\t" + dr["count"];
                            //QueryAnswer.Add(str);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Закрытие соединения
                connection.Close();
            }

            return QueryAnswer;
        }

        public static void Insert_NewData(SqlConnection connection, string table_name, string parameter, string value)
        {
            try
            {
                connection.Open();

                string command = $"insert into {table_name} ({parameter}) " +
                    $"values (N'{value}')";

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    //MessageBox.Show(command);

                    // Исполнение непараметризированного запроса, который не возвращает результатов
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Закрытие соединения
                connection.Close();
            }
        }

        public static SqlCommand PrepareParamInsertSqlCommand(SqlConnection connection, string table_name)
        {
            List<Dictionary<string, string>> column_infos = SqlDatabase.GetTableColumnsInfo(connection, table_name);
            //            string command = $"select COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH," +
            //                    $"NUMERIC_PRECISION, DATETIME_PRECISION," +
            //                    $"IS_NULLABLE " +
            //                    $"from INFORMATION_SCHEMA.COLUMNS " +
            //                    $"where TABLE_NAME = N'{table_name}'";

            Dictionary<string, string> id_column_info = GetKeyColumnInfo(connection, table_name);

            string command1 = null;
            string command2 = null;

            // string com = "insert into authors3(au_fname, au_lname, city, state) values (@p1, @p2, @p3, @p4)";
            int i = 1;
            if (column_infos.Count == 1)
            {
                if (!id_column_info["COLUMN_NAME"].Equals(column_infos[0]["COLUMN_NAME"]))
                {
                    command1 += $"{column_infos[0]["COLUMN_NAME"]} ";
                    command2 += $"@param{i}";
                }
            }
            else
                foreach (var column_info in column_infos)
                {
                    if (id_column_info["COLUMN_NAME"].Equals(column_info["COLUMN_NAME"]))
                        continue;

                    if (command1 != null)
                        command1 += ",";
                    command1 += $"{column_info["COLUMN_NAME"]} ";

                    if (command2 != null)
                        command2 += ",";
                    command2 += $"@param{i++}";
                }

            string command = $"insert into {table_name} ( " + command1 + $") values(" + command2 + " ) ";

            SqlCommand sqlCommand = new SqlCommand(command, connection);

            i = 1;
            foreach (var column_info in column_infos)
            {
                if (id_column_info.Equals(column_info))
                    continue;

                SqlDbType type = (SqlDbType)Enum.Parse(typeof(SqlDbType), column_info["DATA_TYPE"], true);
                int.TryParse(column_info["CHARACTER_MAXIMUM_LENGTH"], out int tmp_length);
                sqlCommand.Parameters.Add($"@param{i++}", type, tmp_length, column_info["COLUMN_NAME"]);
            }

            return sqlCommand;
        }

        public static SqlCommand PrepareParamUpdateSqlCommand(SqlConnection connection, string table_name)
        {
            List<Dictionary<string, string>> column_infos = SqlDatabase.GetTableColumnsInfo(connection, table_name);
            //            string command = $"select COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH," +
            //                    $"NUMERIC_PRECISION, DATETIME_PRECISION," +
            //                    $"IS_NULLABLE " +
            //                    $"from INFORMATION_SCHEMA.COLUMNS " +
            //                    $"where TABLE_NAME = N'{table_name}'";

            Dictionary<string, string> id_column_info = GetKeyColumnInfo(connection, table_name);

            // string  com = "update authors3 set au_fname=@p2, au_lname=@p3, city=@p4, state=@p5 where au_id=@p1";

            string command = null;
            int i = 1;
            int index_id = 1;
            foreach (var column_info in column_infos)
            {
                if (id_column_info["COLUMN_NAME"].Equals(column_info["COLUMN_NAME"]))
                {
                    index_id = i++;
                    continue;
                }

                if (command == null)
                    command = $"update {table_name} set ";
                else
                    command += ",";

                command += $"{column_info["COLUMN_NAME"]} = @param{i++}";
            }
            command += $" where {id_column_info["COLUMN_NAME"]} = @param{index_id}";

            SqlCommand sqlCommand = new SqlCommand(command, connection);

            i = 1;
            foreach (var column_info in column_infos)
            {
                SqlDbType type = (SqlDbType)Enum.Parse(typeof(SqlDbType), column_info["DATA_TYPE"], true);
                int.TryParse(column_info["CHARACTER_MAXIMUM_LENGTH"], out int tmp_length);
                sqlCommand.Parameters.Add($"@param{i++}", type, tmp_length, column_info["COLUMN_NAME"]);
            }

            return sqlCommand;
        }

        public static List<string> GetConstraintKey(SqlConnection connection, string table_name)
        {
            List<string> QueryAnswer = new List<string>();

            try
            {
                string command =
                    $"SELECT name FROM sys.objects " +
                    $"WHERE type = 'PK' AND parent_object_id = OBJECT_ID('{table_name}');";

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    connection.Open();

                    // Объект, который читает информацию из результатов запроса
                    using (SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        StringBuilder str_builder = new StringBuilder(1000);

                        // Прочитать одну строку из результатов запроса
                        while (dr.Read())
                        {
                            str_builder.Clear();
                            if (dr.FieldCount > 0)
                                //имена полей
                                str_builder.AppendFormat("{0}", dr[0].ToString());
                            QueryAnswer.Add(str_builder.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Закрытие соединения
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return QueryAnswer;
        }

        public static List<string> GetKeyColumns(SqlConnection connection, string database_name, string table_name)
        {
            List<string> QueryAnswer = new List<string>();

            try
            {
                string command =
                    $"SELECT COLUMN_NAME FROM {database_name}.INFORMATION_SCHEMA.KEY_COLUMN_USAGE " +
                    $"WHERE TABLE_NAME LIKE '{table_name}' AND CONSTRAINT_NAME LIKE 'PK%'";

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    connection.Open();

                    // Объект, который читает информацию из результатов запроса
                    using (SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        StringBuilder str_builder = new StringBuilder(1000);

                        // Прочитать одну строку из результатов запроса
                        while (dr.Read())
                        {
                            str_builder.Clear();
                            if (dr.FieldCount > 0)
                                //имена полей
                                str_builder.AppendFormat("{0}", dr[0].ToString());
                            QueryAnswer.Add(str_builder.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Закрытие соединения
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return QueryAnswer;
        }

        public static List<string> GetKeyColumns(SqlConnection connection, string table_name)
        {
            List<string> QueryAnswer = new List<string>();

            try
            {
                string command =
                    $"SELECT COLUMN_NAME FROM {connection.Database}.INFORMATION_SCHEMA.KEY_COLUMN_USAGE " +
                    $"WHERE TABLE_NAME LIKE '{table_name}' AND CONSTRAINT_NAME LIKE 'PK%'";

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    connection.Open();

                    // Объект, который читает информацию из результатов запроса
                    using (SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        StringBuilder str_builder = new StringBuilder(1000);

                        // Прочитать одну строку из результатов запроса
                        while (dr.Read())
                        {
                            str_builder.Clear();
                            if (dr.FieldCount > 0)
                                //имена полей
                                str_builder.AppendFormat("{0}", dr[0].ToString());
                            QueryAnswer.Add(str_builder.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Закрытие соединения
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return QueryAnswer;
        }

        public static Dictionary<string, string> GetKeyColumnInfo(SqlConnection connection, string table_name)
        {
            List<Dictionary<string, string>> column_infos = SqlDatabase.GetTableColumnsInfo(connection, table_name);
            //            string command = $"select COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH," +
            //                    $"NUMERIC_PRECISION, DATETIME_PRECISION," +
            //                    $"IS_NULLABLE " +
            //                    $"from INFORMATION_SCHEMA.COLUMNS " +
            //                    $"where TABLE_NAME = N'{table_name}'";

            List<string> column_keys = SqlDatabase.GetKeyColumns(connection, table_name);
            //          $"SELECT COLUMN_NAME FROM {connection.Database}.INFORMATION_SCHEMA.KEY_COLUMN_USAGE " +
            //          $"WHERE TABLE_NAME LIKE '{table_name}' AND CONSTRAINT_NAME LIKE 'PK%'";

            foreach (var name in column_keys)
                foreach (var column_info in column_infos)
                    if (column_info["COLUMN_NAME"].Equals(name))
                    {
                        SqlDbType type_inside = (SqlDbType)Enum.Parse(typeof(SqlDbType), column_info["DATA_TYPE"], true);
                        if (SqlDbType.Int.Equals(type_inside) || SqlDbType.BigInt.Equals(type_inside))
                            return column_info;
                    }

            return null;
        }

        public static SqlCommand PrepareParamDeleteSqlCommand(SqlConnection connection, string table_name)
        {
            Dictionary<string, string> id_column_info = GetKeyColumnInfo(connection, table_name);

            string command = $"delete from {table_name} where {id_column_info["COLUMN_NAME"]}=@param1";

            SqlCommand sqlCommand = new SqlCommand(command, connection);

            SqlDbType type = (SqlDbType)Enum.Parse(typeof(SqlDbType), id_column_info["DATA_TYPE"], true);
            int.TryParse(id_column_info["CHARACTER_MAXIMUM_LENGTH"], out int tmp_length);
            sqlCommand.Parameters.Add($"@param1", type, tmp_length, id_column_info["COLUMN_NAME"]);

            return sqlCommand;
        }

        public static void Insert_NewDataParameter(SqlConnection connection, string table_name, params string[] parameter)
        {
            try
            {
                connection.Open();

                string command1 = $"insert into {table_name} ( ";
                string command2 = $"values ( ";
                int cnt = parameter.Length;
                if (cnt % 2 == 0)
                {
                    if (cnt == 2)
                    {
                        command1 += $"{parameter[0]} ";
                        command2 += $"N'{parameter[1]}' ";
                    }
                    else if (cnt > 2)
                    {
                        command1 += $"{parameter[0]}, ";
                        command2 += $"N'{parameter[1]}', ";
                        for (int i = 2; i < cnt; i += 2)
                        {
                            command1 += $", {parameter[i]}";
                            command2 += $", N'{parameter[i + 1]}'";
                        }
                    }
                }

                string command = command1 + " ) " + command2 + " ) ";
                //$"insert into {table_name} (name) " +
                //    $"values (N'{filename}')";

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    //MessageBox.Show(command);

                    // Исполнение непараметризированного запроса, который не возвращает результатов
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Закрытие соединения
                connection.Close();
            }
        }

        public static void DeleteAll(SqlConnection connection, string table_name)
        {
            try
            {
                connection.Open();

                string command = $"delete from {table_name}";

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Закрытие соединения
                connection.Close();
            }
        }

        public static void UpdateParameter(SqlConnection connection, string table_name, params string[] parameter)
        {
            try
            {
                connection.Open();

                string command = $"update {table_name} set ";
                int cnt = parameter.Length;
                if (cnt % 2 == 0)
                {
                    if (cnt == 2)
                        command += parameter[0] + $" = N'{parameter[1]}'";
                    else if (cnt > 2)
                    {
                        command += parameter[0];
                        for (int i = 2; i < cnt; i += 2)
                            command += ", " + parameter[i] + $" = N'{parameter[i + 1]}'";
                    }
                    command += $" from {table_name}";
                    //"update authors2 set au_fname=@fname, au_lname=@lname, city=@c, state=@st where au_id=@id";

                    using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                    {
                        MessageBox.Show(command);

                        // Исполнение непараметризированного запроса, который не возвращает результатов
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Закрытие соединения
                connection.Close();
            }
        }

        public static void UpdateQuery(SqlConnection connection, string table_name, string name, string new_count)
        {
            try
            {
                connection.Open();

                // Параметризированный запрос
                string command = $"update {table_name} set count=@new_count where name=@name";

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {

                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@name";
                    param1.Value = name;
                    param1.SqlDbType = SqlDbType.VarChar;
                    param1.Size = 20;
                    sqlCommand.Parameters.Add(param1);

                    SqlParameter param2 = new SqlParameter("@new_count", SqlDbType.Int);
                    param2.Value = new_count;
                    sqlCommand.Parameters.Add(param2);

                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Закрытие соединения
                connection.Close();
            }

        }

        public static void BulkQuery(SqlConnection connection, string TableName, DataRow[] rows)
        {
            try
            {
                connection.Open();

                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(connection))
                {
                    sqlBulkCopy.DestinationTableName = TableName;
                    sqlBulkCopy.WriteToServer(rows);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Закрытие соединения
                connection.Close();
            }
        }


        public static object StoredProcedure(SqlConnection connection, string parameter_value)
        {
            /*
             create proc [dbo].[deltest]
             @id varchar(10),
             @n int output
             as begin
             select @n = count(*) from authors2 where au_id = @id
             delete from authors2 where au_id = @id
             end
            */

            object QueryAnswer = null;

            try
            {
                connection.Open();

                // Команда, запускающая хранимую процедуру
                using (SqlCommand sqlCommand = new SqlCommand("deltest", connection))
                {
                    // Тип - хранимая процедура
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    // Класс для передачи параметров
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@id";
                    param1.Value = parameter_value;
                    param1.SqlDbType = SqlDbType.VarChar;
                    param1.Size = 11;
                    param1.Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.Add(param1);

                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@n";
                    param2.SqlDbType = SqlDbType.Int;
                    param2.Size = 4;
                    param2.Direction = ParameterDirection.Output;
                    sqlCommand.Parameters.Add(param2);

                    // Исполнение хранимой процедуры на сервере
                    sqlCommand.ExecuteNonQuery();

                    // Получить выходной параметр из процедуры
                    MessageBox.Show(sqlCommand.Parameters["@n"].Value.ToString());

                    QueryAnswer = sqlCommand.Parameters["@n"].Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Закрытие соединения
                connection.Close();
            }

            return QueryAnswer;
        }


        public static void SyncTransaction(SqlConnection connection, List<string> commands)
        {

            //    // Список команд для выполнения на сервере
            //    List<string> commands = new List<string>();
            //    commands.Add(@"insert into authors2 values ('123-45-6789', 'Alex', 'Petrov', 'Donetsk', 'DN')");
            //    commands.Add(@"insert into authors2 values ('123-45-6780', 'Ivan', 'Demidoff', 'Moskow', 'MS')");

            // Класс, обеспечивающий работу транзакций
            SqlTransaction trans = null;

            try
            {
                connection.Open();

                // Открыть транзакцию
                trans = connection.BeginTransaction();

                // Цикличное исполнение команд на сервере
                foreach (var commandString in commands)
                {
                    SqlCommand command = new SqlCommand(commandString, connection, trans);
                    command.ExecuteNonQuery();
                }

                // Фиксация транзакции
                trans.Commit();
            }
            catch (Exception ex)
            {
                // Откат транзакции
                trans.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Закрытие соединения
                connection.Close();
            }
        }







    }
}
