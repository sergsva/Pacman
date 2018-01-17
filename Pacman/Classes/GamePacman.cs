using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

   public class GamePacman
    {
       public Field gameField;
       public Pacman pacman;
       public List<GHost> ghosts;
       public int score;
       public int lives;

       public GamePacman(int _lives, int _ghosts) //кол-во жизней pacman, кол-во привидений в игре
        {
            Console.WindowHeight = 40;
            Console.WindowWidth = 148;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(50);
            Console.WriteLine();
            Thread.Sleep(50);
            Console.WriteLine();
            Thread.Sleep(50);
            Console.WriteLine();
            Thread.Sleep(50);
            Console.WriteLine();
            Thread.Sleep(50);
            Console.WriteLine();
            Thread.Sleep(50);
            Console.WriteLine();
            Thread.Sleep(50);
            Console.WriteLine();
Console.WriteLine("PPPPPPPPPPPPPPPPP        AAA                  CCCCCCCCCCCCCMMMMMMMM               MMMMMMMM               AAA               NNNNNNNN        NNNNNNNN");
Thread.Sleep(200);
Console.WriteLine("P::::::::::::::::P      A:::A              CCC::::::::::::CM:::::::M             M:::::::M              A:::A              N:::::::N       N::::::N");
Thread.Sleep(200);
Console.WriteLine("P::::::PPPPPP:::::P    A:::::A           CC:::::::::::::::CM::::::::M           M::::::::M             A:::::A             N::::::::N      N::::::N");
Thread.Sleep(200);
Console.WriteLine("PP:::::P     P:::::P  A:::::::A         C:::::CCCCCCCC::::CM:::::::::M         M:::::::::M            A:::::::A            N:::::::::N     N::::::N");
Thread.Sleep(200);
Console.WriteLine("  P::::P     P:::::P A:::::::::A       C:::::C       CCCCCCM::::::::::M       M::::::::::M           A:::::::::A           N::::::::::N    N::::::N");
Thread.Sleep(200);
Console.WriteLine("  P::::P     P:::::PA:::::A:::::A     C:::::C              M:::::::::::M     M:::::::::::M          A:::::A:::::A          N:::::::::::N   N::::::N");
Thread.Sleep(200);
Console.WriteLine("  P::::PPPPPP:::::PA:::::A A:::::A    C:::::C              M:::::::M::::M   M::::M:::::::M         A:::::A A:::::A         N:::::::N::::N  N::::::N");
Thread.Sleep(200);
Console.WriteLine("  P:::::::::::::PPA:::::A   A:::::A   C:::::C              M::::::M M::::M M::::M M::::::M        A:::::A   A:::::A        N::::::N N::::N N::::::N");
Thread.Sleep(200);
Console.WriteLine("  P::::PPPPPPPPP A:::::A     A:::::A  C:::::C              M::::::M  M::::M::::M  M::::::M       A:::::A     A:::::A       N::::::N  N::::N:::::::N");
Thread.Sleep(200);
Console.WriteLine("  P::::P        A:::::AAAAAAAAA:::::A C:::::C              M::::::M   M:::::::M   M::::::M      A:::::AAAAAAAAA:::::A      N::::::N   N:::::::::::N");
Thread.Sleep(200);
Console.WriteLine("  P::::P       A:::::::::::::::::::::AC:::::C              M::::::M    M:::::M    M::::::M     A:::::::::::::::::::::A     N::::::N    N::::::::::N");
Thread.Sleep(200);
Console.WriteLine("  P::::P      A:::::AAAAAAAAAAAAA:::::AC:::::C       CCCCCCM::::::M     MMMMM     M::::::M    A:::::AAAAAAAAAAAAA:::::A    N::::::N     N:::::::::N");
Thread.Sleep(200);
Console.WriteLine("PP::::::PP   A:::::A             A:::::AC:::::CCCCCCCC::::CM::::::M               M::::::M   A:::::A             A:::::A   N::::::N      N::::::::N");
Thread.Sleep(200);
Console.WriteLine("P::::::::P  A:::::A               A:::::ACC:::::::::::::::CM::::::M               M::::::M  A:::::A               A:::::A  N::::::N       N:::::::N");
Thread.Sleep(200);
Console.WriteLine("P::::::::P A:::::A                 A:::::A CCC::::::::::::CM::::::M               M::::::M A:::::A                 A:::::A N::::::N        N::::::N");
Thread.Sleep(200);
Console.WriteLine("PPPPPPPPPPAAAAAAA                   AAAAAAA   CCCCCCCCCCCCCMMMMMMMM               MMMMMMMMAAAAAAA                   AAAAAAANNNNNNNN         NNNNNNN");
Console.WriteLine();
Console.WriteLine("Use the arrow keys to play!");
Console.WriteLine();
Console.WriteLine("Press ANY key to continue");
Console.WriteLine("Esc - exit");
ConsoleKeyInfo keyInfo2;
keyInfo2 = Console.ReadKey();
switch (keyInfo2.Key)
{
    case ConsoleKey.Escape:
        System.Environment.Exit(0);
        break;

    default:
        Console.WriteLine("\t\t\t|");
gameField = new Field();
pacman = new Pacman(gameField);

score = 0;

if (_lives > 0 && _lives < 5)
{
    lives = _lives;
}
else
{
    lives = 2;
}

if (_ghosts > 0 && _ghosts < 5)
{
    ghosts = new List<GHost>();
    for (int i = 0; i < _ghosts; i++)
    {
        ghosts.Add(new GHost(gameField));
    }
}
else
{
    ghosts = new List<GHost>() { new GHost(gameField), new GHost(gameField) };
}
SetGhosts();
        break;
}

       
       }


        //Установка pacman
        public void SetPacman(bool flag) // Установка на игровом поле 0 - default, 1 - random 
        {
            if (flag)
            {
               int x, y;
                do
                {
                    x = Program.rand.Next(gameField.NewField.GetLength(0) - 1);
                    y = Program.rand.Next(gameField.NewField.GetLength(1) - 1);

                } while (gameField.NewField[x, y] != "*");

                gameField.NewField[x, y] = pacman.pacman_img;
                pacman.RealtimeCoordinate = new Coordinate(x, y);
               
            }
            else
            {
                pacman.RealtimeCoordinate = new Coordinate(1, 1);
                gameField.NewField[pacman.RealtimeCoordinate.x, pacman.RealtimeCoordinate.y] = pacman.pacman_img;
            }
        }

       //Установка привидений на игровом поле (в их место)
        private void SetGhosts() 
        {
            int count = ghosts.Count;
            int i = 1;
            while (count > 0)
            {
                   ghosts[count - 1].RealtimeCoordinate = new Coordinate(0 + i, 12);
                   gameField.NewField[ghosts[count - 1].RealtimeCoordinate.x, ghosts[count - 1].RealtimeCoordinate.y] = ghosts[count - 1].ghost_img;

                count--;
                i++;
            }
        }

       //Выход привидения на игровое поле
        public void StartGhost(GHost ghost, Coordinate pacmanCoord)
        {
            try
            {
                if (pacmanCoord.x < 0 || pacmanCoord.x > 24|| pacmanCoord.y < 0 || pacmanCoord.y > 24) throw new Exception("PacmanCoord for method GamePacman.StartGhost IndexOutOfRangeException");
                if (ghost==null)throw new Exception("Null reference ghost in  GamePacman.StartGhost");
                        
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                System.Environment.Exit(0);
            }

            if (pacmanCoord.x != 7 && pacmanCoord.y != 12)
            {
                gameField.NewField[ghost.RealtimeCoordinate.x, ghost.RealtimeCoordinate.y] = " ";
                ghost.RealtimeCoordinate = new Coordinate(7, 12);            
                ghost.previousValue = gameField.NewField[ghost.RealtimeCoordinate.x, ghost.RealtimeCoordinate.y];
                gameField.NewField[ghost.RealtimeCoordinate.x, ghost.RealtimeCoordinate.y] = ghost.ghost_img;
                Console.Clear();
                gameField.Print(score, lives);
            }
            else
            {
                ghost.RealtimeCoordinate = new Coordinate(7, 10);          
                ghost.previousValue = gameField.NewField[ghost.RealtimeCoordinate.x, ghost.RealtimeCoordinate.y];
                gameField.NewField[ghost.RealtimeCoordinate.x, ghost.RealtimeCoordinate.y] = ghost.ghost_img;
            }

            if (pacmanCoord.y <= 12)
            {
                ghost.INeedRoute(ghost.GoLeft);
                
            }
            else
            {
                ghost.INeedRoute(ghost.GoRight);
            }

        }

       //Возвращает кол-во оставшихся звезд на поле
       public int GetCountStarsInField()
        {
            int count = 0;
            for (int i = 0; i < gameField.NewField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.NewField.GetLength(1); j++)
                {
                    if (gameField.NewField[i, j] == "*") count++;
                }
            }

            return count;
       }

       //Метод проверки статуса игры
      public void GameStatus(int counter)
       {
           score = pacman.stars * 100;
           for (int i = 0; i < counter; i++)
           {
               if (
         (ghosts[i].RealtimeCoordinate.x - 1 == pacman.RealtimeCoordinate.x && ghosts[i].RealtimeCoordinate.y == pacman.RealtimeCoordinate.y) ||
         (ghosts[i].RealtimeCoordinate.x + 1 == pacman.RealtimeCoordinate.x && ghosts[i].RealtimeCoordinate.y == pacman.RealtimeCoordinate.y) ||
         (ghosts[i].RealtimeCoordinate.x == pacman.RealtimeCoordinate.x && ghosts[i].RealtimeCoordinate.y - 1 == pacman.RealtimeCoordinate.y) ||
         (ghosts[i].RealtimeCoordinate.x == pacman.RealtimeCoordinate.x && ghosts[i].RealtimeCoordinate.y + 1 == pacman.RealtimeCoordinate.y) ||
                   (ghosts[i].RealtimeCoordinate.x == pacman.RealtimeCoordinate.x && ghosts[i].RealtimeCoordinate.y == pacman.RealtimeCoordinate.y)
     )
               {

                   gameField.NewField[pacman.RealtimeCoordinate.x, pacman.RealtimeCoordinate.y] = "+";
                   Console.Clear();
                   gameField.Print(score, lives);
                   lives--;
                   if (lives == 0)
                   {
                       Console.WriteLine("\n\nGAME OVER");
                       System.Environment.Exit(0);
                   }
                   else
                   {
                       gameField.NewField[pacman.RealtimeCoordinate.x, pacman.RealtimeCoordinate.y] = " ";
                       SetPacman(false);

                   }

               }

           }
           if (GetCountStarsInField() == 0)
           {
               Console.WriteLine("\n\nPLAYER WIN");
               System.Environment.Exit(0);
           }



       }

       //Запуск игры
    public void Start()
        {
            int timer = 0;
            int counter = 0;
            ConsoleKeyInfo keyInfo2, keyTemp;
            Console.Clear();
            gameField.Print(score, lives);
            do
            {
                   keyInfo2 = Console.ReadKey(true);
           } while (keyInfo2.Key != ConsoleKey.LeftArrow && keyInfo2.Key != ConsoleKey.DownArrow && keyInfo2.Key != ConsoleKey.RightArrow && keyInfo2.Key != ConsoleKey.UpArrow);
           
            keyTemp = keyInfo2;
            do
            {
               
                if (timer++ % 20==0)
                {
                    if (counter<ghosts.Count)
                    {
                        StartGhost(ghosts[counter++], pacman.RealtimeCoordinate);
                    }
                    
                }

             
                switch (keyInfo2.Key)
                {
                    case ConsoleKey.DownArrow:
                    do
                        {
                            keyTemp = keyInfo2;
                            Thread.Sleep(250);
                            GameStatus(counter);
                            for (int i = 0; i < counter; i++)
                            {
                                ghosts[i].DetermRoute(pacman.RealtimeCoordinate);
                                 if (!ghosts[i].Go())
                                {
                                    ghosts[i].BreakDeadLock(pacman.RealtimeCoordinate);
                                }
                            }
                                                      
                            Console.Clear();
                            gameField.Print(score, lives);
                            if (Console.KeyAvailable)
                            {
                               
                               keyInfo2 = Console.ReadKey(true);
                                break;
                            }

                        } while (pacman.GoDown());

                        break;

                    case ConsoleKey.LeftArrow:
                        do
                        {
                            keyTemp = keyInfo2;
                            Thread.Sleep(250);
                            GameStatus(counter);
                            for (int i = 0; i < counter; i++)
                            {
                                ghosts[i].DetermRoute(pacman.RealtimeCoordinate);
                                if (!ghosts[i].Go())
                                {
                                    ghosts[i].BreakDeadLock(pacman.RealtimeCoordinate);
                                }
                            }
                            Console.Clear();
                            gameField.Print(score, lives);
                            if (Console.KeyAvailable)
                            {
                                keyInfo2 = Console.ReadKey(true);
                                break;
                            }

                        } while (pacman.GoLeft());
                        break;

                    case ConsoleKey.RightArrow:
                        do
                        {
                            keyTemp = keyInfo2;
                            Thread.Sleep(250);
                            GameStatus(counter);
                            for (int i = 0; i < counter; i++)
                            {
                                ghosts[i].DetermRoute(pacman.RealtimeCoordinate);
                                if (!ghosts[i].Go())
                                {
                                    ghosts[i].BreakDeadLock(pacman.RealtimeCoordinate);
                                }
                            }
                            Console.Clear();
                            gameField.Print(score, lives);
                            if (Console.KeyAvailable)
                            {
                                keyInfo2 = Console.ReadKey(true);
                                break;
                            }

                        } while (pacman.GoRight());

                        break;

                    case ConsoleKey.UpArrow:
                        do
                        {
                            keyTemp = keyInfo2;
                            Thread.Sleep(250);
                            GameStatus(counter);
                            for (int i = 0; i < counter; i++)
                            {
                                ghosts[i].DetermRoute(pacman.RealtimeCoordinate);
                                if (!ghosts[i].Go())
                                {
                                    ghosts[i].BreakDeadLock(pacman.RealtimeCoordinate);
                                }
                            }
                            Console.Clear();
                            gameField.Print(score, lives);
                            if (Console.KeyAvailable)
                            {

                                keyInfo2 = Console.ReadKey(true);
                                break;
                            }

                        } while (pacman.GoUp());

                        break;
                    case ConsoleKey.F5:
                        try
                        {
                            FileStream fs = new FileStream("Saved_game.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                            fs.Close();
                            using (StreamWriter sw = new StreamWriter("Saved_game.txt",false))
                            {
                                sw.WriteLine("SCORE: {0}, LIVES {1}",score,lives);
                                for (int i = 0; i < gameField.NewField.GetLength(0); i++)
                                {
                                    for (int j = 0; j < gameField.NewField.GetLength(1); j++)
                                    {
                                        sw.Write(gameField.NewField[i, j]);
                                        sw.Write("    ");
                                    }
                                    sw.WriteLine("");
                                }
                              
                            }
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        keyInfo2 = keyTemp;
                        break;
                    default:
                   keyInfo2 = keyTemp;
                        break;
                }          
            
               

            } while (keyInfo2.Key != ConsoleKey.Escape);



        }

      
    
     


    }
}
