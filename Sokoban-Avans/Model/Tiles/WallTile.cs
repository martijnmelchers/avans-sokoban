using Sokoban.Model.PlacableItems;
using System;


namespace Sokoban
{
    class WallTile : Tile
    {
        public override PlacableItem Content { get => new Wall(); set { /* can't set this value */ } }
        public override bool IsEmpty()
        {
            return false;
        }
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
            return '█';
        }
    }
}
