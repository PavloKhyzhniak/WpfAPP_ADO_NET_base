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
        public static void Select(SqlConnection connection, ref List<Employee> collection)
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
                    sqlCommand.CommandText = "select * from Employees";

                    // Объект, который читает информацию из результатов запроса
                    SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                    // Прочитать одну строку из результатов запроса
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            Employee employee =
                            new Employee
                            {
                                Id = (int)dr["Id"],
                                FirstName = (string)dr["FirstName"],
                                LastName = (string)dr["LastName"],
                                Age = (int)dr["Age"],
                                Address = (string)dr["Address"],
                                FotoPath = (string)dr["FotoPath"]
                            };
                            collection.Add(employee);
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

            foreach (var item in collection)
                item.Projects=(ICollection<Project>)Select_ProjectsForEmloyeeWithId(connection, item.Id);
        }

        // select au_id, au_fname, au_lname, city, state into authors2 from authors
        public static List<Project> Select_ProjectsForEmloyeeWithId(SqlConnection connection, int Id)
        {
            List<Project> collection = new List<Project>();

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
                        "select p.* from ProjectEmployees pe, Projects p" +
                        " where pe.EmployeeId = @Id and p.Id = pe.ProjectId";

                    SqlParameter paramId = new SqlParameter("@Id", SqlDbType.Int);
                    paramId.Value = Id;
                    sqlCommand.Parameters.Add(paramId);

                    // Объект, который читает информацию из результатов запроса
                    SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                    // Прочитать одну строку из результатов запроса
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            Project project =
                            new Project
                            {
                                Id = (int)dr["Id"],
                                Title = (string)dr["Title"],
                                StartDate = (DateTime)dr["StartDate"],
                                EndDate = (DateTime)dr["EndDate"],
                                Description = (string)dr["Description"],
                            };
                            collection.Add(project);
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

        public static void Insert(SqlConnection connection, Employee employee)
        {

            try
            {
                connection.Open();

                string command = $"insert into Employees (FirstName,LastName,Age,Address,FotoPath) " +
                    $"values ('{employee.FirstName}', '{employee.LastName}','{employee.Age}', '{employee.Address}', '{employee.FotoPath}')";

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

        public static void UpdateQuery(SqlConnection connection, Employee employee)
        {
            try
            {
                connection.Open();

                // Параметризированный запрос
                string command = "update Employees set FirstName=@FirstName, LastName=@LastName, Age=@Age, Address=@Address, FotoPath=@FotoPath where Id=@Id";

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {

                    SqlParameter paramFirstName = new SqlParameter("@FirstName", SqlDbType.VarChar, 50);
                    paramFirstName.Value = employee.FirstName;
                    sqlCommand.Parameters.Add(paramFirstName);

                    SqlParameter paramLastName = new SqlParameter("@LastName", SqlDbType.VarChar, 50);
                    paramLastName.Value = employee.LastName;
                    sqlCommand.Parameters.Add(paramLastName);

                    SqlParameter paramAge = new SqlParameter("@Age", SqlDbType.Int);
                    paramAge.Value = employee.Age;
                    sqlCommand.Parameters.Add(paramAge);

                    SqlParameter paramAddress = new SqlParameter("@Address", SqlDbType.VarChar, 50);
                    paramAddress.Value = employee.Address;
                    sqlCommand.Parameters.Add(paramAddress);

                    SqlParameter paramFotoPath = new SqlParameter("@FotoPath", SqlDbType.VarChar, 100);
                    paramFotoPath.Value = employee.FotoPath;
                    sqlCommand.Parameters.Add(paramFotoPath);

                    SqlParameter paramId = new SqlParameter("@Id", SqlDbType.Int);
                    paramId.Value = employee.Id;
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

        public static void DeleteAll_Employees(SqlConnection connection)
        {
            try
            {
                connection.Open();

                string command = $"delete from Employees";

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


        public static void Delete(SqlConnection connection, Employee employee)
        {
            try
            {
                connection.Open();

                string command = $"delete from Employees where Id=@Id";

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    SqlParameter paramId = new SqlParameter("@Id", SqlDbType.Int);
                    paramId.Value = employee.Id;
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








        public static List<object> Select_EmployeerWithAgeLess(SqlConnection connection, int Count)
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
                        "select e.FirstName,e.LastName from Employees e" +
                        " where e.Age < @Count";

                    SqlParameter paramCount = new SqlParameter("@Count", SqlDbType.Int);
                    paramCount.Value = Count;
                    sqlCommand.Parameters.Add(paramCount);

                    // Объект, который читает информацию из результатов запроса
                    SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                    // Прочитать одну строку из результатов запроса
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            var employee =
                             new 
                             {
                             //    Id = (int)dr["Id"],
                                 FirstName = (string)dr["FirstName"],
                                 LastName = (string)dr["LastName"],
                             //    Age = (int)dr["Age"],
                             //    Address = (string)dr["Address"],
                             //    FotoPath = (string)dr["FotoPath"]
                             };
                            collection.Add(employee);
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

        public static List<object> Select_EmployeerWithLastNameLengthMoreOrEqual(SqlConnection connection, int Count)
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
                        "select e.FirstName,e.LastName from Employees e" +
                        " where Len(e.LastName)>= @Count";

                    SqlParameter paramCount = new SqlParameter("@Count", SqlDbType.Int);
                    paramCount.Value = Count;
                    sqlCommand.Parameters.Add(paramCount);

                    // Объект, который читает информацию из результатов запроса
                    SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                    // Прочитать одну строку из результатов запроса
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            var employee =
                            new 
                            {
                            //    Id = (int)dr["Id"],
                                FirstName = (string)dr["FirstName"],
                                LastName = (string)dr["LastName"],
                            //    Age = (int)dr["Age"],
                            //    Address = (string)dr["Address"],
                            //    FotoPath = (string)dr["FotoPath"]
                            };
                            collection.Add(employee);
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



        public class MyData_GetEmployeerWithAgeLess
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public static List<MyData_GetEmployeerWithAgeLess> SP_GetEmployeerWithAgeLess(SqlConnection connection, int Age)
        {
            /*

create function GetEmployeerWithAgeLess(@st int)
returns table
as
return 
select e.FirstName,e.LastName from Employees e
where e.Age<@st
GO
*/
            List<MyData_GetEmployeerWithAgeLess> collection = new List<MyData_GetEmployeerWithAgeLess>();

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
                        "select * from GetEmployeerWithAgeLess(@Age)";

                    sqlCommand.CommandType = CommandType.Text;

                    SqlParameter paramAge = new SqlParameter("@Age", SqlDbType.Int);
                    paramAge.Value = Age;
                    sqlCommand.Parameters.Add(paramAge);

                    // Объект, который читает информацию из результатов запроса
                    SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                    // Прочитать одну строку из результатов запроса
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            MyData_GetEmployeerWithAgeLess manufacturer =
                                new MyData_GetEmployeerWithAgeLess
                                {
                                    FirstName = (string)dr["FirstName"],
                                    LastName = (string)dr["LastName"],
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


        public class MyData_GetEmployeerWithLastNameLengthMoreOrEqual
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public static List<MyData_GetEmployeerWithLastNameLengthMoreOrEqual> SP_GetEmployeerWithLastNameLengthMoreOrEqual(SqlConnection connection, int Count)
        {
            /*

       create function GetEmployeerWithLastNameLengthMoreOrEqual(@st int)
       returns table
       as
       return 
       select e.FirstName,e.LastName from Employees e
       where Len(e.LastName)>=@st
       GO
       */
            List<MyData_GetEmployeerWithLastNameLengthMoreOrEqual> collection = new List<MyData_GetEmployeerWithLastNameLengthMoreOrEqual>();

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
                        "select * from GetEmployeerWithLastNameLengthMoreOrEqual(@Count)";

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
                            MyData_GetEmployeerWithLastNameLengthMoreOrEqual employee =
                                new MyData_GetEmployeerWithLastNameLengthMoreOrEqual
                                {
                                    FirstName = (string)dr["FirstName"],
                                    LastName = (string)dr["LastName"],
                                    //   Address = (string)dr["Address"],
                                    //   Phone = (string)dr["Phone"],
                                };
                            collection.Add(employee);
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
