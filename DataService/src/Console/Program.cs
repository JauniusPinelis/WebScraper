using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using Infrastructure;
using Application;
using Application.Services;
using Serilog;
using Console;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var app = new App();

            app.RegisterServices();
            app.Run();
        }  
    }
}
