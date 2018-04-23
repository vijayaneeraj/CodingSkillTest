using CoreApplication.Entity;
using System.Collections.Generic;


namespace CoreApplication.Repository
{
    /*
     * Support multiple type of repository with single interface.
     * Repository can consume data from different data provider like Service or Database
     * */
    public interface IRepository
    {
        //Retrieves list of all person records 
        IList<Person> GetAll();
    }
}
