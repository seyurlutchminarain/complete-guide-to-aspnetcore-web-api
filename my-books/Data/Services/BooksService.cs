using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace my_books.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context; //DB Context
        }

        public void AddBookWithAuthors(BookVM book) // we pass View Model instead of Model bc the VM will pass fields
        {                                // like BookID, DateRead etc. which we didnt ask the user for. 
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null, // if book is read then use DateRead else use NULL
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId,

            };

            _context.Books.Add(_book);// DB Post 
            _context.SaveChanges(); //DB Save

            foreach (var id in book.AuthorId) // Creating the book author relationship after adding
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id,
                };

                _context.Books_Authors.Add(_book_author);
                _context.SaveChanges();
            }
        }

        public List<Book> GetAllBooks() => _context.Books.ToList(); // Store all the books as a list.

        public BookWithAuthorsVM GetBookById(int bookID) // retrieve a single book from DB
        {
            var _bookWithAuthors = _context.Books.Where(n => n.Id == bookID).Select(book => new BookWithAuthorsVM()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null, // if book is read then use DateRead else use NULL
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publisher.Name,
                AuthorNames = book.Book_Authors.Select(n => n.Author.FullName).ToList() // Getting the author names using the relationship created previously 

            }).FirstOrDefault(); // We use FirstOrDefault in case the book cant be found, in this case we will return NULL

            return _bookWithAuthors;
        }

        public Book UpdateBookById(int bookId, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId); // search for a specific book
            if (_book != null) // if we find this book
            {
                // we update the book
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null; // if book is read then use DateRead else use NULL
                _book.Rate = book.IsRead ? book.Rate.Value : null;
                _book.Genre = book.Genre;
                _book.CoverUrl = book.CoverUrl;

                _context.SaveChanges();
            }

            return _book;
        }
        public void DeleteBookById(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId); // search for a specific book
            if (_book != null) // if we find this book
            {
                _context.Books.Remove(_book);
            }

            _context.SaveChanges();
        }
    }


}
