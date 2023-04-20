using BookAuthorApp.Models.Entities;

namespace BookAuthorApp.Models.ViewModels
{
    public class CreateBookVM
    {
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public Book GetBookInstance() {
            
            return new Book {
                Id = 0,
                Title = this.Title, 
                PublicationYear = this.PublicationYear
            };
        }
    }
}
