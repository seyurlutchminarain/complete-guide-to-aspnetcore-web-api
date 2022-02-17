using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Models;
using System;
using System.Linq;

namespace my_books.Data
{
    public class AppDbInitializer // This class will be used to intiliaze our DB
    {
        public static void Seed(IApplicationBuilder applicationBuilder) //create method for seeding info within the DB
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) // used to build a context to insert into DB
            { 
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>(); // getting the context

                if (!context.Books.Any()) // If there are no books in the DB?
                { 
                    context.Books.AddRange(new Book() // Add Books...AddRange allows us to add multiple records
                    { 
                        Title = "1st Book Title",
                        Description = "1st Book Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        CoverUrl = "https...",
                        DateAdded = DateTime.Now,

                    },
                    new Book()
                    {
                        Title = "2nd Book Title",
                        Description = "2nd Book Description",
                        IsRead = false,
                        Genre = "Biography",
                        CoverUrl = "https...",
                        DateAdded = DateTime.Now,

                    });

                    context.SaveChanges(); // Save/Post to the DB once insert is complete.
                }
            }
        }
    }
}
