using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_Avans
{
    public abstract class Tile
    {
        public Tile TileRight { get; set; }
        public Tile TileLeft { get; set; }
        public Tile TileUp { get; set; }
        public Tile TileDown { get; set; }

        public static Tile getTile(char c)
        {
            Tile tile = new EmptyTile();
            switch (c)
            {
                case ' ':
                    tile = new EmptyTile();
                    break;
                case '#':
                    tile = new WallTile();
                    break;
                case '$':
                case '.':
                case '@':
                case 'Z':
                case 'o':
                    tile = new FloorTile();
                    break;
                case 'x':
                    tile = new TargetTile();
                    break;
                case '~':
                    // Pitfall.
                    break;
                default:
                    // Throw exception or something.
                    break;
            }

            return tile;
        }

        public Tile getNeigbour()
        {
            return this.TileUp;
        }
    }
}
