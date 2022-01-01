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
    public class SQLiteAuthorsService : IAuthorsService
    {
        private readonly MyContext ctx;

        public SQLiteAuthorsService(MyContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            EntityEntry<Author> newlyAdded = await ctx.Authors.AddAsync(author);
            await ctx.SaveChangesAsync();
            return newlyAdded.Entity;
        }

        public async Task<IList<Author>> GetAuthorsAsync()
        {
            return await ctx.Authors.ToListAsync();
        }
    }
}
