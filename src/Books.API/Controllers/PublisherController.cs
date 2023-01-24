using Books.Repositories.Dto.Publihers;
using Books.Repositories.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly PublisherRepository publishersRepository;
        public PublishersController(PublisherRepository publishersRepository)
        {
            this.publishersRepository = publishersRepository;
        }

        /// <summary>
        /// Returns list of publishers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<PublishersReadDto>> GetListAsync()
        {
            return await publishersRepository.GetPublishersAsync();
        }

        /// <summary>
        /// Create publisher
        /// </summary>
        /// /// <param name="dto"></param>
        [HttpPost]
        public async Task<int> AddPublisher(PublishersCreateUpdateDto dto)
        {
            return await publishersRepository.AddPublisher(dto);
        }

        /// <summary>
        /// Update publisher
        /// </summary>
        /// <param name="id"></param>
        [HttpPut("{id}")]
        public async Task<int> EditPublisher(PublishersReadDto author)
        {
            return await publishersRepository.UpdatePublisher(author);
        }

        /// <summary>
        /// Delete publisher by id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await publishersRepository.DeletePublisher(id);
        }
    }
}
