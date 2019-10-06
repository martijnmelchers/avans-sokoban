using System;

namespace Sokoban
{
    class OutputView
    {
        public void ShowGameStart()
        {
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────────────────────┐");
            Console.WriteLine("| Welkom bij Sokoban                                 |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("| betekenis van de symbolen   |   doel van het spel  |");
            Console.WriteLine("|                             |                      |");
            Console.WriteLine("| spatie : outerspace         |   duw met de truck   |");
            Console.WriteLine("|      █ : muur               |   de krat(ten)       |");
            Console.WriteLine("|      · : vloer              |   naar de bestemming |");
            Console.WriteLine("|      O : krat               |                      |");
            Console.WriteLine("|      0 : krat op bestemming |                      |");
            Console.WriteLine("|      x : bestemming         |                      |");
            Console.WriteLine("|      @ : truck              |                      |");
            Console.WriteLine("|      ~ : pitfall            |                      |");
            Console.WriteLine("└────────────────────────────────────────────────────┘");
            Console.WriteLine("");
        }

        public void RenderMaze(Maze maze)
        {
            Console.Clear();
            Console.WriteLine("┌──────────┐   ");
            Console.WriteLine("| Sokoban  |   ");
            Console.WriteLine("└──────────┘   ");
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────");
            int height = maze.Height;
            int width = maze.Width;
            Tile originTile = maze.Origin;
            Tile fieldBelow = originTile.TileDown;
            for (int index1 = 0; index1 < height; ++index1)
            {
                for (int index2 = 0; index2 < width; ++index2)
                {
                    Console.Write(originTile.ToChar());
                    originTile = originTile.TileRight;
                }
                originTile = fieldBelow;
                if (fieldBelow != null)
                    fieldBelow = originTile.TileDown;
                Console.WriteLine();
            }
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────");
        }

        internal void ShowMazeFinished()
        {
            Console.WriteLine();
            Console.WriteLine("JE BENT EEN KANJER, Je hebt gewonnen");
            Console.WriteLine("Druk op een toets om te stoppen.");
            Console.ReadKey();
        }
    }
}
