// Decompiled with JetBrains decompiler
// Type: Sokoban.Domain.BaseField
// Assembly: MODL3_Sokoban_Console, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093DAD0A-C5DE-47B2-9FD1-E13B237341D3
// Assembly location: C:\Users\Martijn\Downloads\MODL3_Sokoban_Console.exe~\MODL3_Sokoban_Console.exe

namespace Sokoban.Domain
{
  public abstract class BaseField
  {
    public BaseField FieldToRight { get; set; }

    public BaseField FieldBelow { get; set; }

    public BaseField FieldToLeft { get; set; }

    public BaseField FieldAbove { get; set; }

    public abstract PlacableObject Content { get; set; }

    public abstract bool IsEmpty();

    public abstract char ToChar();

    public abstract bool Place(PlacableObject objectToBePlaced);

    public abstract void Remove();

    public BaseField NeighbourInDirection(Direction direction)
    {
      switch (direction)
      {
        case Direction.Right:
          return this.FieldToRight;
        case Direction.Left:
          return this.FieldToLeft;
        case Direction.Down:
          return this.FieldBelow;
        case Direction.Up:
          return this.FieldAbove;
        default:
          return (BaseField) null;
      }
    }
  }
}
