using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BookRepository : IBookRepository
    {
        private const string ConnectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=\"LibraryDB \";";

        [Obsolete]
        public List<Book> GetAllBooks()
        {
            List<Book> list = new List<Book>();
            using(SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM Books";
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book();
                    book.Id = reader.GetInt32(0);
                    book.Title = reader.GetString(1);
                    book.Description = reader.GetString(2);
                    book.NumberOfPage = reader.GetInt32(3);
                    list.Add(book);
                }
            }
            return list;
        }

        [Obsolete]
        public bool InsertBook(Book book)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "INSERT INTO Books(Title,Description,NumberOfPages) VALUES(@Title,@Description,@NumberOfPages)";
                sqlCommand.Parameters.AddWithValue("@Title", book.Title);
                sqlCommand.Parameters.AddWithValue("@Description", book.Description);
                sqlCommand.Parameters.AddWithValue("@NumberOfPages", book.NumberOfPage);
                // sqlCommand.Parameters.AddWithValue("@VolumeInMl", (object?)perfume.VolumeInMl ?? DBNull.Value);  AKO JE NULL
                int result = sqlCommand.ExecuteNonQuery();
                return result > 0;
            }
        }

       [Obsolete]
        public bool DeleteCar(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "DELETE FROM Cars WHERE Id = @Id";
                sqlCommand.Parameters.AddWithValue("@Id", id);
                int result = sqlCommand.ExecuteNonQuery();
                return result > 0;
            }
        } 

       [Obsolete]
        public Car? GetCarById(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Cars WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Car car = new Car();
                    car.Id = reader.GetInt32(0);
                    car.Title = reader.GetString(1);
                    car.Year = reader.IsDBNull(2) ? null : reader.GetInt32(2);
                    car.Price = reader.GetDecimal(3);
                    return car;
                }
            }
            return null;
        }

       [Obsolete]
        public bool UpdateCar(Car car)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Cars SET Title=@Title, Year=@Year, Price=@Price WHERE Id=@Id";
                cmd.Parameters.AddWithValue("@Title", car.Title);
                cmd.Parameters.AddWithValue("@Year", (object?)car.Year ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Price", car.Price);
                cmd.Parameters.AddWithValue("@Id", car.Id);
                return cmd.ExecuteNonQuery() > 0;
            }
        } 
    }
}
