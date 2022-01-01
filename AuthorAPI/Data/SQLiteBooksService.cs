using AuthorAPI.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorAPI.Data
{
    public class SQLiteBooksService : IBooksService
    {
        private readonly MyContext ctx;

        public SQLiteBooksService(MyContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            EntityEntry<Book> newlyAdded = await ctx.Books.AddAsync(book);
            await ctx.SaveChangesAsync();
            return newlyAdded.Entity;
        }

        public async Task<Book> DeleteBookAsync(int isbn)
        {
            Book toDelete = await ctx.Books.FirstOrDefaultAsync(b => b.ISBN == isbn);
            if (toDelete != null)
            {
                ctx.Books.Remove(toDelete);
                await ctx.SaveChangesAsync();
            }

            return toDelete;
        }

        public async Task<IList<Book>> GetBooksAsync()
        {
            return await ctx.Books.ToListAsync();
        }
    }
}
