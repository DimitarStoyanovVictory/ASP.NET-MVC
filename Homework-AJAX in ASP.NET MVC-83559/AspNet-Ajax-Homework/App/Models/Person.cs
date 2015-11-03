namespace App.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string ImageUrl { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Status { get; set; }

        public int Age { get; set; }
    }
}