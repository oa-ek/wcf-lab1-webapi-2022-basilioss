using Books.Repositories.Dto.Genres;
using Books.Repositories.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : Controller
    {
        private readonly GenreRepository genresRepository;
        public GenresController(GenreRepository genresRepository)
        {
            this.genresRepository = genresRepository;
        }

        /// <summary>
        /// Return list of genres
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<GenresReadDto>> GetListAsync()
        {
            return await genresRepository.GetGenresAsync();
        }

        /// <summary>
        /// Create genre
        /// </summary>
        /// <param name="dto"></param>
        [HttpPost]
        public async Task<int> AddGenre(GenresCreateUpdateDto dto)
        {
            return await genresRepository.AddGenre(dto);
        }

        /// <summary>
        /// Update genre
        /// </summary>
        /// <param name="id"></param>
        [HttpPut("{id}")]
        public async Task<int> EditActor(GenresReadDto genre)
        {
            return await genresRepository.UpdateGenre(genre);
        }

        /// <summary>
        /// Delete genre by id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await genresRepository.DeleteGenre(id);
        }
    }
}
