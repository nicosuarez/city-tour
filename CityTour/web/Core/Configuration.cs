using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace web.Core
{
    public static class Configuration
    {        
        public static string GetNotifierEmailAddress()
        {
            return GetValueFromConfigFile("NotifierEmailAddress");
        }
        
        public static string GetNotifierEmailUser()
        {
            return GetValueFromConfigFile("NotifierEmailUser");
        }
                
        public static string GetNotifierEmailPass()
        {
            return GetValueFromConfigFile("NotifierEmailPass");
        }

        public static string GetSMTPServer()
        {
            return GetValueFromConfigFile("SMTPServer");
        }

        public static int GetSMTPPort()
        {
            return ConvertToInt("SMTPPort");
        }
                    
        private static string GetValueFromConfigFile(string parameterKey)
        {
            string value = ConfigurationManager.AppSettings.Get(parameterKey);
            if (!string.IsNullOrEmpty(value))
            {
                return value;
            }
            else
            {
                throw new Exception(string.Format("The parameter {0} was not set in the configuration file.", parameterKey));
            }
        }

        private static int ConvertToInt(string parameterName)
        {
            try
            {
                return int.Parse(GetValueFromConfigFile(parameterName));
            }
            catch (FormatException ex)
            {
                throw new FormatException(string.Format("The value for the {0} parameter in the configuration file cannot be converted to an integer.", parameterName), ex);
            }
        }
    }
}