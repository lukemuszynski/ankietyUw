using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnkietyUW.Utilities
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        public string SendGridApiKey { get; set; }

        public ConfigurationRepository(string sendGridApiKey)
        {
            SendGridApiKey = sendGridApiKey;
        }
    }
}
