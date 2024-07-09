using User.Models;

namespace User.Data.Repository
{
    public interface IRepository
    {
        Post GetPost(int id);
        List<Post> GetAllPosts();
        public IndexViewModel GetAllPosts(string category, string search);
        void AddPost(Post post);
        void UpdatePost(Post post);
        void RemovePost(int id);
        Task<bool> SaveChangesAsync();

        void AddReply(Reply comment);
    }
}
