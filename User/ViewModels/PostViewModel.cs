namespace User.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public string Title { get; set; } = "";
        public string Body { get; set; } = "";


        public string Description { get; set; } = "";
        public string Tags { get; set; } = "";
        public string Category { get; set; } = "";
    }
}
