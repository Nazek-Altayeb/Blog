using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using User.Data.Repository;
using User.Models;
using User.ViewModels;

namespace User.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IRepository _repo;

        public HomeController(ILogger<HomeController> logger, IRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index(string category, string search)
         {
             var vm = _repo.GetAllPosts(category, search);

             return View(vm);
         }

        //public IActionResult Index()
        //{
        //    var posts = _repo.GetAllPosts();
        //    return View(posts);

        //}

        public IActionResult Post(int id) => View(_repo.GetPost(id));


        [HttpPost]
        public async Task<IActionResult> Comment(CommentViewModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Post", new { id = model.PostId });

            var post = _repo.GetPost(model.PostId);
            if (model.MainCommentId == 0)
            {
                post.MainComments = post.MainComments ?? new List<MainComment>();

                post.MainComments.Add(new MainComment
                {
                    Opinion = model.Opinion,
                    Created = DateTime.Now,
                });

                _repo.UpdatePost(post);
            }
            else
            {
                var reply = new Reply
                {
                    MainCommentId = model.MainCommentId,
                    Opinion = model.Opinion,
                    Created = DateTime.Now,
                };
                _repo.AddReply(reply);
            }

            await _repo.SaveChangesAsync();

            return RedirectToAction("Post", new { id = model.PostId });
        }

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
