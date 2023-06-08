using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reserveringsysteem_project_B
{
    internal class Grid
    {
        private int _width;
        private int _height;
        private List<Vector2> _takenSpots;
        private static Grid _instance;

        public Grid(int width, int height)
        {
            _width = width;
            _height = height;
            _takenSpots = new List<Vector2>();
            foreach (var i in Reservations.GetInstance().GetReservations())
            {
                _takenSpots.Add(new Vector2(i.TableLocationX, i.TableLocationY));
            }

        }
        
        public static Grid GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Grid(5, 5);
            }
            return _instance;
        }

        public string DrawGrid()
        {
            string grid = "";
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    grid += "+-";
                }
                grid += "+\n";
                for (int k = 0; k < _width; k++)
                {
                    grid = _takenSpots.Contains(new Vector2(k, i)) ? grid + "|x" : grid + "| ";
                }
                grid += "|\n";
            }
            for (int j = 0; j < _width; j++)
            {
                grid += "+-";
            }
            grid += "+";
            return grid;
        }

        private void SelectOnGrid(Vector2 cursor)
        {
            string grid = "";
            Console.WriteLine("Selecteer een plek in het restaurant.\n");
            
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    grid += "+-";
                }
                Console.Write(grid + "+\n");
                grid = "";
                for (int k = 0; k < _width; k++)
                {
                    if (cursor == new Vector2(k, i))
                    {
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                    else if (_takenSpots.Contains(new Vector2(k, i)))
                    {
                        Console.Write("|x");
                    }
                    else
                    {
                        Console.Write("| ");
                    }
                }
                Console.Write("|\n");
            }
            for (int j = 0; j < _width; j++)
            {
                grid += "+-";
            }
            grid += "+";
            Console.WriteLine(grid);
            if (cursor.Y != (float)_height)
            {
                Console.WriteLine("Terug");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Terug");
                Console.ResetColor();
            }
            //Console.WriteLine("x: " + cursor.X);
            //Console.WriteLine("y: " + cursor.Y + "\n");
            //Console.WriteLine(_takenSpots[0].X);
            //Console.WriteLine(_takenSpots[0].Y);
        }

        public Vector2 SelectorRun()
        {
            int x = 0;
            int y = 0;

            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                SelectOnGrid(new Vector2(x, y));

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    if (y != 0) { y--; }
                    else { y = _height; }
                    if (_takenSpots.Contains(new Vector2(x, y))) { y--; }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    if (y < _height) { y++; }
                    else { y = 0; }
                    if (_takenSpots.Contains(new Vector2(x, y))) { y++; }

                    // y = y > _height ? 0 : y++; //y++;
                }
                else if (keyPressed == ConsoleKey.LeftArrow)
                {
                    if (x != 0) { x--; }
                    else { x = _width - 1; }
                    if (_takenSpots.Contains(new Vector2(x, y))) { x--; }
                }
                else if (keyPressed == ConsoleKey.RightArrow)
                {
                    if (x < _width - 1) { x++; }
                    else { x = 0; }
                    if (_takenSpots.Contains(new Vector2(x, y))) { x++; }
                }
            } while (keyPressed != ConsoleKey.Enter);

            Vector2 SelectedSpot = new Vector2(x, y);
            if (y != _height) { _takenSpots.Add(SelectedSpot); }
            return SelectedSpot;
        }
    }
}
