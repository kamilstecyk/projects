using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RPC_manager
{
    // actions connected with adding categories and elements

    class DbActionsAddForm
    {

        // we use userID from dbActions static filed which is connected with login part

        static public dbModel dbContext = new dbModel();



        private static int getMaxLevelForLoggedUser()
        {
            int currentUserId = dbActions.getLoggedUser();
            var charactersQuery = from ue in dbContext.UserElements where ue.UserID == currentUserId select ue.Characters;

            int maxLvl = charactersQuery.Single().Max(ch => ch.Level);
            Console.WriteLine("------- max Level" + maxLvl);

            return maxLvl;

        }

        private static int getMaxPowerForLoggedUser()
        {
            int currentUserId = dbActions.getLoggedUser();
            var charactersQuery = from ue in dbContext.UserElements where ue.UserID == currentUserId select ue.Characters;

            int maxPow = charactersQuery.Single().Max(ch => ch.Power);
            Console.WriteLine("------- max Power" + maxPow);


            return maxPow;

        }

        private  static int getCountOfCharactersCategory()
        {
            int currentUserId = dbActions.getLoggedUser();
            try
            {
                var charactersQuery = from ue in dbContext.UserElements where ue.UserID == currentUserId select ue.Characters;

                return charactersQuery.Single().Count;

            }
            catch(Exception ex)
            {
                Console.WriteLine("There is no characters");
            }

            return 0;
        }


        private static int getFirstAvailableLevel()
        {

            int currentUserId = dbActions.getLoggedUser();

            var charactersQuery = from ue in dbContext.UserElements where ue.UserID == currentUserId select ue.Characters;
            var sortedCharsBylvl = charactersQuery.Single().ToList().OrderByDescending(ch => ch.Level);

            int maxLvl = sortedCharsBylvl.ElementAt(0).Level - 1;


            if (sortedCharsBylvl.Count() >= 1)
            {
                //int maxDifference = sortedCharsBylvl.ElementAt(0).Level - sortedCharsBylvl.ElementAt(1).Level;
                //  maxLvl = sortedCharsBylvl.ElementAt(0).Level - maxDifference / 2;

                bool wasFoundedLvl = false;


                for (int i = maxLvl; i > 0; --i)  // we find first available max category level
                {
                    wasFoundedLvl = false;
                    foreach (var charInList in sortedCharsBylvl)
                    {
                        if (charInList.Level == i)
                        {
                            wasFoundedLvl = true;
                            break;
                        }
                    }


                    if (wasFoundedLvl == false)
                    {
                        maxLvl = i;
                        break;
                    }
                    else
                    {
                        maxLvl = -1;  // we cannot add 
                        //throw new Exception(); // we could not find available valuet to add 
                    }
                }

              
            }
            else
            {
                maxLvl = -1;
            }


            if (maxLvl == -1)
            {
                throw new Exception();
            }


            return maxLvl;


        }


        static private int getFirstAvailablePower()
        {
            int currentUserId = dbActions.getLoggedUser();

            var charactersQuery = from ue in dbContext.UserElements where ue.UserID == currentUserId select ue.Characters;


            var sortedCharsByPower = charactersQuery.Single().ToList().OrderByDescending(ch => ch.Power);

            int maxPower = sortedCharsByPower.ElementAt(0).Power - 1;


            if (sortedCharsByPower.Count() >= 1)
            {
                // int maxDifference = sortedCharsByPower.ElementAt(0).Power - sortedCharsByPower.ElementAt(1).Power;
                // maxPower = sortedCharsByPower.ElementAt(0).Power - maxDifference / 2;

                bool wasFoundedPower = false;


                for (int i = maxPower; i > 0; --i)  // we find first available max category level
                {
                    wasFoundedPower = false;
                    foreach (var charInList in sortedCharsByPower)
                    {
                        if (charInList.Power == i)
                        {
                            wasFoundedPower = true;
                            break;
                        }
                    }


                    if (wasFoundedPower == false)
                    {
                        maxPower = i;
                        break;
                    }
                    else
                    {
                        maxPower = -1;  // we cannot add \
                                        // throw new Exception(); // we could not find available valuet to add 

                    }
                }

            }
            else
            {
                maxPower = -1;
            }


            if ( maxPower == -1)
            {
                throw new Exception();
            }


            return maxPower;

        }

        public static bool addCharactersCategoryForLoggedUser(int level,int power)
        {

            // first we check if user have record in UserElements table

            int currentUserID = dbActions.getLoggedUser();

            var query = from ue in dbContext.UserElements where ue.UserID == currentUserID select ue;

            // user has record in UserElements table so we only add category in it

            try
            {
                var foudedRow = query.Single();

                if (getCountOfCharactersCategory() > 0)
                {
                    int maxLevel = getMaxLevelForLoggedUser();
                    int maxPower = getMaxPowerForLoggedUser();

                    if (maxLevel == 1 || maxPower == 1)
                    {
                        throw new Exception();
                       // return false;
                    }

                    // new characters cannot have higher lvl and power than older

                    if (level >= maxLevel)
                    {
                        level = getFirstAvailableLevel();
                    }

                    if (power >= maxPower)
                    {
                        power = getFirstAvailablePower();
                    }

                }


                foudedRow.Characters.Add(new Characters { Level = level, Power = power });
               

                try
                {
                    dbContext.SaveChanges();
                }
                catch (Exception ex2)  // these means that we have such a category
                {
                    dbContext = new dbModel();  // we must reset context to avoid exception
                    return false;
                }


                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("User does not have record in UserElements table");

                // we must create record in UserElements table and then add category


                UserElements newUE = new UserElements { UserID = currentUserID };
                newUE.Characters.Add(new Characters { Level = level, Power = power });

                dbContext.UserElements.Add(newUE);
                dbContext.SaveChanges();

                return true;

            }


         


            return false;  
        }


        public static bool addInAnimateCategoryForLoggedUser(int area)
        {

            // first we check if user have record in UserElements table

            int currentUserID = dbActions.getLoggedUser();

            var query = from ue in dbContext.UserElements where ue.UserID == currentUserID select ue;

            // user has record in UserElements table so we only add category in it

            try
            {
                

                var foudedRow = query.Single();

                foudedRow.Inanimates.Add(new Inanimate {Area = area  });
                dbContext.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("User does not have record in UserElements table");

                // we must create record in UserElements table and then add category


                UserElements newUE = new UserElements { UserID = currentUserID };
                newUE.Inanimates.Add(new Inanimate { Area = area });

              
                    dbContext.UserElements.Add(newUE);
               

                try  // this means that we have such a category
                {
                    dbContext.SaveChanges();
                }
                catch (Exception ex2)
                {
                    dbContext = new dbModel();  // we must reset context to avoid exception
                    return false;
                }


                return true;

            }





            return false;
        }






        public static void showUsersCharacters()
        {
            int currentUserID = dbActions.getLoggedUser();
            var query = from ue in dbContext.UserElements where ue.UserID == currentUserID select ue.Characters;
            var founded = query.Single();

            foreach(var row in founded)
            {
                Console.WriteLine("Character: " + row.Level + "  " + row.Power);
            }


        }

        public static void showUsersInAnimates()
        {
            int currentUserID = dbActions.getLoggedUser();
            var query = from ue in dbContext.UserElements where ue.UserID == currentUserID select ue.Inanimates;
            var founded = query.Single();

            foreach (var row in founded)
            {
                Console.WriteLine("Inanimate: " + row.Area );
            }


        }


        public static Dictionary<string,int> getLoggedUserAllCharactersCategories()
        {
            int currentUserID = dbActions.getLoggedUser();
            var query = from ue in dbContext.UserElements where ue.UserID == currentUserID select ue.Characters;

            Dictionary<string,int> charactersStringToDisplay = new Dictionary<string, int>();

            try
            {
                var founded = query.Single();
                    
                foreach(var character in founded)
                {
                    string toDisplay = "Level: " + character.Level + " , Power: " + character.Power;
                    charactersStringToDisplay.Add(toDisplay,character.CharactersID);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("User does not have characters categories!");
            }

            return charactersStringToDisplay;

        }

        public static Dictionary<string, int> getLoggedUserAllInanimatesCategories()
        {
            int currentUserID = dbActions.getLoggedUser();
            var query = from ue in dbContext.UserElements where ue.UserID == currentUserID select ue.Inanimates;

            Dictionary<string, int> charactersStringToDisplay = new Dictionary<string, int>();

            try
            {
                var founded = query.Single();

                foreach (var inanimate in founded)
                {
                    string toDisplay = "Area: " + inanimate.Area;
                    charactersStringToDisplay.Add(toDisplay,inanimate.InanimateID);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("User does not have characters categories!");
            }

            return charactersStringToDisplay;

        }


        public static bool addDragonForLoggedUser(string name, int wingSpan,int species ,int categoryID)
        {
            int currentUserId = dbActions.getLoggedUser();
            var query = from ue in dbContext.UserElements where ue.UserID == currentUserId select ue.Characters;
            var founded = query.Single();

            // we add dragon



            var query2 = from ch in founded where ch.CharactersID == categoryID select ch.Dragons;
            var founded2 = query2.Single();


          
            

            founded2.Add(new Dragon {addedDate = DateTime.Now ,CategoryID = categoryID, Name = name, WingSpan = wingSpan , Species = (DragonSpecies)species});
           

            dbContext.SaveChanges();


            var characters = from ue in dbContext.UserElements where (ue.UserID == currentUserId ) select ue.Characters;
            var foundedCharacters = characters.Single();


            return true;

        }

        public static bool addMagForLoggedUser(string name, int levelOfPower, int magCircle, int categoryID)
        {
            int currentUserId = dbActions.getLoggedUser();
            var query = from ue in dbContext.UserElements where ue.UserID == currentUserId select ue.Characters;
            var founded = query.Single();

            // we add dragon


            var query2 = from ch in founded where ch.CharactersID == categoryID select ch.Mags;
            var founded2 = query2.Single();

            founded2.Add(new Mag { addedDate = DateTime.Now, CategoryID = categoryID, Name = name, LevelOfPower = levelOfPower, Circle = (MagCircle)magCircle });

            dbContext.SaveChanges();

            return true;

        }


        public static bool addEntForLoggedUser(int numberOfJars, int spec, string name, int categoryID)
        {

            int currentUserId = dbActions.getLoggedUser();
            var query = from ue in dbContext.UserElements where ue.UserID == currentUserId select ue.Characters;
            var founded = query.Single();

            // we add dragon


            var query2 = from ch in founded where ch.CharactersID == categoryID select ch.Ents;
            var founded2 = query2.Single();

            founded2.Add(new Ent { addedDate = DateTime.Now, CategoryID = categoryID, NumberOfJars = numberOfJars, Species = (EntSpecies) spec, Name = name });

            dbContext.SaveChanges();

            return true;

        }



        public static bool addTowerForLoggedUser(int height ,string Material, int categoryID)
        {
            int currentUserId = dbActions.getLoggedUser();
            var query = from ue in dbContext.UserElements where ue.UserID == currentUserId select ue.Inanimates;
            var founded = query.Single();

            // we add dragon


            var query2 = from ia in founded where ia.InanimateID == categoryID select ia.Towers;
            var founded2 = query2.Single();

            founded2.Add(new Tower { CategoryID = categoryID, Height = height, material = Material });

            dbContext.SaveChanges();

            return true;

        }


        public static bool addCaveForLoggedUser(int depth, int categoryID)
        {
            int currentUserId = dbActions.getLoggedUser();
            var query = from ue in dbContext.UserElements where ue.UserID == currentUserId select ue.Inanimates;
            var founded = query.Single();

            // we add dragon


            var query2 = from ia in founded where ia.InanimateID == categoryID select ia.Caves;
            var founded2 = query2.Single();

            founded2.Add(new Cave { CategoryID = categoryID, depth = depth });

            dbContext.SaveChanges();

            return true;

        }


        public static bool addCoppiceForLoggedUser(int numberOfTrees, int categoryID)
        {
            int currentUserId = dbActions.getLoggedUser();
            var query = from ue in dbContext.UserElements where ue.UserID == currentUserId select ue.Inanimates;
            var founded = query.Single();

            // we add dragon


            var query2 = from ia in founded where ia.InanimateID == categoryID select ia.Coppices;
            var founded2 = query2.Single();

            founded2.Add(new Coppice { CategoryID = categoryID, NumberOfTrees = numberOfTrees });

            dbContext.SaveChanges();

            return true;

        }


        public static void resetContext()
        {
            dbContext = new dbModel();
        }

    }
}
