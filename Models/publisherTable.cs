namespace Assignment2Library.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("publisherTable")]
    public partial class publisherTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public publisherTable()
        {
            bookTables = new HashSet<bookTable>();
        }

        [Key]
        public int publisherId { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string country { get; set; }

        public bool international { get; set; }

        [Required]
        public string paperQuality { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bookTable> bookTables { get; set; }
    }
}
