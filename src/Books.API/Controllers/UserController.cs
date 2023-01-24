using Books.Core;
using Books.Core.Entities;
using Books.Repositories;
using Books.Repository.Dto.UserDto;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly BooksDbContext _context;
       
        public UserController(BooksDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get List of all users in db
        /// </summary>
        /// <returns>List of User</returns>
        [HttpGet]
        public List<User> Get()
        {
            return _context.Users.ToList();
        }
    }
}
