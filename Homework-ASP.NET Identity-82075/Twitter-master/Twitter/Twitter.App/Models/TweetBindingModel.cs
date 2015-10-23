namespace Twitter.App.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TweetBindingModel
    {
        [Required]
        [StringLength(250, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Content { get; set; }
    }
}