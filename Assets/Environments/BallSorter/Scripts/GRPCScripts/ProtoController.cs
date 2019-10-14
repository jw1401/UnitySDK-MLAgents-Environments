// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: ProtoController.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from ProtoController.proto</summary>
public static partial class ProtoControllerReflection {

  #region Descriptor
  /// <summary>File descriptor for ProtoController.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static ProtoControllerReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "ChVQcm90b0NvbnRyb2xsZXIucHJvdG8iKwoTT2JzZXJ2YXRpb25SZXNwb25z",
          "ZRIUCgxvYnNlcnZhdGlvbnMYASADKAIiBwoFRW1wdHkiIAoNQWN0aW9uUmVx",
          "dWVzdBIPCgdhY3Rpb25zGAEgAygCIisKD0FjdGlvbnNSZXNwb25zZRIYChBh",
          "Y3Rpb25zUGVyZm9ybWVkGAEgASgIIjYKBlN0YXR1cxIRCglpc1J1bm5pbmcY",
          "ASABKAgSGQoRaXNXYWl0aW5nRm9yU3RhcnQYAiABKAgykQEKCkNvbnRyb2xs",
          "ZXISMQoPR2V0T2JzZXJ2YXRpb25zEgYuRW1wdHkaFC5PYnNlcnZhdGlvblJl",
          "c3BvbnNlIgASMAoKU2V0QWN0aW9ucxIOLkFjdGlvblJlcXVlc3QaEC5BY3Rp",
          "b25zUmVzcG9uc2UiABIeCglHZXRTdGF0dXMSBi5FbXB0eRoHLlN0YXR1cyIA",
          "YgZwcm90bzM="));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { },
        new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
          new pbr::GeneratedClrTypeInfo(typeof(global::ObservationResponse), global::ObservationResponse.Parser, new[]{ "Observations" }, null, null, null),
          new pbr::GeneratedClrTypeInfo(typeof(global::Empty), global::Empty.Parser, null, null, null, null),
          new pbr::GeneratedClrTypeInfo(typeof(global::ActionRequest), global::ActionRequest.Parser, new[]{ "Actions" }, null, null, null),
          new pbr::GeneratedClrTypeInfo(typeof(global::ActionsResponse), global::ActionsResponse.Parser, new[]{ "ActionsPerformed" }, null, null, null),
          new pbr::GeneratedClrTypeInfo(typeof(global::Status), global::Status.Parser, new[]{ "IsRunning", "IsWaitingForStart" }, null, null, null)
        }));
  }
  #endregion

}
#region Messages
public sealed partial class ObservationResponse : pb::IMessage<ObservationResponse> {
  private static readonly pb::MessageParser<ObservationResponse> _parser = new pb::MessageParser<ObservationResponse>(() => new ObservationResponse());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pb::MessageParser<ObservationResponse> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::ProtoControllerReflection.Descriptor.MessageTypes[0]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public ObservationResponse() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public ObservationResponse(ObservationResponse other) : this() {
    observations_ = other.observations_.Clone();
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public ObservationResponse Clone() {
    return new ObservationResponse(this);
  }

  /// <summary>Field number for the "observations" field.</summary>
  public const int ObservationsFieldNumber = 1;
  private static readonly pb::FieldCodec<float> _repeated_observations_codec
      = pb::FieldCodec.ForFloat(10);
  private readonly pbc::RepeatedField<float> observations_ = new pbc::RepeatedField<float>();
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public pbc::RepeatedField<float> Observations {
    get { return observations_; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override bool Equals(object other) {
    return Equals(other as ObservationResponse);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool Equals(ObservationResponse other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if(!observations_.Equals(other.observations_)) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override int GetHashCode() {
    int hash = 1;
    hash ^= observations_.GetHashCode();
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
    observations_.WriteTo(output, _repeated_observations_codec);
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int CalculateSize() {
    int size = 0;
    size += observations_.CalculateSize(_repeated_observations_codec);
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(ObservationResponse other) {
    if (other == null) {
      return;
    }
    observations_.Add(other.observations_);
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
        case 10:
        case 13: {
          observations_.AddEntriesFrom(input, _repeated_observations_codec);
          break;
        }
      }
    }
  }

}

public sealed partial class Empty : pb::IMessage<Empty> {
  private static readonly pb::MessageParser<Empty> _parser = new pb::MessageParser<Empty>(() => new Empty());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pb::MessageParser<Empty> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::ProtoControllerReflection.Descriptor.MessageTypes[1]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public Empty() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public Empty(Empty other) : this() {
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public Empty Clone() {
    return new Empty(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override bool Equals(object other) {
    return Equals(other as Empty);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool Equals(Empty other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override int GetHashCode() {
    int hash = 1;
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
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int CalculateSize() {
    int size = 0;
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(Empty other) {
    if (other == null) {
      return;
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
      }
    }
  }

}

public sealed partial class ActionRequest : pb::IMessage<ActionRequest> {
  private static readonly pb::MessageParser<ActionRequest> _parser = new pb::MessageParser<ActionRequest>(() => new ActionRequest());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pb::MessageParser<ActionRequest> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::ProtoControllerReflection.Descriptor.MessageTypes[2]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public ActionRequest() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public ActionRequest(ActionRequest other) : this() {
    actions_ = other.actions_.Clone();
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public ActionRequest Clone() {
    return new ActionRequest(this);
  }

  /// <summary>Field number for the "actions" field.</summary>
  public const int ActionsFieldNumber = 1;
  private static readonly pb::FieldCodec<float> _repeated_actions_codec
      = pb::FieldCodec.ForFloat(10);
  private readonly pbc::RepeatedField<float> actions_ = new pbc::RepeatedField<float>();
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public pbc::RepeatedField<float> Actions {
    get { return actions_; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override bool Equals(object other) {
    return Equals(other as ActionRequest);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool Equals(ActionRequest other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if(!actions_.Equals(other.actions_)) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override int GetHashCode() {
    int hash = 1;
    hash ^= actions_.GetHashCode();
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
    actions_.WriteTo(output, _repeated_actions_codec);
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int CalculateSize() {
    int size = 0;
    size += actions_.CalculateSize(_repeated_actions_codec);
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(ActionRequest other) {
    if (other == null) {
      return;
    }
    actions_.Add(other.actions_);
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
        case 10:
        case 13: {
          actions_.AddEntriesFrom(input, _repeated_actions_codec);
          break;
        }
      }
    }
  }

}

public sealed partial class ActionsResponse : pb::IMessage<ActionsResponse> {
  private static readonly pb::MessageParser<ActionsResponse> _parser = new pb::MessageParser<ActionsResponse>(() => new ActionsResponse());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pb::MessageParser<ActionsResponse> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::ProtoControllerReflection.Descriptor.MessageTypes[3]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public ActionsResponse() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public ActionsResponse(ActionsResponse other) : this() {
    actionsPerformed_ = other.actionsPerformed_;
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public ActionsResponse Clone() {
    return new ActionsResponse(this);
  }

  /// <summary>Field number for the "actionsPerformed" field.</summary>
  public const int ActionsPerformedFieldNumber = 1;
  private bool actionsPerformed_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool ActionsPerformed {
    get { return actionsPerformed_; }
    set {
      actionsPerformed_ = value;
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override bool Equals(object other) {
    return Equals(other as ActionsResponse);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool Equals(ActionsResponse other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (ActionsPerformed != other.ActionsPerformed) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override int GetHashCode() {
    int hash = 1;
    if (ActionsPerformed != false) hash ^= ActionsPerformed.GetHashCode();
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
    if (ActionsPerformed != false) {
      output.WriteRawTag(8);
      output.WriteBool(ActionsPerformed);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int CalculateSize() {
    int size = 0;
    if (ActionsPerformed != false) {
      size += 1 + 1;
    }
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(ActionsResponse other) {
    if (other == null) {
      return;
    }
    if (other.ActionsPerformed != false) {
      ActionsPerformed = other.ActionsPerformed;
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
          ActionsPerformed = input.ReadBool();
          break;
        }
      }
    }
  }

}

public sealed partial class Status : pb::IMessage<Status> {
  private static readonly pb::MessageParser<Status> _parser = new pb::MessageParser<Status>(() => new Status());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pb::MessageParser<Status> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::ProtoControllerReflection.Descriptor.MessageTypes[4]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public Status() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public Status(Status other) : this() {
    isRunning_ = other.isRunning_;
    isWaitingForStart_ = other.isWaitingForStart_;
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public Status Clone() {
    return new Status(this);
  }

  /// <summary>Field number for the "isRunning" field.</summary>
  public const int IsRunningFieldNumber = 1;
  private bool isRunning_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool IsRunning {
    get { return isRunning_; }
    set {
      isRunning_ = value;
    }
  }

  /// <summary>Field number for the "isWaitingForStart" field.</summary>
  public const int IsWaitingForStartFieldNumber = 2;
  private bool isWaitingForStart_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool IsWaitingForStart {
    get { return isWaitingForStart_; }
    set {
      isWaitingForStart_ = value;
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override bool Equals(object other) {
    return Equals(other as Status);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool Equals(Status other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (IsRunning != other.IsRunning) return false;
    if (IsWaitingForStart != other.IsWaitingForStart) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override int GetHashCode() {
    int hash = 1;
    if (IsRunning != false) hash ^= IsRunning.GetHashCode();
    if (IsWaitingForStart != false) hash ^= IsWaitingForStart.GetHashCode();
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
    if (IsRunning != false) {
      output.WriteRawTag(8);
      output.WriteBool(IsRunning);
    }
    if (IsWaitingForStart != false) {
      output.WriteRawTag(16);
      output.WriteBool(IsWaitingForStart);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int CalculateSize() {
    int size = 0;
    if (IsRunning != false) {
      size += 1 + 1;
    }
    if (IsWaitingForStart != false) {
      size += 1 + 1;
    }
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(Status other) {
    if (other == null) {
      return;
    }
    if (other.IsRunning != false) {
      IsRunning = other.IsRunning;
    }
    if (other.IsWaitingForStart != false) {
      IsWaitingForStart = other.IsWaitingForStart;
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
          IsRunning = input.ReadBool();
          break;
        }
        case 16: {
          IsWaitingForStart = input.ReadBool();
          break;
        }
      }
    }
  }

}

#endregion


#endregion Designer generated code
