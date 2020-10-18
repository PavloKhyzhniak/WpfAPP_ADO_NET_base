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
        public static void Select(SqlConnection connection, ref List<Project> collection)
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
                    sqlCommand.CommandText = "select * from Projects";

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

            foreach (var item in collection)
                item.Employees = (ICollection<Employee>)Select_EmployeesForProjectWithId(connection, item.Id);
        }

        // select au_id, au_fname, au_lname, city, state into authors2 from authors
        public static List<Employee> Select_EmployeesForProjectWithId(SqlConnection connection, int Id)
        {
            List<Employee> collection = new List<Employee>();

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
                        "select e.* from ProjectEmployees pe, Employees e" +
                        " where pe.ProjectId = @Id and e.Id = pe.EmployeeId";

                    SqlParameter paramId = new SqlParameter("@Id", SqlDbType.Int);
                    paramId.Value = Id;
                    sqlCommand.Parameters.Add(paramId);

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

            return collection;
        }

        public static void Insert(SqlConnection connection, Project project)
        {

            try
            {
                connection.Open();

                string command = $"insert into Manufacturers (Title, StartDate,EndDate, Description) " +
                    $"values ('{project.Title}', '{project.StartDate}','{project.EndDate}', '{project.Description}')";

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

        public static void UpdateQuery(SqlConnection connection, Project project)
        {
            try
            {
                connection.Open();

                // Параметризированный запрос
                string command = "update Projects set Title=@Title, StartDate=@StartDate, EndDate=@EndDate, Description=@Description where Id=@Id";

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {

                    SqlParameter paramTitle = new SqlParameter("@BrandTitle", SqlDbType.VarChar, 50);
                    paramTitle.Value = project.Title;
                    sqlCommand.Parameters.Add(paramTitle);

                    SqlParameter paramStartDate = new SqlParameter("@StartDate", SqlDbType.DateTime);
                    paramStartDate.Value = project.StartDate;
                    sqlCommand.Parameters.Add(paramStartDate);

                    SqlParameter paramEndDate = new SqlParameter("@EndDate", SqlDbType.DateTime);
                    paramEndDate.Value = project.EndDate;
                    sqlCommand.Parameters.Add(paramEndDate);

                    SqlParameter paramDescription = new SqlParameter("@Description", SqlDbType.VarChar, 200);
                    paramDescription.Value = project.Description;
                    sqlCommand.Parameters.Add(paramDescription);

                    SqlParameter paramId = new SqlParameter("@Id", SqlDbType.Int);
                    paramId.Value = project.Id;
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

        public static void DeleteAll_Projects(SqlConnection connection)
        {
            try
            {
                connection.Open();

                string command = $"delete from Projects";

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


        public static void Delete(SqlConnection connection, Project project)
        {
            try
            {
                connection.Open();

                string command = $"delete from Projects where Id=@Id";

                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    SqlParameter paramId = new SqlParameter("@Id", SqlDbType.Int);
                    paramId.Value = project.Id;
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







        public static List<object> Select_ProjectWithMaxEmployees(SqlConnection connection)
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
                        "SELECT p.Id,p.Title" +
                        " FROM Projects p" +
                        " WHERE p.Id IN (" +
                        "    SELECT pe.ProjectId" +
                        "    FROM ProjectEmployees pe GROUP BY pe.ProjectId" +
                        "    HAVING count(pe.ProjectId) =" +
                        "        (" +
                        "    SELECT MAX(g.cnt)" +
                        "    FROM(SELECT COUNT(ppe.ProjectId) cnt" +
                        "    FROM ProjectEmployees ppe" +
                        "    GROUP BY ppe.ProjectId) g" +
                        "	)" +
                        "	)";

                    // Объект, который читает информацию из результатов запроса
                    SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                    // Прочитать одну строку из результатов запроса
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            var project =
                            new 
                            {
                                Id = (int)dr["Id"],
                                Title = (string)dr["Title"],
                            //    StartDate = (DateTime)dr["StartDate"],
                            //    EndDate = (DateTime)dr["EndDate"],
                            //    Description = (string)dr["Description"],
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


        public class MyData_GetProjectWithMaxEmployees
        {
            public int? Id { get; set; }
            public string Title { get; set; }
        }

        public static List<MyData_GetProjectWithMaxEmployees> SP_GetProjectWithMaxEmployees(SqlConnection connection)
        {
            /*

create function GetProjectWithMaxEmployees()
returns table
as
return 
SELECT p.Id,p.Title
FROM Projects p 
WHERE p.Id = (
  SELECT pe.ProjectId
  FROM ProjectEmployees pe GROUP BY pe.ProjectId
  HAVING count(pe.ProjectId)=
      (
  SELECT MAX(g.cnt)
  FROM (SELECT COUNT(ppe.ProjectId) cnt 
  FROM ProjectEmployees ppe 
  GROUP BY ppe.ProjectId) g
  )
  )
GO
       */
            List<MyData_GetProjectWithMaxEmployees> collection = new List<MyData_GetProjectWithMaxEmployees>();

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
                        "select * from GetProjectWithMaxEmployees()";

                    sqlCommand.CommandType = CommandType.Text;

                    // Объект, который читает информацию из результатов запроса
                    SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                    // Прочитать одну строку из результатов запроса
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            MyData_GetProjectWithMaxEmployees project =
                                new MyData_GetProjectWithMaxEmployees
                                {
                                    Id = (int)dr["Id"],
                                    Title = (string)dr["Title"],
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
    }
}
