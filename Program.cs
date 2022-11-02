using System;
using System.IO;

namespace MazeBazhin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 150;
            Console.WindowHeight = 50;
            Console.SetBufferSize(200, 50);
            var wdth = Console.WindowWidth / 2 - 72;
            var hght = Console.WindowHeight / 2 -9;

            int n = 0;
            int pl1 = 0;
            int pl2 = 0;
            int kon = 0;
            int kon2 = 0;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 70, 20);
            Console.WriteLine("--------------------------");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 65, 21);
            Console.WriteLine("ИГРА ЛАБИРИНТ!");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 70, 22);
            Console.WriteLine("--------------------------");
            
            Console.WriteLine("Ваша задача добраться до сердечка ♥\n\n\n " +
           "W-идти вперёд \n" +
           " A-идти влево \n" +
           " S-идти назад \n" +
           " D-идти вправо \n\n" +

           "\t\t   W \n" +
           " \t\t A S D\n");

            
            string[] str = File.ReadAllLines("../../res/maze.txt");
            int[,] maze = new int[str.Length, str[0].Split(' ').Length];
            for (int i = 0; i < str.Length; i++)
            {
               
                string[] str2 = str[i].Split(' ');
                for (int j = 0; j < str2.Length; j++)
                    maze[i, j] = Int32.Parse(str2[j]);
                n = str2.Length;
            }
            for (var i = 0; i < str.Length; i++)
            {
                
                Console.WriteLine();

                for (var j = 0; j < n; j++)
                {
                   
                    switch (maze[i, j])
                    {
                        case 1: Console.Write(' '); break;
                        case 0: Console.Write('█'); break;
                        case 2:
                            Console.Write('☺');
                            pl1 = i;//y
                            pl2 = j;//x
                            break;
                        case 3:
                            Console.Write('♥');
                            kon = i;//y
                            kon2 = j;//x
                            break;

                    }
                }
            }


            do
            {
                Console.SetCursorPosition(0, 20);
                string step = Console.ReadKey(true).KeyChar.ToString().ToLower();
                switch (step)
                {
                    case "w":
                        if (maze[pl1 - 1, pl2] != 0)
                        {
                            Console.SetCursorPosition(wdth, hght);
                            Console.WriteLine(" ");
                            Console.SetCursorPosition(wdth, --hght);
                            Console.WriteLine("☺");
                            pl1--;
                        }
                        break;
                    case "s":
                        if (maze[pl1 + 1, pl2] != 0)
                        {
                            Console.SetCursorPosition(wdth, hght);
                            Console.WriteLine(" ");
                            Console.SetCursorPosition(wdth, ++hght);
                            Console.WriteLine("☺");
                            pl1++;
                        }
                        break;
                    case "d":
                        if (maze[pl1, pl2 + 1] != 0)
                        {
                            Console.SetCursorPosition(wdth, hght);
                            Console.WriteLine(" ");
                            Console.SetCursorPosition(++wdth, hght);
                            Console.WriteLine("☺");
                            pl2++;
                        }
                        break;
                    case "a":
                        if (maze[pl1, pl2 - 1] != 0)
                        {
                            Console.SetCursorPosition(wdth, hght);
                            Console.WriteLine(" ");
                            Console.SetCursorPosition(--wdth, hght);

                            Console.WriteLine("☺");
                            pl2--;
                        }
                        break;
                }
            } while (pl1 != kon || pl2 != kon2);
            Console.SetCursorPosition(Console.WindowWidth / 2 - 13, 20);
            Console.WriteLine("--------------------------");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 7, 20);
            Console.WriteLine("Вы прошли игру!");
            Console.ReadLine();
        }
    }
}