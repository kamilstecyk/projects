using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPC_manager
{

    class dbActionsMainForm
    {

        static public dbModel dbContext = new dbModel();
           
        public static List<string> getTop5Characters()
        {
    //        Console.WriteLine(" top 5");

            

            List<string> top5List = new List<string>();

            var query = from ue in dbContext.UserElements select ue.Characters;  // we have all users characters

         

            

        List<Characters> allCharList = new List<Characters>();


        foreach(var userChar in query)
        {
            foreach(var ch in userChar)
            {
                allCharList.Add(ch);
                  //  Console.WriteLine(ch.Dragons.Count + " count of chars");

            }
        }

        // we order list of all characters , we have sorted categories of chars all users
        allCharList.OrderByDescending(e => e.Power).ThenByDescending(f => f.Level);

//        Console.WriteLine(allCharList.Count + " Count allcharlist");

        int counter = 0;

        foreach(var charCategory in allCharList)
        {

                Console.WriteLine(charCategory.CharactersID + "Category ID");

                var queryDragon = from dr in dbContext.Dragons where dr.CategoryID == charCategory.CharactersID select dr;


                var queryMag = from mag in dbContext.Mags where mag.CategoryID == charCategory.CharactersID select mag;

                var queryEnt = from en in dbContext.Ents where en.CategoryID == charCategory.CharactersID select en;

               
                foreach(var drag in queryDragon)
                {



                    if(counter < 5)
                    {
                     
                        string toAdd = "Dragon: " + drag.Name + ", Power: " + charCategory.Power + ", Level: " + charCategory.Level;
                        top5List.Add(toAdd);
                      //  Console.WriteLine(toAdd);
                        ++counter;
                    }
                }

                foreach (var drag in queryMag)
                {
                    if (counter < 5)
                    {
                        string toAdd = "Mag: " + drag.Name + ", Power: " + charCategory.Power + ", Level: " + charCategory.Level;
                        top5List.Add(toAdd);
                       // Console.WriteLine(toAdd);
                        ++counter;
                    }
                }

                foreach (var drag in queryEnt)
                {
                    if (counter < 5)
                    {
                        string toAdd = "Ent: " + drag.Name + ", Power: " + charCategory.Power + ", Level: " + charCategory.Level;
                        top5List.Add(toAdd);
                       // Console.WriteLine(toAdd);
                        ++counter;
                    }
                }
        }
        
            return top5List;
        }

        public static List<string> getNewestArtefactsCharacters(int toDisplayCount)
        {

            Console.WriteLine("get Newest ----");

            List<string> listOfArtefacts = new List<string>();

            var dragonsQuery = from d in dbContext.Dragons select d;
            var magsQuery = from mag in dbContext.Mags select mag;
            var entsQuery = from en in dbContext.Ents select en;


            List<Dragon> dragonList = dragonsQuery.OrderByDescending(d => d.addedDate).ToList();
            List<Mag> magList = magsQuery.OrderByDescending(m => m.addedDate).ToList();
            List<Ent> entList =  entsQuery.OrderByDescending(e => e.addedDate).ToList();



            for(int i=0;i<toDisplayCount && (dragonList.Count != 0 || magList.Count!=0 || entList.Count!= 0) ;++i)
            {
                // we have long values and then we can convert it  to date

                long dateDragon;
                long dateMag;
                long dateEnt;

                if(dragonList.Count != 0)
                { 
                    Dragon firstDragon = dragonList.First();
                    dateDragon = firstDragon.addedDate.Ticks;
                }
               else
                {
                    dateDragon = long.MinValue;
                }

               if(magList.Count != 0) { 
                    Mag firstMag = magList.First(); // if null then long.min value solution 
                    dateMag = firstMag.addedDate.Ticks;
                }
                else { 
                    dateMag = long.MinValue;  
                }

                if(entList.Count != 0) { 
                    Ent firstEnt = entList.First();
                    dateEnt = firstEnt.addedDate.Ticks;
                }
                else { 
                    dateEnt = long.MinValue;
                }

                

                List<long> listOfDate = new List<long>() { dateDragon,dateMag,dateEnt};

                long maxValue = listOfDate.Max();
                int maxIndex = listOfDate.IndexOf(maxValue);



                if(maxIndex == 0)  // dragon
                {
                    string toAdd = "Dragon: " + dragonList.ElementAt(0).Name + " , " + dragonList.ElementAt(0).addedDate;
                    listOfArtefacts.Add(toAdd);
                    dragonList.RemoveAt(0);
                }
                else if(maxIndex == 1)
                {
                    string toAdd = "Mag: " +  magList.ElementAt(0).Name + " , " + magList.ElementAt(0).addedDate;
                    listOfArtefacts.Add(toAdd);
                    magList.RemoveAt(0);
                }
                else if(maxIndex == 2)
                {
                    string toAdd = "Mag: " + entList.ElementAt(0).Name + " , " + entList.ElementAt(0).addedDate;
                    listOfArtefacts.Add(toAdd);
                    entList.RemoveAt(0);
                }


            }

            return listOfArtefacts;
        }



    }
}
