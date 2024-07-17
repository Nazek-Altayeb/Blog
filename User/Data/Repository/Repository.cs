using Microsoft.EntityFrameworkCore;
using User.Models;

namespace User.Data.Repository
{
    public class Repository : IRepository
    {
        private AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public void AddPost(Post post)
        {
            _context.Posts.Add(post);
        }

        public List<Post>? GetAllPosts()
        {
            return _context.Posts.ToList();
        }

        public List<Post>? GetPostsOfTheCurrentUser(string accountId)
        {
            return _context.Posts.Where(acc => acc.AccountId == accountId).ToList();

        }

        public IndexViewModel GetAllPosts(
           string category,
           string search)
        {
            Func<Post, bool> InCategory = (post) => { return post.Category.ToLower().Equals(category.ToLower()); };

            int pageSize = 5;

            var query = _context.Posts.AsNoTracking().AsQueryable();

            if (!String.IsNullOrEmpty(category))
                query = query.Where(x => InCategory(x));

            if (!String.IsNullOrEmpty(search))
                query = query.Where(x => EF.Functions.Like(x.Title, $"%{search}%")
                                    || EF.Functions.Like(x.Body, $"%{search}%")
                                    || EF.Functions.Like(x.Description, $"%{search}%"));

            int postsCount = query.Count();
            int pageCount = (int)Math.Ceiling((double)postsCount / pageSize);

            return new IndexViewModel
            {
                Category = category,
                Search = search,
                Posts = query.ToList()
            };
        }

        public Post GetPost(int id)
        {
          var result =  _context.Posts
                .Include(p => p.MainComments)
                    .ThenInclude(mc => mc.Replies)
                .FirstOrDefault(p => p.Id == id);

            return result;
        }

        public string? GetAuthorIdByPostId(int id)
        {
            return _context.Posts
                .Include(acc => acc.AccountId)
                .FirstOrDefault(p => p.Id == id).ToString();
        }

    
        public void RemovePost(int id)
        {
             _context.Posts.Remove(GetPost(id));
        }

        public void UpdatePost(Post post)
        {
            _context.Posts.Update(post);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public void AddReply(Reply reply)
        {
            _context.Replies.Add(reply);
        }
    }
}
