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
        public abstract PlacableItem Content { get; set; }
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
                    tile = new PitTile();
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
                    return TileRight;
                case MazeAction.Left:
                    return TileLeft;
                case MazeAction.Down:
                    return TileDown;
                case MazeAction.Up:
                    return TileUp;
                default:
                    return null;
            }
        }


        public virtual bool IsEmpty()
        {
            return Content == null;    
        }

        public abstract bool PlaceItem(PlacableItem item);
    }
}
