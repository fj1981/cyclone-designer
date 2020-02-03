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
public partial class ScrapConfig : TBase
{
  private MouseEventType _triggerEventType;
  private MouseEventType _cancleEventType;
  private bool _highlight;
  private string _highlightColor;
  private double _alpha;
  private int _waitMilliSeconds;
  private string _extraJson;
  private int _id;

  /// <summary>
  /// 
  /// <seealso cref="MouseEventType"/>
  /// </summary>
  public MouseEventType TriggerEventType
  {
    get
    {
      return _triggerEventType;
    }
    set
    {
      __isset.triggerEventType = true;
      this._triggerEventType = value;
    }
  }

  /// <summary>
  /// 
  /// <seealso cref="MouseEventType"/>
  /// </summary>
  public MouseEventType CancleEventType
  {
    get
    {
      return _cancleEventType;
    }
    set
    {
      __isset.cancleEventType = true;
      this._cancleEventType = value;
    }
  }

  public bool Highlight
  {
    get
    {
      return _highlight;
    }
    set
    {
      __isset.highlight = true;
      this._highlight = value;
    }
  }

  public string HighlightColor
  {
    get
    {
      return _highlightColor;
    }
    set
    {
      __isset.highlightColor = true;
      this._highlightColor = value;
    }
  }

  public double Alpha
  {
    get
    {
      return _alpha;
    }
    set
    {
      __isset.alpha = true;
      this._alpha = value;
    }
  }

  public int WaitMilliSeconds
  {
    get
    {
      return _waitMilliSeconds;
    }
    set
    {
      __isset.waitMilliSeconds = true;
      this._waitMilliSeconds = value;
    }
  }

  public string ExtraJson
  {
    get
    {
      return _extraJson;
    }
    set
    {
      __isset.extraJson = true;
      this._extraJson = value;
    }
  }

  public int Id
  {
    get
    {
      return _id;
    }
    set
    {
      __isset.id = true;
      this._id = value;
    }
  }


  public Isset __isset;
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public struct Isset {
    public bool triggerEventType;
    public bool cancleEventType;
    public bool highlight;
    public bool highlightColor;
    public bool alpha;
    public bool waitMilliSeconds;
    public bool extraJson;
    public bool id;
  }

  public ScrapConfig() {
    this._triggerEventType = MouseEventType.MOUSE_LEFT_CLICK;
    this.__isset.triggerEventType = true;
    this._cancleEventType = MouseEventType.MOUSE_RIGHT_CLICK;
    this.__isset.cancleEventType = true;
    this._highlight = true;
    this.__isset.highlight = true;
    this._highlightColor = "#fec611";
    this.__isset.highlightColor = true;
    this._alpha = 0.6;
    this.__isset.alpha = true;
    this._waitMilliSeconds = 0;
    this.__isset.waitMilliSeconds = true;
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
            if (field.Type == TType.I32) {
              TriggerEventType = (MouseEventType)iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.I32) {
              CancleEventType = (MouseEventType)iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.Bool) {
              Highlight = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.String) {
              HighlightColor = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.Double) {
              Alpha = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 7:
            if (field.Type == TType.I32) {
              WaitMilliSeconds = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 6:
            if (field.Type == TType.String) {
              ExtraJson = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 8:
            if (field.Type == TType.I32) {
              Id = iprot.ReadI32();
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
      TStruct struc = new TStruct("ScrapConfig");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.triggerEventType) {
        field.Name = "triggerEventType";
        field.Type = TType.I32;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32((int)TriggerEventType);
        oprot.WriteFieldEnd();
      }
      if (__isset.cancleEventType) {
        field.Name = "cancleEventType";
        field.Type = TType.I32;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32((int)CancleEventType);
        oprot.WriteFieldEnd();
      }
      if (__isset.highlight) {
        field.Name = "highlight";
        field.Type = TType.Bool;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(Highlight);
        oprot.WriteFieldEnd();
      }
      if (HighlightColor != null && __isset.highlightColor) {
        field.Name = "highlightColor";
        field.Type = TType.String;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(HighlightColor);
        oprot.WriteFieldEnd();
      }
      if (__isset.alpha) {
        field.Name = "alpha";
        field.Type = TType.Double;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(Alpha);
        oprot.WriteFieldEnd();
      }
      if (ExtraJson != null && __isset.extraJson) {
        field.Name = "extraJson";
        field.Type = TType.String;
        field.ID = 6;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(ExtraJson);
        oprot.WriteFieldEnd();
      }
      if (__isset.waitMilliSeconds) {
        field.Name = "waitMilliSeconds";
        field.Type = TType.I32;
        field.ID = 7;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(WaitMilliSeconds);
        oprot.WriteFieldEnd();
      }
      if (__isset.id) {
        field.Name = "id";
        field.Type = TType.I32;
        field.ID = 8;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Id);
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
    StringBuilder __sb = new StringBuilder("ScrapConfig(");
    bool __first = true;
    if (__isset.triggerEventType) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("TriggerEventType: ");
      __sb.Append(TriggerEventType);
    }
    if (__isset.cancleEventType) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("CancleEventType: ");
      __sb.Append(CancleEventType);
    }
    if (__isset.highlight) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Highlight: ");
      __sb.Append(Highlight);
    }
    if (HighlightColor != null && __isset.highlightColor) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("HighlightColor: ");
      __sb.Append(HighlightColor);
    }
    if (__isset.alpha) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Alpha: ");
      __sb.Append(Alpha);
    }
    if (__isset.waitMilliSeconds) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("WaitMilliSeconds: ");
      __sb.Append(WaitMilliSeconds);
    }
    if (ExtraJson != null && __isset.extraJson) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("ExtraJson: ");
      __sb.Append(ExtraJson);
    }
    if (__isset.id) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Id: ");
      __sb.Append(Id);
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}

