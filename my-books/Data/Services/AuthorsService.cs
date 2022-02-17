using my_books.Data.Models;
using my_books.Data.ViewModels;
using System.Linq;

namespace my_books.Data.Services
{
    public class AuthorsService
    {
        AppDbContext _context;

        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }
        public void AddAuthor(AuthorVM author) // we pass View Model instead of Model bc the VM will pass fields
        {                                // like BookID, DateRead etc. which we didnt ask the user for. 
            var _author = new Author()
            {
                  FullName = author.FullName,

            };

            _context.Authors.Add(_author);// DB Post 
            _context.SaveChanges(); //DB Save
        }

        public void DeleteAuthorById(int AuthorId) 
        {
            var _author = _context.Authors.FirstOrDefault(n => n.Id == AuthorId); // search for a specific book
            if (_author != null) // if we find this book
            {
                _context.Authors.Remove(_author);
            }

            _context.SaveChanges();
        }

        public AuthorWithBooksVM GetAuthorWithBooks(int authorId)
        {
            var _author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthorWithBooksVM()
            {
                FullName = n.FullName,
                BookTitles = n.Book_Authors.Select(n => n.Book.Title).ToList() // SELECT Book Title WHERE AuthorID = n
            }).FirstOrDefault();

            return _author;
        }
    }
}
