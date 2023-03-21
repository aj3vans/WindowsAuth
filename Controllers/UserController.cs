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

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;   
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
        //------------------------------------------------
        //
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}