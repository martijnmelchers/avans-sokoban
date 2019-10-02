// Decompiled with JetBrains decompiler
// Type: Sokoban.Domain.TargetField
// Assembly: MODL3_Sokoban_Console, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093DAD0A-C5DE-47B2-9FD1-E13B237341D3
// Assembly location: C:\Users\Martijn\Downloads\MODL3_Sokoban_Console.exe~\MODL3_Sokoban_Console.exe

namespace Sokoban.Domain
{
  internal class TargetField : FloorField
  {
    public override char ToChar()
    {
      if (!this.IsEmpty() && !(this.Content is Crate))
        return this.Content.ToChar();
      return this.Content is Crate ? '0' : 'x';
    }
  }
}
