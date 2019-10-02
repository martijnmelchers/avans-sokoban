// Decompiled with JetBrains decompiler
// Type: Sokoban.Domain.FloorField
// Assembly: MODL3_Sokoban_Console, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093DAD0A-C5DE-47B2-9FD1-E13B237341D3
// Assembly location: C:\Users\Martijn\Downloads\MODL3_Sokoban_Console.exe~\MODL3_Sokoban_Console.exe

namespace Sokoban.Domain
{
  public class FloorField : BaseField
  {
    public override PlacableObject Content { get; set; }

    public override bool IsEmpty()
    {
      return this.Content == null;
    }

    public override bool Place(PlacableObject objectToBePlaced)
    {
      if (!this.IsEmpty())
        return false;
      this.Content = objectToBePlaced;
      return true;
    }

    public override void Remove()
    {
      this.Content = (PlacableObject) null;
    }

    public override char ToChar()
    {
      if (!this.IsEmpty())
        return this.Content.ToChar();
      return '.';
    }
  }
}
