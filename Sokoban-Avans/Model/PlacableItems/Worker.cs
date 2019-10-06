using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban_Avans.Model;

namespace Sokoban_Avans
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

        public override char toChar()
        {
            return this._asleep ? 'Z' : '$';
        }
    }
}
