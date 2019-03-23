using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using HW_ado_1.Entities;

namespace HW_ado_1.Repository
{
    public class LinksRepository
    {
        public void insertLink(Links ln)
        {
            using (SqlConnection sqlConnection = new SqlConnection(GetConnectionString()))
            {
                sqlConnection.Open();
                string sql = $"INSERT INTO URLs VALUES(@shortUrl, @fullUrl,@usCount,@finish_date,@l_description)";

                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    SqlParameter su = new SqlParameter("@shortUrl", ln.shortUrl);
                    SqlParameter fu = new SqlParameter("@fullUrl", ln.fullUrl);
                    SqlParameter uc = new SqlParameter("@usCount", ln.usCount);
                    SqlParameter fd = new SqlParameter("@finish_date", ln.finishDate);
                    SqlParameter ld = new SqlParameter("@l_description", ln.lDescription);

                    sqlCommand.Parameters.Add(su);
                    sqlCommand.Parameters.Add(fu);
                    sqlCommand.Parameters.Add(uc);
                    sqlCommand.Parameters.Add(fd);
                    sqlCommand.Parameters.Add(ld);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
        public List<shortLinks> ReadALL()
        {
            List<shortLinks> ll = new List<shortLinks>();
            string sql = $"SELECT * FROM URLs WHERE us_count>0 AND finish_date>=getdate()";
            using (SqlConnection sqlConnection = new SqlConnection(GetConnectionString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {                    
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {                        
                        while (reader.Read())
                        {
                            shortLinks l = new shortLinks();
                            l.Id = Int32.Parse(reader["id"].ToString());
                            l.lDescription = reader["l_description"].ToString();
                            ll.Add(l);                                                                            
                        }
                    }
                    else throw new Exception("No data found!");
                }
            }
            return ll;
        }
        public string ReadById(int id)
        {
            string shortURL=string.Empty;            
            string sql = $"SELECT * FROM URLs WHERE id=@id";
            using (SqlConnection sqlConnection = new SqlConnection(GetConnectionString()))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    SqlParameter lid = new SqlParameter("@id", id);
                    sqlCommand.Parameters.Add(lid);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            shortURL = reader["short_URL"].ToString();                                                     
                        }
                    }
                    else throw new Exception("No data found!");
                }
            }
            return shortURL;
        }
        public void updateCount(int id)
        {
            string sql = $"UPDATE URLs SET us_count = us_count-1 WHERE id = @id";
            using (SqlConnection sqlConnection = new SqlConnection(GetConnectionString()))
            {
                sqlConnection.Open();                

                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    SqlParameter lid = new SqlParameter("@id", id);
                    sqlCommand.Parameters.Add(lid);                    
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
        public string GetConnectionString()
        {
           var connectionString = ConfigurationManager
                .ConnectionStrings["DefaultConnectionString"]
                .ConnectionString;                

            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("No connection string provided!");

            return connectionString;
        }
    }

}
