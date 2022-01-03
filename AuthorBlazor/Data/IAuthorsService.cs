using ModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBlazor.Data
{
    public interface IAuthorsService
    {
        Task<Author> AddAuthorAsync(Author author);    //POST
        Task<IList<Author>> GetAuthorsAsync();    //GET
    }
}
