using Books.Repositories.Dto.Books;
using Books.Repositories.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookRepository bookRepository;
        public BookController(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        /// <summary>
        /// Returns list of books
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<BooksReadDto>> GetListAsync()
        {
            return await bookRepository.GetBooksAsync();
        }

        /// <summary>
        /// Create book
        /// </summary>
        /// /// <param name="dto"></param>
        [HttpPost]
        public async Task<int> AddBook(BooksCreateUpdateDto dto)
        {
            return await bookRepository.AddBook(dto);
        }

        /// <summary>
        /// Update book
        /// </summary>
        /// <param name="id"></param>
        [HttpPut("{id}")]
        public async Task<int> EditBook(BooksReadDto book)
        {
            return await bookRepository.UpdateBook(book);
        }

        /// <summary>
        /// Delete book by id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await bookRepository.DeleteBook(id);
        }
    }
}
