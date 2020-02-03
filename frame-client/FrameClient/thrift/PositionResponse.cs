/**
 * Autogenerated by Thrift Compiler (0.12.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;


#if !SILVERLIGHT
[Serializable]
#endif
public partial class PositionResponse : TBase
{
  private ScreenPosition _position;
  private string _packageName;

  public ScreenPosition Position
  {
    get
    {
      return _position;
    }
    set
    {
      __isset.position = true;
      this._position = value;
    }
  }

  public string PackageName
  {
    get
    {
      return _packageName;
    }
    set
    {
      __isset.packageName = true;
      this._packageName = value;
    }
  }


  public Isset __isset;
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public struct Isset {
    public bool position;
    public bool packageName;
  }

  public PositionResponse() {
  }

  public void Read (TProtocol iprot)
  {
    iprot.IncrementRecursionDepth();
    try
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.Struct) {
              Position = new ScreenPosition();
              Position.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              PackageName = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }
    finally
    {
      iprot.DecrementRecursionDepth();
    }
  }

  public void Write(TProtocol oprot) {
    oprot.IncrementRecursionDepth();
    try
    {
      TStruct struc = new TStruct("PositionResponse");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (Position != null && __isset.position) {
        field.Name = "position";
        field.Type = TType.Struct;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        Position.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (PackageName != null && __isset.packageName) {
        field.Name = "packageName";
        field.Type = TType.String;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(PackageName);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }
    finally
    {
      oprot.DecrementRecursionDepth();
    }
  }

  public override string ToString() {
    StringBuilder __sb = new StringBuilder("PositionResponse(");
    bool __first = true;
    if (Position != null && __isset.position) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Position: ");
      __sb.Append(Position== null ? "<null>" : Position.ToString());
    }
    if (PackageName != null && __isset.packageName) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("PackageName: ");
      __sb.Append(PackageName);
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}

