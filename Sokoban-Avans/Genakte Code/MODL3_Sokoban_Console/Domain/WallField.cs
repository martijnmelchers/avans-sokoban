// Decompiled with JetBrains decompiler
// Type: Sokoban.Domain.WallField
// Assembly: MODL3_Sokoban_Console, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093DAD0A-C5DE-47B2-9FD1-E13B237341D3
// Assembly location: C:\Users\Martijn\Downloads\MODL3_Sokoban_Console.exe~\MODL3_Sokoban_Console.exe

namespace Sokoban.Domain
{
  internal class WallField : BaseField
  {
    private Wall _wall = new Wall();

    public override bool IsEmpty()
    {
      return false;
    }

    public override PlacableObject Content
    {
      get
      {
        return (PlacableObject) this._wall;
      }
      set
      {
      }
    }

    public override char ToChar()
    {
      return '█';
    }

    public override bool Place(PlacableObject objectToBePlaced)
    {
      return false;
    }

    public override void Remove()
    {
    }
  }
}
