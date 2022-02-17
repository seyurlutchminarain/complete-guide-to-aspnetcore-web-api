using System.Collections.Generic;

namespace my_books.Data.ViewModels
{
    public class AuthorVM
    {
        public string FullName { get; set; }

    }

    public class AuthorWithBooksVM // We have to create seperate classes like these if we want to access data that this table is related to
    {                               // i.e. Here we want to access all the books that an author has written (They are Seperate Tables)
        public string FullName { get; set; }

        public List<string> BookTitles { get; set; }
    }
}
