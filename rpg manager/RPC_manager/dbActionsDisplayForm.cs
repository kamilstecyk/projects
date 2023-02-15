using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPC_manager
{
    class dbActionsDisplayForm
    {

        static public dbModel dbContext = new dbModel();


        static public List<string> getAllUsersCharacters()
        {
            List<string> charList = new List<string>();

            var query = from ue in dbContext.UserElements select ue.Characters;




            return charList;
        }


        static public List<string> getAllLoggedUSerCharacters(bool forAdmin)
        {


            List<string> charList = new List<string>();

            int currentUserId = dbActions.getLoggedUser();

            IQueryable<ICollection<Characters>> query = from ue in dbContext.UserElements where ue.UserID == currentUserId select ue.Characters;  // we have all users characters

            if (forAdmin)
            {
                query = from ue in dbContext.UserElements select ue.Characters;
            }
         



            foreach (var records in query)
            {
                foreach (var charCategory in records)
                {

                    Console.WriteLine(charCategory.CharactersID + "Category ID");

                    var queryDragon = from dr in dbContext.Dragons where dr.CategoryID == charCategory.CharactersID select dr;


                    var queryMag = from mag in dbContext.Mags where mag.CategoryID == charCategory.CharactersID select mag;

                    var queryEnt = from en in dbContext.Ents where en.CategoryID == charCategory.CharactersID select en;


                    foreach(var drag in queryDragon)
                    {
                        string toAdd = "Dragon: " + drag.Name + ", Power: " + charCategory.Power + ", Level: " + charCategory.Level;
                        charList.Add(toAdd);
                    }

                    foreach(var mag in queryMag)
                    {
                        string toAdd = "Mag: " + mag.Name + " , level of power: " +  mag.LevelOfPower + " , Circle: " + mag.Circle  + ", Power: " + charCategory.Power + ", Level: " + charCategory.Level;
                        charList.Add(toAdd);
                    }

                    foreach (var ent in queryEnt)
                    {
                        string toAdd = "Ent: " + ent.Name + " , number of jars: " + ent.NumberOfJars + " , species: " + ent.Species  +",Power: " + charCategory.Power + ", Level: " + charCategory.Level;
                        charList.Add(toAdd);
                    }


                }
            }

            return charList;
       
        
        }

        static public List<string> getAllLoggedUserInanimates(bool forAdmin)
        {


            List<string> charList = new List<string>();

            int currentUserId = dbActions.getLoggedUser();

           // var query = from ue in dbContext.UserElements where ue.UserID == currentUserId select ue.Inanimates;  // we have all users characters

            IQueryable<ICollection<Inanimate>> query = from ue in dbContext.UserElements where ue.UserID == currentUserId select ue.Inanimates;

            if (forAdmin)
            {
                query = from ue in dbContext.UserElements select ue.Inanimates;
            }



            foreach (var records in query)
            {
                foreach (var charCategory in records)
                {


                    var queryCave = from cv in dbContext.Caves where cv.CategoryID == charCategory.InanimateID select cv;


                    var queryTower = from tw in dbContext.Towers where tw.CategoryID == charCategory.InanimateID select tw;
                    var queryCoppice = from cp in dbContext.Coppices where cp.CategoryID == charCategory.InanimateID select cp;


                    foreach (var cave in queryCave)
                    {
                        string toAdd = "Cave " + ", area: " + charCategory.Area + " , depth: " + cave.depth; 
                        charList.Add(toAdd);
                    }

                    foreach (var tower in queryTower)
                    {
                        string toAdd = "Tower ," + " area: " + charCategory.Area + " , height: " + tower.Height + " , material: " + tower.material; 
                        charList.Add(toAdd);
                    }

                    foreach (var coppice in queryCoppice)
                    {
                        string toAdd = "Coppice ," + " area: " + charCategory.Area + " ,number of trees: " + coppice.NumberOfTrees; 
                        charList.Add(toAdd);
                    }


                }
            }

            return charList;
        }


    }

}
