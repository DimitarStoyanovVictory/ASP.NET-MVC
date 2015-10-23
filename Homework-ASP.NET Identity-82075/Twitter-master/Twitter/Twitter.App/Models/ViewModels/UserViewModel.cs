namespace Twitter.App.Models.ViewModels
{
    using Twitter.Models.Enums;
    using Twitter.Models;

    public class UserViewModel
    {
        public UserViewModel(User user)
        {
            this.Id = user.Id;
            this.UserName = user.UserName;
            this.Age = user.Age;
            this.Sex = user.Sex;
        }
        public string Id { get; set; }

        public string UserName { get; set; }

        public int Age { get; set; }

        public Sex Sex { get; set; }
    }
}