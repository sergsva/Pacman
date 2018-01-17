using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pacman
{

    

   public class Program
    {

        public static Random rand = new Random();
        static void Main(string[] args)
        {
            GamePacman newGame = new GamePacman(2,2);//params: кол-во жизней pacman, кол-во привидений в игре
            newGame.SetPacman(true); // param: Установка pacman на игровом поле 0 - default coordinate(1,1), 1 - random 
            newGame.Start();
            Console.Read();
        }
    }
}
