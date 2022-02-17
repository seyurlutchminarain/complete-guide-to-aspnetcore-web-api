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
    }
}
