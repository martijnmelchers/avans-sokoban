// Decompiled with JetBrains decompiler
// Type: Sokoban.Domain.PitfallField
// Assembly: MODL3_Sokoban_Console, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093DAD0A-C5DE-47B2-9FD1-E13B237341D3
// Assembly location: C:\Users\Martijn\Downloads\MODL3_Sokoban_Console.exe~\MODL3_Sokoban_Console.exe

namespace Sokoban.Domain
{
  internal class PitfallField : FloorField
  {
    private int count;

    public override bool Place(PlacableObject objectToBePlaced)
    {
      this.Content = objectToBePlaced;
      ++this.count;
      if (this.count > 3 && objectToBePlaced is Crate)
        this.Content = (PlacableObject) null;
      return true;
    }

    public override char ToChar()
    {
      if (!this.IsEmpty())
        return this.Content.ToChar();
      return this.count < 3 ? '~' : ' ';
    }
  }
}
