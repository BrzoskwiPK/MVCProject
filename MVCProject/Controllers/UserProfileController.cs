using Microsoft.AspNetCore.Mvc;
using MVCProject.Interfaces;
using MVCProject.ViewModels;

namespace MVCProject.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserProfileController(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            string currentUserEmail = _httpContextAccessor.HttpContext.User.Identity.Name;
            var userEntity = await _userService.GetUserByEmail(currentUserEmail);

            var userViewModel = new UserViewModel()
            {
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                DateOfBirth = userEntity.DateOfBirth,
                EmailAddress = userEntity.Email,
                Gender = userEntity.Gender,
            };

            return View(userViewModel);
        }
    }
}
