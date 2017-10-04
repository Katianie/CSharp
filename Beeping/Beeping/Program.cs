using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beeping
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            while (true)
            {
                Console.Beep(rand.Next(37, 32767), 200);
            }
        }
    }
}
