// Decompiled with JetBrains decompiler
// Type: Sokoban.SequenceDiagramStubs
// Assembly: MODL3_Sokoban_Console, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093DAD0A-C5DE-47B2-9FD1-E13B237341D3
// Assembly location: C:\Users\Martijn\Downloads\MODL3_Sokoban_Console.exe~\MODL3_Sokoban_Console.exe

using Sokoban.Domain;

namespace Sokoban
{
  public class SequenceDiagramStubs
  {
    private FloorField currentField = new FloorField();
    private FloorField targetField = new FloorField();

    public void polymorphMove()
    {
      Crate crate = new Crate((BaseField) this.currentField);
      Truck truck = new Truck((BaseField) this.currentField);
      new Wall().Move(Direction.Right);
      crate.Move(Direction.Right);
      truck.Move(Direction.Right);
    }

    public void polymorphPlace()
    {
      Crate crate = new Crate((BaseField) this.currentField);
      Truck truck = new Truck((BaseField) this.currentField);
      Wall wall = new Wall();
      FloorField floorField = new FloorField();
      WallField wallField = new WallField();
      EmptyField emptyField = new EmptyField();
      floorField.Place((PlacableObject) crate);
      wallField.Place((PlacableObject) crate);
      emptyField.Place((PlacableObject) crate);
    }

    public void polymorphToChar()
    {
      Crate crate = new Crate((BaseField) this.currentField);
      Truck truck = new Truck((BaseField) this.currentField);
      Wall wall = new Wall();
      FloorField floorField = new FloorField();
      TargetField targetField = new TargetField();
      WallField wallField = new WallField();
      EmptyField emptyField = new EmptyField();
      int num1 = (int) crate.ToChar();
      int num2 = (int) truck.ToChar();
      int num3 = (int) wall.ToChar();
      int num4 = (int) floorField.ToChar();
      int num5 = (int) wallField.ToChar();
      int num6 = (int) emptyField.ToChar();
      int num7 = (int) targetField.ToChar();
    }
  }
}
