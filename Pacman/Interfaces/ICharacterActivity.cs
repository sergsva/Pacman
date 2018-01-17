using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    interface ICharacterActivity
    {
       
        bool CanNextStep(Coordinate coord); // Проверка возможн-и сделать шаг в эту точку

        bool GoUp(); //Метод смещения вверх

        bool GoDown();   //Метод смещения вниз

        bool GoRight();//Метод смещения вправо

        bool GoLeft();//Метод смещения влево
     

    }
}
