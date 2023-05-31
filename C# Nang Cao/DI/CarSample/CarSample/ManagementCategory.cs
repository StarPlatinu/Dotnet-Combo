using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSample
{

    public record Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }



     
    }
    public class ManagementCategory
    {
        SqlConnection connection;
        SqlCommand command;

        string ConnectionString = "server=(local);database=MyStore;user id=sa;password=sa;Encrypt=True;TrustServerCertificate=Yes;TrustServerCertificate=True";

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            connection = new SqlConnection(ConnectionString);
            string SQL = "select CategoryID,CategoryName from Categories";
            command = new SqlCommand(SQL, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if(reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        categories.Add(new Category
                        {
                            CategoryID = reader.GetInt32("CategoryID"),
                            CategoryName = reader.GetString("CategoryName")
                        });
                    }
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }finally { connection.Close(); }

            return categories;
        }

        public void Insert(Category category)
        {
            connection = new SqlConnection(ConnectionString);
            string sql = "Insert Categories values (@CategoryName)";
            command = new SqlCommand(sql,connection);
            command.Parameters.AddWithValue("CategoryName", category.CategoryName);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { connection.Close(); }
        }

        public void Update(Category category)
        {
            connection = new SqlConnection(ConnectionString);
            string Sql = "Update Categories  set CategoryName = @CategoryName where CategoryID = @CategoryID";
            command = new SqlCommand (Sql,connection);
            command.Parameters.AddWithValue ("@CategoryName", category.CategoryName);
            command.Parameters.AddWithValue("@CategoryID", category.CategoryID);
            try {
                connection.Open();
                command.ExecuteNonQuery();

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection?.Close();    
            }
        }

    }
}
