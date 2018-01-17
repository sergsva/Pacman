using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public struct Coordinate
    {
        public int x;
        public int y;

        public Coordinate(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

    };

   public  class GamePacman
    {
        private Coordinate Value;
        private string[,] Field;
        public string Pacman;
        public GamePacman()
        {
Field = new string [,] {
{"|","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","|"},
{"|","*","*","*","*","*","*","|","*","|","*","|"," ","|","*","|","*","|","*","*","*","*","*","*","|"},
{"|","*","-","-","-","-","*","|","*","|","*","|"," ","|","*","|","*","|","*","-","-","-","-","*","|"},
{"|","*","|"," "," ","|","*","*","*","*","*","|"," ","|","*","*","*","*","*","|"," "," ","|","*","|"},
{"|","*","|"," "," ","|","*","|","*","|","*","|"," ","|","*","|","*","|","*","|"," "," ","|","*","|"},
{"|","*","|"," "," ","|","*","|","*","|","*","|"," ","|","*","|","*","|","*","|"," "," ","|","*","|"},
{"|","*","-","-","-","-","*","|","*","|","*","-","-","-","*","|","*","|","*","-","-","-","-","*","|"},
{"|","*","*","*","*","*","*","*","*","|","*","*","*","*","*","|","*","*","*","*","*","*","*","*","|"},
{"-","-","-","-","-","-","*","|","*","|","*","*","|","*","*","|","*","|","*","-","-","-","-","-","-"},
{"|"," "," "," "," ","|","*","*","*","*","*","*","|","*","*","*","*","*","*","|"," "," "," "," "," "},
{"|"," "," "," "," ","|","*","|","-","-","*","*","|","*","*","-","*","|","*","|"," "," "," "," "," "},
{"-","-","-","-","-","-","*","|"," ","|","*","-","-","-","*","|","*","|","*","-","-","-","-","-","-"},
{"*","*","*","*","*","*","*","|"," ","|","*","*","*","*","*","|","-","|","*","*","*","*","*","*","*"},
{"-","-","-","-","-","-","*","|"," ","|","*","-","-","-","*","|","*","|","*","-","-","-","-","-","-"},
{"|"," "," "," "," ","|","*","|","-","-","*","*","|","*","*","-","*","|","*","|"," "," "," "," "," "},
{"|"," "," "," "," ","|","*","*","*","*","*","*","|","*","*","*","*","*","*","|"," "," "," "," "," "},
{"-","-","-","-","-","-","*","|","*","|","*","*","|","*","*","|","*","|","*","-","-","-","-","-","-"},
{"|","*","*","*","*","*","*","*","*","|","*","*","*","*","*","|","*","|","*","*","*","*","*","*","|"},
{"|","*","-","-","-","-","*","|","*","|","*","-","-","-","*","|","*","|","*","-","-","-","-","*","|"},
{"|","*","|"," "," ","|","*","|","*","|","*","|"," ","|","*","|","*","|","*","|"," "," ","|","*","|"},
{"|","*","|"," "," ","|","*","|","*","|","*","|"," ","|","*","|","*","|","*","|"," "," ","|","*","|"},
{"|","*","|"," "," ","|","*","*","*","*","*","|"," ","|","*","*","*","*","*","|"," "," ","|","*","|"},
{"|","*","-","-","-","-","*","|","*","|","*","|"," ","|","*","|","*","|","*","-","-","-","-","*","|"},
{"|","*","*","*","*","*","*","|","*","|","*","|"," ","|","*","|","*","|","*","*","*","*","*","*","|"},
{"|","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","|"}
};
Pacman = "C";

Print();
        }


        //Установка pacman
        public void SetPacman(bool flag) 
        {
            if (flag)
            {
                Random rand = new Random();
                int x, y;
                do
                {
                    x = rand.Next(Field.GetLength(0) - 1);
                    y = rand.Next(Field.GetLength(1) - 1);

                } while (Field[x, y] != "*");

                Field[x, y] = Pacman;
                Value = new Coordinate(x, y);
               
            }
            else
            {
                Value = new Coordinate(1, 1);
                Field[Value.x, Value.y] = Pacman;
            }
        }

       public bool CanStep(Coordinate coord)
        {
            if (Field[coord.x,coord.y]!="_" && Field[coord.x,coord.y]!="-" && Field[coord.x,coord.y]!="|")
            {
                return true;
            }
            return false;

        }

        //Метод смещения вверх
        public bool GoUp()
        {
            if (Value.x > 0 && Value.x < Field.GetLength(0) && CanStep(new Coordinate(Value.x - 1, Value.y)))
            {
                Field[Value.x, Value.y] = " ";
                Field[Value.x - 1, Value.y] = Pacman;
                Value.x--;
                return true;
            }
            else if (Value.x == 0 && CanStep(new Coordinate(Field.GetLength(0) - 1, Value.y)))
            {
                Field[Value.x, Value.y] = " ";
                Field[Field.GetLength(0) - 1, Value.y] = Pacman;
                Value.x = Field.GetLength(0) - 1;
                return true;
            }
            return false;
        }

        //Метод смещения вниз
        public bool GoDown()
        {
            if (Value.x < Field.GetLength(0) - 1 && Value.x >=0 && CanStep(new Coordinate(Value.x + 1, Value.y)))
            {
                Field[Value.x, Value.y] = " ";
                Field[Value.x + 1, Value.y] = Pacman;
                Value.x++;
                return true;
            }
            else if (Value.x == Field.GetLength(0) - 1 && CanStep(new Coordinate(0, Value.y)))
            {
                Field[Value.x, Value.y] = " ";
                Field[0, Value.y] = Pacman;
                Value.x = 0;
                return true;
            }
            return false;
        }

        //Метод смещения вправо
        public bool GoRight()
        {
            if (Value.y >= 0 && Value.y < Field.GetLength(1) - 1 && CanStep(new Coordinate(Value.x, Value.y + 1)))
            {
                Field[Value.x, Value.y] = " ";
                Field[Value.x, Value.y + 1] = Pacman;
                Value.y++;
                return true;
            }
            else if (Value.y == Field.GetLength(1) - 1 && CanStep(new Coordinate(Value.x, 0)))
            {
                Field[Value.x, Value.y] = " ";
                Field[Value.x, 0] = Pacman;
                Value.y = 0;
                return true;
            }
            return false;
        }

        //Метод смещения влево
        public bool GoLeft()
        {
            if (Value.y > 0 && Value.y < Field.GetLength(1) && CanStep(new Coordinate(Value.x, Value.y - 1)))
            {
                Field[Value.x, Value.y] = " ";
                Field[Value.x, Value.y - 1] = Pacman;
                Value.y--;
                return true;
            }
            else if (Value.y == 0 && CanStep(new Coordinate(Value.x, Field.GetLength(1)-1)))
            {
                Field[Value.x, Value.y] = " ";
                Field[Value.x, Field.GetLength(1)-1] = Pacman;
                Value.y = Field.GetLength(1)-1;
                return true;
            }
            return false;

        }

        //Метод вывода
        public void Print()
        {
            Console.WindowHeight = 40;
            Console.WindowWidth = 130;
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    if (Field[i, j] == "|" || Field[i, j] == "_" || Field[i, j] == "-")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.Write(Field[i, j]);
                    Console.Write("    ");
                }
                Console.WriteLine();
            }

        }


    }
}
