using MVCProject.Models;

namespace MVCProject.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAllUsers();
        Task<ApplicationUser> GetUserByEmail(string id);
        bool Add(ApplicationUser user);
        bool Update(ApplicationUser user);
        bool Delete(ApplicationUser user);
        bool Save();
    }
}
