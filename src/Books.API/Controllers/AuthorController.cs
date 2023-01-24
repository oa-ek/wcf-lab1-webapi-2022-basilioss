using Books.Repositories.Dto.Authors;
using Books.Repositories.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorRepository authorsRepository;
        public AuthorController(AuthorRepository authorsRepository)
        {
            this.authorsRepository = authorsRepository;
        }
        /// <summary>
        /// Returns list of authors
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<AuthorReadDto>> GetListAsync()
        {
            return await authorsRepository.GetAuthorsAsync();
        }

        /// <summary>
        /// Create author
        /// </summary>
        /// <param name="dto"></param>
        [HttpPost]
        public async Task<int> AddAuthor(AuthorCreateUpdateDto dto)
        {
            return await authorsRepository.AddAuthor(dto);
        }

        /// <summary>
        /// Update author
        /// </summary>
        /// <param name="id"></param>
        [HttpPut("{id}")]
        public async Task<int> EditActor(AuthorReadDto author)
        {
            return await authorsRepository.UpdateAuthor(author);
        }

        /// <summary>
        /// Delete author by id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await authorsRepository.DeleteAuthor(id);
        }

    }
}
