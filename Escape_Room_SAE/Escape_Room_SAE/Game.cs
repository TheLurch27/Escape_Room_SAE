using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room_SAE
{
    class Game
    {
        const int groundSize = 20;
        const int groundYPos = 10;
        const ConsoleColor groundColor = ConsoleColor.Green;

        public void Run() // Neue "Main"
        {
            // Boden visuell anzeigen
            // Spieler visuell anzeigen
            // Spieler bewegen mit USer Input
            DrawMap();

            Console.ReadLine();
        }

        public void DrawMap()
        {
            Console.SetCursorPosition(0, groundYPos);
            Console.BackgroundColor = groundColor;
            for (int i = 0; 1 < groundSize; i++)
            {
                Console.Write(" ");
            }
        }
    }
}
