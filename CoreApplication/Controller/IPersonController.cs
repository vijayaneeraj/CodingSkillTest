
using CoreApplication.DTO;
using System.Collections.Generic;


namespace CoreApplication.Controller
{
    public interface IPersonController
    {
        PetOwners GetPetOwnerNamesByPetCat();
    }
}
