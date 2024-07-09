using System.ComponentModel.DataAnnotations;

namespace User.ViewModels
{
    public class CommentViewModel
    {
        [Required]
        public int PostId { get; set; }
        
        [Required]
        public int MainCommentId { get; set; }
       
        [Required]
        public string Opinion { get; set; }
    }
}
