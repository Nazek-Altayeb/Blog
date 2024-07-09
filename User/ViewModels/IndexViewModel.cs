namespace User.Models
{
    public class IndexViewModel
    {
        public string Category { get; set; }
        public string Search { get; set; }
        public IEnumerable<Post> Posts { get; set; }

    }
}
