using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public class EnvironmentConfig : IConfig
    {
        private List<string> keyNames;

        public EnvironmentConfig()
        {
            keyNames = new List<string>();
        }

        public bool GetConfigValue(string name, string? value)
        {
            value = Environment.GetEnvironmentVariable(name);
            if (value == null)
                return true;
            else return false;
        }

        public bool SetConfigValue(string name, string? value)
        {
            Environment.SetEnvironmentVariable(name, value);
            if(value == null)
            {
                return false;
            }
            else
            {
                keyNames.Add(name);
                return true;
            }
        }

        ~EnvironmentConfig()
        {
            foreach (string name in keyNames)
                Environment.SetEnvironmentVariable(name, null);
        }
    }
}
