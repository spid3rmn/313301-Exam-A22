using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsLibrary
{
    class Book
    {
        public int ISBN { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public int NumOfPages { get; set; }
        public string Genre { get; set; }
        public int AuthorId { get; set; }
    }
}
