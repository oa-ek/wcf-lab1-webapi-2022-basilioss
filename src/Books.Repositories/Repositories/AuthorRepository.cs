using AutoMapper;
using Books.Core;
using Books.Core.Entities;
using Books.Repositories.Dto.Authors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Repositories.Repositories
{
    public class AuthorRepository
    {
        private readonly BooksDbContext _ctx;
        private readonly IMapper _mapper;

        public AuthorRepository(BooksDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        // GET ALL
        public async Task<IEnumerable<AuthorReadDto>> GetAuthorsAsync()
        {
            return _mapper.Map<IEnumerable<AuthorReadDto>>(await _ctx.Authors.ToListAsync());
        }

        //CREATE
        public async Task<int> AddAuthor(AuthorCreateUpdateDto author)
        {
            var data = await _ctx.Authors.AddAsync(_mapper.Map<Author>(author));
            await _ctx.SaveChangesAsync();
            return data.Entity.Id;
        }

        //EDIT
        public async Task<int> UpdateAuthor(AuthorReadDto newAuthor)
        {
            var authorInDB = _ctx.Authors.FirstOrDefault(x => x.Id == newAuthor.Id);
            authorInDB.Name = newAuthor.Name;
            await _ctx.SaveChangesAsync();

            var data = _mapper.Map<AuthorReadDto>(authorInDB);
            return data.Id;
        }

        //DELETE
        public async Task DeleteAuthor(int id)
        {
            _ctx.Authors.Remove(_ctx.Authors.Find(id));
            _ctx.SaveChanges();
        }
    }
}
