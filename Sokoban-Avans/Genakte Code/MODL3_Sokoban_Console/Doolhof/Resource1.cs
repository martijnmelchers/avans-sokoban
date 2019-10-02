// Decompiled with JetBrains decompiler
// Type: Sokoban.Doolhof.Resource1
// Assembly: MODL3_Sokoban_Console, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093DAD0A-C5DE-47B2-9FD1-E13B237341D3
// Assembly location: C:\Users\Martijn\Downloads\MODL3_Sokoban_Console.exe~\MODL3_Sokoban_Console.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Sokoban.Doolhof
{
  [CompilerGenerated]
  [DebuggerNonUserCode]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  internal class Resource1
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resource1()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) Resource1.resourceMan, (object) null))
          Resource1.resourceMan = new ResourceManager("Sokoban.Doolhof.Resource1", typeof (Resource1).Assembly);
        return Resource1.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return Resource1.resourceCulture;
      }
      set
      {
        Resource1.resourceCulture = value;
      }
    }

    internal static string doolhof1
    {
      get
      {
        return Resource1.ResourceManager.GetString(nameof (doolhof1), Resource1.resourceCulture);
      }
    }

    internal static string doolhof2
    {
      get
      {
        return Resource1.ResourceManager.GetString(nameof (doolhof2), Resource1.resourceCulture);
      }
    }

    internal static string doolhof3
    {
      get
      {
        return Resource1.ResourceManager.GetString(nameof (doolhof3), Resource1.resourceCulture);
      }
    }

    internal static string doolhof4
    {
      get
      {
        return Resource1.ResourceManager.GetString(nameof (doolhof4), Resource1.resourceCulture);
      }
    }
  }
}
