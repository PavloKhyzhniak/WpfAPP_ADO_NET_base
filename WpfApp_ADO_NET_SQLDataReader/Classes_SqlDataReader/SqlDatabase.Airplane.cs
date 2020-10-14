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
        public static void Select(SqlConnection connection, ref List<Airplane> collection)
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
                    sqlCommand.CommandText =
                        "select a.Id,a.Model,a.Price,a.Speed,a.VendorId,m.BrandTitle" +
                        " from Airplanes a, Manufacturers m" +
                        " where a.VendorId = m.VendorId";

                    // Объект, который читает информацию из результатов запроса
                    SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                    // Прочитать одну строку из результатов запроса
                    if (dr.HasRows)
                        while (dr.Read())
                    {
                        Airplane airplane =
                        new Airplane
                        {
                            Id = (int)dr["Id"],
                            Model = (string)dr["Model"],
                            Price = (double)dr["Price"],
                            Speed = (int)dr["Speed"],
                            VendorId = (int)dr["VendorId"],

                            Vendor = (string)dr["BrandTitle"]
                        };
                        collection.Add(airplane);
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

        // select au_id, au_fname, au_lname, city, state into authors2 from authors
        public static List<Airplane> Select_AiplaneWithVendorId(SqlConnection connection, int VendorId )
        {
            List<Airplane> collection = new List<Airplane>();

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
                        "select a.Id,a.Model,a.Price,a.Speed,a.VendorId,m.BrandTitle" +
                        " from Airplanes a, Manufacturers m" +
                        " where a.VendorId = m.VendorId and a.VendorId = @VendorId";

                    SqlParameter paramVendorId = new SqlParameter("@VendorId", SqlDbType.Int);
                    paramVendorId.Value = VendorId;
                    sqlCommand.Parameters.Add(paramVendorId);

                    // Объект, который читает информацию из результатов запроса
                    SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                    // Прочитать одну строку из результатов запроса
                    if (dr.HasRows)
                        while (dr.Read())
                    {
                        Airplane airplane =
                        new Airplane
                        {
                            Id = (int)dr["Id"],
                            Model = (string)dr["Model"],
                            Price = (double)dr["Price"],
                            Speed = (int)dr["Speed"],
                            VendorId = (int)dr["VendorId"],

                            Vendor = (string)dr["BrandTitle"]
                        };
                        collection.Add(airplane);
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

        public static void Insert(SqlConnection connection, Airplane airplane)
        {

            try
            {
                connection.Open();

                string command = $"insert into Airplanes (Model, Price, Speed, VendorId) " +
                    $"values ('{airplane.Model}', '{airplane.Price}', '{airplane.Speed}', '{airplane.VendorId}')";

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

        public static void UpdateQuery(SqlConnection connection, Airplane airplane)
        {
            try
            {
                connection.Open();

                // Параметризированный запрос
                string command = "update Airplanes set Model=@Model, Price=@Price, Speed=@Speed, VendorId=@VendorId  where Id=@Id";

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {

                    SqlParameter paramModel = new SqlParameter("@Model", SqlDbType.VarChar, 50);
                    paramModel.Value = airplane.Model;
                    sqlCommand.Parameters.Add(paramModel);

                    SqlParameter paramPrice = new SqlParameter("@Price", SqlDbType.Float);
                    paramPrice.Value = airplane.Price;
                    sqlCommand.Parameters.Add(paramPrice);

                    SqlParameter paramSpeed = new SqlParameter("@Speed", SqlDbType.Int);
                    paramSpeed.Value = airplane.Speed;
                    sqlCommand.Parameters.Add(paramSpeed);

                    SqlParameter paramVendorId = new SqlParameter("@VendorId", SqlDbType.Int);
                    paramVendorId.Value = airplane.VendorId;
                    sqlCommand.Parameters.Add(paramVendorId);

                    SqlParameter paramId = new SqlParameter("@Id", SqlDbType.Int);
                    paramId.Value = airplane.VendorId;
                    sqlCommand.Parameters.Add(paramId);

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


        public static void DeleteAll_Airplane(SqlConnection connection)
        {
            try
            {
                connection.Open();

                string command = $"delete from Airplanes";

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


        public static void Delete(SqlConnection connection, Airplane airplane)
        {
            try
            {
                connection.Open();

                string command = $"delete from Airplanes where Id=@Id";

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    SqlParameter paramId = new SqlParameter("@Id", SqlDbType.Int);
                    paramId.Value = airplane.Id;
                    sqlCommand.Parameters.Add(paramId);

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









        public static List<Airplane> Select_AiplaneWithSpeedLess(SqlConnection connection, int Speed)
        {
            List<Airplane> collection = new List<Airplane>();

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
                        "select a.Id ,a.Model ,a.Price,a.Speed,a.VendorId,m.BrandTitle from Airplanes a, Manufacturers m" +
                        " where a.Speed < @Speed and a.VendorId = m.VendorId";

                    SqlParameter paramSpeed = new SqlParameter("@Speed", SqlDbType.Int);
                    paramSpeed.Value = Speed;
                    sqlCommand.Parameters.Add(paramSpeed);

                    // Объект, который читает информацию из результатов запроса
                    SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                   
                    // Прочитать одну строку из результатов запроса
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            Airplane airplane =
                            new Airplane
                            {
                                Id = (int)dr["Id"],
                                Model = (string)dr["Model"],
                                Price = (double)dr["Price"],
                                Speed = (int)dr["Speed"],
                                VendorId = (int)dr["VendorId"],

                                Vendor = (string)dr["BrandTitle"]
                            };
                            collection.Add(airplane);
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


        public class MyData_GetAirplaineWithSpeedLess
        {
            public int Id { get; set; }
            public string Model { get; set; }
            public double Price { get; set; }
            public int Speed { get; set; }
            public string Vendor { get; set; }
        }

        public static List<MyData_GetAirplaineWithSpeedLess> SP_GetAirplaineWithSpeedLess(SqlConnection connection, int Speed)
        {
            /*

create function GetAirplaineWithSpeedLess(@st int)
returns table
as
return 
select a.Id,a.Model,a.Price,a.Speed,m.BrandTitle from Airplanes a, Manufacturers m
where a.Speed<@st and a.VendorId=m.VendorId
GO

   */        
            List<MyData_GetAirplaineWithSpeedLess> collection = new List<MyData_GetAirplaineWithSpeedLess>();

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
                        "select * from GetAirplaineWithSpeedLess(@Speed)";

                    sqlCommand.CommandType = CommandType.Text;

                    SqlParameter paramSpeed = new SqlParameter("@Speed", SqlDbType.Int);
                    paramSpeed.Value = Speed;
                    sqlCommand.Parameters.Add(paramSpeed);

                    // Объект, который читает информацию из результатов запроса
                    SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                    // Прочитать одну строку из результатов запроса
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            MyData_GetAirplaineWithSpeedLess airplane =
                            new MyData_GetAirplaineWithSpeedLess
                            {
                                Id = (int)dr["Id"],
                                Model = (string)dr["Model"],
                                Price = (double)dr["Price"],
                                Speed = (int)dr["Speed"],
                               // VendorId = (int)dr["VendorId"],

                                Vendor = (string)dr["BrandTitle"]
                            };
                            collection.Add(airplane);
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
