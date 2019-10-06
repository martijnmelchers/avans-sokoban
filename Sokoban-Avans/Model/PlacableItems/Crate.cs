using Sokoban_Avans.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_Avans
{
    class Crate : PlacableItem
    {
        public Crate(Tile tile)
        {
            this._tile = tile;
        }

        public override char toChar()
        {
            return '#';
        }

        public override bool Move(MazeAction direction)
        {
            Tile currentTile = this._tile.GetNeigbour(direction);
            if (!currentTile.isEmpty())
                return false;
            currentTile.PlaceItem((PlacableItem)this);
            this._tile.Remove();
            this._tile = currentTile;
            return true;
        }

        public bool IsOnTarget()
        {
            return this._tile is TargetTile;
        }
    }
}
