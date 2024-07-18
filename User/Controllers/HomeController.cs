using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using User.Data.Repository;
using User.Models;
using User.ViewModels;

namespace User.Controllers
{
    // [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IRepository _repo;
        private readonly UserManager<Account> _userManager;

        public HomeController(ILogger<HomeController> logger, IRepository repo, UserManager<Account> userManager)
        {
            _logger = logger;
            _repo = repo;
            _userManager = userManager;
        }

        public IActionResult Index(string category, string search)
         {
            var currentUserId = _userManager.GetUserId(User); // current logged in user
            ViewData["currentUserId"] = currentUserId;
            var postsOfTheCurrentUser = _repo.GetPostsOfTheCurrentUser(currentUserId); // retrieve all posts written by the current logged in user.
            var posts = _repo.GetAllPosts(category, search);
            
                return View(posts);
         }

        public IActionResult Post(int id) => View(_repo.GetPost(id));


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
