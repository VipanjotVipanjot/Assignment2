namespace Assignment2Library.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("usersTable")]
    public partial class usersTable
    {
        [Key]
        public int userId { get; set; }

        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        [StringLength(15)]
        public string phoneNo { get; set; }

        [Required]
        public string email { get; set; }

        public int bookId { get; set; }

        public virtual bookTable bookTable { get; set; }
    }
}
