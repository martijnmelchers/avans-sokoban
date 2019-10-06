using System;

namespace Sokoban
{
    class EmptyTile : Tile
    {
        public override bool PlaceItem(PlacableItem item)
        {
            throw new NotImplementedException();
        }

        public override void Remove()
        {
            throw new NotImplementedException();
        }

        public override char ToChar()
        {
            return ' ';
        }
    }
}
