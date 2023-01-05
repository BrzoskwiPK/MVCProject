using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Interfaces;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserProfileController(IUserRepository userRepository, UserManager<ApplicationUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            string actualUserEmail = new HttpContextAccessor().HttpContext.User.Identity.Name;
            var userEntity = await _userRepository.GetUserByEmail(actualUserEmail);

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

        public async Task<IActionResult> EditUser()
        {
            string actualUserEmail = new HttpContextAccessor().HttpContext.User.Identity.Name;
            var userEntity = await _userRepository.GetUserByEmail(actualUserEmail);

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

        [HttpPost]
        public async Task<IActionResult> EditUser(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Those fields are required!";
                return View(userViewModel);
            }

            var updatedUser = new ApplicationUser()
            {
                FirstName = userViewModel.FirstName,
                LastName = userViewModel.LastName,
                Email = userViewModel.EmailAddress,
                DateOfBirth = (DateTime)userViewModel.DateOfBirth,
                Gender = userViewModel.Gender
            };

            var updatedUserResponse = await _userManager.UpdateAsync(updatedUser);

            if (updatedUserResponse.Succeeded) return RedirectToAction("Index", "UserProfile");

            TempData["Error"] = "Oops! User update gone wrong!";
            return View(userViewModel);
        }
    }
}
