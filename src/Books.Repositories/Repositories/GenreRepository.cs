using AutoMapper;
using Books.Core;
using Books.Core.Entities;
using Books.Repositories.Dto.Genres;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Repositories.Repositories
{
    public class GenreRepository
    {
        private readonly BooksDbContext _ctx;
        private readonly IMapper _mapper;
        public GenreRepository(BooksDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        //GET ALL
        public async Task<IEnumerable<GenresReadDto>> GetGenresAsync()
        {
            return _mapper.Map<IEnumerable<GenresReadDto>>(await _ctx.Genres.ToListAsync());
        }

        //CREATE
        public async Task<int> AddGenre(GenresCreateUpdateDto genre)
        {
            var data = await _ctx.Genres.AddAsync(_mapper.Map<Genre>(genre));
            await _ctx.SaveChangesAsync();
            return data.Entity.Id;
        }

        //EDIT
        public async Task<int> UpdateGenre(GenresReadDto newGenre)
        {
            var genreInDB = _ctx.Genres.FirstOrDefault(x => x.Id == newGenre.Id);
            genreInDB.GenreName = newGenre.GenreName;
            await _ctx.SaveChangesAsync();

            var data = _mapper.Map<GenresReadDto>(genreInDB);
            return data.Id;
        }

        //DELETE
        public async Task DeleteGenre(int id)
        {
            _ctx.Genres.Remove(_ctx.Genres.Find(id));
            await _ctx.SaveChangesAsync();
        }
    }
}
