// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: libsserialdata.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from libsserialdata.proto</summary>
public static partial class LibsserialdataReflection {

  #region Descriptor
  /// <summary>File descriptor for libsserialdata.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static LibsserialdataReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "ChRsaWJzc2VyaWFsZGF0YS5wcm90byKkAQoIc3BlY2RhdGESEwoLbGFtYmRh",
          "Y291bnQYASABKAUSDgoGaW50YWN0GAIgASgIEhAKCHNwZWNsYW1iGAMgAygB",
          "EhAKCGZpbGVuYW1lGAQgASgJEhAKCGZvbGRuYW1lGAUgASgJEhEKCXNwZWNj",
          "b3VudBgGIAEoBRIRCglpbnRlbnNpdHkYByADKAUSEQoJdGltZXN0YW1wGA0g",
          "ASgJSgQICBANYgZwcm90bzM="));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { },
        new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
          new pbr::GeneratedClrTypeInfo(typeof(global::specdata), global::specdata.Parser, new[]{ "Lambdacount", "Intact", "Speclamb", "Filename", "Foldname", "Speccount", "Intensity", "Timestamp" }, null, null, null)
        }));
  }
  #endregion

}
#region Messages
public sealed partial class specdata : pb::IMessage<specdata> {
  private static readonly pb::MessageParser<specdata> _parser = new pb::MessageParser<specdata>(() => new specdata());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pb::MessageParser<specdata> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::LibsserialdataReflection.Descriptor.MessageTypes[0]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public specdata() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public specdata(specdata other) : this() {
    lambdacount_ = other.lambdacount_;
    intact_ = other.intact_;
    speclamb_ = other.speclamb_.Clone();
    filename_ = other.filename_;
    foldname_ = other.foldname_;
    speccount_ = other.speccount_;
    intensity_ = other.intensity_.Clone();
    timestamp_ = other.timestamp_;
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public specdata Clone() {
    return new specdata(this);
  }

  /// <summary>Field number for the "lambdacount" field.</summary>
  public const int LambdacountFieldNumber = 1;
  private int lambdacount_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int Lambdacount {
    get { return lambdacount_; }
    set {
      lambdacount_ = value;
    }
  }

  /// <summary>Field number for the "intact" field.</summary>
  public const int IntactFieldNumber = 2;
  private bool intact_;
  /// <summary>
  ///测试的光谱是否完整
  /// </summary>
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool Intact {
    get { return intact_; }
    set {
      intact_ = value;
    }
  }

  /// <summary>Field number for the "speclamb" field.</summary>
  public const int SpeclambFieldNumber = 3;
  private static readonly pb::FieldCodec<double> _repeated_speclamb_codec
      = pb::FieldCodec.ForDouble(26);
  private readonly pbc::RepeatedField<double> speclamb_ = new pbc::RepeatedField<double>();
  /// <summary>
  ///波长值
  /// </summary>
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public pbc::RepeatedField<double> Speclamb {
    get { return speclamb_; }
  }

  /// <summary>Field number for the "filename" field.</summary>
  public const int FilenameFieldNumber = 4;
  private string filename_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Filename {
    get { return filename_; }
    set {
      filename_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "foldname" field.</summary>
  public const int FoldnameFieldNumber = 5;
  private string foldname_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Foldname {
    get { return foldname_; }
    set {
      foldname_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "speccount" field.</summary>
  public const int SpeccountFieldNumber = 6;
  private int speccount_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int Speccount {
    get { return speccount_; }
    set {
      speccount_ = value;
    }
  }

  /// <summary>Field number for the "intensity" field.</summary>
  public const int IntensityFieldNumber = 7;
  private static readonly pb::FieldCodec<int> _repeated_intensity_codec
      = pb::FieldCodec.ForInt32(58);
  private readonly pbc::RepeatedField<int> intensity_ = new pbc::RepeatedField<int>();
  /// <summary>
  ///光谱强度，按行依次排列
  /// </summary>
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public pbc::RepeatedField<int> Intensity {
    get { return intensity_; }
  }

  /// <summary>Field number for the "timestamp" field.</summary>
  public const int TimestampFieldNumber = 13;
  private string timestamp_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Timestamp {
    get { return timestamp_; }
    set {
      timestamp_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override bool Equals(object other) {
    return Equals(other as specdata);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool Equals(specdata other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (Lambdacount != other.Lambdacount) return false;
    if (Intact != other.Intact) return false;
    if(!speclamb_.Equals(other.speclamb_)) return false;
    if (Filename != other.Filename) return false;
    if (Foldname != other.Foldname) return false;
    if (Speccount != other.Speccount) return false;
    if(!intensity_.Equals(other.intensity_)) return false;
    if (Timestamp != other.Timestamp) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override int GetHashCode() {
    int hash = 1;
    if (Lambdacount != 0) hash ^= Lambdacount.GetHashCode();
    if (Intact != false) hash ^= Intact.GetHashCode();
    hash ^= speclamb_.GetHashCode();
    if (Filename.Length != 0) hash ^= Filename.GetHashCode();
    if (Foldname.Length != 0) hash ^= Foldname.GetHashCode();
    if (Speccount != 0) hash ^= Speccount.GetHashCode();
    hash ^= intensity_.GetHashCode();
    if (Timestamp.Length != 0) hash ^= Timestamp.GetHashCode();
    if (_unknownFields != null) {
      hash ^= _unknownFields.GetHashCode();
    }
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void WriteTo(pb::CodedOutputStream output) {
    if (Lambdacount != 0) {
      output.WriteRawTag(8);
      output.WriteInt32(Lambdacount);
    }
    if (Intact != false) {
      output.WriteRawTag(16);
      output.WriteBool(Intact);
    }
    speclamb_.WriteTo(output, _repeated_speclamb_codec);
    if (Filename.Length != 0) {
      output.WriteRawTag(34);
      output.WriteString(Filename);
    }
    if (Foldname.Length != 0) {
      output.WriteRawTag(42);
      output.WriteString(Foldname);
    }
    if (Speccount != 0) {
      output.WriteRawTag(48);
      output.WriteInt32(Speccount);
    }
    intensity_.WriteTo(output, _repeated_intensity_codec);
    if (Timestamp.Length != 0) {
      output.WriteRawTag(106);
      output.WriteString(Timestamp);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int CalculateSize() {
    int size = 0;
    if (Lambdacount != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(Lambdacount);
    }
    if (Intact != false) {
      size += 1 + 1;
    }
    size += speclamb_.CalculateSize(_repeated_speclamb_codec);
    if (Filename.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Filename);
    }
    if (Foldname.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Foldname);
    }
    if (Speccount != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(Speccount);
    }
    size += intensity_.CalculateSize(_repeated_intensity_codec);
    if (Timestamp.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Timestamp);
    }
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(specdata other) {
    if (other == null) {
      return;
    }
    if (other.Lambdacount != 0) {
      Lambdacount = other.Lambdacount;
    }
    if (other.Intact != false) {
      Intact = other.Intact;
    }
    speclamb_.Add(other.speclamb_);
    if (other.Filename.Length != 0) {
      Filename = other.Filename;
    }
    if (other.Foldname.Length != 0) {
      Foldname = other.Foldname;
    }
    if (other.Speccount != 0) {
      Speccount = other.Speccount;
    }
    intensity_.Add(other.intensity_);
    if (other.Timestamp.Length != 0) {
      Timestamp = other.Timestamp;
    }
    _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(pb::CodedInputStream input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
          break;
        case 8: {
          Lambdacount = input.ReadInt32();
          break;
        }
        case 16: {
          Intact = input.ReadBool();
          break;
        }
        case 26:
        case 25: {
          speclamb_.AddEntriesFrom(input, _repeated_speclamb_codec);
          break;
        }
        case 34: {
          Filename = input.ReadString();
          break;
        }
        case 42: {
          Foldname = input.ReadString();
          break;
        }
        case 48: {
          Speccount = input.ReadInt32();
          break;
        }
        case 58:
        case 56: {
          intensity_.AddEntriesFrom(input, _repeated_intensity_codec);
          break;
        }
        case 106: {
          Timestamp = input.ReadString();
          break;
        }
      }
    }
  }

}

#endregion


#endregion Designer generated code
