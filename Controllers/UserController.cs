using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WindowsAuth.Interfaces;
using WindowsAuth.Models;
using WindowsAuth.ViewModels;

namespace WindowsAuth.Controllers
{
    [Authorize]
    [Route("User")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IAuthorizationService _authorizationService; // inject authorization service to access policies in action methods - see check method  

        public UserController(ILogger<UserController> logger, IUserRepository userRepository, IAuthorizationService authorizationService)
        {
            _logger = logger;
            _userRepository = userRepository;
            _authorizationService = authorizationService;
        }
        //--

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("Manage")]
        public IActionResult Manage()
        {
            var viewModel = new HomeIndexVm();
            viewModel.Users = _userRepository.GetAll();
                                 
            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("Check")]
        public async Task<IActionResult> Check()
        {            
            var result = await _authorizationService
                .AuthorizeAsync(User, "IsOlderThan");

            if (result.Succeeded) 
            {
                return Content("You are older than 38.");
            }
            return Content("You do not have access.");
        }
        //------------------------------------------------
        //------------------------------------------------
        //
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}