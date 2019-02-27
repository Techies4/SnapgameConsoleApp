using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Let's Play Snap! Press Any Key to Start");
            Console.ReadLine();

            Player player = new Player();
            player.Start();
           
        }
    }
}
