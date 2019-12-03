using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using StackExchange.Redis;

namespace Razor
{
    public static class Redis_Request
    {
        private static ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
        private static IDatabase db = redis.GetDatabase();

        static Redis_Request()
        {


        }

        public static string GetValue(string charge)
        {
            bool match;
            int counter = 0;
            var server = redis.GetServer("localhost", 6379);
            foreach (String key in server.Keys())
            {
                if (match = Regex.IsMatch(key, "IN_[0-9]{6}_[0-9]{13}_23"))
                    if (db.StringGet(key) == charge)
                        counter++;

            }
            return counter.ToString();
        }

        /* ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            var server = redis.GetServer("localhost", 6379);
            IDatabase db = redis.GetDatabase();             // Connection

            String charge = "000028233";
            bool match;
            int counter = 0;

            foreach (String key in server.Keys())
            {
                if (match = Regex.IsMatch(key, "IN_[0-9]{6}_[0-9]{13}_23"))
                    if (db.StringGet(key) == charge)
                        counter++;

            }
            Console.WriteLine("Es sind {0} Treffer für Charge {1} aufgetreten", counter.ToString(), charge);*/

    }
}
