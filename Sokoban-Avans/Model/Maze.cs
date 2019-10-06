using System.Collections.Generic;

namespace Sokoban_Avans
{
    class Maze
    {
        private List<Crate> _crates = new List<Crate>();

        public Worker worker { get; set; }
        public int height { get; set; }
        public int width { get; set; }

        public Truck truck { get; set;  }
        public bool IsSolved { get; private set; }
        public Tile Origin { get; set; }

        public void AddCrate(Crate crate)
        {
            this._crates.Add(crate);
        }

        public Maze() { }


    }
}
