using Sokoban.Model;
using System;

namespace Sokoban
{
    class Worker : PlacableItem
    {
        private readonly Random _random = new Random();
        private bool _asleep;
        public Worker(Tile tile, bool sleeping)
        {
            _tile = tile;
            _asleep = sleeping;
        }

        public override bool Move(MazeAction action)
        {
            if (_asleep)
                _asleep = false;
            return false;
        }

        public void WalkAround(MazeAction action)
        {
            Tile currentTile = _tile.GetNeigbour(action);
            if (!currentTile.IsEmpty())
                currentTile.Content.Move(action);
            if (!currentTile.IsEmpty())
                return;


            if (currentTile is FloorTile)
            {
                FloorTile floorTile = (FloorTile)currentTile;
                floorTile.PlaceItem(this);
                _tile.Remove();
                _tile = floorTile;
            }

        }

        public override char ToChar()
        {
            return _asleep ? 'Z' : '$';
        }


        public void Work()
        {
            if (_asleep)
            {
                if (_random.Next(10) != 0)
                    return;
                _asleep = false;
            }
            else if (_random.Next(4) == 0)
            {
                _asleep = true;
            }
            else
            {
                switch (_random.Next(4))
                {
                    case 0:
                        WalkAround(MazeAction.Left);
                        break;
                    case 1:
                        WalkAround(MazeAction.Up);
                        break;
                    case 2:
                        WalkAround(MazeAction.Right);
                        break;
                    case 3:
                        WalkAround(MazeAction.Down);
                        break;
                }
            }
        }
    }
}
