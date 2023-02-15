using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPC_manager
{
    class dbActionsRemoveForm
    {
        static public dbModel dbContext = new dbModel();


        static public bool removeCharacterElement(int operation,int elementID)
        {

            if(operation == 0)
            {
                var elementToDelete = dbContext.Dragons.Find(elementID);
                dbContext.Dragons.Remove(elementToDelete);


            }
            else if(operation == 1)
            {
                var elementToDelete = dbContext.Mags.Find(elementID);
                dbContext.Mags.Remove(elementToDelete);

            }
            else if(operation == 2)
            {
                var elementToDelete = dbContext.Ents.Find(elementID);
                dbContext.Ents.Remove(elementToDelete);

            }

            dbContext.SaveChanges();

            return true;

        }

        static public bool removeInAnimaterElement(int operation, int elementID)
        {

            if (operation == 0)
            {
                var elementToDelete = dbContext.Caves.Find(elementID);
                dbContext.Caves.Remove(elementToDelete);


            }
            else if (operation == 1)
            {
                var elementToDelete = dbContext.Towers.Find(elementID);
                dbContext.Towers.Remove(elementToDelete);

            }
            else if (operation == 2)
            {
                var elementToDelete = dbContext.Coppices.Find(elementID);
                dbContext.Coppices.Remove(elementToDelete);

            }

            dbContext.SaveChanges();

            return true;

        }

        public static bool removeCharacterCategory(int categoryID)
        {
            int currentUserID = dbActions.getLoggedUser();

           
           
                // we delete elements with categoery
           
            
                try
                {
                    var elementsToDelete = from ed in dbContext.Dragons where ed.CategoryID == categoryID select ed;

                    foreach(var element in elementsToDelete)
                    {
                        dbContext.Dragons.Remove(element);
                    Console.WriteLine("I just have deleted element " + element.DragonID);
                    }

                }
                catch(Exception ex)
                {
                    Console.WriteLine("there is no elements in table in this category to remvoe 1");
                }

                try
                {
                    var elementsToDelete = from ed in dbContext.Mags where ed.CategoryID == categoryID select ed;

                    foreach (var element in elementsToDelete)
                    {
                        dbContext.Mags.Remove(element);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("there is no elements in table in this category to remvoe 1");
                }

                try
                {
                    var elementsToDelete = from ed in dbContext.Ents where ed.CategoryID == categoryID select ed;

                    foreach (var element in elementsToDelete)
                    {
                        dbContext.Ents.Remove(element);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("there is no elements in table in this category to remvoe 1");
                }
            

            // we remove category from user
            
            var userCharacters = from ue in dbContext.UserElements where ue.UserID == currentUserID select ue.Characters;
            var rows = userCharacters.Single();

            foreach( var character in rows)
            {
                if(character.CharactersID == categoryID)
                {
                    dbContext.Characters.Remove(character);
                }
            }
            

            dbContext.SaveChanges();

            return true;
        }


        public static bool removeInAnimateCategory(int categoryID)
        {
            int currentUserID = dbActions.getLoggedUser();



            // we delete elements with categoery


            try
            {
                var elementsToDelete = from ed in dbContext.Caves where ed.CategoryID == categoryID select ed;

                foreach (var element in elementsToDelete)
                {
                    dbContext.Caves.Remove(element);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("there is no elements in table in this category to remvoe 1");
            }

            try
            {
                var elementsToDelete = from ed in dbContext.Towers where ed.CategoryID == categoryID select ed;

                foreach (var element in elementsToDelete)
                {
                    dbContext.Towers.Remove(element);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("there is no elements in table in this category to remvoe 1");
            }

            try
            {
                var elementsToDelete = from ed in dbContext.Coppices where ed.CategoryID == categoryID select ed;

                foreach (var element in elementsToDelete)
                {
                    dbContext.Coppices.Remove(element);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("there is no elements in table in this category to remvoe 1");
            }


            // we remove category from user

            var userCharacters = from ue in dbContext.UserElements where ue.UserID == currentUserID select ue.Inanimates;
            var rows = userCharacters.Single();

            foreach (var inAnimate in rows)
            {
                if (inAnimate.InanimateID == categoryID)
                {
                    dbContext.Inanimates.Remove(inAnimate);
                }
            }

            dbContext.SaveChanges();

            return true;
        }



    }
}
