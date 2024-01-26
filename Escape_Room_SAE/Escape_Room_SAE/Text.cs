using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room_SAE
{
    internal class Text
    {
        internal static void WelcomeMessage()
        // Bisschen was fürs Auge.
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" _____ ____   ____    _    ____  _____   ____   ___   ___  __  __ \r\n| ____/ ___| / ___|  / \\  |  _ \\| ____| |  _ \\ / _ \\ / _ \\|  \\/  |\r\n|  _| \\___ \\| |     / _ \\ | |_) |  _|   | |_) | | | | | | | |\\/| |\r\n| |___ ___) | |___ / ___ \\|  __/| |___  |  _ <| |_| | |_| | |  | |\r\n|_____|____/ \\____/_/   \\_\\_|   |_____| |_| \\_\\\\___/ \\___/|_|  |_|");
            Console.WriteLine("__        _____ ____  _   _          \r\n\\ \\      / /_ _/ ___|| | | |         \r\n \\ \\ /\\ / / | |\\___ \\| |_| |         \r\n  \\ V  V /  | | ___) |  _  |         \r\n __\\_/\\_/__|___|____/|_|_|_|_  _   _ \r\n| ____|  _ \\_ _|_   _|_ _/ _ \\| \\ | |\r\n|  _| | | | | |  | |  | | | | |  \\| |\r\n| |___| |_| | |  | |  | | |_| | |\\  |\r\n|_____|____/___| |_| |___\\___/|_| \\_|");
            Console.ReadKey();
            Console.Clear();
        }

        internal static void InstructionMessage()
        // Viel Bla Bla... Tastenbelegung und so.
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Find the key (");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("O╣");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(") and open the door (");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("▒▒");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(")");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("Key assignment");
            Console.WriteLine("   Up =  W | \u2191");
            Console.WriteLine(" Down =  S | \u2193");
            Console.WriteLine(" Left =  A | Computer says no... (Think of an left arrow here)");
            Console.WriteLine("Right =  D | \u2192");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
