using System.ComponentModel.DataAnnotations;

namespace OnlineBookStore.DTOs
{
    public class BookDto
    {
        public int BookId { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public string? ISBN { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
