using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Books.Core;
using Books.Core.Entities;
using Books.Repositories.Dto.Books;
using Microsoft.EntityFrameworkCore;

namespace Books.Repositories.Repositories
{
    public class BookRepository
    {
        private readonly BooksDbContext _ctx;
        private readonly IMapper _mapper;
        public BookRepository(BooksDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        //GET ALL
        public async Task<IEnumerable<BooksReadDto>> GetBooksAsync()
        {
            return _mapper.Map<IEnumerable<BooksReadDto>>(await _ctx.Books.ToListAsync());
        }
        //CREATE
        public async Task<int> AddBook(BooksCreateUpdateDto book)
        {
            var data = await _ctx.Books.AddAsync(_mapper.Map<Book>(book));
            await _ctx.SaveChangesAsync();
            return data.Entity.Id;
        }

        //EDIT
        public async Task<int> UpdateBook(BooksReadDto newBook)
        {
            var bookInDB = _ctx.Books.FirstOrDefault(x => x.Id == newBook.Id);
            bookInDB.Title = newBook.Title;
            bookInDB.Description = newBook.Description;
            bookInDB.IconPath = newBook.IconPath;
            bookInDB.Rating = newBook.Rating;
            bookInDB.PublishDate = newBook.PublishDate;
            bookInDB.PageCount = newBook.PageCount;
            await _ctx.SaveChangesAsync();

            var data = _mapper.Map<BooksReadDto>(bookInDB);
            return data.Id;
        }

        //DELETE
        public async Task DeleteBook(int id)
        {
            _ctx.Books.Remove(_ctx.Books.Find(id));
            _ctx.SaveChanges();
        }
    }
}
