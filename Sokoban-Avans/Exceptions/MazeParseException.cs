using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_Avans.Exceptions
{
    class MazeParseException : Exception
    {
        private char character;

        public MazeParseException(char character)
        {
            this.character = character;
        }

        public override string ToString()
        {
            return $"An error occurered while parsing the maze. Unkown character: `{character}`";
        }
    }
}
