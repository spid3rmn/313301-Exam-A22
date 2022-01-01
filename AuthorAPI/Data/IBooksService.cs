using ModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorAPI.Data
{
    public interface IBooksService
    {
        Task<IList<Book>> GetBooksAsync();    //GET
        Task<Book> AddBookAsync(Book book);    //POST
        Task<Book> DeleteBookAsync(int id);    //DELETE
    }
}
