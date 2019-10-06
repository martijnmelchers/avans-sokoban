using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_Avans
{
    class WallTile : Tile
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
            return '█';
        }
    }
}
