﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Field
    {
        public string[,] NewField;

        public Field()
        {
            NewField = new string[,] {
{"|","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","|"},
{"|","*","*","*","*","*","*","*","*","*","*","|"," ","|","*","*","*","*","*","*","*","*","*","*","|"},
{"|","*","-","-","-","-","*","|","-","|","*","|"," ","|","*","|","-","|","*","-","-","-","-","*","|"},
{"|","*","|"," "," ","|","*","|"," ","|","*","|"," ","|","*","|"," ","|","*","|"," "," ","|","*","|"},
{"|","*","|"," "," ","|","*","|"," ","|","*","|"," ","|","*","|"," ","|","*","|"," "," ","|","*","|"},
{"|","*","|"," "," ","|","*","|"," ","|","*","|"," ","|","*","|"," ","|","*","|"," "," ","|","*","|"},
{"|","*","-","-","-","-","*","|"," ","|","*","-","-","-","*","|"," ","|","*","-","-","-","-","*","|"},
{"*","*","*","*","*","*","*","|"," ","|","*","*","*","*","*","|"," ","|","*","*","*","*","*","*","*"},
{"|","*","-","-","-","-","*","|","-","|","*","|","-","|","*","|","-","|","*","-","-","-","-","*","|"},
{"|","*","|"," "," ","|","*","*","*","*","*","|"," ","|","*","*","*","*","*","|"," "," ","|","*","|"},
{"|","*","|"," "," ","|","*","|","-","|","*","|"," ","|","*","|","-","|","*","|"," "," ","|","*","|"},
{"|","*","-","-","-","-","*","|"," ","|","*","-","-","-","*","|"," ","|","*","-","-","-","-","*","|"},
{"*","*","*","*","*","*","*","|"," ","|","*","*","*","*","*","|"," ","|","*","*","*","*","*","*","*"},
{"|","*","-","-","-","-","*","|"," ","|","*","-","-","-","*","|"," ","|","*","-","-","-","-","*","|"},
{"|","*","|"," "," ","|","*","|","-","|","*","|"," ","|","*","|","-","|","*","|"," "," ","|","*","|"},
{"|","*","|"," "," ","|","*","*","*","*","*","|"," ","|","*","*","*","*","*","|"," "," ","|","*","|"},
{"|","*","-","-","-","-","*","|","-","|","*","|","-","|","*","|","-","|","*","-","-","-","-","*","|"},
{"*","*","*","*","*","*","*","|"," ","|","*","*","*","*","*","|"," ","|","*","*","*","*","*","*","*"},
{"|","*","-","-","-","-","*","|"," ","|","*","-","-","-","*","|"," ","|","*","-","-","-","-","*","|"},
{"|","*","|"," "," ","|","*","|"," ","|","*","|"," ","|","*","|"," ","|","*","|"," "," ","|","*","|"},
{"|","*","|"," "," ","|","*","|"," ","|","*","|"," ","|","*","|","-","|","*","|"," "," ","|","*","|"},
{"|","*","|"," "," ","|","*","|"," ","|","*","|"," ","|","*","|"," ","|","*","|"," "," ","|","*","|"},
{"|","*","-","-","-","-","*","|","-","|","*","|"," ","|","*","|","-","|","*","-","-","-","-","*","|"},
{"|","*","*","*","*","*","*","*","*","*","*","|"," ","|","*","*","*","*","*","*","*","*","*","*","|"},
{"|","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","_","|"}
};
}
        
        public void Print(int score, int lives)
        {
            Console.WindowHeight = 40;
            Console.WindowWidth = 122;
            Console.WriteLine("F5 - SAVE GAME TO FILE");
            Console.WriteLine();
            for (int i = 0; i < NewField.GetLength(0); i++)
            {
                for (int j = 0; j < NewField.GetLength(1); j++)
                {
                    if (NewField[i, j] == "|" || NewField[i, j] == "_" || NewField[i, j] == "-")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (NewField[i, j] == "&")
                    {
                        Console.ForegroundColor = ConsoleColor.Red; 
                    }
                    else if (NewField[i, j] == "C")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.Write(NewField[i, j]);
                    Console.Write("    ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine( "\tSCORE:{0}\tLIVES:{1}",score,lives);
        }


    }
}
