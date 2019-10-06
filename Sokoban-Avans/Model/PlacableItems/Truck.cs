using Sokoban.Model;

namespace Sokoban
{
    class Truck : PlacableItem
    {
        public Truck(Tile tile)
        {
            this._tile = tile;
        }

        public override char ToChar()
        {
            return '@';
        }

        public override bool Move(MazeAction action)
        {
            Tile currentTile = _tile.GetNeigbour(action);

            if (!currentTile.isEmpty())
                currentTile.Content.Move(action);

            if (!currentTile.isEmpty())
                return false;

            FloorTile floorTile = (FloorTile)currentTile;
            floorTile.PlaceItem(this);

            _tile.Remove();
            _tile = floorTile;

            return true;
        }
    }
}
