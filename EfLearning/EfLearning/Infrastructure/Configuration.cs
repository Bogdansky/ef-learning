using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace EfLearning.Infrastructure
{
    public static class Configuration
    {
        private static IConfiguration _configuration;

        public static void Initialize(IConfiguration configuration)
        {
            if (_configuration != null) throw new InvalidOperationException("Configuration is already set");

            _configuration = configuration;
        }

        public static IConfigurationSection GetSection(string name)
        {
            Guard.NotNull(_configuration);

            return _configuration.GetSection(name);
        }

        public static string GetConnectionString(string key)
        {
            Guard.NotNull(_configuration);

            return _configuration.GetConnectionString(key);
        }
    }
}
