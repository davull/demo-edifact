namespace Edifact.App.Edifact.Segments;

//  UNA:+.? '
public record UNA(
    char ComponentDataElementSeparator,
    char DataElementSeparator,
    char DecimalNotation,
    char ReleaseCharacter,
    char SegmentTerminator)
{
    public static UNA Default => new UNA(':', '+', '.', '?', '\'');
}