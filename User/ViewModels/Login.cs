using System.ComponentModel.DataAnnotations;

namespace User.ViewModels
{
    public class Login
    {
        [Required(ErrorMessage ="User name is requied")]
        public string? Username { get; set; }

        [Required(ErrorMessage ="Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
