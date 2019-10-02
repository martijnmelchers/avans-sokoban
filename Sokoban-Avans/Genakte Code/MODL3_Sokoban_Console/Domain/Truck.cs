// Decompiled with JetBrains decompiler
// Type: Sokoban.Domain.Truck
// Assembly: MODL3_Sokoban_Console, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093DAD0A-C5DE-47B2-9FD1-E13B237341D3
// Assembly location: C:\Users\Martijn\Downloads\MODL3_Sokoban_Console.exe~\MODL3_Sokoban_Console.exe

namespace Sokoban.Domain
{
  public class Truck : PlacableObject
  {
    public Truck(BaseField initialField)
    {
      this.Spot = initialField;
    }

    public override char ToChar()
    {
      return '@';
    }

    public override bool Move(Direction direction)
    {
      BaseField baseField = this.Spot.NeighbourInDirection(direction);
      if (!baseField.IsEmpty())
        baseField.Content.Move(direction);
      if (!baseField.IsEmpty())
        return false;
      FloorField floorField = (FloorField) baseField;
      floorField.Place((PlacableObject) this);
      this.Spot.Remove();
      this.Spot = (BaseField) floorField;
      return true;
    }
  }
}
