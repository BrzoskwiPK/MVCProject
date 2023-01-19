using Microsoft.EntityFrameworkCore;
using MVCProject.Interfaces;
using MVCProject.Models;

namespace MVCProject.service
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(ApplicationUser user)
        {
            _context.Users.Add(user);
            return Save();
        }

        public bool Delete(ApplicationUser user)
        {
            _context.Users.Remove(user);
            return Save();
        }

        public async Task<List<ApplicationUser>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<ApplicationUser> GetUserByEmail(string email) => await _context.Users.Where(u => u.Email == email).AsNoTracking().FirstOrDefaultAsync();

        public bool Save()
        {
            var saved = _context.SaveChangesAsync();
            return saved.IsCompletedSuccessfully;
        }
    }
}
