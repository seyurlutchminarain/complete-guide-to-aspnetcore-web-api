using my_books.Data.Models;
using my_books.Data.ViewModels;
using System.Linq;

namespace my_books.Data.Services
{
    //REMEMBER TO ADD THE SERVICES IN THE STARTUP FILE

    public class PublishersService
    {
        AppDbContext _context;

        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public void addPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name,
            };

            _context.Publishers.Add(_publisher); 
            _context.SaveChanges();
        }
        public void DeletePublisherById(int PublisherId)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.id == PublisherId); // search for a specific book
            if (_publisher != null) // if we find this book
            {
                _context.Publishers.Remove(_publisher);
            }

            _context.SaveChanges();
        }

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.id == publisherId).Select(n => new PublisherWithBooksAndAuthorsVM() // Look for specific publisher Id
            {                                                                                               // Then Create PublisherWithBooksAndAuthors object using this id
                Name = n.Name, // inherit publisher name
                BookAuthors = n.Books.Select(n => new BookAuthorVM() // create new BookAuthor object
                { 
                    BookName =  n.Title, // inherit book title
                    Authors = n.Book_Authors.Select(n => n.Author.FullName).ToList() // return list of others
                }).ToList() // return whole list of objects
            }).FirstOrDefault();

            return _publisherData;
        }
    }
}
