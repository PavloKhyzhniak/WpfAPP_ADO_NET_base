using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp_ADO_NET_SQLDataReader.Classes_SqlDataReader
{
    public static partial class SqlDatabase
    {
        // select au_id, au_fname, au_lname, city, state into authors2 from authors
        public static void Select(SqlConnection connection, ref List<Manufacturer> collection)
        {
            collection.Clear();

            try
            {
                // Открыть соединение с сервером БД
                connection.Open();

                // Команда SQL для выполнения на сервере
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText = "select * from Manufacturers";

                    // Объект, который читает информацию из результатов запроса
                    SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                    // Прочитать одну строку из результатов запроса
                    if (dr.HasRows)
                        while (dr.Read())
                    {
                        Manufacturer manufacturer =
                        new Manufacturer
                        {
                            VendorId = (int)dr["VendorId"],
                            BrandTitle = (string)dr["BrandTitle"],
                            Address = (string)dr["Address"],
                            Phone = (string)dr["Phone"],
                        };
                        collection.Add(manufacturer);
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

        public static void Insert(SqlConnection connection, Manufacturer manufacturer)
        {

            try
            {
                connection.Open();

                string command = $"insert into Manufacturers (BrandTitle, Address, Phone) " +
                    $"values ('{manufacturer.BrandTitle}', '{manufacturer.Address}', '{manufacturer.Phone}')";

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

        public static void UpdateQuery(SqlConnection connection, Manufacturer manufacturer)
        {
            try
            {
                connection.Open();

                // Параметризированный запрос
                string command = "update Manufacturers set BrandTitle=@BrandTitle, Address=@Address, Phone=@Phone where VendorId=@VendorId";

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {

                    SqlParameter paramBrandTitle = new SqlParameter("@BrandTitle", SqlDbType.VarChar, 50);
                    paramBrandTitle.Value = manufacturer.BrandTitle;
                    sqlCommand.Parameters.Add(paramBrandTitle);

                    SqlParameter paramAddress = new SqlParameter("@Address", SqlDbType.VarChar, 100);
                    paramAddress.Value = manufacturer.Address;
                    sqlCommand.Parameters.Add(paramAddress);

                    SqlParameter paramPhone = new SqlParameter("@Phone", SqlDbType.VarChar, 20);
                    paramPhone.Value = manufacturer.Phone;
                    sqlCommand.Parameters.Add(paramPhone);

                    SqlParameter paramVendorId = new SqlParameter("@VendorId", SqlDbType.Int);
                    paramVendorId.Value = manufacturer.VendorId;
                    sqlCommand.Parameters.Add(paramVendorId);

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

        public static void DeleteAll_Manufacturer(SqlConnection connection)
        {
            try
            {
                connection.Open();

                string command = $"delete from Manufacturers";

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


        public static void Delete(SqlConnection connection, Manufacturer manufacturer)
        {
            try
            {
                connection.Open();

                string command = $"delete from Manufacturers where VendorId=@VendorId";

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {                   
                    SqlParameter paramVendorId = new SqlParameter("@VendorId", SqlDbType.Int);
                    paramVendorId.Value = manufacturer.VendorId;
                    sqlCommand.Parameters.Add(paramVendorId);

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









        public static List<object> Select_ManufacturerWithAiplaneCountMore(SqlConnection connection, int Count)
        {
            List<object> collection = new List<object>();

            try
            {
                // Открыть соединение с сервером БД
                connection.Open();

                // Параметризированный запрос
                // Команда SQL для выполнения на сервере
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText =
                        "select DISTINCT m.VendorId, m.BrandTitle, m.Address, m.Phone from Airplanes a, Manufacturers m" +
                        " where a.VendorId = m.VendorId " +
                        " and (select COUNT(a.Id) cnt from Airplanes a where a.VendorId = m.VendorId group by a.VendorId) > @Count";
                        
                    SqlParameter paramCount = new SqlParameter("@Count", SqlDbType.Int);
                    paramCount.Value = Count;
                    sqlCommand.Parameters.Add(paramCount);

                    // Объект, который читает информацию из результатов запроса
                    SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                    // Прочитать одну строку из результатов запроса
                    if (dr.HasRows)
                        while (dr.Read())
                    {
                        var manufacturer =
                       new 
                       {
                           VendorId = (int)dr["VendorId"],
                           BrandTitle = (string)dr["BrandTitle"],
                           Address = (string)dr["Address"],
                           Phone = (string)dr["Phone"],
                       };
                        collection.Add(manufacturer);
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

            return collection;
        }

        public static List<object> Select_ManufacturerWithLengthBrandTitleLess(SqlConnection connection, int Count)
        {
            List<object> collection = new List<object>();

            try
            {
                // Открыть соединение с сервером БД
                connection.Open();

                // Параметризированный запрос
                // Команда SQL для выполнения на сервере
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText =
                        "select m.VendorId, m.BrandTitle, m.Address, m.Phone " +
                        " from Manufacturers m" +
                        " where Len(m.BrandTitle) < @Count";

                    SqlParameter paramCount = new SqlParameter("@Count", SqlDbType.Int);
                    paramCount.Value = Count;
                    sqlCommand.Parameters.Add(paramCount);

                    // Объект, который читает информацию из результатов запроса
                    SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                    // Прочитать одну строку из результатов запроса
                    if (dr.HasRows)
                        while (dr.Read())
                    {
                        var manufacturer =
                       new 
                       {
                           VendorId = (int)dr["VendorId"],
                           BrandTitle = (string)dr["BrandTitle"],
                           Address = (string)dr["Address"],
                           Phone = (string)dr["Phone"],
                       };
                        collection.Add(manufacturer);
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

            return collection;
        }

        public class MyData_GetManufacturerWithAirplaneMore
        {
            public string BrandTitle { get; set; }
        }

        public static List<MyData_GetManufacturerWithAirplaneMore> SP_GetManufacturerWithAirplaneMore(SqlConnection connection, int Count)
        {
            /*

create function GetManufacturerWithAirplaneMore(@st int)
returns table
as
return 
select DISTINCT m.BrandTitle from Airplanes a, Manufacturers m
where a.VendorId=m.VendorId and (select COUNT(a.Id) cnt from Airplanes a where a.VendorId=m.VendorId group by a.VendorId)>@st
GO

   */
            List<MyData_GetManufacturerWithAirplaneMore> collection = new List<MyData_GetManufacturerWithAirplaneMore>();

            try
            {
                // Открыть соединение с сервером БД
                connection.Open();

                // Параметризированный запрос
                // Команда SQL для выполнения на сервере
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText =
                        "select * from GetManufacturerWithAirplaneMore(@Count)";

                    sqlCommand.CommandType = CommandType.Text;

                    SqlParameter paramCount = new SqlParameter("@Count", SqlDbType.Int);
                    paramCount.Value = Count;
                    sqlCommand.Parameters.Add(paramCount);

                    // Объект, который читает информацию из результатов запроса
                    SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                    // Прочитать одну строку из результатов запроса
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            MyData_GetManufacturerWithAirplaneMore manufacturer =
                  new MyData_GetManufacturerWithAirplaneMore
                  {
                   //   VendorId = (int)dr["VendorId"],
                      BrandTitle = (string)dr["BrandTitle"],
                   //   Address = (string)dr["Address"],
                   //   Phone = (string)dr["Phone"],
                  };
                            collection.Add(manufacturer);
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

            return collection;
        }

        public class MyData_GetManufacturerNameWithLengthLess
        {
            public string BrandTitle { get; set; }
        }

        public static List<MyData_GetManufacturerNameWithLengthLess> SP_GetManufacturerNameWithLengthLess(SqlConnection connection, int Count)
        {
            /*

create function GetManufacturerNameWithLengthLess(@st int)
returns table
as
return 
select m.BrandTitle from Manufacturers m
where Len(m.BrandTitle)<@st
GO

   */
            List<MyData_GetManufacturerNameWithLengthLess> collection = new List<MyData_GetManufacturerNameWithLengthLess>();

            try
            {
                // Открыть соединение с сервером БД
                connection.Open();

                // Параметризированный запрос
                // Команда SQL для выполнения на сервере
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText =
                        "select * from GetManufacturerNameWithLengthLess(@Count)";

                    sqlCommand.CommandType = CommandType.Text;

                    SqlParameter paramCount = new SqlParameter("@Count", SqlDbType.Int);
                    paramCount.Value = Count;
                    sqlCommand.Parameters.Add(paramCount);

                    // Объект, который читает информацию из результатов запроса
                    SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                    // Прочитать одну строку из результатов запроса
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            MyData_GetManufacturerNameWithLengthLess manufacturer =
                  new MyData_GetManufacturerNameWithLengthLess
                  {
                      //   VendorId = (int)dr["VendorId"],
                      BrandTitle = (string)dr["BrandTitle"],
                      //   Address = (string)dr["Address"],
                      //   Phone = (string)dr["Phone"],
                  };
                            collection.Add(manufacturer);
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

            return collection;
        }

    } 
}

