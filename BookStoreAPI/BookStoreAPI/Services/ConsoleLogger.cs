using System;
using BookStoreAPI.Services;

namespace BookStoreAPI.Services
{
    public class ConsoleLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("Console Logger - " + message);
        }
    }
}