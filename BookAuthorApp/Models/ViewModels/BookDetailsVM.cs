using BookAuthorApp.Models.Entities;
using NuGet.Packaging.Signing;
using System.ComponentModel;

namespace BookAuthorApp.Models.ViewModels
{
    public class BookDetailsVM
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DisplayName("Publication Year")]
        public int PublicationYear { get; set; }
        [DisplayName("Number of Authors")]
        public int NumberOfAuthors { get; set; }

        public ICollection<Author> Authors { get; set; } = new List<Author>();
    }
}
