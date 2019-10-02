using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_Avans
{
    class EmptyTile : Tile
    {
        public override char toChar()
        {
            return ' ';
        }
    }
}
