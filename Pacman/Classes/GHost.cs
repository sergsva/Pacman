using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class GHost : ICharacterActivity
    {
        public delegate bool Moove();
        public Moove Go; // обратный вызов для движения приведений, меняем указатели на методы по ходу игры 
        public void INeedRoute(Moove method)
        {
            Go = new Moove(method);

        }

        public Coordinate RealtimeCoordinate;
        public Coordinate PreviousCoordinate;
        public string ghost_img { get; private set; }
        public string previousValue;
        private string currMethodName;
        private Field actualField;

        public GHost(Field _actualField)
        {
            try
            {
                actualField = _actualField;
                if (actualField == null)    throw new Exception("Null reference Field in ctor GHost");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                System.Environment.Exit(0);
            }
            ghost_img = "&";
        }

        public void BreakDeadLock(Coordinate PacmanCoord) // выбор маршрута в случае попадания в углы, антиблок
        {
            try
            {
                if (PacmanCoord.x < 0 || PacmanCoord.x > 24 || PacmanCoord.y < 0 || PacmanCoord.y > 24) throw new Exception("Coordinate for method GHost.BreakDeadLock IndexOutOfRangeException");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                System.Environment.Exit(0);
            }

            if ((currMethodName == "GoLeft" || currMethodName == "GoRight") && PacmanCoord.x < RealtimeCoordinate.x)
            {
                INeedRoute(GoUp); return;
            }
            if ((currMethodName == "GoLeft" || currMethodName == "GoRight") && PacmanCoord.x >RealtimeCoordinate.x)
            {
                INeedRoute(GoDown); return;
            }
            if ((currMethodName == "GoUp" || currMethodName == "GoDown") && PacmanCoord.y < RealtimeCoordinate.y)
            {
                INeedRoute(GoLeft); return;
            }
            if ((currMethodName == "GoUp" || currMethodName == "GoDown") && PacmanCoord.y > RealtimeCoordinate.y)
            {
                INeedRoute(GoRight); return;
            }
            if (CanNextStep(new Coordinate(RealtimeCoordinate.x-1,RealtimeCoordinate.y)))
            {
                 INeedRoute(GoUp); return;
            }
             if (CanNextStep(new Coordinate(RealtimeCoordinate.x+1,RealtimeCoordinate.y)))
            {
                 INeedRoute(GoDown); return;
            }
             if (CanNextStep(new Coordinate(RealtimeCoordinate.x,RealtimeCoordinate.y-1)))
            {
                 INeedRoute(GoLeft); return;
            }
          
                 INeedRoute(GoRight); return;
        }


         public void DetermRoute(Coordinate PacmanCoord) // выбор маршрута для приведения при прохождении перекрестков в игре в зависимости от расположения pacman (взято из оригинала)
         {
             try
             {
                 if (PacmanCoord.x < 0 || PacmanCoord.x > 24 || PacmanCoord.y < 0 || PacmanCoord.y > 24) throw new Exception("Coordinate for method GHost.DetermRoute IndexOutOfRangeException");
             }
             catch (Exception e)
             {
                 Console.WriteLine(e.Message);
                 System.Environment.Exit(0);
             }
  if ((
(RealtimeCoordinate.x == 7 && RealtimeCoordinate.y == 1)||
(RealtimeCoordinate.x == 12 && RealtimeCoordinate.y == 1)||
(RealtimeCoordinate.x == 17 && RealtimeCoordinate.y == 1)||
(RealtimeCoordinate.x == 7 && RealtimeCoordinate.y == 6)||
(RealtimeCoordinate.x == 12 && RealtimeCoordinate.y == 6)||
(RealtimeCoordinate.x == 17 && RealtimeCoordinate.y == 6)||
(RealtimeCoordinate.x == 7 && RealtimeCoordinate.y == 18)||
(RealtimeCoordinate.x == 12 && RealtimeCoordinate.y == 18)||
(RealtimeCoordinate.x == 17 && RealtimeCoordinate.y == 18)||
(RealtimeCoordinate.x == 7 && RealtimeCoordinate.y == 23)||
(RealtimeCoordinate.x == 12 && RealtimeCoordinate.y == 23)||
(RealtimeCoordinate.x == 17 && RealtimeCoordinate.y == 23)||
(RealtimeCoordinate.x == 1 && RealtimeCoordinate.y == 6) || 
(RealtimeCoordinate.x == 23 && RealtimeCoordinate.y == 6) || 
(RealtimeCoordinate.x == 1 && RealtimeCoordinate.y == 18) ||
(RealtimeCoordinate.x == 23 && RealtimeCoordinate.y == 18))
&& (currMethodName == "GoRight" ||currMethodName == "GoLeft"))
             {
                 if (PacmanCoord.x<RealtimeCoordinate.x)
                 {
                     INeedRoute(GoUp); return;
                 }
                 if (PacmanCoord.x > RealtimeCoordinate.x)
                 {
                     INeedRoute(GoDown); return;
                 }
                
             }

if ((
(RealtimeCoordinate.x == 7 && RealtimeCoordinate.y == 1) || 
(RealtimeCoordinate.x == 12 && RealtimeCoordinate.y == 1) || 
(RealtimeCoordinate.x == 17 && RealtimeCoordinate.y == 1) ||
(RealtimeCoordinate.x == 7 && RealtimeCoordinate.y == 23) || 
(RealtimeCoordinate.x == 12 && RealtimeCoordinate.y == 23) || 
(RealtimeCoordinate.x == 17 && RealtimeCoordinate.y == 23))
&& (currMethodName == "GoUp" || currMethodName == "GoDown") )
             {
                 if (PacmanCoord.y < RealtimeCoordinate.y)
                 {
                     INeedRoute(GoLeft); return;
                 }
                 if (PacmanCoord.y > RealtimeCoordinate.y)
                 {
                     INeedRoute(GoRight); return;
                 }

             }



 if ((
(RealtimeCoordinate.x == 7 && RealtimeCoordinate.y == 6) || 
(RealtimeCoordinate.x == 12 && RealtimeCoordinate.y == 6) || 
(RealtimeCoordinate.x == 17 && RealtimeCoordinate.y == 6) ||
(RealtimeCoordinate.x == 7 && RealtimeCoordinate.y == 14) || 
(RealtimeCoordinate.x == 12 && RealtimeCoordinate.y == 14) || 
(RealtimeCoordinate.x == 17 && RealtimeCoordinate.y == 14) ||
(RealtimeCoordinate.x == 9 && RealtimeCoordinate.y == 10) ||
(RealtimeCoordinate.x == 15 && RealtimeCoordinate.y == 10) ||
(RealtimeCoordinate.x == 9 && RealtimeCoordinate.y == 17) || 
(RealtimeCoordinate.x == 15 && RealtimeCoordinate.y == 17)
)
&& (currMethodName == "GoUp" || currMethodName == "GoDown") )
             {
                 if (PacmanCoord.y < RealtimeCoordinate.y)
                 {
                     INeedRoute(GoLeft); return;
                 }

             }




 if ((
 (RealtimeCoordinate.x == 9 && RealtimeCoordinate.y == 6) || 
 (RealtimeCoordinate.x == 15 && RealtimeCoordinate.y == 6) ||
 (RealtimeCoordinate.x == 7 && RealtimeCoordinate.y == 10) || 
 (RealtimeCoordinate.x == 12 && RealtimeCoordinate.y == 10) || 
 (RealtimeCoordinate.x == 17 && RealtimeCoordinate.y == 10) ||
 (RealtimeCoordinate.x == 9 && RealtimeCoordinate.y == 14) || 
 (RealtimeCoordinate.x == 15 && RealtimeCoordinate.y == 14) ||
  (RealtimeCoordinate.x == 7 && RealtimeCoordinate.y == 18) || 
  (RealtimeCoordinate.x == 12 && RealtimeCoordinate.y == 18) || 
  (RealtimeCoordinate.x == 17 && RealtimeCoordinate.y == 18)
 )
 && (currMethodName == "GoUp" || currMethodName == "GoDown"))
 {
     if (PacmanCoord.y > RealtimeCoordinate.y)
     {
         INeedRoute(GoRight); return;
     }

 }
}


        public bool CanNextStep(Coordinate coord) // проверка на возможность хода
        {
            try
            {
                if (coord.x < 0 || coord.x > 24 || coord.y < 0 || coord.y > 24) throw new Exception("Coordinate for method GHost.CanNextStep IndexOutOfRangeException");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                System.Environment.Exit(0);
            }

            if (actualField.NewField[coord.x, coord.y] != "_" && actualField.NewField[coord.x, coord.y] != "-" && actualField.NewField[coord.x, coord.y] != "|" && actualField.NewField[coord.x, coord.y] != ghost_img)
            {
                return true;
            }
            return false;
        }



        //Метод смещения вверх
        public bool GoUp()
        {
            currMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            if (RealtimeCoordinate.x > 0 && RealtimeCoordinate.x < actualField.NewField.GetLength(0) && CanNextStep(new Coordinate(RealtimeCoordinate.x - 1, RealtimeCoordinate.y)))
            {
                actualField.NewField[RealtimeCoordinate.x, RealtimeCoordinate.y] = previousValue;
                previousValue = actualField.NewField[RealtimeCoordinate.x - 1, RealtimeCoordinate.y];
                actualField.NewField[RealtimeCoordinate.x - 1, RealtimeCoordinate.y] = ghost_img;
                RealtimeCoordinate.x--;
                return true;
            }
            else if (RealtimeCoordinate.x == 0 && CanNextStep(new Coordinate(actualField.NewField.GetLength(0) - 1, RealtimeCoordinate.y)))
            {
                actualField.NewField[RealtimeCoordinate.x, RealtimeCoordinate.y] = previousValue;
                previousValue = actualField.NewField[actualField.NewField.GetLength(0) - 1, RealtimeCoordinate.y];
                actualField.NewField[actualField.NewField.GetLength(0) - 1, RealtimeCoordinate.y] = ghost_img;
                RealtimeCoordinate.x = actualField.NewField.GetLength(0) - 1;
                return true;
            }
            return false;
        }

        //Метод смещения вниз
        public bool GoDown()
        {
            currMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            if (RealtimeCoordinate.x < actualField.NewField.GetLength(0) - 1 && RealtimeCoordinate.x >= 0 && CanNextStep(new Coordinate(RealtimeCoordinate.x + 1, RealtimeCoordinate.y)))
            {
                actualField.NewField[RealtimeCoordinate.x, RealtimeCoordinate.y] = previousValue;
                previousValue = actualField.NewField[RealtimeCoordinate.x + 1, RealtimeCoordinate.y];
                actualField.NewField[RealtimeCoordinate.x + 1, RealtimeCoordinate.y] = ghost_img;
                RealtimeCoordinate.x++;
                return true;
            }
            else if (RealtimeCoordinate.x == actualField.NewField.GetLength(0) - 1 && CanNextStep(new Coordinate(0, RealtimeCoordinate.y)))
            {
                actualField.NewField[RealtimeCoordinate.x, RealtimeCoordinate.y] = previousValue;
                previousValue = actualField.NewField[0, RealtimeCoordinate.y];
                actualField.NewField[0, RealtimeCoordinate.y] = ghost_img;
                RealtimeCoordinate.x = 0;
                return true;
            }
            return false;
        }

        //Метод смещения вправо
        public bool GoRight()
        {
            currMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            if (RealtimeCoordinate.y >= 0 && RealtimeCoordinate.y < actualField.NewField.GetLength(1) - 1 && CanNextStep(new Coordinate(RealtimeCoordinate.x, RealtimeCoordinate.y + 1)))
            {
                actualField.NewField[RealtimeCoordinate.x, RealtimeCoordinate.y] = previousValue;
                previousValue = actualField.NewField[RealtimeCoordinate.x, RealtimeCoordinate.y + 1];
                actualField.NewField[RealtimeCoordinate.x, RealtimeCoordinate.y + 1] = ghost_img;
                RealtimeCoordinate.y++;
                return true;
            }
            else if (RealtimeCoordinate.y == actualField.NewField.GetLength(1) - 1 && CanNextStep(new Coordinate(RealtimeCoordinate.x, 0)))
            {
                actualField.NewField[RealtimeCoordinate.x, RealtimeCoordinate.y] = previousValue;
                previousValue = actualField.NewField[RealtimeCoordinate.x, 0];
                actualField.NewField[RealtimeCoordinate.x, 0] = ghost_img;
                RealtimeCoordinate.y = 0;
                return true;
            }
            return false;
        }

        //Метод смещения влево
        public bool GoLeft()
        {
            currMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            if (RealtimeCoordinate.y > 0 && RealtimeCoordinate.y < actualField.NewField.GetLength(1) && CanNextStep(new Coordinate(RealtimeCoordinate.x, RealtimeCoordinate.y - 1)))
            {
                actualField.NewField[RealtimeCoordinate.x, RealtimeCoordinate.y] = previousValue;
                actualField.NewField[RealtimeCoordinate.x, RealtimeCoordinate.y - 1] = ghost_img;
                RealtimeCoordinate.y--;
                return true;
            }
            else if (RealtimeCoordinate.y == 0 && CanNextStep(new Coordinate(RealtimeCoordinate.x, actualField.NewField.GetLength(1) - 1)))
            {
                actualField.NewField[RealtimeCoordinate.x, RealtimeCoordinate.y] = previousValue;
                actualField.NewField[RealtimeCoordinate.x, actualField.NewField.GetLength(1) - 1] = ghost_img;
                RealtimeCoordinate.y = actualField.NewField.GetLength(1) - 1;
                return true;
            }
            return false;

        }
    }
}
