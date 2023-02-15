using System;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBoperationsService
{
    public class Model1 : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DBoperationsService.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public Model1()
            : base("name=Model1")
        {
        }



        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

            // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<Leases> Leases { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Books> Books { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}


    public class Users
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Login { get; set; }
        public string Password { get; set; }

        public string Role { get; set; }

        public ICollection<Leases> Leases { get; set; }

    }

    public class Leases
    {
        [Key]
        public int LeaseID { get; set; }

        public int UserID { get; set; }
        public Users Users;

        public int BookID { get; set; }
        public Books Books;

        public DateTime LeaseStart { get; set; }
        public DateTime LeaseEnd { get; set; }
    }

    public class Books
    {
        [Key]
        public int BookID { get; set; }

        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Title { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }
        public long Price { get; set; }
        public string Currency { get; set; }
        public int NumberOfPages { get; set; }
        public bool isLeased { get; set; }

        public ICollection<Leases> Leases { get; set; }
    }


}