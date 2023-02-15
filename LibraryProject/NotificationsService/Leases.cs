namespace NotificationsService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Leases
    {
        public int BookID { get; set; }

        public int UserID { get; set; }

        public DateTime LeaseStart { get; set; }

        public DateTime LeaseEnd { get; set; }

        [Key]
        public int LeaseID { get; set; }

        public virtual Books Books { get; set; }

        public virtual Users Users { get; set; }
    }
}
