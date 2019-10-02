// Decompiled with JetBrains decompiler
// Type: Sokoban.Presentation.InputView
// Assembly: MODL3_Sokoban_Console, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093DAD0A-C5DE-47B2-9FD1-E13B237341D3
// Assembly location: C:\Users\Martijn\Downloads\MODL3_Sokoban_Console.exe~\MODL3_Sokoban_Console.exe

using System;

namespace Sokoban.Presentation
{
  public class InputView
  {
    public int AskForMove()
    {
      bool flag = true;
      ConsoleKey consoleKey = ConsoleKey.Escape;
      while (flag)
      {
        Console.WriteLine("> gebruik pijljestoetsen (s = stop, r = reset)");
        consoleKey = Console.ReadKey().Key;
        switch (consoleKey)
        {
          case ConsoleKey.LeftArrow:
          case ConsoleKey.UpArrow:
          case ConsoleKey.RightArrow:
          case ConsoleKey.DownArrow:
          case ConsoleKey.R:
          case ConsoleKey.S:
            flag = false;
            continue;
          default:
            Console.WriteLine("> ?");
            continue;
        }
      }
      switch (consoleKey)
      {
        case ConsoleKey.LeftArrow:
          return 1;
        case ConsoleKey.UpArrow:
          return 3;
        case ConsoleKey.RightArrow:
          return 0;
        case ConsoleKey.DownArrow:
          return 2;
        case ConsoleKey.R:
          return -2;
        case ConsoleKey.S:
          return -1;
        default:
          throw new NotImplementedException();
      }
    }

    public int AskForMazeNumber()
    {
      int num = 0;
      char ch = '?';
      while ((num < 1 || num > 6) && ch != 's')
      {
        Console.WriteLine("> Kies een doolhof (1 - 6), s = stop");
        ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
        ch = consoleKeyInfo.KeyChar;
        Console.WriteLine();
        if (ch >= '1' && ch <= '6')
          num = Convert.ToInt32(char.ToString(consoleKeyInfo.KeyChar));
        else if (ch != 's')
          Console.WriteLine("> ?");
      }
      if (ch == 's')
        num = -1;
      return num;
    }
  }
}
