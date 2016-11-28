using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZEFPlusUpdateTest.Models;
using Z.EntityFramework.Plus;

namespace ZEFPlusUpdateTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        public static async Task MainAsync()
        {
            // initialize data
            using (var context = new SampleDbContext())
            {
                await context.Book.DeleteAsync();
                context.Book.Add(new Book { Id = 1, Title = "book1" });
                context.Book.Add(new Book { Id = 2, Title = "book2" });
                context.Book.Add(new Book { Id = 3, Title = "book3" });
                context.Book.Add(new Book { Id = 4, Title = "book4" });
                await context.SaveChangesAsync();
            }

            using (var context = new SampleDbContext())
            {
                var ids = new[] { 1, 4 };
                var books = context.Book.Where(v => ids.Contains(v.Id)).ToArray();
                foreach (var book in books) Console.WriteLine($"Title: {book.Title}");

                // ok
                await context.Book.Where(v => v.Id == 2).DeleteAsync();

                // cause exception
                await context.Book.Where(v => ids.Contains(v.Id)).DeleteAsync();
            }
        }
    }
}