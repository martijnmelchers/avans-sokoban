using System.Collections.Generic;

namespace Sokoban
{
    class Maze
    {
        private readonly List<Crate> _crates = new List<Crate>();

        public Worker Worker { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public Truck Truck { get; set;  }
        public bool IsSolved { get; private set; }
        public Tile Origin { get; set; }

        public void AddCrate(Crate crate)
        {
            _crates.Add(crate);
        }

        public Maze() { }


    }
}
