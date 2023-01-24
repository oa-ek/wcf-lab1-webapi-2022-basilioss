using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Repositories.Dto.Books
{
    public class BooksCreateUpdateDto
    {
        public string? Title { get; set; }
        //public int PublisherId { get; set; }
        public string? Description { get; set; }
        //public int[]? Genres { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public string? IconPath { get; set; }
        public float? Rating { get; set; }
    }
}
