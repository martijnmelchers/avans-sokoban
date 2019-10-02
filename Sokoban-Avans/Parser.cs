
using System.Collections.Generic;
using System.IO;
namespace Sokoban_Avans
{
    class Parser
    {

        private Maze _maze;
        public Maze LoadMaze()
        {

            this._maze = new Maze();

            using (var fileStream = File.OpenRead("C:/Doolhof/doolhof1.txt"))
            {
                using (var streamReader = new StreamReader(fileStream))
                {

                    List<Tile> prevRow = null; 
                    string line;
                    while ((line = streamReader.ReadLine()) != null){
                        List<Tile> curRow = this.procesRow(line);


                        // Link rows when we have a previous row.
                        if (prevRow != null)
                        {
                            linkRows(prevRow, curRow);
                        }

                        // This is the first line, set the original Tile of the maze.
                        else
                        {
                            this._maze.Origin = curRow[0];
                        }
                    }
                }
            }

            return this._maze;
        }

        // Handle each line of the maze file.
        private List<Tile> procesRow(string line)
        {
            List<Tile> tileList = new List<Tile>();
            Tile prevTile = (Tile) null;
            for(var i = 0; i < line.Length; i++)
            {
                char character = line[i];

                Tile curTile = Tile.getTile(character);

                // If there is a previous tile.
                if(prevTile != null)
                {
                    prevTile.TileRight = curTile;
                    curTile.TileLeft = prevTile;
                }

                // Save the current tile for comparison / linking with the next one
                prevTile = curTile;
                tileList.Add(curTile);

                // Handle place-able items. (workers etc.)
            }

            return tileList;
        }

        // Set the top/ down urls on the lists.
        private void linkRows(List<Tile> a, List<Tile> b)
        {
            for (var i = 0; i < 0; i++)
            {
                if (a[i] != null && b[i] != null)
                {
                    b[i].TileUp = a[i];
                    a[i].TileDown = b[i];
                }
            }
        }
    }
}
