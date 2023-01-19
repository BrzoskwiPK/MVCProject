using MVCProject.Models;

namespace MVCProject.Interfaces
{
    public interface IUserService
    {
        public Task<List<ApplicationUser>> GetAllUsers();
        public Task<ApplicationUser?> GetUserByEmail(string email);
        public bool Add(ApplicationUser user);
        public bool Delete(ApplicationUser user);
        public bool Save();
    }
}
