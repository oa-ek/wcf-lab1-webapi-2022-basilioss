using Books.Core.Entities;
using Books.Repositories.Dto.Genres;
using Books.Repositories.Dto.Publihers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Repositories.Dto.Books
{
    public class BooksReadDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        //public PublishersReadDto? Publisher { get; set; }
        public string? Description { get; set; }
        //public ICollection<GenresReadDto>? Genres { get; set; } = new List<GenresReadDto>();
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public string? IconPath { get; set; }
        public float? Rating { get; set; }
    }
}
