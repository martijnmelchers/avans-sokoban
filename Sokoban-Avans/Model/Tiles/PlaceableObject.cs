using Sokoban.Model;

namespace Sokoban
{
    abstract class PlacableItem
    {
        protected Tile _tile;


        public abstract bool Move(MazeAction action);
        public abstract char ToChar();
    }
}
