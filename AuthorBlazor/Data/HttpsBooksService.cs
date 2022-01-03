using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorBlazor.Data;
using ModelsLibrary;

namespace AuthorBlazor.Data
{
    public class HttpsBooksService : IBooksService
    {
        public Task<Book> AddBookAsync(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<Book> DeleteBookAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Book>> GetBooksAsync()
        {
            throw new NotImplementedException();
        }
    }
}
