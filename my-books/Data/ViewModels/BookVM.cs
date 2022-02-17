using System;
using System.Collections.Generic;

namespace my_books.Data.ViewModels
{
    public class BookVM
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsRead { get; set; }

        public DateTime? DateRead { get; set; } // The "?" after type DateTime refers to the property being optional!

        public int? Rate { get; set; }

        public string Genre { get; set; }

        public string CoverUrl { get; set; }

        public int PublisherId { get; set; }

        public List<int> AuthorId { get; set; } // We use a list since a book can have multiple authors
    }
}
