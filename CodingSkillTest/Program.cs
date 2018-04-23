
using CoreApplication;
using CoreApplication.Controller;
using CoreApplication.DTO;
using CoreApplication.Repository;
using System;
using System.Collections.Generic;

namespace CodingSkillTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Init controller with repository. Data provider as service
            IPersonController personController = new PersonController(new PersonWebServiceRepository());

            //Retrieve and list sorted female pet owners who has cat
            PetOwners petOwners = null;
            try
            {
                petOwners = personController.GetPetOwnerNamesByPetCat();
                int count = 1;
                System.Console.WriteLine("\nList of female owners.");
                if (petOwners == null || petOwners.FemaleOwners == null || petOwners.FemaleOwners.Count == 0)
                    System.Console.WriteLine("NONE.");
                else
                {
                    foreach (var ownerName in petOwners.FemaleOwners)
                    {
                        System.Console.WriteLine(string.Format("{0}. {1}", count++, ownerName));
                    }
                }

                //Retrieve and list sorted male pet owners who has cat
                System.Console.WriteLine("\nList of male owners.");
                if (petOwners == null || petOwners.MaleOwners == null || petOwners.MaleOwners.Count == 0)
                    System.Console.WriteLine("NONE.");
                else
                {
                    count = 1;
                    foreach (var ownerName in petOwners.MaleOwners)
                    {
                        System.Console.WriteLine(string.Format("{0}. {1}", count++, ownerName));
                    }
                }
            }
            catch (AppException e)
            {
                System.Console.WriteLine(string.Format("Error: {0}", e.Message));
                System.Console.WriteLine(e.ToString());

            }
            catch (Exception e)
            {
                System.Console.WriteLine("Something went wrong unexpected.");
                System.Console.WriteLine(e.ToString());
            }

        }
    }
}
