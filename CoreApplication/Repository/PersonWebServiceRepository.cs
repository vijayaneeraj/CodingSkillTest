using System.Collections.Generic;
using CoreApplication.Entity;
using RestSharp;
using System.Web.Script.Serialization;
using System;

namespace CoreApplication.Repository
{
    /*
     * Repository implements IRepository and consumes data from web service
     * */
    public class PersonWebServiceRepository : IRepository
    {
        public PersonWebServiceRepository()
        {
        }

        //Read web service configuration settings
        public AppConfiguration AppConfig
        {
            get
            {
                return appConfig ?? (appConfig =  AppConfiguration.Configuration());
            }
        }

        AppConfiguration appConfig;

        /*
         * Prepare ServiceRequest based on API call requirement
         * */
        private IRestResponse CallAPI(string serviceURL, Method reqMethod)
        {

            //Prepare request
            var serviceRequest = new RestRequest();
            //Set accept header
            serviceRequest.AddHeader("Accept", "application/json");
            //Set Method
            serviceRequest.Method = reqMethod;
            //Service call

            var response = new RestClient(serviceURL).Execute(serviceRequest);
            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response from web service.  Check details for more info.";
                var excep = new AppException(message, response.ErrorException);
                throw excep;
            }

            //Other settings can go here
            return response;
        }

        #region IRepository
        public IList<Person> GetAll()
        {
            //Prepare URL
            if (string.IsNullOrEmpty(AppConfig.WebServicePath))
                throw new AppException("Web service URL not configured to retrieve person.");

            string serviceURL = string.Format("{0}{1}", AppConfig.WebServicePath, "people.json");
            var response = CallAPI(serviceURL, Method.GET);

            //Deserialise JSON string
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            IList<Person> persons = null;
            try
            {
                persons = json_serializer.Deserialize<IList<Person>>(response.Content);
            }catch(Exception e)
            {
                throw new AppException(String.Format("Failed to deserialize the json string. {0}", e.ToString()));
            }
            return persons;
        }
        #endregion
    }
}
