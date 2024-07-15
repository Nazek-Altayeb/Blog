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
                    AccountId = post.AccountId,
                    Title = post.Title,
                    Body = post.Body,
                    Description = post.Description,
                    Category = post.Category,
                    Tags = post.Tags,
                    
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel model)
        {
            var post = new Post
            {
                Id = model.Id,
                AccountId = model.AccountId,
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
