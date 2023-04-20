using System.ComponentModel.DataAnnotations;

namespace BookAuthorApp.Models.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [StringLength(128)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(128)]
        public string LastName { get; set; } = String.Empty;

        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}
