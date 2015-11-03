namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        private DateTime _craetedOn = DateTime.Now;
       // [ConcurrencyCheck]
        public virtual DateTime CreatedOn {
            get { return _craetedOn; }
            set { _craetedOn = value; }
        }
    }

}
