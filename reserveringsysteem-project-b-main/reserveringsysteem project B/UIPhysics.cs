using System;
using System.Linq;

namespace reserveringsysteem_project_B
{
    internal class UIPhysics
    {
        private const string V = "Restaurant";
        private int SelectedIndex;
        private readonly string[] Options;
        private readonly string Title;

        public UIPhysics(string title, string[] options)
        {
            Title = title;
            Options = options;
            SelectedIndex = 0;
        }

        private static bool bob(int selectedIndex, string[] options)
        {
            return options[selectedIndex] == "";
        }

        private void DisplayOptions()
        {
            Console.Title = V;
            // ConsoleKey keyPressed;
            Console.WriteLine(Title + "\n");
            foreach (string option in Options)
            {
                string prefix;
                if (option == Options[SelectedIndex] && option != "")
                {
                    prefix = ">>";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }

                else
                {
                    prefix = "  ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"{prefix} {option}");
            }
            Console.ResetColor();
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex = SelectedIndex != 0 ? SelectedIndex - 1 : Options.Count() - 1;
                    if (bob(SelectedIndex, Options))
                    {
                        SelectedIndex--;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex = SelectedIndex != Options.Count() - 1 ? SelectedIndex + 1 : SelectedIndex = 0;
                    if (bob(SelectedIndex, Options))
                    {
                        SelectedIndex++;
                    }

                }
            } while (keyPressed != ConsoleKey.Enter); // && Options[SelectedIndex] != "/input"
            return SelectedIndex;
        }

        public static int QuickOptions(string[] options)
        {
            ConsoleKey keyPressed;
            int SelectedIndex = 0;
            do
            {
                foreach (string option in options)
                {
                    string prefix;
                    if (option == options[SelectedIndex] && option != "")
                    {
                        prefix = ">>";
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                    }

                    else
                    {
                        prefix = "  ";
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine($"{prefix} {option}");
                }
                Console.ResetColor();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex = SelectedIndex != 0 ? SelectedIndex - 1 : options.Count() - 1;
                    if (bob(SelectedIndex, options))
                    {
                        SelectedIndex--;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex = SelectedIndex != options.Count() - 1 ? SelectedIndex + 1 : SelectedIndex = 0;
                    if (bob(SelectedIndex, options))
                    {
                        SelectedIndex++;
                    }

                }
            } while (keyPressed != ConsoleKey.Enter);
            return SelectedIndex;
        }
    }
}
