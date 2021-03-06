using Sokoban.Exceptions;
using Sokoban.Model;
using System.IO;

namespace Sokoban
{
    class Controller
    {
        private readonly OutputView _outputView;
        private readonly InputView _inputView;
        private Maze _maze;

        public Controller()
        {
            _outputView = new OutputView();
            _inputView = new InputView();
        }
        public void Start()
        {
            bool gameActive = true;
            GameState gameState = GameState.Menu;

            SelectAction action = 0;
            // Use a loop to keep the game active
            while(gameActive)
            {
                if(gameState == GameState.Menu)
                {
                    _outputView.ShowGameStart();
                    action = _inputView.AskForAction();

                    // Quit if user asked to do so
                    if (action == SelectAction.Quit)
                        gameActive = false;
                }

                if(gameActive)
                {
                    try
                    {
                        gameState = GameState.InGame;
                        _maze = new Parser().LoadMaze((int)action);
                        _outputView.RenderMaze(_maze);
                        MoveResult result = PlayMaze();

                        switch(result)
                        {
                            case MoveResult.Quit:
                                gameState = GameState.Menu;
                                continue;
                            case MoveResult.Solved:
                                _outputView.ShowMazeFinished();
                                gameState = GameState.Menu;
                                continue;
                            case MoveResult.Reset:
                                continue;


                        }

                    }
                    // If the file is not found in the filesystem
                    catch (FileNotFoundException e)
                    {
                        _outputView.PrintError("Doolhof niet gevonden! Check je systeem of het bestand bestaat");
                        gameState = GameState.Menu;
                    }
                    // If the directory is not found in the filesystem
                    catch (DirectoryNotFoundException e)
                    {
                        _outputView.PrintError("Doolhof niet gevonden! Check je systeem of het bestand bestaat");
                        gameState = GameState.Menu;
                    }
                    // If an error occured while parsing the maze
                    catch (MazeParseException e)
                    {
                        _outputView.PrintError(e.ToString());
                        gameState = GameState.Menu;
                    }
                }
            }
        }

        private MoveResult PlayMaze()
        {
            bool inMaze = true;
            MoveResult result = MoveResult.Quit;

            while(inMaze)
            {
                MazeAction action = _inputView.AskForMove();

                switch(action)
                {
                    case MazeAction.Quit:
                        inMaze = false;
                        result = MoveResult.Quit;
                        break;
                    case MazeAction.Reset:
                        inMaze = false;
                        result = MoveResult.Reset;
                        break;
                    default:
                         _maze.Truck.Move(action);
                         _maze.MoveWorker();
                        if(_maze.IsSolved)
                        {
                            inMaze = false;
                            result = MoveResult.Solved;
                        }

                        _outputView.RenderMaze(_maze);
                        break;
                }
            }

            return result;
        }
    }
}
