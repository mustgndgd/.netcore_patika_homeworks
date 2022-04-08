using System;
using BookStoreAPI.Services;

namespace BookStoreAPI.Services
{
    public class DBLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("DB Logger - " + message);
        }
    }
}