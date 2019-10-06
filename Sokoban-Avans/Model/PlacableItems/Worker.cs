using Sokoban.Model;

namespace Sokoban
{
    class Worker : PlacableItem
    {

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

        public void walkAround()
        {

        }

        public override char ToChar()
        {
            return this._asleep ? 'Z' : '$';
        }
    }
}
