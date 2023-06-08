using System;

namespace reserveringsysteem_project_B
{
    public class GridScreen : Screen
    {
        public override void Show()
        {
            
            // Console.WriteLine(NewGrid.DrawGrid());
            Grid.GetInstance().SelectorRun();
            Back();
        }
    }
}