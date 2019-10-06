using System.Collections.Generic;

namespace Sokoban
{
    class Maze
    {
        private readonly List<Crate> _crates = new List<Crate>();

        public Worker Worker { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public Truck Truck { get; set; }
        public bool IsSolved
        {
            get
            {
                int totalCrates = _crates.Count;
                int completedCrates = 0;

                // Loop through all crates and see if they are on a target.
                foreach (Crate crate in _crates)
                    if (crate.IsOnTarget())
                        completedCrates++;

                return totalCrates == completedCrates;
            }
        }
        public Tile Origin { get; set; }

        public void AddCrate(Crate crate)
        {
            _crates.Add(crate);
        }

        public Maze() { }


        public void MoveWorker()
        {
            if (Worker == null)
                return;
            Worker.Work();
        }
    }
}
