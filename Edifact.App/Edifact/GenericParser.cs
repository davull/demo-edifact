using System.Reflection;
using Edifact.App.Edifact.Attributes;
using Edifact.App.Edifact.Segments;

namespace Edifact.App.Edifact;

public static class GenericParser
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

    public static object ParseComponentDataElement(string raw, UNA una, Type type)
    {
        var tuples = type.GetProperties()
            .Select(p => (property: p, attribute: p.GetCustomAttribute<DataElementAttribute>()))
            .Where(t => t.attribute != null);

        var dataElements = raw.Split(una.ComponentDataElementSeparator);
        var instance = Activator.CreateInstance(type);

        foreach (var (property, attribute) in tuples)
        {
            var value = dataElements.ElementAtOrDefault(attribute!.Position - 1);
            property.SetValue(instance, value);
        }

        return instance!;
    }

    public static T ParseComponentDataElement<T>(string raw, UNA una) =>
        (T)ParseComponentDataElement(raw, una, typeof(T));

    public static T ParseSegment<T>(string raw, UNA una)
    {
        var tuples = typeof(T).GetProperties()
            .Select(p => (property: p, attribute: p.GetCustomAttribute<DataElementAttribute>()))
            .Where(t => t.attribute != null);

        var dataElements = raw.Split(una.DataElementSeparator);
        var instance = Activator.CreateInstance<T>();

        foreach (var (property, attribute) in tuples)
        {
            var value = dataElements.ElementAtOrDefault(attribute!.Position - 1);

            if (property.PropertyType.IsAssignableTo(typeof(ComponentDataElement)))
            {
                var componentDataElement = ParseComponentDataElement(value, una, property.PropertyType);
                property.SetValue(instance, componentDataElement);
                continue;
            }

            property.SetValue(instance, value);
        }

        return instance;
    }
}