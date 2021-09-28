using BookApiModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApiData
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<BookContext>();
            if (!context.Books.Any())
            {
                context.Books.AddRange(new Book()
                {
                    Title = "1st Book Title",
                    Description = "1st Book Description",
                    Genre = "1st Book Genre",
                    IsRead = true,
                    DateRead = DateTime.Now.AddDays(-5),
                    Rating = 8,
                    CoverUrl = "Https...",
                    DateAdded = DateTime.Now
                },
                new Book()
                {
                    Title = "2nd Book Title",
                    Description = "2nd Book Description",
                    Genre = "2nd Book Genre",
                    IsRead = false,
                    CoverUrl = "Https...",
                    DateAdded = DateTime.Now
                });
            }
            context.SaveChanges();
        }
    }
}
