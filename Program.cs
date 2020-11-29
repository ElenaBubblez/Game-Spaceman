using System;

namespace Game_Spaceman
{
    class Program
    {
        static void Main(string[] args)
        {
            Start: Game ufo = new Game();
            ufo.Greet();
            
             do
            {
                ufo.Display();
                ufo.Ask();

                    if (ufo.DidWin().Equals(true) || ufo.DidLose().Equals(true))
                    {

                    goto Start;
                    
                    }
            }
            while (true);
           
            
                
            
            
        }
    }
}
