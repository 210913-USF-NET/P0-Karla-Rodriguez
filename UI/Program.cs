using System;
using System.Diagnostics;
using Serilog;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
        Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.Console()
        .WriteTo.File("../logs/logs.text", rollingInterval: RollingInterval.Day)
        .CreateLogger();
        
        new MainMenu().Start();
        Log.Information("Application closing...");
        Log.CloseAndFlush();
        }
    }
}

