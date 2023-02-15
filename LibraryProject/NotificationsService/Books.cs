namespace NotificationsService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Books
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Books()
        {
            Leases = new HashSet<Leases>();
        }

        [Key]
        public int BookID { get; set; }

        [StringLength(450)]
        public string Title { get; set; }

        public string Author { get; set; }

        public string Type { get; set; }

        public long Price { get; set; }

        public string Currency { get; set; }

        public int NumberOfPages { get; set; }

        public bool isLeased { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Leases> Leases { get; set; }
    }
}
