using System.Collections.Generic;
using BookServer.Models;

namespace BookServer.DAO
{
        public interface IBookDAO
        {
            List<Book> GetBooksByBookId(int bookId);

        bool AddBook(Book book);
        }
    }

