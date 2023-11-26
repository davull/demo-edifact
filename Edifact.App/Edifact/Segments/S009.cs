namespace Edifact.App.Edifact.Segments;

// MESSAGE IDENTIFIER
public record S009(
    string MessageType,
    string MessageVersionNumber,
    string MessageReleaseNumber,
    string ControllingAgencyCoded,
    string? AssociationAssignedCode,
    string? CodeListDirectoryVersionNumber,
    string? MessageTypeSubFunctionIdentificationCode);