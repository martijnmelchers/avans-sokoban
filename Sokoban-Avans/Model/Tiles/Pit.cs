using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class PitTile : FloorTile
    {
        private int damage = 0;

        public override bool PlaceItem(PlacableItem item)
        {
            Content = item;
            damage++;

            if(damage > 3 && item is Crate)
            {
                Content = null;    
            }

            return true;
        }

        public override char ToChar()
        {
            if (!this.IsEmpty())
                return this.Content.ToChar();
            return this.damage < 3 ? '~' : ' ';
        }
    }
}
