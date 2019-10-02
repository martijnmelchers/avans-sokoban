// Decompiled with JetBrains decompiler
// Type: Sokoban.Exception_MazeIncorrectFileFormat
// Assembly: MODL3_Sokoban_Console, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093DAD0A-C5DE-47B2-9FD1-E13B237341D3
// Assembly location: C:\Users\Martijn\Downloads\MODL3_Sokoban_Console.exe~\MODL3_Sokoban_Console.exe

using System;

namespace Sokoban
{
  public class Exception_MazeIncorrectFileFormat : ApplicationException
  {
    private char _unrecognisedCharacter;

    public Exception_MazeIncorrectFileFormat(char onbekendteken)
    {
      this._unrecognisedCharacter = onbekendteken;
    }

    public override string ToString()
    {
      return "Cannot parse Maze file, unkown character: `" + (object) this._unrecognisedCharacter + "`";
    }
  }
}
