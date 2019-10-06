using Sokoban.Exceptions;
using Sokoban.Model;

namespace Sokoban
{
    abstract class Tile
    {
        public Tile TileRight { get; set; }
        public Tile TileLeft { get; set; }
        public Tile TileUp { get; set; }
        public Tile TileDown { get; set; }

        public abstract void Remove();


        public PlacableItem Content { get; set; }
        public abstract char ToChar();
        public static Tile GetTile(char c)
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
                    tile = new TargetTile();
                    break;
                default:
                    throw new MazeParseException(c);
            }

            return tile;
        }

        public Tile GetNeigbour(MazeAction action)
        {
            switch (action)
            {
                case MazeAction.Right:
                    return this.TileRight;
                case MazeAction.Left:
                    return this.TileLeft;
                case MazeAction.Down:
                    return this.TileDown;
                case MazeAction.Up:
                    return this.TileUp;
                default:
                    return (Tile)null;
            }
        }


        public bool isEmpty()
        {
            return this.Content == null;    
        }

        public abstract bool PlaceItem(PlacableItem item);
    }
}
