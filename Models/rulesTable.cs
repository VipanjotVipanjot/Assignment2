namespace Assignment2Library.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("rulesTable")]
    public partial class rulesTable
    {
        [Key]
        public int ruleId { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public string inactionFrom { get; set; }

        [Required]
        public string penalty { get; set; }
    }
}
