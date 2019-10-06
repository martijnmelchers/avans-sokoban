using System;
using System.Collections.Generic;
using System.IO;

namespace Sokoban
{
    class Parser
    {

        private Maze _maze;
        public Maze LoadMaze(int mazeNumber)
        {

            _maze = new Maze();
            this.DetectDimensions(mazeNumber);
            using (var fileStream = File.OpenRead($"..\\..\\Doolhof\\doolhof{mazeNumber}.txt"))
            {
                using (var streamReader = new StreamReader(fileStream))
                {

                    List<Tile> prevRow = null; 
                    string line;
                    while ((line = streamReader.ReadLine()) != null){
                        List<Tile> curRow = ProcessRow(line);


                        // Link rows when we have a previous row.
                        if (prevRow != null)
                            LinkRows(prevRow, curRow);
                        // This is the first line, set the original Tile of the maze.
                        else
                            _maze.Origin = curRow[0];
                        

                        prevRow = curRow;
                    }
                }
            }

            return _maze;
        }

        // Handle each line of the maze file.
        private List<Tile> ProcessRow(string line)
        {
            List<Tile> tileList = new List<Tile>();
            Tile prevTile = null;
            for(var i = 0; i < line.Length; i++)
            {
                char character = line[i];

                Tile curTile = Tile.GetTile(character);

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


                if (character == '@')
                {
                    Truck truck = new Truck(curTile);
                    _maze.Truck = truck;
                    curTile.PlaceItem(truck);
                }
                if (character == 'o')
                {
                    Crate k = new Crate(curTile);
                    _maze.AddCrate(k);
                    curTile.PlaceItem(k);
                }
                if (character == '$' || character == 'Z')
                {
                    Worker worker = new Worker(curTile, character == 'Z');
                    _maze.Worker = worker;
                    curTile.PlaceItem(worker);
                }


            }

            return tileList;
        }

        // Set the top/ down urls on the lists.
        private void LinkRows(List<Tile> prev, List<Tile> cur)
        {
            for (var i = 0; i < cur.Count; ++i)
            {
                if (prev[i] != null && cur[i] != null)
                {
                    cur[i].TileUp = prev[i];
                    prev[i].TileDown = cur[i];
                }
            }
        }


        private void DetectDimensions(int mazeNumber)
        {
            using (var fileStream = File.OpenRead($"..\\..\\Doolhof\\doolhof{mazeNumber}.txt"))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    int width = 0;
                    int height = 0;
                    try
                    {
                        string str = streamReader.ReadLine();
                        while (str != null)
                        {
                            if (str != null)
                            {
                                if (str.Length > width)
                                    width = str.Length;

                                height++;
                                str = streamReader.ReadLine();
                            }
                            else
                            {
                                streamReader.Close();
                                streamReader.Close();
                            }
                        }
                       
                        _maze.Width = width;
                        _maze.Height = height;
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
 
        }
    }
}
