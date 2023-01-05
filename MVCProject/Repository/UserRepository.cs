using Microsoft.EntityFrameworkCore;
using MVCProject.Interfaces;
using MVCProject.Models;

namespace MVCProject.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(ApplicationUser user)
        {
            _context.Add(user);
            return Save();
        }

        public bool Delete(ApplicationUser user)
        {
            _context.Remove(user);
            return Save();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            return await _context.Users.FirstAsync(x => x.Email == email);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(ApplicationUser user)
        {
            _context.Update(user);
            return Save();
        }
    }
}
