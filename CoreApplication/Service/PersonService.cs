using System.Linq;
using System.Collections.Generic;
using CoreApplication.Repository;
using CoreApplication.Entity;

namespace CoreApplication.Service
{
    /*
     * PersonService implements IPersonService services
     * */
    public class PersonService : IPersonService
    {
        /*
         * Service use given repository to communicate with data provider.
         * For now it user web service as data provider
         */
        public PersonService(IRepository repository)
        {
            personRepository = repository;
        }
        #region IPersonService

        IList<Person> IPersonService.GetPetOwnersByPetCat()
        {
            List<Person> petCatOwners = null;

            //Retrieve female owners
            var petOwners = personRepository.GetAll();

            if (petOwners != null && petOwners.Count > 0)
            {
                //Retrieve owners, who own cat as pet
                petCatOwners = petOwners.Where(p => p.Pets != null 
                                            && p.Pets.Any(pet => pet.Type == PetTypeEnum.Cat))
                                     .Select(p => p).ToList();
            }
            return petCatOwners;
        }


        #endregion
        private IRepository personRepository;
    }
}
