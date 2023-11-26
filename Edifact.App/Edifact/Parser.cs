using Edifact.App.Edifact.Segments;

namespace Edifact.App.Edifact;

public static class Parser
{
    public static UNA ParseUNA(string line)
    {
        // UNA:+.? '
        return new UNA(
            ComponentDataElementSeparator: line[3],
            DataElementSeparator: line[4],
            DecimalNotation: line[5],
            ReleaseCharacter: line[6],
            SegmentTerminator: line[8]);
    }

    public static UNH ParseUNH(IReadOnlyList<object> obj)
    {
        var messageReferenceNumber = GetSingleValue(obj, 1)!;
        var messageIdentifier = ParseS009((string[])obj[2]);
        var commonAccessReference = GetSingleValue(obj, 3);

        return new UNH(messageReferenceNumber, messageIdentifier, commonAccessReference);
    }

    public static IEnumerable<object> ParseMessage(string[] lines)
    {
        var una = UNA.Default;

        for (var i = 0; i < lines.Length; i++)
        {
        }

        yield break;
    }

    public static IEnumerable<object> ParseSegment(string line, UNA una)
    {
        var dataElements = line.Split(una.DataElementSeparator);

        yield return dataElements[0];

        foreach (var de in dataElements.Skip(1))
            yield return ParseDataElement(de, una);
    }

    public static IEnumerable<object> ParseDataElement(string raw, UNA una) =>
        raw.Split(una.ComponentDataElementSeparator);

    public static S009 ParseS009(IReadOnlyList<string> parts)
    {
        var messageType = parts[0];
        var messageVersionNumber = parts[1];
        var messageReleaseNumber = parts[2];
        var controllingAgencyCoded = parts[3];
        var associationAssignedCode = parts.GetOptionalValue(4);
        var codeListDirectoryVersionNumber = parts.GetOptionalValue(5);
        var messageTypeSubFunctionIdentificationCode = parts.GetOptionalValue(6);

        return new S009(
            messageType, messageVersionNumber, messageReleaseNumber,
            controllingAgencyCoded, associationAssignedCode,
            codeListDirectoryVersionNumber, messageTypeSubFunctionIdentificationCode);
    }

    private static string? GetOptionalValue(this IReadOnlyList<string> parts, int index)
        => parts.Count > index ? parts[index] : null;

    private static string? GetSingleValue(IReadOnlyList<object> list, int index)
    {
        if (list.Count <= index)
            return null;

        return list[index] switch
        {
            string s => s,
            IEnumerable<object> e => e.First() as string,
            _ => null
        };
    }
}