using Sokoban_Avans.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_Avans
{
    class Truck : PlacableItem
    {
        public Truck(Tile tile)
        {
            this._tile = tile;
        }

        public override char toChar() {
            return '@';
        }

        public override bool Move(MazeAction action)
        {
            Tile currentTile = this._tile.GetNeigbour(action);
            if (!currentTile.isEmpty())
                currentTile.Content.Move(action);
            if (!currentTile.isEmpty())
                return false;
            FloorTile floorTile = (FloorTile)currentTile;
            floorTile.PlaceItem((PlacableItem)this);
            this._tile.Remove();
            this._tile = (Tile)floorTile;
            return true;
        }
    }
}
