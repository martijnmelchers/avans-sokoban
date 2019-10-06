using System;

namespace Sokoban
{
    class TargetTile : Tile
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
            return 'x';
        }
    }
}
