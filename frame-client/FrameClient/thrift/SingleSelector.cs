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
public partial class SingleSelector : TBase
{
  private IntAttr _resultCount;
  private StringAttr _id;
  private StringAttr _text;
  private StringAttr _nodeTextDescription;
  private StringAttr _nodeClassName;
  private StringAttr _nodeContentdescription;
  private IntAttr _depth;
  private IntAttr _index;
  private IntAttr _contentIndex;
  private long _parentNodeResourceId;
  private List<long> _childNodeResourceIds;
  private bool _resultMark;
  private int _direction;
  private IntAttr _depthToContent;
  private long _nodeSourceId;
  private int _weight;
  private bool _enable;
  private bool _anchorMask;
  private int _depthForAnchor;

  public IntAttr ResultCount
  {
    get
    {
      return _resultCount;
    }
    set
    {
      __isset.resultCount = true;
      this._resultCount = value;
    }
  }

  public StringAttr Id
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

  public StringAttr Text
  {
    get
    {
      return _text;
    }
    set
    {
      __isset.text = true;
      this._text = value;
    }
  }

  public StringAttr NodeTextDescription
  {
    get
    {
      return _nodeTextDescription;
    }
    set
    {
      __isset.nodeTextDescription = true;
      this._nodeTextDescription = value;
    }
  }

  public StringAttr NodeClassName
  {
    get
    {
      return _nodeClassName;
    }
    set
    {
      __isset.nodeClassName = true;
      this._nodeClassName = value;
    }
  }

  public StringAttr NodeContentdescription
  {
    get
    {
      return _nodeContentdescription;
    }
    set
    {
      __isset.nodeContentdescription = true;
      this._nodeContentdescription = value;
    }
  }

  public IntAttr Depth
  {
    get
    {
      return _depth;
    }
    set
    {
      __isset.depth = true;
      this._depth = value;
    }
  }

  public IntAttr Index
  {
    get
    {
      return _index;
    }
    set
    {
      __isset.index = true;
      this._index = value;
    }
  }

  public IntAttr ContentIndex
  {
    get
    {
      return _contentIndex;
    }
    set
    {
      __isset.contentIndex = true;
      this._contentIndex = value;
    }
  }

  public long ParentNodeResourceId
  {
    get
    {
      return _parentNodeResourceId;
    }
    set
    {
      __isset.parentNodeResourceId = true;
      this._parentNodeResourceId = value;
    }
  }

  public List<long> ChildNodeResourceIds
  {
    get
    {
      return _childNodeResourceIds;
    }
    set
    {
      __isset.childNodeResourceIds = true;
      this._childNodeResourceIds = value;
    }
  }

  public bool ResultMark
  {
    get
    {
      return _resultMark;
    }
    set
    {
      __isset.resultMark = true;
      this._resultMark = value;
    }
  }

  public int Direction
  {
    get
    {
      return _direction;
    }
    set
    {
      __isset.direction = true;
      this._direction = value;
    }
  }

  public IntAttr DepthToContent
  {
    get
    {
      return _depthToContent;
    }
    set
    {
      __isset.depthToContent = true;
      this._depthToContent = value;
    }
  }

  public long NodeSourceId
  {
    get
    {
      return _nodeSourceId;
    }
    set
    {
      __isset.nodeSourceId = true;
      this._nodeSourceId = value;
    }
  }

  public int Weight
  {
    get
    {
      return _weight;
    }
    set
    {
      __isset.weight = true;
      this._weight = value;
    }
  }

  public bool Enable
  {
    get
    {
      return _enable;
    }
    set
    {
      __isset.enable = true;
      this._enable = value;
    }
  }

  public bool AnchorMask
  {
    get
    {
      return _anchorMask;
    }
    set
    {
      __isset.anchorMask = true;
      this._anchorMask = value;
    }
  }

  public int DepthForAnchor
  {
    get
    {
      return _depthForAnchor;
    }
    set
    {
      __isset.depthForAnchor = true;
      this._depthForAnchor = value;
    }
  }


  public Isset __isset;
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public struct Isset {
    public bool resultCount;
    public bool id;
    public bool text;
    public bool nodeTextDescription;
    public bool nodeClassName;
    public bool nodeContentdescription;
    public bool depth;
    public bool index;
    public bool contentIndex;
    public bool parentNodeResourceId;
    public bool childNodeResourceIds;
    public bool resultMark;
    public bool direction;
    public bool depthToContent;
    public bool nodeSourceId;
    public bool weight;
    public bool enable;
    public bool anchorMask;
    public bool depthForAnchor;
  }

  public SingleSelector() {
    this._resultMark = false;
    this.__isset.resultMark = true;
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
              ResultCount = new IntAttr();
              ResultCount.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.Struct) {
              Id = new StringAttr();
              Id.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.Struct) {
              Text = new StringAttr();
              Text.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.Struct) {
              NodeTextDescription = new StringAttr();
              NodeTextDescription.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 5:
            if (field.Type == TType.Struct) {
              NodeClassName = new StringAttr();
              NodeClassName.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 6:
            if (field.Type == TType.Struct) {
              NodeContentdescription = new StringAttr();
              NodeContentdescription.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 7:
            if (field.Type == TType.Struct) {
              Depth = new IntAttr();
              Depth.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 8:
            if (field.Type == TType.Struct) {
              Index = new IntAttr();
              Index.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 9:
            if (field.Type == TType.Struct) {
              ContentIndex = new IntAttr();
              ContentIndex.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 10:
            if (field.Type == TType.I64) {
              ParentNodeResourceId = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 11:
            if (field.Type == TType.List) {
              {
                ChildNodeResourceIds = new List<long>();
                TList _list0 = iprot.ReadListBegin();
                for( int _i1 = 0; _i1 < _list0.Count; ++_i1)
                {
                  long _elem2;
                  _elem2 = iprot.ReadI64();
                  ChildNodeResourceIds.Add(_elem2);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 12:
            if (field.Type == TType.Bool) {
              ResultMark = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 13:
            if (field.Type == TType.I32) {
              Direction = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 14:
            if (field.Type == TType.Struct) {
              DepthToContent = new IntAttr();
              DepthToContent.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 15:
            if (field.Type == TType.I64) {
              NodeSourceId = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 16:
            if (field.Type == TType.I32) {
              Weight = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 17:
            if (field.Type == TType.Bool) {
              Enable = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 18:
            if (field.Type == TType.Bool) {
              AnchorMask = iprot.ReadBool();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 19:
            if (field.Type == TType.I32) {
              DepthForAnchor = iprot.ReadI32();
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
      TStruct struc = new TStruct("SingleSelector");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (ResultCount != null && __isset.resultCount) {
        field.Name = "resultCount";
        field.Type = TType.Struct;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        ResultCount.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (Id != null && __isset.id) {
        field.Name = "id";
        field.Type = TType.Struct;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        Id.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (Text != null && __isset.text) {
        field.Name = "text";
        field.Type = TType.Struct;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        Text.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (NodeTextDescription != null && __isset.nodeTextDescription) {
        field.Name = "nodeTextDescription";
        field.Type = TType.Struct;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        NodeTextDescription.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (NodeClassName != null && __isset.nodeClassName) {
        field.Name = "nodeClassName";
        field.Type = TType.Struct;
        field.ID = 5;
        oprot.WriteFieldBegin(field);
        NodeClassName.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (NodeContentdescription != null && __isset.nodeContentdescription) {
        field.Name = "nodeContentdescription";
        field.Type = TType.Struct;
        field.ID = 6;
        oprot.WriteFieldBegin(field);
        NodeContentdescription.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (Depth != null && __isset.depth) {
        field.Name = "depth";
        field.Type = TType.Struct;
        field.ID = 7;
        oprot.WriteFieldBegin(field);
        Depth.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (Index != null && __isset.index) {
        field.Name = "index";
        field.Type = TType.Struct;
        field.ID = 8;
        oprot.WriteFieldBegin(field);
        Index.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (ContentIndex != null && __isset.contentIndex) {
        field.Name = "contentIndex";
        field.Type = TType.Struct;
        field.ID = 9;
        oprot.WriteFieldBegin(field);
        ContentIndex.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (__isset.parentNodeResourceId) {
        field.Name = "parentNodeResourceId";
        field.Type = TType.I64;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(ParentNodeResourceId);
        oprot.WriteFieldEnd();
      }
      if (ChildNodeResourceIds != null && __isset.childNodeResourceIds) {
        field.Name = "childNodeResourceIds";
        field.Type = TType.List;
        field.ID = 11;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.I64, ChildNodeResourceIds.Count));
          foreach (long _iter3 in ChildNodeResourceIds)
          {
            oprot.WriteI64(_iter3);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (__isset.resultMark) {
        field.Name = "resultMark";
        field.Type = TType.Bool;
        field.ID = 12;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(ResultMark);
        oprot.WriteFieldEnd();
      }
      if (__isset.direction) {
        field.Name = "direction";
        field.Type = TType.I32;
        field.ID = 13;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Direction);
        oprot.WriteFieldEnd();
      }
      if (DepthToContent != null && __isset.depthToContent) {
        field.Name = "depthToContent";
        field.Type = TType.Struct;
        field.ID = 14;
        oprot.WriteFieldBegin(field);
        DepthToContent.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (__isset.nodeSourceId) {
        field.Name = "nodeSourceId";
        field.Type = TType.I64;
        field.ID = 15;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(NodeSourceId);
        oprot.WriteFieldEnd();
      }
      if (__isset.weight) {
        field.Name = "weight";
        field.Type = TType.I32;
        field.ID = 16;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Weight);
        oprot.WriteFieldEnd();
      }
      if (__isset.enable) {
        field.Name = "enable";
        field.Type = TType.Bool;
        field.ID = 17;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(Enable);
        oprot.WriteFieldEnd();
      }
      if (__isset.anchorMask) {
        field.Name = "anchorMask";
        field.Type = TType.Bool;
        field.ID = 18;
        oprot.WriteFieldBegin(field);
        oprot.WriteBool(AnchorMask);
        oprot.WriteFieldEnd();
      }
      if (__isset.depthForAnchor) {
        field.Name = "depthForAnchor";
        field.Type = TType.I32;
        field.ID = 19;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(DepthForAnchor);
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
    StringBuilder __sb = new StringBuilder("SingleSelector(");
    bool __first = true;
    if (ResultCount != null && __isset.resultCount) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("ResultCount: ");
      __sb.Append(ResultCount);
    }
    if (Id != null && __isset.id) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Id: ");
      __sb.Append(Id);
    }
    if (Text != null && __isset.text) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Text: ");
      __sb.Append(Text);
    }
    if (NodeTextDescription != null && __isset.nodeTextDescription) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("NodeTextDescription: ");
      __sb.Append(NodeTextDescription);
    }
    if (NodeClassName != null && __isset.nodeClassName) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("NodeClassName: ");
      __sb.Append(NodeClassName);
    }
    if (NodeContentdescription != null && __isset.nodeContentdescription) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("NodeContentdescription: ");
      __sb.Append(NodeContentdescription);
    }
    if (Depth != null && __isset.depth) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Depth: ");
      __sb.Append(Depth);
    }
    if (Index != null && __isset.index) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Index: ");
      __sb.Append(Index);
    }
    if (ContentIndex != null && __isset.contentIndex) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("ContentIndex: ");
      __sb.Append(ContentIndex);
    }
    if (__isset.parentNodeResourceId) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("ParentNodeResourceId: ");
      __sb.Append(ParentNodeResourceId);
    }
    if (ChildNodeResourceIds != null && __isset.childNodeResourceIds) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("ChildNodeResourceIds: ");
      __sb.Append(ChildNodeResourceIds);
    }
    if (__isset.resultMark) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("ResultMark: ");
      __sb.Append(ResultMark);
    }
    if (__isset.direction) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Direction: ");
      __sb.Append(Direction);
    }
    if (DepthToContent != null && __isset.depthToContent) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("DepthToContent: ");
      __sb.Append(DepthToContent);
    }
    if (__isset.nodeSourceId) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("NodeSourceId: ");
      __sb.Append(NodeSourceId);
    }
    if (__isset.weight) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Weight: ");
      __sb.Append(Weight);
    }
    if (__isset.enable) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Enable: ");
      __sb.Append(Enable);
    }
    if (__isset.anchorMask) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("AnchorMask: ");
      __sb.Append(AnchorMask);
    }
    if (__isset.depthForAnchor) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("DepthForAnchor: ");
      __sb.Append(DepthForAnchor);
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}

