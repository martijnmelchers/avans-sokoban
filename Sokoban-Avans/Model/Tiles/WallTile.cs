using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_Avans
{
    class WallTile : Tile
    {
        public override char ToChar()
        {
            return '|';
        }
    }
}