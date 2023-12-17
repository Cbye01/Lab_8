using System;
using System.Collections.Generic;

public class ConfigurationManager
{
    private static ConfigurationManager instance;
    private Dictionary<string, string> settings;

    private ConfigurationManager()
    {
        // Initialize the settings dictionary
        settings = new Dictionary<string, string>();
    }

    public static ConfigurationManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ConfigurationManager();
            }
            return instance;
        }
    }

    public void SetSetting(string key, string value)
    {
        // Set or update a configuration setting
        settings[key] = value;
    }

    public string GetSetting(string key)
    {
        // Get a configuration setting by key
        if (settings.ContainsKey(key))
        {
            return settings[key];
        }
        return null;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ConfigurationManager configManager = ConfigurationManager.Instance;

        // Access the configuration settings
        configManager.SetSetting("loggingMode", "debug");
        configManager.SetSetting("databaseUrl", "localhost");

        // Retrieve the configuration settings
        string loggingMode = configManager.GetSetting("loggingMode");
        string databaseUrl = configManager.GetSetting("databaseUrl");

        Console.WriteLine("Logging Mode: " + loggingMode);
        Console.WriteLine("Database URL: " + databaseUrl);
    }
}