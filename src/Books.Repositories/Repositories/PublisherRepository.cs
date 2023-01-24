using AutoMapper;
using Books.Core;
using Books.Core.Entities;
using Books.Repositories.Dto.Publihers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Repositories.Repositories
{

	public class PublisherRepository
	{
		private readonly BooksDbContext _ctx;
        private readonly IMapper _mapper;
        public PublisherRepository(BooksDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        //GET ALL
        public async Task<IEnumerable<PublishersReadDto>> GetPublishersAsync()
        {
            return _mapper.Map<IEnumerable<PublishersReadDto>>(await _ctx.Publishers.ToListAsync());
        }

        //CREATE
        public async Task<int> AddPublisher(PublishersCreateUpdateDto publisher)
        {
            var data = await _ctx.Publishers.AddAsync(_mapper.Map<Publisher>(publisher));
            await _ctx.SaveChangesAsync();
            return data.Entity.Id;
        }

        //EDIT
        public async Task<int> UpdatePublisher(PublishersReadDto newPublisher)
        {
            var publisherInDB = _ctx.Publishers.FirstOrDefault(x => x.Id == newPublisher.Id);
            publisherInDB.Name = newPublisher.Name;
            await _ctx.SaveChangesAsync();

            var data = _mapper.Map<PublishersReadDto>(publisherInDB);
            return data.Id;
        }

        //DELETE
        public async Task DeletePublisher(int id)
        {
            _ctx.Publishers.Remove(_ctx.Publishers.Find(id));
            await _ctx.SaveChangesAsync();
        }
    }
}
