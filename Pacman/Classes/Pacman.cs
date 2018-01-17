using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Pacman : ICharacterActivity
    {
        public Coordinate RealtimeCoordinate;
        public string pacman_img { get; private set; }
        Field actualField; 
        public int stars; // Kол-во собранных звезд

        public Pacman(Field _actualField)
        {
            try { 
            actualField = _actualField;
                if (actualField == null)
	
		 throw new Exception("Null reference Field in ctor Pacman");
	}
                catch(Exception e)
            {
                    Console.WriteLine(e.Message);
                    System.Environment.Exit(0);
                }
            stars = 0;
            pacman_img = "C";
        }

        //Проверям возможность сделать ход по полю
        public bool CanNextStep(Coordinate coord)
        {
            try
            {
                if (coord.x < 0 || coord.x > 24 || coord.y < 0 || coord.y > 24) throw new Exception("Coordinate for method Pacman.CanNextStep IndexOutOfRangeException");
            }
                catch(Exception e)
            {
                Console.WriteLine(e.Message);
                System.Environment.Exit(0);
            }
           
            if (actualField.NewField[coord.x, coord.y] != "_" && actualField.NewField[coord.x, coord.y] != "-" && actualField.NewField[coord.x, coord.y] != "|" && actualField.NewField[coord.x, coord.y] != "C")
            {
                return true;
            }
            return false;
        }

        //Метод смещения вверх
        public bool GoUp()
        {
            if (RealtimeCoordinate.x > 0 && RealtimeCoordinate.x < actualField.NewField.GetLength(0) && CanNextStep(new Coordinate(RealtimeCoordinate.x - 1, RealtimeCoordinate.y)))
            {
                actualField.NewField[RealtimeCoordinate.x, RealtimeCoordinate.y] = " ";
                if ( actualField.NewField[RealtimeCoordinate.x - 1, RealtimeCoordinate.y]=="*")
                {
                    stars++;
                }
                actualField.NewField[RealtimeCoordinate.x - 1, RealtimeCoordinate.y] = pacman_img;
                RealtimeCoordinate.x--;
                return true;
            }
            else if (RealtimeCoordinate.x == 0 && CanNextStep(new Coordinate(actualField.NewField.GetLength(0) - 1, RealtimeCoordinate.y)))
            {
                actualField.NewField[RealtimeCoordinate.x, RealtimeCoordinate.y] = " ";
                if (actualField.NewField[actualField.NewField.GetLength(0) - 1, RealtimeCoordinate.y] == "*")
                {
                    stars++;
                }
                actualField.NewField[actualField.NewField.GetLength(0) - 1, RealtimeCoordinate.y] = pacman_img;
                RealtimeCoordinate.x = actualField.NewField.GetLength(0) - 1;
                return true;
            }
            return false;
        }

        //Метод смещения вниз
        public bool GoDown()
        {
            if (RealtimeCoordinate.x < actualField.NewField.GetLength(0) - 1 && RealtimeCoordinate.x >= 0 && CanNextStep(new Coordinate(RealtimeCoordinate.x + 1, RealtimeCoordinate.y)))
            {
                actualField.NewField[RealtimeCoordinate.x, RealtimeCoordinate.y] = " ";
                if (actualField.NewField[RealtimeCoordinate.x + 1, RealtimeCoordinate.y] == "*")
                {
                    stars++;
                }
                actualField.NewField[RealtimeCoordinate.x + 1, RealtimeCoordinate.y] = pacman_img;
                RealtimeCoordinate.x++;
                return true;
            }
            else if (RealtimeCoordinate.x == actualField.NewField.GetLength(0) - 1 && CanNextStep(new Coordinate(0, RealtimeCoordinate.y)))
            {
                actualField.NewField[RealtimeCoordinate.x, RealtimeCoordinate.y] = " ";
                if (actualField.NewField[0, RealtimeCoordinate.y] == "*")
                {
                    stars++;
                }
                actualField.NewField[0, RealtimeCoordinate.y] = pacman_img;
                RealtimeCoordinate.x = 0;
                return true;
            }
            return false;
        }

        //Метод смещения вправо
        public bool GoRight()
        {
            if (RealtimeCoordinate.y >= 0 && RealtimeCoordinate.y < actualField.NewField.GetLength(1) - 1 && CanNextStep(new Coordinate(RealtimeCoordinate.x, RealtimeCoordinate.y + 1)))
            {
                actualField.NewField[RealtimeCoordinate.x, RealtimeCoordinate.y] = " ";
                if (actualField.NewField[RealtimeCoordinate.x, RealtimeCoordinate.y + 1] == "*")
                {
                    stars++;
                }
                actualField.NewField[RealtimeCoordinate.x, RealtimeCoordinate.y + 1] = pacman_img;
                RealtimeCoordinate.y++;
                return true;
            }
            else if (RealtimeCoordinate.y == actualField.NewField.GetLength(1) - 1 && CanNextStep(new Coordinate(RealtimeCoordinate.x, 0)))
            {
                actualField.NewField[RealtimeCoordinate.x, RealtimeCoordinate.y] = " ";
                if (actualField.NewField[RealtimeCoordinate.x, 0] == "*")
                {
                    stars++;
                }
                actualField.NewField[RealtimeCoordinate.x, 0] = pacman_img;
                RealtimeCoordinate.y = 0;
                return true;
            }
            return false;
        }

        //Метод смещения влево
        public bool GoLeft()
        {
            if (RealtimeCoordinate.y > 0 && RealtimeCoordinate.y < actualField.NewField.GetLength(1) && CanNextStep(new Coordinate(RealtimeCoordinate.x, RealtimeCoordinate.y - 1)))
            {
                actualField.NewField[RealtimeCoordinate.x, RealtimeCoordinate.y] = " ";
                if (actualField.NewField[RealtimeCoordinate.x, RealtimeCoordinate.y - 1] == "*")
                {
                    stars++;
                }
                actualField.NewField[RealtimeCoordinate.x, RealtimeCoordinate.y - 1] = pacman_img;
                RealtimeCoordinate.y--;
                return true;
            }
            else if (RealtimeCoordinate.y == 0 && CanNextStep(new Coordinate(RealtimeCoordinate.x, actualField.NewField.GetLength(1) - 1)))
            {
                actualField.NewField[RealtimeCoordinate.x, RealtimeCoordinate.y] = " ";
                if (actualField.NewField[RealtimeCoordinate.x, actualField.NewField.GetLength(1) - 1] == "*")
                {
                    stars++;
                }
                actualField.NewField[RealtimeCoordinate.x, actualField.NewField.GetLength(1) - 1] = pacman_img;
                RealtimeCoordinate.y = actualField.NewField.GetLength(1) - 1;
                return true;
            }
            return false;

        }

    }
}
