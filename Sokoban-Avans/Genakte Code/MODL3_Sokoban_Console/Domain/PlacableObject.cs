﻿// Decompiled with JetBrains decompiler
// Type: Sokoban.Domain.PlacableObject
// Assembly: MODL3_Sokoban_Console, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093DAD0A-C5DE-47B2-9FD1-E13B237341D3
// Assembly location: C:\Users\Martijn\Downloads\MODL3_Sokoban_Console.exe~\MODL3_Sokoban_Console.exe

namespace Sokoban.Domain
{
  public abstract class PlacableObject
  {
    public BaseField Spot;

    public abstract bool Move(Direction richting);

    public abstract char ToChar();
  }
}