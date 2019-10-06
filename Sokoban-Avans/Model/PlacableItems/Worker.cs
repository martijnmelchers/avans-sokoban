using Sokoban.Model;
using System;

namespace Sokoban
{
    class Worker : PlacableItem
    {
        private Random _random = new Random();
        private bool _asleep;
        public Worker(Tile tile, bool sleeping)
        {
            this._tile = tile;
            this._asleep = sleeping;
        }

        public override bool Move(MazeAction action)
        {
            if (this._asleep)
                this._asleep = false;
            return false;
        }

        public void walkAround(MazeAction action)
        {
            Tile currentTile = this._tile.GetNeigbour(action);
            if (!currentTile.IsEmpty())
                currentTile.Content.Move(action);
            if (!currentTile.IsEmpty())
                return;


            if (currentTile is FloorTile)
            {
                FloorTile floorTile = (FloorTile)currentTile;
                floorTile.PlaceItem((PlacableItem)this);
                this._tile.Remove();
                this._tile = (Tile)floorTile;
            }

        }

        public override char ToChar()
        {
            return this._asleep ? 'Z' : '$';
        }


        public void Work()
        {
            if (this._asleep)
            {
                if (this._random.Next(10) != 0)
                    return;
                this._asleep = false;
            }
            else if (this._random.Next(4) == 0)
            {
                this._asleep = true;
            }
            else
            {
                switch (this._random.Next(4))
                {
                    case 0:
                        this.walkAround(MazeAction.Left);
                        break;
                    case 1:
                        this.walkAround(MazeAction.Up);
                        break;
                    case 2:
                        this.walkAround(MazeAction.Right);
                        break;
                    case 3:
                        this.walkAround(MazeAction.Down);
                        break;
                }
            }
        }
    }
}
