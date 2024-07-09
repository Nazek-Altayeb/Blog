namespace User.Models
{
    public class MainComment : Comment
    {
        public List<Reply> Replies { get; set; }
    }
}
