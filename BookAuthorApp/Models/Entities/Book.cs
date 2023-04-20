using System.ComponentModel.DataAnnotations;

namespace BookAuthorApp.Models.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Title { get; set; } = String.Empty;

        public int PublicationYear { get; set; }
        public List<Author> Authors { get; set; } = new List<Author>();
    }
}
