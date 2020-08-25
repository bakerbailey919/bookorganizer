using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BookServer.Models;

namespace BookServer.DAO
{
    public class BookSqlDAO : IBookDAO
    {
        private string connectionString;

        public BookSqlDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public bool AddBook(Book book)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO book VALUES (@bookId, @title, @description, @releaseYear, @pageLength, @rating, @genreId, @authorId, @publisherId);", conn);
                    cmd.Parameters.AddWithValue("@bookId", book.BookId);
                    cmd.Parameters.AddWithValue("@title", book.Title);
                    cmd.Parameters.AddWithValue("@description", book.Description);
                    cmd.Parameters.AddWithValue("@releaseYear", book.ReleaseYear);
                    cmd.Parameters.AddWithValue("@pageLength", book.PageLength);
                    cmd.Parameters.AddWithValue("@rating", book.Rating);
                    cmd.Parameters.AddWithValue("@genreId", book.GenreId);
                    cmd.Parameters.AddWithValue("@authorId", book.AuthorId);
                    cmd.Parameters.AddWithValue("@publisherId", book.PublisherId);

                    int count = cmd.ExecuteNonQuery();

                    if (count == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
        public List<Book> GetBooksByBookId(int bookId)
        {
            List<Book> books = new List<Book>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM book WHERE bookId = @bookId;", conn);

                    cmd.Parameters.AddWithValue("@bookId", bookId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Book book = ConvertReaderToBook(reader);
                        books.Add(book);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred reading books by book id");
                Console.WriteLine(ex.Message);
                throw;
            }

            return books;
        }

        private Book ConvertReaderToBook(SqlDataReader reader)
        {
            Book book = new Book();
            book.BookId = Convert.ToInt32(reader["bookId"]);
            book.Title = Convert.ToString(reader["title"]);
            book.Description = Convert.ToString(reader["description"]);
            book.ReleaseYear = Convert.ToInt32(reader["releaseYear"]);
            book.PageLength = Convert.ToInt32(reader["pageLength"]);
            book.Rating = Convert.ToInt32(reader["rating"]);
            book.GenreId = Convert.ToInt32(reader["genreId"]);
            book.AuthorId = Convert.ToInt32(reader["authorId"]);
            book.PublisherId = Convert.ToInt32(reader["publisherId"]);

            return book;

        }
    }
}

