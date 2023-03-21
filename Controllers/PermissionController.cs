using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WindowsAuth.Interfaces;
using WindowsAuth.ViewModels;

namespace WindowsAuth.Controllers
{
    [Authorize]
    [Route("Permission")]
    public class PermissionController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserPermissionRepository _userPermissionRepository;

        public PermissionController(IUserRepository userRepository, IUserPermissionRepository userPermissionRepository)
        {
            _userRepository = userRepository;
            _userPermissionRepository = userPermissionRepository;
        }
        //--

        [HttpGet]
        [Route("Manage/{UserId}")]
        public IActionResult Manage(int userId)
        {
            var viewModel = new PermissionManageVm();
            viewModel.User = _userRepository.GetById(userId);
            viewModel.UserPermissions = _userPermissionRepository.GetById(userId);

            return View(viewModel);
        }

        [HttpGet]
        [Route("Add/{UserId}")]
        public IActionResult Add(int userId)
        {
            var viewModel = new PermissionAddVm();
            viewModel.User = _userRepository.GetById(userId);
           
            return View(viewModel);
        }
    }
}
