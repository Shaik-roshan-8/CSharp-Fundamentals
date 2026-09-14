static void Log(string message, string level = "INFO", bool timestamp = true)
{
    string prefix = timestamp ? $"[{DateTime.Now:HH:mm:ss}] " : "";
    Console.WriteLine($"{prefix}{level}: {message}");
}

//Log("Saved successfully");
//Log("Disk almost full", "WARN");
//Log("Cache cleared", timestamp: false);              // skip the middle one
Log(level: "ERROR", message: "Connection lost");     // order does not matter
