
using System.IO;
namespace Sokoban_Avans
{
    class Parser
    {
        public Maze LoadMaze()
        {

            using (var fileStream = File.OpenRead("./Doolhof/doolhof1.txt"))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    while (var line = streamReader.ReadLine() != null){

                    }
                }
            }
        }


        
    }
}
