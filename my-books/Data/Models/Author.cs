using System.Collections.Generic;

namespace my_books.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        // Navigation Properties [MANY-TO-MANY relationship -> we need a join model Book_Author]
        // In essence we split the M-M relationship into 2 1-M relationships
        public List<Book_Author> Book_Authors { get; set; }
    }
}
