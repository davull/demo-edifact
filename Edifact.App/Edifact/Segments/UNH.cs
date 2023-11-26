namespace Edifact.App.Edifact.Segments;

// https://www.stylusstudio.com/edifact/40100/UNH_.htm
// UNH+1+ORDERS:D:97A:UN
public record UNH(
    string MessageReferenceNumber,
    S009 MessageIdentifier,
    string? CommonAccessReference);