using System;

namespace reserveringsysteem_project_B
{
    public class Screen
    {
        private Screen _prev;

        public Screen()
        {
            
        }

        public void SetPrevious(Screen s)
        {
            _prev = s;
        }

        //public void Log(string message)
        //{
        //    // Write to log.txt
        //}

        public void Display(string message)
        {
            Console.WriteLine(message);
        }

        public virtual void Show()
        {
            throw new NotImplementedException("Let op: deze functie overschrijven");
        }

        public void Back()
        {
            // Log("[Back]");

            if (_prev != null)
            {
                _prev.Show();
            }
        }

        public void BackToPrevious()
        {
            Console.WriteLine("\nDruk op een knop om terug te gaan...");

            ConsoleKey keyPressed;
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            keyPressed = keyInfo.Key;

            if (keyPressed == ConsoleKey.Enter)
            {
                Back();
            }
            else
            {
                Back();
            }
        }

        public void QuickOptionBack()
        {
         
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            string prefix = ">>";
            Console.WriteLine($"{prefix} Terug");
            Console.ResetColor();
            if(Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Back();
            }
            else
            {
                Back();
            }
        }
        public void Jump(int steps)
        {
            if (_prev != null)
            {
                if (steps > 1)
                {
                    _prev.Jump(steps - 1);
                }
                else
                {
                    _prev.Show();
                }
            }
        }
        public void switchFullScreen()
        {
            {
                Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                Console.SetWindowPosition(0, 0);
            }
        }

        public static bool IsAdmin(string name, string password)
        {
            if (name == "Admin" && password == "unlimitedpower")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsKok(string name, string password)
        {
            if (name == "Kok" && password == "iamthechef")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}