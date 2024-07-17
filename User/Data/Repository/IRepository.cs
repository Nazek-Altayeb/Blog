using User.Models;

namespace User.Data.Repository
{
    public interface IRepository
    {
        Post GetPost(int id);
        List<Post> GetAllPosts();

        List<Post>? GetPostsOfTheCurrentUser(string accountId);
        string? GetAuthorIdByPostId(int id);
        public IndexViewModel GetAllPosts(string category, string search);
        void AddPost(Post post);
        void UpdatePost(Post post);
        void RemovePost(int id);
        Task<bool> SaveChangesAsync();

        void AddReply(Reply comment);
    }
}
