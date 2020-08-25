namespace BookServer.Models
{
    public class Book
    {
       public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public int PageLength { get; set; }
        public int Rating { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        }
    }
