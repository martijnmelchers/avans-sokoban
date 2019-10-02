// Decompiled with JetBrains decompiler
// Type: Sokoban.Presentation.OutputView
// Assembly: MODL3_Sokoban_Console, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093DAD0A-C5DE-47B2-9FD1-E13B237341D3
// Assembly location: C:\Users\Martijn\Downloads\MODL3_Sokoban_Console.exe~\MODL3_Sokoban_Console.exe

using Sokoban.Domain;
using System;

namespace Sokoban.Presentation
{
  public class OutputView
  {
    public void ShowBoardState(Maze maze)
    {
      Console.Clear();
      Console.WriteLine("┌──────────┐   ");
      Console.WriteLine("| Sokoban  |   ");
      Console.WriteLine("└──────────┘   ");
      Console.WriteLine("─────────────────────────────────────────────────────────────────────────");
      this.Show(maze);
      Console.WriteLine("─────────────────────────────────────────────────────────────────────────");
    }

    public void ShowGameStart()
    {
      Console.Clear();
      Console.WriteLine("┌────────────────────────────────────────────────────┐");
      Console.WriteLine("| Welkom bij Sokoban                                 |");
      Console.WriteLine("|                                                    |");
      Console.WriteLine("| betekenis van de symbolen   |   doel van het spel  |");
      Console.WriteLine("|                             |                      |");
      Console.WriteLine("| spatie : outerspace         |   duw met de truck   |");
      Console.WriteLine("|      █ : muur               |   de krat(ten)       |");
      Console.WriteLine("|      · : vloer              |   naar de bestemming |");
      Console.WriteLine("|      O : krat               |                      |");
      Console.WriteLine("|      0 : krat op bestemming |                      |");
      Console.WriteLine("|      x : bestemming         |                      |");
      Console.WriteLine("|      @ : truck              |                      |");
      Console.WriteLine("└────────────────────────────────────────────────────┘");
      Console.WriteLine("");
    }

    public void ShowMazeSolved()
    {
      Console.WriteLine();
      Console.WriteLine("=== HOERA OPGELOST ===");
      Console.WriteLine("> press key to continue");
      Console.ReadKey();
    }

    private void Show(Maze mazeModel)
    {
      int height = mazeModel.Height;
      int width = mazeModel.Width;
      BaseField baseField = mazeModel.Origin;
      BaseField fieldBelow = baseField.FieldBelow;
      for (int index1 = 0; index1 < height; ++index1)
      {
        for (int index2 = 0; index2 < width; ++index2)
        {
          Console.Write(baseField.ToChar());
          baseField = baseField.FieldToRight;
        }
        baseField = fieldBelow;
        if (fieldBelow != null)
          fieldBelow = baseField.FieldBelow;
        Console.WriteLine();
      }
    }

    public void ShowError(string message)
    {
      Console.WriteLine();
      Console.WriteLine("> " + message);
      Console.WriteLine("> press key to continue");
      Console.ReadKey();
    }
  }
}
