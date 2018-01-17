using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacman;

namespace GamePacmanUnitTests
{
    [TestClass]
    public class PacmanUnitTests
    {
        //Class Pacman Tests
        [TestMethod]
        public void PacmanCanNextStep()
        {
            Field field = new Field();
            Pacman.Pacman pacman = new Pacman.Pacman(field);
            field.NewField[1, 1] = "C";
            field.NewField[1, 2] = "-";
            field.NewField[1, 3] = "|";
            field.NewField[1, 4] = "_";
            Assert.IsFalse(pacman.CanNextStep(new Coordinate(1, 1)));
            Assert.IsFalse(pacman.CanNextStep(new Coordinate(1, 2)));
            Assert.IsFalse(pacman.CanNextStep(new Coordinate(1, 3)));
            Assert.IsFalse(pacman.CanNextStep(new Coordinate(1, 4)));
         }

        [TestMethod]
        public void PacmanGoUp_StarPlus_StarClearInField()
        {
            Field field = new Field();
            Pacman.Pacman pacman = new Pacman.Pacman(field);
            pacman.RealtimeCoordinate = new Coordinate(7, 1);
            field.NewField[7, 1] = "C";
            Assert.IsTrue(pacman.GoUp());
            Assert.AreEqual(" ", field.NewField[7, 1]);
           Assert.AreEqual(1, pacman.stars);         
        }
        [TestMethod]
        public void PacmanNotGoUp_NoStarPlus_NoStarClearInField()
        {
            Field field = new Field();
            Pacman.Pacman pacman = new Pacman.Pacman(field);
            pacman.RealtimeCoordinate = new Coordinate(1, 1);
            field.NewField[1, 1] = "C";
            Assert.IsFalse(pacman.GoUp());
            Assert.AreEqual("C", field.NewField[1, 1]);
            Assert.AreEqual(0, pacman.stars);
        }

        [TestMethod]
        public void PacmanGoLeft_StarPlus_StarClearInField()
        {
            Field field = new Field();
            Pacman.Pacman pacman = new Pacman.Pacman(field);
            pacman.RealtimeCoordinate = new Coordinate(7, 3);
            field.NewField[7, 3] = "C";
            Assert.IsTrue(pacman.GoLeft());
            Assert.AreEqual(" ", field.NewField[7, 3]);
            Assert.AreEqual(1, pacman.stars);
        }

        [TestMethod]
        public void PacmanNotGoLeft_NotStarPlus_NotStarClearInField()
        {
            Field field = new Field();
            Pacman.Pacman pacman = new Pacman.Pacman(field);
            pacman.RealtimeCoordinate = new Coordinate(3, 1);
            field.NewField[3, 1] = "C";
            Assert.IsFalse(pacman.GoLeft());
            Assert.AreEqual("C", field.NewField[3, 1]);
            Assert.AreEqual(0, pacman.stars);
        }

        [TestMethod]
        public void PacmanGoLeftFromX0_StarPlus_StarClearInField()
        {
            Field field = new Field();
            Pacman.Pacman pacman = new Pacman.Pacman(field);
            pacman.RealtimeCoordinate = new Coordinate(7, 0);
            field.NewField[7, 0] = "C";
            Assert.IsTrue(pacman.GoLeft());
            Assert.AreEqual(" ", field.NewField[7, 0]);
            Assert.AreEqual(1, pacman.stars);
        }

        [TestMethod]
        public void PacmanGoRightFromX23_StarPlus_StarClearInField()
        {
            Field field = new Field();
            Pacman.Pacman pacman = new Pacman.Pacman(field);
            pacman.RealtimeCoordinate = new Coordinate(7, 23);
            field.NewField[7, 23] = "C";
            Assert.IsTrue(pacman.GoRight());
            Assert.AreEqual(" ", field.NewField[7, 23]);
            Assert.AreEqual(1, pacman.stars);
        }

        [TestMethod]
        public void PacmanGoRight_StarPlus_StarClearInField()
        {
            Field field = new Field();
            Pacman.Pacman pacman = new Pacman.Pacman(field);
            pacman.RealtimeCoordinate = new Coordinate(7, 3);
            field.NewField[7, 3] = "C";
            Assert.IsTrue(pacman.GoRight());
            Assert.AreEqual(" ", field.NewField[7, 3]);
            Assert.AreEqual(1, pacman.stars);
        }

        [TestMethod]
        public void PacmanNotGoRight_NotStarPlus_NotStarClearInField()
        {
            Field field = new Field();
            Pacman.Pacman pacman = new Pacman.Pacman(field);
            pacman.RealtimeCoordinate = new Coordinate(3, 1);
            field.NewField[3, 1] = "C";
            Assert.IsFalse(pacman.GoRight());
            Assert.AreEqual("C", field.NewField[3, 1]);
            Assert.AreEqual(0, pacman.stars);
        }

        [TestMethod]
        public void PacmanGoDown_StarPlus_StarClearInField()
        {
            Field field = new Field();
            Pacman.Pacman pacman = new Pacman.Pacman(field);
            pacman.RealtimeCoordinate = new Coordinate(7, 1);
            field.NewField[7, 1] = "C";
            Assert.IsTrue(pacman.GoDown());
            Assert.AreEqual(" ", field.NewField[7, 1]);
            Assert.AreEqual(1, pacman.stars);
        }

        [TestMethod]
        public void PacmanNotGoDown_NotStarPlus_NotStarClearInField()
        {
            Field field = new Field();
            Pacman.Pacman pacman = new Pacman.Pacman(field);
            pacman.RealtimeCoordinate = new Coordinate(1, 4);
            field.NewField[1, 4] = "C";
            Assert.IsFalse(pacman.GoDown());
            Assert.AreEqual("C", field.NewField[1, 4]);
            Assert.AreEqual(0, pacman.stars);
        }

       //Class GHost Tests
        [TestMethod]
        public void GHostCanNextStep()
        {
            Field field = new Field();
            Pacman.GHost ghost = new Pacman.GHost(field);
            field.NewField[1, 1] = "&";
            field.NewField[1, 2] = "-";
            field.NewField[1, 3] = "|";
            field.NewField[1, 4] = "_";
            Assert.IsFalse(ghost.CanNextStep(new Coordinate(1, 1)));
            Assert.IsFalse(ghost.CanNextStep(new Coordinate(1, 2)));
            Assert.IsFalse(ghost.CanNextStep(new Coordinate(1, 3)));
            Assert.IsFalse(ghost.CanNextStep(new Coordinate(1, 4)));
            
        }
      
        [TestMethod]
        public void GhostGoUp_SavePreviousValue()
        {
            Field field = new Field();
            GHost ghost = new GHost(field);
            ghost.RealtimeCoordinate = new Coordinate(7, 1);
            ghost.previousValue = " ";
            field.NewField[7, 1] = "&";
            Assert.IsTrue(ghost.GoUp());
            Assert.AreEqual(" ", field.NewField[7, 1]);
          }

        
        [TestMethod]
        public void  GhostNotGoUp_NotSavePreviousValue()
        {
             Field field = new Field();
            GHost ghost = new GHost(field);
            ghost.RealtimeCoordinate = new Coordinate(1, 1);
             ghost.previousValue = " ";
            field.NewField[1, 1] = "&";
            Assert.IsFalse(ghost.GoUp());
             Assert.AreEqual("&", field.NewField[1, 1]);
        }

        [TestMethod]
        public void GhostGoLeft_SavePreviousValue()
        {
            Field field = new Field();
            GHost ghost = new GHost(field);
            ghost.RealtimeCoordinate = new Coordinate(7, 3);
            ghost.previousValue = " ";
            field.NewField[7, 3] = "&";
            Assert.IsTrue(ghost.GoLeft());
            Assert.AreEqual(" ", field.NewField[7, 3]);
        }


        [TestMethod]
        public void GhostNotGoLeft_NotSavePreviousValue()
        {
            Field field = new Field();
            GHost ghost = new GHost(field);
            ghost.RealtimeCoordinate = new Coordinate(3, 1);
            ghost.previousValue = " ";
            field.NewField[3, 1] = "&";
            Assert.IsFalse(ghost.GoLeft());
            Assert.AreEqual("&", field.NewField[3, 1]);
        }
        [TestMethod]
        public void GhostGoLeftFromX0_GhostGoLeft_SavePreviousValue()
        {
            Field field = new Field();
            GHost ghost = new GHost(field);
            ghost.RealtimeCoordinate = new Coordinate(7, 0);
            ghost.previousValue = " ";
            field.NewField[7, 0] = "&";
            Assert.IsTrue(ghost.GoLeft());
            Assert.AreEqual(" ", field.NewField[7, 0]);
        }


        [TestMethod]
        public void GhostGoRight_SavePreviousValue()
        {
            Field field = new Field();
            GHost ghost = new GHost(field);
            ghost.RealtimeCoordinate = new Coordinate(7, 3);
            ghost.previousValue = " ";
            field.NewField[7, 3] = "&";
            Assert.IsTrue(ghost.GoRight());
            Assert.AreEqual(" ", field.NewField[7, 3]);
        }


        [TestMethod]
        public void GhostNotGoRight_NotSavePreviousValue()
        {
            Field field = new Field();
            GHost ghost = new GHost(field);
            ghost.RealtimeCoordinate = new Coordinate(3, 1);
            ghost.previousValue = " ";
            field.NewField[3, 1] = "&";
            Assert.IsFalse(ghost.GoRight());
            Assert.AreEqual("&", field.NewField[3, 1]);
        }

        [TestMethod]
        public void GhostGoRightFromX23_SavePrevV()
        {
            Field field = new Field();
            GHost ghost = new GHost(field);
            ghost.RealtimeCoordinate = new Coordinate(7, 23);
            ghost.previousValue = " ";
            field.NewField[7, 23] = "&";
            Assert.IsTrue(ghost.GoRight());
            Assert.AreEqual(" ", field.NewField[7, 23]);
        }

        [TestMethod]
        public void GhostGoDown_SavePreviousValue()
        {
            Field field = new Field();
            GHost ghost = new GHost(field);
            ghost.RealtimeCoordinate = new Coordinate(7, 1);
            ghost.previousValue = " ";
            field.NewField[7, 1] = "&";
            Assert.IsTrue(ghost.GoDown());
            Assert.AreEqual(" ", field.NewField[7, 1]);
        }


        [TestMethod]
        public void GhostNotGoDown_NotSavePreviousValue()
        {
            Field field = new Field();
            GHost ghost = new GHost(field);
            ghost.RealtimeCoordinate = new Coordinate(1, 4);
            ghost.previousValue = " ";
            field.NewField[1, 4] = "&";
            Assert.IsFalse(ghost.GoDown());
            Assert.AreEqual("&", field.NewField[1, 4]);
        }

    }
}
