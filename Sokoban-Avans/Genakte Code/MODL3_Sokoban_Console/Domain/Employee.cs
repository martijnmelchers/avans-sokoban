// Decompiled with JetBrains decompiler
// Type: Sokoban.Domain.Employee
// Assembly: MODL3_Sokoban_Console, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093DAD0A-C5DE-47B2-9FD1-E13B237341D3
// Assembly location: C:\Users\Martijn\Downloads\MODL3_Sokoban_Console.exe~\MODL3_Sokoban_Console.exe

using System;

namespace Sokoban.Domain
{
  public class Employee : PlacableObject
  {
    private Random generator = new Random();
    private bool _asleep;

    private bool IsAsleep
    {
      get
      {
        return this._asleep;
      }
    }

    public Employee(BaseField initialField, bool startSleaping)
    {
      this.Spot = initialField;
      this._asleep = startSleaping;
    }

    public override char ToChar()
    {
      return this._asleep ? 'Z' : '$';
    }

    public void Act()
    {
      if (this._asleep)
      {
        if (this.generator.Next(10) != 0)
          return;
        this._asleep = false;
      }
      else if (this.generator.Next(4) == 0)
      {
        this._asleep = true;
      }
      else
      {
        switch (this.generator.Next(4))
        {
          case 0:
            this.Wander(Direction.Left);
            break;
          case 1:
            this.Wander(Direction.Up);
            break;
          case 2:
            this.Wander(Direction.Right);
            break;
          case 3:
            this.Wander(Direction.Down);
            break;
        }
      }
    }

    public override bool Move(Direction direction)
    {
      if (this._asleep)
        this._asleep = false;
      return false;
    }

    public void Wander(Direction direction)
    {
      BaseField baseField = this.Spot.NeighbourInDirection(direction);
      if (!baseField.IsEmpty())
        baseField.Content.Move(direction);
      if (!baseField.IsEmpty())
        return;
      FloorField floorField = (FloorField) baseField;
      floorField.Place((PlacableObject) this);
      this.Spot.Remove();
      this.Spot = (BaseField) floorField;
    }
  }
}
