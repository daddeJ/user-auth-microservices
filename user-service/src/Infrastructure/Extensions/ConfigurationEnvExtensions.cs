using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetEnv;

namespace Infrastructure.Extensions
{
    public class ConfigurationEnvExtensions
    {
        public static void LoadEnvironmentVariables()
        {
            var envPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", ".env");
            envPath = Path.GetFullPath(envPath);

            if (!File.Exists(envPath))
            {
                throw new FileNotFoundException($"Environment file not found at {envPath}");
            }
            else
            {
                Env.Load(envPath);
            }
        }
    }
}