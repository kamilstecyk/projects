using System;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RPC_manager
{
    public class dbModel : DbContext
    {
        // Your context has been configured to use a 'dbModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'RPC_manager.dbModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'dbModel' 
        // connection string in the application configuration file.
        public dbModel()
            : base("name=dbModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        public virtual DbSet<UserElements> UserElements { get; set; }
        public virtual DbSet<Cave> Caves { get; set; }
        public virtual DbSet<Dragon> Dragons { get; set; }
        public virtual DbSet<Tower> Towers { get; set; }
        public virtual DbSet<Mag> Mags { get; set; }
        public virtual DbSet<Coppice> Coppices { get; set; }
        public virtual DbSet<Ent> Ents { get; set; }

        public virtual DbSet<Characters> Characters { get; set; }  // added
        public virtual DbSet<Inanimate> Inanimates { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}


    public class Users
    {
        [Key]
        public int userID { get; set; }
        [Index(IsUnique = true)]
        [StringLength(30)]
        public string login { get; set; }
        public string password { get; set; }

        // we have user role and admin role

        public string role { get; set; } = "user";   // default
    }


    // problem is that we cannot define dynamically type of attribute

    /*   

    public class Categories
    {
        [Key]
        public int CategorieID { get; set; }
        
        [Index(IsUnique = true)]
        [StringLength(30)]
        public string name { get; set; }   // e.g jaskina

        public ICollection<CategoriesAttributes> CategoriesAttributes { get; set; }
    }


    public class CategoriesAttributes
    {
        [Key]
        public int CategoriesAttributeID {get;set;}
        public string AttributeName { get; set; }   // for example powierzchnia i value to jej wartosc
        public string AttributeValue { get; set; }   // all values of attributes are strings, they can be converted in run time , selected from db

        public ICollection<CategorieElements> CategorieElements { get; set; }   // particular category have elements

    }


    public class CategorieElements
    {
        [Key]
        public int ElementID { get; set; }

        public string elementName { get; set; }
        public string elementValue { get; set; }
    }

    */




    /*    


        // table that summarize users elements in category


        public class UserElements
        {
            [Key]
            public int UserElementsID {get;set;}

            public ICollection<Cave> Caves { get; set; }
            public ICollection<Tower> Towers { get; set; }
            public ICollection<Coppice> Coppices { get; set; }


            public int UserID { get; set; }
            public Users Users;
        }






        // 1 

        public class Cave  // category
        {
            [Key]
            public int CaveID { get; set; }

            public int Area { get; set; }
            public ICollection<Dragon> Dragons { get; set; }

        }

        public enum DragonSpecies
        {
            [Display(Name = "The Chinese Dragon")]
            Chineese,
            [Display(Name = "The Standard Western Dragon")]
            Western,
            [Display(Name = "The Wyvern")]
            Wyvern,
            [Display(Name = "The Hydra")]
            TheHydra,
            [Display(Name = "The Japanese Dragon")]
            Japanese

        }


        public class Dragon
        {
            [Key]
            public int DragonID { get; set; }

            public string Name { get; set; }
            public int WingSpan { get; set; }
            public DragonSpecies Species { get; set; }
        }



        //// 2



        public class Tower
        {
            [Key]
            public int TowerID { get; set; }

            public int Height { get; set; }
            public string material { get; set; }

            public ICollection<Mag> Mags { get; set; }

        }


        public enum MagCircle
        {
            Anderfels, Antiva, Ferelden, Rivain, FreeMarches, Orlais
        }



        public class Mag
        {
            [Key]
            public int MagID { get; set; }

            public string Name { get; set; }
            public int LevelOfPower { get; set; }
            public MagCircle Circle { get; set; }

        }


        /// 3



        public class Coppice  // zagajnik po polsku
        {
            [Key]
            public int CoppiceID { get; set; }

            public int Area { get; set; }

            public ICollection<Ent> Ents { get; set; }
        }



        public enum EntSpecies
        {
            Anderfels, Antiva, Ferelden, Rivain, FreeMarches, Orlais
        }

        public class Ent
        {
            [Key]
            public int EntID { get; set; }

            public int NumberOfJars { get; set; }
            public EntSpecies Species { get; set; }
            public string Name { get; set; }

        }



        */


    /* second verision  ============================================================== */


    // hashset prevent from doubling the same values

   


    public class UserElements
    {
        [Key]
        public int UserElementsID { get; set; }

        // these ones are categories
        public ICollection<Characters> Characters {get;set;}
        public ICollection<Inanimate> Inanimates { get; set; }

        [Index(IsUnique = true)]
        public int UserID { get; set; }
        public Users Users;

        public UserElements()
        {
            Characters = new HashSet<Characters>();  // we initialize to prevent from having null values
            Inanimates = new HashSet<Inanimate>();
        }

    }


    // 1  - Characters


    public class Characters
    {
        [Key]
        public int CharactersID { get; set; }


        [Index(IsUnique = true)]
        public int Level { get; set; }
        [Index(IsUnique = true)]
        public int Power { get; set; }

        public ICollection<Dragon> Dragons { get; set; }
        public ICollection<Mag> Mags { get; set; }
        public ICollection<Ent> Ents { get; set; }


        public Characters()
        {
            Dragons = new HashSet<Dragon>();
            Mags = new HashSet<Mag>();
            Ents = new HashSet<Ent>();

        }


    }



    public enum DragonSpecies
    {
        [Display(Name = "The Chinese Dragon")]
        Chineese,
        [Display(Name = "The Standard Western Dragon")]
        Western,
        [Display(Name = "The Wyvern")]
        Wyvern,
        [Display(Name = "The Hydra")]
        TheHydra,
        [Display(Name = "The Japanese Dragon")]
        Japanese

    }


    public class Dragon
    {
        [Key]
        public int DragonID { get; set; }

        [Index(IsUnique = true)]
        [StringLength(30)]
        public string Name { get; set; }
        public int WingSpan { get; set; }
        public DragonSpecies Species { get; set; }

        public int CategoryID {get;set;}
        public Characters Characters;


        public DateTime addedDate { get; set; }
    }



    public enum MagCircle
    {
        Anderfels, Antiva, Ferelden, Rivain, FreeMarches, Orlais
    }



    public class Mag
    {
        [Key]
        public int MagID { get; set; }

        [Index(IsUnique = true)]
        [StringLength(30)]
        public string Name { get; set; }
        public int LevelOfPower { get; set; }
        public MagCircle Circle { get; set; }


        public int CategoryID { get; set; }
        public Characters Characters;

        public DateTime addedDate { get; set; }

    }


    public enum EntSpecies
    {
        Anderfels, Antiva, Ferelden, Rivain, FreeMarches, Orlais
    }

    public class Ent
    {
        [Key]
        public int EntID { get; set; }

        public int NumberOfJars { get; set; }
        public EntSpecies Species { get; set; }

        [Index(IsUnique = true)]
        [StringLength(30)]
        public string Name { get; set; }

        public int CategoryID { get; set; }
        public Characters Characters;


        public DateTime addedDate { get; set; }


    }



    // 2 - inanimate



    public class Inanimate
    {
        [Key]
        public int InanimateID { get; set; }

        [Index(IsUnique = true)]
        public int Area { get; set; }

        public ICollection<Cave> Caves { get; set; }
        public ICollection<Tower> Towers { get; set; }
        public ICollection<Coppice> Coppices { get; set; }

        public Inanimate()
        {
            Caves = new HashSet<Cave>();
            Towers = new HashSet<Tower>();
            Coppices = new HashSet<Coppice>();

        }


    }


    public class Cave  // category
    {
        [Key]
        public int CaveID { get; set; }

        public int depth { get; set; }


        public int CategoryID { get; set; }
        public Characters Characters;

    }



    public class Tower
    {
        [Key]
        public int TowerID { get; set; }

        public int Height { get; set; }
        public string material { get; set; }


        public int CategoryID { get; set; }
        public Characters Characters;


    }



    public class Coppice  // zagajnik po polsku
    {
        [Key]
        public int CoppiceID { get; set; }

        public int NumberOfTrees { get; set; }

        public int CategoryID { get; set; }
        public Characters Characters;

    }








}