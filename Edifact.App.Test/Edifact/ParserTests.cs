using Edifact.App.Edifact;
using Edifact.App.Edifact.Enums;
using Edifact.App.Edifact.Segments;
using FluentAssertions;

namespace Edifact.App.Test.Edifact;

public class ParserTests
{
    [Test]
    public void ShouldParseUNA()
    {
        var line = "UNA:+.? '";
        var una = Parser.ParseUNA(line);

        una.ComponentDataElementSeparator.Should().Be(':');
        una.DataElementSeparator.Should().Be('+');
        una.DecimalNotation.Should().Be('.');
        una.ReleaseCharacter.Should().Be('?');
        una.SegmentTerminator.Should().Be('\'');
    }

    [Test]
    public void ShouldParseS009()
    {
        var raw = "ORDERS:D:97A:UN";

        var s009 = Parser.ParseComponentDataElement<S009>(raw, UNA.Default);

        s009.MessageType.Should().Be("ORDERS");
        s009.MessageVersionNumber.Should().Be("D");
        s009.MessageReleaseNumber.Should().Be("97A");
        s009.ControllingAgencyCoded.Should().Be("UN");
    }

    [Test]
    public void ShouldParseC002()
    {
        var raw = "220::9";

        var c002 = Parser.ParseComponentDataElement<C002>(raw, UNA.Default);

        c002.DocumentMessageNameCodedString.Should().Be("220");
        c002.DocumentMessageNameCoded.Should().Be(DocumentMessageName.Order);
        c002.CodeListQualifier.Should().BeNullOrEmpty();
        c002.CodeListResponsibleAgencyCoded.Should().Be("9");
    }

    [Test]
    public void ShouldParseUNH()
    {
        var raw = "UNH+1+ORDERS:D:97A:UN";

        var unh = Parser.ParseSegment<UNH>(raw, UNA.Default);

        unh.MessageReferenceNumber.Should().Be("1");
        unh.MessageIdentifier.MessageType.Should().Be("ORDERS");
    }
}