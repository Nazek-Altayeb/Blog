using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using User.Data.Repository;
using User.Models;
using User.ViewModels;
using Post = User.Models.Post;


namespace User.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private IRepository _repo;

        public PostController(IRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var posts = _repo.GetAllPosts();
            return View(posts);
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View(new PostViewModel());
            }
            else
            {
                var post = _repo.GetPost((int)id);
                return View(new PostViewModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    Body = post.Body,
                    Description = post.Description,
                    Category = post.Category,
                    Tags = post.Tags
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel model)
        {
            var post = new Post
            {
                Id = model.Id,
                Title = model.Title,
                Body = model.Body,
                Description = model.Description,
                Category = model.Category,
                Tags = model.Tags,
            };

            
            if (post.Id > 0)
                _repo.UpdatePost(post);
            else
                _repo.AddPost(post);


            if (await _repo.SaveChangesAsync())
                return RedirectToAction("Index");
            else
                return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            _repo.RemovePost(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
