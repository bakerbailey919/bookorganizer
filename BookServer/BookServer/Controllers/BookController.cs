using System.Collections.Generic;
using BookServer.DAO;
using BookServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookServer.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    public class BookController : ControllerBase
    {
        private IBookDAO bookDAO;

        public BookController(IBookDAO bookDAO)
        {
            this.bookDAO = bookDAO;
        }

        [HttpGet("{bookId}")]
        public List<Book> GetBooksByBookId(int bookId)
        {
            List<Book> books = bookDAO.GetBooksByBookId(bookId);
            return books;
        }

        [HttpPost]
        public ActionResult AddBook (Book book)
        {
            bool result = bookDAO.AddBook(book);

            if (result)
            {
                return Created("", book);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
