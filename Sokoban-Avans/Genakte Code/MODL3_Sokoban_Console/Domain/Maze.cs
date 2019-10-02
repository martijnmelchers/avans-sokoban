// Decompiled with JetBrains decompiler
// Type: Sokoban.Domain.Maze
// Assembly: MODL3_Sokoban_Console, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093DAD0A-C5DE-47B2-9FD1-E13B237341D3
// Assembly location: C:\Users\Martijn\Downloads\MODL3_Sokoban_Console.exe~\MODL3_Sokoban_Console.exe

using System;
using System.Collections.Generic;

namespace Sokoban.Domain
{
  public class Maze
  {
    private List<Crate> _crates = new List<Crate>();

    public bool IsSolved
    {
      get
      {
        int count = this._crates.Count;
        int num = 0;
        foreach (Crate crate in this._crates)
        {
          if (crate.IsOnTarget())
            ++num;
        }
        return count == num;
      }
    }

    public BaseField Origin { get; set; }

    public Truck TheTruck { set; get; }

    public Employee theEmployee { set; get; }

    public int Width { get; set; }

    public int Height { get; set; }

    public void AddCrate(Crate k)
    {
      if (k == null)
        throw new ArgumentNullException("crate");
      this._crates.Add(k);
    }

    public void moveTruck(Direction r)
    {
      this.TheTruck.Move(r);
    }

    public void ActEmployee()
    {
      if (this.theEmployee == null)
        return;
      this.theEmployee.Act();
    }
  }
}
