
using System.Collections.Generic;
using CoreApplication.Entity;

namespace CoreApplication.Service
{
    /*
     * PersonService layer which implements the business logic
     */
    public interface IPersonService
    {
        //Retrieve female pet owners who own cat
        IList<Person> GetPetOwnersByPetCat();

    }
}
