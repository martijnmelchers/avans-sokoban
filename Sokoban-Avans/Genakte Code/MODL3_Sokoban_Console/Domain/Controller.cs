// Decompiled with JetBrains decompiler
// Type: Sokoban.Domain.Controller
// Assembly: MODL3_Sokoban_Console, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093DAD0A-C5DE-47B2-9FD1-E13B237341D3
// Assembly location: C:\Users\Martijn\Downloads\MODL3_Sokoban_Console.exe~\MODL3_Sokoban_Console.exe

using Sokoban.Presentation;
using System.IO;

namespace Sokoban.Domain
{
  public class Controller
  {
    public const int KeyCancel = -1;
    public const int KeyReset = -2;
    public const int IsMazeSolved = 1;
    public const int FirstStart = -9;
    private InputView _inputview;
    private OutputView _outputview;
    private Maze _maze;

    public Controller()
    {
      this._inputview = new InputView();
      this._outputview = new OutputView();
    }

    public void Go()
    {
      bool flag = true;
      int number = 1;
      Parser parser = new Parser();
      int num = -9;
      while (flag)
      {
        if (num == -9)
        {
          this._outputview.ShowGameStart();
          number = this._inputview.AskForMazeNumber();
          if (number == -1)
            flag = false;
        }
        if (flag)
        {
          try
          {
            this._maze = parser.LoadMaze(number);
            this._outputview.ShowBoardState(this._maze);
            num = this.RunAround();
            switch (num)
            {
              case -1:
                num = -9;
                continue;
              case 1:
                this._outputview.ShowMazeSolved();
                num = -9;
                continue;
              default:
                continue;
            }
          }
          catch (Exception_MazeIncorrectFileFormat ex)
          {
            this._outputview.ShowError("doolhof" + (object) number + " bevat een fout: \n\t" + ex.ToString());
          }
          catch (FileNotFoundException ex)
          {
            this._outputview.ShowError("doolhof" + (object) number + " niet gevonden: \n\t" + ex.FileName);
          }
          catch (DirectoryNotFoundException ex)
          {
            this._outputview.ShowError("doolhof" + (object) number + " niet gevonden: \n\t" + ex.Message);
          }
        }
      }
    }

    private int RunAround()
    {
      bool flag = true;
      int num1 = 0;
      while (flag)
      {
        int num2 = this._inputview.AskForMove();
        switch (num2)
        {
          case -2:
            flag = false;
            num1 = -2;
            continue;
          case -1:
            flag = false;
            num1 = -1;
            continue;
          default:
            this._maze.TheTruck.Move((Direction) num2);
            this._maze.ActEmployee();
            if (this._maze.IsSolved)
            {
              flag = false;
              num1 = 1;
            }
            this._outputview.ShowBoardState(this._maze);
            continue;
        }
      }
      return num1;
    }
  }
}
