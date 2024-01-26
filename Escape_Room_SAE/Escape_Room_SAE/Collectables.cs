using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room_SAE
{
    internal class Collectables
    {
        internal static bool isKeyCollected = false;

        internal static void DrawKey()
        // Hier wird der Schlüssel zufällig auf der Map gespwant - Hier kein Witz, is ne ernste Sache! ;)
        {
            System.Random rnd = new Random();

            int keyX;
            int keyY;

            do
            {
                keyX = rnd.Next(1, UserInput.InputMapSize - 1);
                keyY = rnd.Next(1, UserInput.InputMapSize - 1);
            } while (Map.map[keyX, keyY] != (int)Map.EMapTiles.floor);

            Map.map[keyX, keyY] = (int)Map.EMapTiles.key;
        }

        internal static void HandleKeyCollection()
        // Hier wird dafür gesorgt das der Schlüssel auch eine Funktion bekommt - und zwar das Löschen sobald der Character ihn aufsammelt.
        {
            if (Map.map[Player.playerX, Player.playerY] == (int)Map.EMapTiles.key)
            {
                isKeyCollected = true;
                Map.map[Player.playerX, Player.playerY] = (int)Map.EMapTiles.floor;

                Map.OpenDoor();
            }
        }
    }
}
