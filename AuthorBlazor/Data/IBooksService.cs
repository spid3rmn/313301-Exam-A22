using ModelsLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthorBlazor.Data
{
    public interface IBooksService
    {
        Task<IList<Book>> GetBooksAsync();    //GET
        Task<Book> AddBookAsync(Book book);    //POST
        Task<Book> DeleteBookAsync(int id);    //DELETE
    }
}
