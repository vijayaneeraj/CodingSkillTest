using System.Configuration;

namespace CoreApplication
{
    public class AppConfiguration
    {
        //Static configurable setting - settings are static for now
        private static AppConfiguration configObj = null;
        //Maintain single instance of configuration.
        private AppConfiguration()
        { }
        public string WebServicePath;
        //Accesser for config settings
        public static AppConfiguration Configuration()
        {
            if (configObj == null)
            {
                configObj = new AppConfiguration();
                configObj.WebServicePath = ConfigurationManager.AppSettings["WebServiceURL"];
            }
            return configObj;
        }

    }
}
