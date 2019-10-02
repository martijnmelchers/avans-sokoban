// Decompiled with JetBrains decompiler
// Type: Sokoban.Domain.Parser
// Assembly: MODL3_Sokoban_Console, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093DAD0A-C5DE-47B2-9FD1-E13B237341D3
// Assembly location: C:\Users\Martijn\Downloads\MODL3_Sokoban_Console.exe~\MODL3_Sokoban_Console.exe

using System;
using System.Collections.Generic;
using System.IO;

namespace Sokoban.Domain
{
  internal class Parser
  {
    private string _pathName = "";
    private FileStream _inputStream;
    private StreamReader _streamReader;
    private Maze _maze;

    public Maze LoadMaze(int number)
    {
      this._maze = new Maze();
      this._pathName = "..\\..\\Doolhof\\doolhof" + (object) number + ".txt";
      List<BaseField> previousLine = (List<BaseField>) null;
      int y = 0;
      try
      {
        this.detectDimensions();
        this._inputStream = new FileStream(this._pathName, FileMode.Open, FileAccess.Read);
        this._streamReader = new StreamReader((Stream) this._inputStream);
        string lineString = this._streamReader.ReadLine();
        do
        {
          if (lineString != null)
          {
            List<BaseField> currentLine = this.procesLine(lineString, y);
            if (previousLine != null)
              this.linkLines(previousLine, currentLine);
            else
              this._maze.Origin = currentLine[0];
            previousLine = currentLine;
            ++y;
            lineString = this._streamReader.ReadLine();
          }
          else
          {
            this._streamReader.Close();
            this._inputStream.Close();
          }
        }
        while (lineString != null);
        return this._maze;
      }
      catch (Exception_MazeIncorrectFileFormat ex)
      {
        throw;
      }
      catch (Exception ex)
      {
        throw;
      }
    }

    private List<BaseField> procesLine(string lineString, int y)
    {
      List<BaseField> baseFieldList = new List<BaseField>();
      BaseField baseField = (BaseField) null;
      for (int index = 0; index < lineString.Length; ++index)
      {
        BaseField initialField;
        switch (lineString[index])
        {
          case ' ':
            initialField = (BaseField) new EmptyField();
            break;
          case '#':
            initialField = (BaseField) new WallField();
            break;
          case '$':
          case '.':
          case '@':
          case 'Z':
          case 'o':
            initialField = (BaseField) new FloorField();
            break;
          case 'x':
            initialField = (BaseField) new TargetField();
            break;
          case '~':
            initialField = (BaseField) new PitfallField();
            break;
          default:
            throw new Exception_MazeIncorrectFileFormat(lineString[index]);
        }
        if (baseField != null)
        {
          initialField.FieldToLeft = baseField;
          baseField.FieldToRight = initialField;
        }
        baseField = initialField;
        baseFieldList.Add(initialField);
        if (lineString[index] == '@')
        {
          Truck truck = new Truck(initialField);
          this._maze.TheTruck = truck;
          initialField.Place((PlacableObject) truck);
        }
        if (lineString[index] == 'o')
        {
          Crate k = new Crate(initialField);
          this._maze.AddCrate(k);
          initialField.Place((PlacableObject) k);
        }
        if (lineString[index] == '$' || lineString[index] == 'Z')
        {
          Employee employee = new Employee(initialField, lineString[index] == 'Z');
          this._maze.theEmployee = employee;
          initialField.Place((PlacableObject) employee);
        }
      }
      return baseFieldList;
    }

    private void linkLines(List<BaseField> previousLine, List<BaseField> currentLine)
    {
      for (int index = 0; index < currentLine.Count; ++index)
      {
        if (previousLine[index] != null && currentLine[index] != null)
        {
          currentLine[index].FieldAbove = previousLine[index];
          previousLine[index].FieldBelow = currentLine[index];
        }
      }
    }

    private void detectDimensions()
    {
      this._inputStream = new FileStream(this._pathName, FileMode.Open, FileAccess.Read);
      this._streamReader = new StreamReader((Stream) this._inputStream);
      int num1 = 0;
      int num2 = 0;
      try
      {
        string str = this._streamReader.ReadLine();
        do
        {
          if (str != null)
          {
            if (str.Length > num1)
              num1 = str.Length;
            ++num2;
            str = this._streamReader.ReadLine();
          }
          else
          {
            this._streamReader.Close();
            this._inputStream.Close();
          }
        }
        while (str != null);
        this._maze.Width = num1;
        this._maze.Height = num2;
      }
      catch (Exception ex)
      {
        throw;
      }
    }
  }
}
