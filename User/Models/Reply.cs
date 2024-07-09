namespace User.Models
{
    public class Reply : Comment
    {
        public int MainCommentId { get; set; }
    }
}
