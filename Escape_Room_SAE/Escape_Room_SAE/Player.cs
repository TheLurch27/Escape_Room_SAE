using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room_SAE
{
    internal class Player
    {
        internal static int playerX;
        internal static int playerY;
        internal static string playerChar = ":)";

        internal static void CheckCharacterPosition()
        // Player Position... Check! Hier wird geschaut das der Charackter nicht ausbüchsen kann.
        {
            Map.CheckDoor();


            if (playerX <= 0)
            {
                playerX = 1;
            }
            else if (playerX >= UserInput.InputMapSize - 1)
            {
                playerX = UserInput.InputMapSize - 2;
            }

            if (playerY <= 0)
            {
                playerY = 1;
            }
            else if (playerY >= UserInput.InputMapSize - 1)
            {
                playerY = UserInput.InputMapSize - 2;
            }
        }
    }
}
