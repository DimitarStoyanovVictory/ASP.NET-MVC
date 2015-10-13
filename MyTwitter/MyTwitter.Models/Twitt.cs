namespace MyTwitter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Twitt
    {
        private ICollection<Replay> replays;

        private ICollection<Report> reports;

        private ICollection<User> userFavorites;

        private ICollection<User> usersReTwittes;

        public Twitt()
        {
            this.userFavorites = new HashSet<User>();
            this.usersReTwittes = new HashSet<User>();
            this.replays = new HashSet<Replay>();
            this.reports = new HashSet<Report>();
        }

        [Key]
        public int Id { get; set; }

        public DateTime PublishedOn { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public virtual ICollection<User> UsersFavorites
        {
            get
            {
                return this.userFavorites;
            }

            set
            {
                this.userFavorites = value;
            }
        }

        public virtual ICollection<User> UsersReTwittes
        {
            get
            {
                return this.usersReTwittes;
            }

            set
            {
                this.usersReTwittes = value;
            }
        }

        public virtual ICollection<Replay> Replays
        {
            get
            {
                return this.replays;
            }

            set
            {
                this.replays = value;
            }
        }

        public virtual ICollection<Report> Reports
        {
            get
            {
                return this.reports;
            }

            set
            {
                this.reports = value;
            }
        }
    }
}