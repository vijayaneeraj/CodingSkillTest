
using System.Collections.Generic;
using System.Linq;
using CoreApplication.Entity;
using CoreApplication.Repository;
using CoreApplication.Service;
using CoreApplication.DTO;
using System;

namespace CoreApplication.Controller
{
    public class PersonController : IPersonController
    {
        public PersonController(IRepository repository)
        {
            personRepository = repository;
        }

        #region IPersonController
        /*
         * Retrieve owners who own cat. 
         * Extract data requiered for view to display.
         */
        public PetOwners GetPetOwnerNamesByPetCat()
        {

            PetOwners petOwnersByGender = null;
            //Catch the exception if any and create error response. For now throw it and handle in main
            IList<Person> petOwners = null;
            try
            {
                petOwners = ServiceProvider.GetPetOwnersByPetCat();
            }catch(AppException e)
            {
                throw;
            }
            if(petOwners != null && petOwners.Count > 0)
            {
                petOwnersByGender = new PetOwners();
                //List of female owner names
                petOwnersByGender.FemaleOwners = petOwners.Where(p => p.Gender == GenderEnum.Female)
                                            .Select(p => p.Name)
                                            .OrderBy(p => p)
                                            .ToList();
                //List of male owner names
                petOwnersByGender.MaleOwners = petOwners.Where(p => p.Gender == GenderEnum.Male)
                                            .Select(p => p.Name)
                                            .OrderBy(p => p)
                                            .ToList();

            }
            return petOwnersByGender;
        }

        #endregion

        private IRepository personRepository;
        private IPersonService serviceProvider;

        //Create Service provider with given repository
        protected virtual IPersonService ServiceProvider
        {
            get
            {
                if (serviceProvider == null)
                {
                    if (personRepository == null)
                        throw new AppException("Repository not set.");
                    serviceProvider = new PersonService(personRepository);
                }
                return serviceProvider;
            }
        }
    }
}
