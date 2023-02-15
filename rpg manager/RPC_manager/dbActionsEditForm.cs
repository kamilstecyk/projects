using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RPC_manager
{
    class dbActionsEditForm
    {
        static public dbModel dbContext = new dbModel();


        public static Dictionary<int, string> getAllElementsCharactersForLoggedUSer(int categoryID,int operation)
        {

            Dictionary<int, string> dict = new Dictionary<int, string>();

            int currentUserID = dbActions.getLoggedUser();


            var query = from ue in dbContext.UserElements where ue.UserID == currentUserID select ue.Characters;  // we have all users characters


            foreach (var records in query)
            {
                foreach (var charCategory in records)
                {

                    Console.WriteLine(charCategory.CharactersID + "Category ID");

                    if (operation == 0 )
                    {

                        var queryDrag = from dr in dbContext.Dragons where (dr.CategoryID == charCategory.CharactersID && dr.CategoryID == categoryID) select dr;

                        foreach (var drag in queryDrag)
                        {
                            string toAdd = "Dragon: " + drag.Name + ", Power: " + charCategory.Power + ", Level: " + charCategory.Level;
                            dict.Add(drag.DragonID,toAdd);
                        }


                    }
                    else if (operation == 1)
                    {
                        var queryMag = from mag in dbContext.Mags where (mag.CategoryID == charCategory.CharactersID && mag.CategoryID == categoryID) select mag;

                        foreach (var mag in queryMag)
                        {
                            string toAdd = "Mag: " + mag.Name + " , level of power: " + mag.LevelOfPower + " , Circle: " + mag.Circle + ", Power: " + charCategory.Power + ", Level: " + charCategory.Level;
                            dict.Add(mag.MagID,toAdd);
                        }

                    }

                    else if(operation == 2)
                    { 
                        
                            var queryEnt = from en in dbContext.Ents where (en.CategoryID == charCategory.CharactersID && en.CategoryID == categoryID ) select en;

                            foreach (var ent in queryEnt)
                            {
                                string toAdd = "Ent: " + ent.Name + " , number of jars: " + ent.NumberOfJars + " , species: " + ent.Species + ",Power: " + charCategory.Power + ", Level: " + charCategory.Level;
                                dict.Add(ent.EntID,toAdd);
                            }

                    }

                  


                }
            }

         

            return dict;

        }


        public static Dictionary<int, string> getAllElementsInAnimatesForLoggedUSer(int categoryID, int operation)
        {

            Dictionary<int, string> dict = new Dictionary<int, string>();

            int currentUserID = dbActions.getLoggedUser();


            var query = from ue in dbContext.UserElements where ue.UserID == currentUserID select ue.Inanimates;  // we have all users characters


            foreach (var records in query)
            {
                foreach (var charCategory in records)
                {

                    Console.WriteLine(charCategory.InanimateID + "Category ID");

                    if (operation == 0)
                    {

                        var queryCave = from cv in dbContext.Caves where cv.CategoryID == charCategory.InanimateID select cv;

                        foreach (var cave in queryCave)
                        {
                            string toAdd = "Cave " + ", area: " + charCategory.Area + " , depth: " + cave.depth;
                            dict.Add(cave.CaveID, toAdd);
                        }


                    }
                    else if (operation == 1)
                    {
                        var queryTower = from tw in dbContext.Towers where tw.CategoryID == charCategory.InanimateID select tw;

                        foreach (var tower in queryTower)
                        {
                            string toAdd = "Tower ," + " area: " + charCategory.Area + " , height: " + tower.Height + " , material: " + tower.material;
                            dict.Add(tower.TowerID, toAdd);
                        }


                    }

                    else if (operation == 2)
                    {

                        var queryCoppice = from cp in dbContext.Coppices where cp.CategoryID == charCategory.InanimateID select cp;


                        foreach (var coppice in queryCoppice)
                        {
                            string toAdd = "Coppice ," + " area: " + charCategory.Area + " ,number of trees: " + coppice.NumberOfTrees;
                            dict.Add(coppice.CoppiceID, toAdd);
                        }

                    }




                }
            }



            return dict;

        }





        public static bool editDragonForLoggedUser(string name, int wingSpan, int species, int idDragon)
        {
           

            // we edut



            var query2 = from dr in dbContext.Dragons where dr.DragonID == idDragon select dr;
            var founded2 = query2.Single();

            founded2.Name = name;
            founded2.WingSpan = wingSpan;
            founded2.Species = (DragonSpecies)species;


            dbContext.SaveChanges();



            return true;

        }

        public static bool editMagForLoggedUser(string name, int levelOfPower, int magCircle, int magID)
        {



            var query2 = from mg in dbContext.Mags where mg.MagID == magID select mg;
            var founded2 = query2.Single();

            founded2.Name = name;
            founded2.LevelOfPower = levelOfPower;
            founded2.Circle = (MagCircle)magCircle;

            dbContext.SaveChanges();

            return true;

        }


        public static bool editEntForLoggedUser(int numberOfJars, int spec, string name, int entID)
        {



            var query2 = from en in dbContext.Ents where en.EntID == entID select en;
            var founded2 = query2.Single();

            founded2.NumberOfJars = numberOfJars;
            founded2.Species = (EntSpecies)spec;
            founded2.Name = name;

            dbContext.SaveChanges();

            return true;

        }



        public static bool editTowerForLoggedUser(int height, string Material, int towerID)
        {


            var query2 = from t in dbContext.Towers where t.TowerID == towerID select t;
            var founded2 = query2.Single();

            founded2.Height = height;
            founded2.material = Material;

            dbContext.SaveChanges();

            return true;

        }


        public static bool editCaveForLoggedUser(int depth, int caveID)
        {



            var query2 = from c in dbContext.Caves where c.CaveID == caveID select c;
            var founded2 = query2.Single();

            founded2.depth = depth;

            dbContext.SaveChanges();

            return true;

        }


        public static bool editCoppiceForLoggedUser(int numberOfTrees, int coppiceID)
        {



            var query2 = from cp in dbContext.Coppices where cp.CoppiceID == coppiceID select cp;
            var founded2 = query2.Single();

            founded2.NumberOfTrees = numberOfTrees;

            dbContext.SaveChanges();

            return true;

        }



        public static bool editCharCategoryOfTheElement(int operationOnTable,int elementID,int newLevel,int newPower)
        {

            int currentUserID = dbActions.getLoggedUser();

            var queryUsersCharactersCategory = from ue in dbContext.UserElements where ue.UserID == currentUserID select ue.Characters;


            int destCategoryID = -1;

            foreach(var rows in queryUsersCharactersCategory)
            {
                foreach(var charCategory in rows)
                {
                    
                    if(charCategory.Level == newLevel && charCategory.Power == newPower)
                    {
                        destCategoryID = charCategory.CharactersID;
                        break;
                    }

                }
            }

            Console.WriteLine("------------------------------edit");

            Console.WriteLine(destCategoryID + " dest category");

            if(destCategoryID != -1)  // we have such a category
            {

                updateCharacterCategoryElement(operationOnTable, elementID, destCategoryID);

            }
            else
            {


                DbActionsAddForm.addCharactersCategoryForLoggedUser(newLevel, newPower);


                foreach (var rows in queryUsersCharactersCategory)
                {
                    foreach (var charCategory in rows)
                    {

                        if (charCategory.Level == newLevel && charCategory.Power == newPower)
                        {
                            destCategoryID = charCategory.CharactersID;
                            break;
                        }

                    }
                }

                updateCharacterCategoryElement(operationOnTable, elementID, destCategoryID);

                

            }



            return true;
        }


        public static bool editInanimateCategoryOtftheElement(int operationOnTable,int elementID,int newArea)
        {
            int currentUserID = dbActions.getLoggedUser();

            var queryUsersCharactersCategory = from ue in dbContext.UserElements where ue.UserID == currentUserID select ue.Inanimates;


            int destCategoryID = -1;

            foreach (var rows in queryUsersCharactersCategory)
            {
                foreach (var inanimateCategory in rows)
                {

                    if (inanimateCategory.Area == newArea)
                    {
                        destCategoryID = inanimateCategory.InanimateID;
                        break;
                    }

                }
            }

            if (destCategoryID != -1)
            {

                updateInAnimateCategoryElement(operationOnTable, elementID, destCategoryID);

            }
            else
            {


                DbActionsAddForm.addInAnimateCategoryForLoggedUser(newArea);

                foreach (var rows in queryUsersCharactersCategory)
                {
                    foreach (var inanimateCategory in rows)
                    {

                        if (inanimateCategory.Area == newArea)
                        {
                            destCategoryID = inanimateCategory.InanimateID;
                            break;
                        }

                    }
                }


                updateInAnimateCategoryElement(operationOnTable, elementID, destCategoryID);
                

            }



            return true;
        }


        private static bool updateCharacterCategoryElement(int operationOnTable, int elementID, int destCategoryID)
        {


            if (operationOnTable == 0)  // dragons
            {
                var dragons = from dr in dbContext.Dragons where dr.DragonID == elementID select dr;
                var dragon = dragons.Single();

                dragon.CategoryID = destCategoryID;

                dbContext.SaveChanges();

            }
            else if (operationOnTable == 1)
            {
                var mags = from mg in dbContext.Mags where mg.MagID == elementID select mg;
                var mag = mags.Single();

                mag.CategoryID = destCategoryID;

                dbContext.SaveChanges();
            }
            else if (operationOnTable == 2)
            {
                var ents = from en in dbContext.Ents where en.EntID == elementID select en;
                var ent = ents.Single();

                ent.CategoryID = destCategoryID;
            }

            dbContext.SaveChanges();

            return true;

        }


        private static bool updateInAnimateCategoryElement(int operationOnTable, int elementID, int destCategoryID)
        {
            if (operationOnTable == 0)  // dragons
            {
                var caves = from cv in dbContext.Caves where cv.CaveID == elementID select cv;
                var cave = caves.Single();

                cave.CategoryID = destCategoryID;


            }
            else if (operationOnTable == 1)
            {
                var towers = from tw in dbContext.Towers where tw.TowerID == elementID select tw;
                var tower = towers.Single();

                tower.CategoryID = destCategoryID;

            }
            else if (operationOnTable == 2)
            {
                var coppices = from cp in dbContext.Coppices where cp.CoppiceID == elementID select cp;
                var coppice = coppices.Single();

                coppice.CategoryID = destCategoryID;
            }

            dbContext.SaveChanges();

            return true;

        }



    }
}
