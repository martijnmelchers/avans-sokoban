// Decompiled with JetBrains decompiler
// Type: Sokoban.Program
// Assembly: MODL3_Sokoban_Console, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093DAD0A-C5DE-47B2-9FD1-E13B237341D3
// Assembly location: C:\Users\Martijn\Downloads\MODL3_Sokoban_Console.exe~\MODL3_Sokoban_Console.exe

using Sokoban.Domain;

namespace Sokoban
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      new Controller().Go();
    }
  }
}
