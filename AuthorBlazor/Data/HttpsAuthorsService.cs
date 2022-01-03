using AuthorBlazor.Data;
using ModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AuthorBlazor.Data
{
    public class HttpsAuthorsService : IAuthorsService
    {
        private readonly HttpClient client;

        public HttpsAuthorsService()
        {
            client = new HttpClient();
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            StringContent content =
                new StringContent(JsonSerializer.Serialize(author), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://localhost:5001/Authors", content);
            response.EnsureSuccessStatusCode();

            return author;
        }

        public async Task<IList<Author>> GetAuthorsAsync()
        {
            HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:5001/Authors");

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();
            List<Author> authors = JsonSerializer.Deserialize<List<Author>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return authors;
        }
    }
}
