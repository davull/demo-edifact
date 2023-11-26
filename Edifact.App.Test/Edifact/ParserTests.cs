using Edifact.App.Edifact;
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
        var parts = "ORDERS:D:97A:UN".Split(':');
        var s009 = Parser.ParseS009(parts);

        s009.MessageType.Should().Be("ORDERS");
        s009.MessageVersionNumber.Should().Be("D");
        s009.MessageReleaseNumber.Should().Be("97A");
        s009.ControllingAgencyCoded.Should().Be("UN");
    }

    [Test]
    public void ShouldParseUNH()
    {
        var line = "UNH+1+ORDERS:D:97A:UN";
        var una = UNA.Default;

        var segment = Parser.ParseSegment(line, una).ToList();
        var unh = Parser.ParseUNH(segment);

        unh.MessageReferenceNumber.Should().Be("1");
        unh.MessageIdentifier.MessageType.Should().Be("ORDERS");
    }

    [TestCase("UNH+1+ORDERS:D:97A:UN")]
    [TestCase("BGM+220::9+8900140287+9")]
    public void ShouldParseSegment(string line)
    {
        var una = UNA.Default;
        var segment = Parser.ParseSegment(line, una);


    }

    [TestCaseSource(nameof(GetTestfiles))]
    public void ShouldParseTestfiles(string filePath)
    {
        var document = File.ReadAllLines(filePath);
    }

    public static IEnumerable<TestCaseData> GetTestfiles()
    {
        var testfiles = Directory.GetFiles("../../../Edifact/Testfiles", "*.txt");

        foreach (var testfile in testfiles)
        {
            yield return new TestCaseData(testfile)
                { TestName = Path.GetFileName(testfile) };
        }
    }
}