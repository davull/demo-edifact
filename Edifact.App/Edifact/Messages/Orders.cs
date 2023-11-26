using Edifact.App.Edifact.Attributes;
using Edifact.App.Edifact.Segments;

namespace Edifact.App.Edifact.Messages;

// https://service.unece.org/trade/untdid/d97a/trmd/orders_c.htm
// https://service.unece.org/trade/untdid/d97a/trmd/orders_d.htm

/// <summary>
/// ORDERS D.97A
/// </summary>
public class Orders : Message
{
    /// <summary>
    /// Beginning of message
    /// </summary>
    [Segment(2)]
    public BGM BGM { get; set; }
}