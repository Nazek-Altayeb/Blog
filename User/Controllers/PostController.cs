using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<Account> _userManager;

        public PostController(IRepository repo, UserManager<Account> userManager)
        {
            _repo = repo;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var currentUserId = _userManager.GetUserId(User); // current logged in user
            ViewData["currentUserId"] = currentUserId;
            var postsOfTheCurrentUser = _repo.GetPostsOfTheCurrentUser(currentUserId); // retrieve all posts written by the current logged in user.
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
            var userId = _userManager.GetUserId(User);
            // var authorId = _repo.GetAuthorIdByPostId(id)
            if (id == null)
            {
                return View(new PostViewModel());
            }
            else
            {
                var post = _repo.GetPost((int)id);
                return View(new PostViewModel
                {
                    //Id = post.Id,
                    // AccountId = userId,
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
            var postAuthorId = _userManager.GetUserId(User); // Post-auther Id
            ViewData["postAuthorId"] = postAuthorId;
            var post = new Post
            {
                //Id = model.Id,
                AccountId = postAuthorId,
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
