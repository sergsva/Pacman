using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pacman
{

    

   /* class MovinginArray
    {

        private int size_str;
        private int size_col;
        private Coordinate MyValue;
        private char[,] Arr;
        public char valueForArray;
        public char valueForCell;


              //Конструктор: создаем массив, заполняем его и ставим наш перемешающийся элемент
        public MovinginArray(int _size = 10, int _size1 = 10)
        {
            if (_size > 1 && _size1 > 1)
            {
                size_str = _size;
                size_col = _size1;
            }
            else
            {
                size_str = 10;
                size_col = 10;
            }

            valueForCell = '0';
            valueForArray = ' ';
            MyValue = new Coordinate();
            MyValue.x = MyValue.y = 0;
            Arr = new char[size_str, size_col];
            for (int i = 0; i < size_str; i++)
            {
                for (int j = 0; j < size_col; j++)
                {
                    Arr[i, j] = valueForArray;
                }
            }
            Arr[MyValue.x, MyValue.y] = valueForCell;
        }

        //Метод для смены символов, которыми заполнено поле и смены активного элемента
        public void WriteArrValueAndMyValue(char valueFA, char valueFC)
        {
            if (valueFA != valueFC)
            {
                valueForArray = valueFA;
                valueForCell = valueFC;
                for (int i = 0; i < size_str; i++)
                {
                    for (int j = 0; j < size_col; j++)
                    {
                        Arr[i, j] = valueForArray;
                    }
                }
                Arr[MyValue.x, MyValue.y] = valueForCell;
            }

        }
        //Метод смены расположения активного элемента
        public void ChangeStartingPoint(Coordinate Obj)
        {
            Arr[Obj.x, Obj.y] = Arr[MyValue.x, MyValue.y];
            Arr[MyValue.x, MyValue.y] = valueForArray;
            MyValue.x = Obj.x;
            MyValue.y = Obj.y;

        }

        //Метод смещения вверх
        public void GoUp()
        {
            if (MyValue.x > 0 && MyValue.x < size_str)
            {
                ChangeStartingPoint(MakeCoordinate(MyValue.x - 1, MyValue.y));
            }
            else if (MyValue.x == 0)
            {
                ChangeStartingPoint(MakeCoordinate(size_str - 1, MyValue.y));
            }
        }

        //Метод смещения вниз
        public void GoDown()
        {
            if (MyValue.x < size_str - 1 && MyValue.x >= 0)
            {
                ChangeStartingPoint(MakeCoordinate(MyValue.x + 1, MyValue.y));
            }
            else if (MyValue.x == size_str - 1)
            {
                ChangeStartingPoint(MakeCoordinate(0, MyValue.y));
            }
        }

        //Метод смещения вправо
        public void GoRight()
        {
            if (MyValue.y >= 0 && MyValue.y < size_col - 1)
            {
                ChangeStartingPoint(MakeCoordinate(MyValue.x, MyValue.y + 1));
            }
            else if (MyValue.y == size_col - 1)
            {
                ChangeStartingPoint(MakeCoordinate(MyValue.x, 0));
            }
        }

        //Метод смещения влево
        public void GoLeft()
        {
            if (MyValue.y > 0 && MyValue.y < size_col)
            {
                ChangeStartingPoint(MakeCoordinate(MyValue.x, MyValue.y - 1));
            }
            else if (MyValue.y == 0)
            {
                ChangeStartingPoint(MakeCoordinate(MyValue.x, size_col - 1));
            }
        }

        //Метод вывода
        public void Print()
        {
            for (int i = 0; i < size_str; i++)
            {
                for (int j = 0; j < size_col; j++)
                {
                    Console.Write(Arr[i, j]);

                }
                Console.WriteLine();
            }


        }
    };*/


    class Program
    {
        static void Main(string[] args)
        {
            GamePacman newGame = new GamePacman();
            newGame.SetPacman(true);
              ConsoleKeyInfo keyInfo2;
              Console.Clear();
              newGame.Print();
              keyInfo2 = Console.ReadKey();
                 do
                 {
                    
                     switch (keyInfo2.Key)
                     {
                         case ConsoleKey.DownArrow:
                         case ConsoleKey.NumPad2:
                         case ConsoleKey.S:
                             do
                             {
                                 Thread.Sleep(400);
                                 Console.Clear();
                                 newGame.Print();
                                 if (Console.KeyAvailable)
                                 {
                                     keyInfo2 = Console.ReadKey(true);
                                     break;
                                 }
                                
                             } while (newGame.GoDown());
                            
                             break;

                         case ConsoleKey.LeftArrow:
                         case ConsoleKey.NumPad4:
                         case ConsoleKey.A:
                            
                             do
                             {
                                 Thread.Sleep(400);
                                 Console.Clear();
                                 newGame.Print();
                                 if (Console.KeyAvailable)
                                 {
                                     keyInfo2 = Console.ReadKey(true);
                                     break;
                                 }
                                
                             } while ( newGame.GoLeft());
                             break;

                         case ConsoleKey.RightArrow:
                         case ConsoleKey.NumPad6:
                         case ConsoleKey.D:

                             do
                             {
                                 Thread.Sleep(400);
                                 Console.Clear();
                                 newGame.Print();
                                 if (Console.KeyAvailable)
                                 {
                                     keyInfo2 = Console.ReadKey(true);
                                     break;
                                 }
                                
                             } while (newGame.GoRight());
                           
                             break;

                         case ConsoleKey.UpArrow:
                         case ConsoleKey.NumPad8:
                         case ConsoleKey.W:
                             do
                             {
                                 Thread.Sleep(400);
                                 Console.Clear();
                                 newGame.Print();
                                 if (Console.KeyAvailable)
                                 {
                                     keyInfo2 = Console.ReadKey(true);
                                     break;
                                 }
                                
                             } while (newGame.GoUp());
                           
                             break;
                     }
                 } while (keyInfo2.Key != ConsoleKey.Escape);




        }
    }
}
