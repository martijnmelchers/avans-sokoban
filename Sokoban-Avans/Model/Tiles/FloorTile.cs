namespace Sokoban
{
    class FloorTile : Tile
    {
        public override PlacableItem Content { get; set; }

        public override bool PlaceItem(PlacableItem objectToBePlaced)
        {
            if (!IsEmpty())
                return false;
            Content = objectToBePlaced;

            return true;
        }

        public override void Remove()
        {
            Content = null;
        }

        public override char ToChar()
        {
            if (!IsEmpty())
                return Content.ToChar();
            return '.';
        }
    }
}
