using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_Avans
{
    class FloorTile : Tile
    {
        public override bool PlaceItem(PlacableItem objectToBePlaced)
        {
            if (!this.isEmpty())
                return false;
            this.Content = objectToBePlaced;
            return true;
        }

        public override void Remove()
        {
            this.Content = (PlacableItem)null;
        }

        public override char ToChar()
        {
            if (!this.isEmpty())
                return this.Content.toChar();
            return '.';
        }
    }
}
