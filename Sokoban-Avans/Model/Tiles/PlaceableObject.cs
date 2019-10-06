using Sokoban_Avans.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_Avans
{
    abstract class PlacableItem
    {
        protected Tile _tile;


        public abstract bool Move(MazeAction action);
        public abstract char toChar();
    }
}
