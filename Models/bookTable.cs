namespace Assignment2Library.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bookTable")]
    public partial class bookTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bookTable()
        {
            usersTables = new HashSet<usersTable>();
        }

        [Key]
        public int bookId { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string genre { get; set; }

        [Required]
        public string readType { get; set; }

        [Required]
        public string publishDate { get; set; }

        public int authorId { get; set; }

        public int publisherId { get; set; }

        public virtual authorTable authorTable { get; set; }

        public virtual publisherTable publisherTable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usersTable> usersTables { get; set; }
    }
}
