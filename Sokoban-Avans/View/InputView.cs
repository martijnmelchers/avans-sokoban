using Sokoban.Model;
using System;

namespace Sokoban
{
    class InputView
    {
        public SelectAction AskForAction()
        {
            int input = 0;
            char consoleInput = '?';

            // Loop until we got the answer that we want or we get a quit action
            while ((input < 1 || input > 6) && consoleInput != 's')
            {
                Console.WriteLine("> Kies een doolhof (1 - 6), s = stop");

                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                consoleInput = consoleKeyInfo.KeyChar;
                Console.WriteLine();

                if (consoleInput >= '1' && consoleInput <= '6')
                    input = Convert.ToInt32(char.ToString(consoleInput));
                else if (consoleInput != 's')
                    Console.WriteLine("> Onbekende actie!");
            }

            if (consoleInput == 's')
                input = 6;

            return (SelectAction) input;
        }

        public MazeAction AskForMove()
        {
            bool validInput = false;
            ConsoleKey consoleInput = ConsoleKey.Escape;

            while (!validInput)
            {
                Console.WriteLine("> gebruik pijljestoetsen (s = stop, r = reset)");
                consoleInput = Console.ReadKey().Key;

                switch (consoleInput)
                {
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.R:
                    case ConsoleKey.S:
                        validInput = true;
                        continue;
                    default:
                        Console.WriteLine("> Onbekende actie!");
                        continue;
                }
            }

            switch (consoleInput)
            {
                case ConsoleKey.LeftArrow:
                    return MazeAction.Left;
                case ConsoleKey.RightArrow:
                    return MazeAction.Right;
                case ConsoleKey.UpArrow:
                    return MazeAction.Up;
                case ConsoleKey.DownArrow:
                    return MazeAction.Down;
                case ConsoleKey.R:
                    return MazeAction.Reset;
                case ConsoleKey.S:
                    return MazeAction.Quit;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
