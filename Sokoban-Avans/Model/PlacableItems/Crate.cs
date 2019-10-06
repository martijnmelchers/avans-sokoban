using Sokoban.Model;

namespace Sokoban
{
    class Crate : PlacableItem
    {
        public Crate(Tile tile)
        {
            this._tile = tile;
        }

        public override char ToChar()
        {
            return '#';
        }

        public override bool Move(MazeAction direction)
        {
            Tile currentTile = _tile.GetNeigbour(direction);
            if (!currentTile.IsEmpty())
                return false;
            currentTile.PlaceItem(this);
            _tile.Remove();
            _tile = currentTile;
            return true;
        }

        public bool IsOnTarget()
        {
            return _tile is TargetTile;
        }
    }
}
