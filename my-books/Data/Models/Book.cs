﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// "prop"+Tab+Tab -> shortcut for property creation

namespace my_books.Data.Models
{
    public class Book // This class will describe our schema format
    {
        public int Id { get; set; }

        public string Title { get; set; }   

        public string Description { get; set; }
        
        public bool IsRead { get; set; }

        public DateTime? DateRead { get; set; } // The "?" after type DateTime refers to the property being optional!

        public int? Rate { get; set; }

        public string Genre { get; set; }

        public string Author { get; set; }

        public string CoverUrl { get; set; }

        public DateTime DateAdded { get; set; }




    }
}