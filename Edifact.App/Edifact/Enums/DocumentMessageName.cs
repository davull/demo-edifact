namespace Edifact.App.Edifact.Enums;

// https://service.unece.org/trade/untdid/d97a/uncl/uncl1001.htm

/// <summary>
/// Document/message identifier expressed in code.
/// </summary>
public enum DocumentMessageName
{
   /// <summary>
   /// Certificate providing the values of an analysis.
   /// </summary>
   CertificateOfAnalysis = 1,

   /// <summary>
   /// Certificate certifying the conformity to predefined definitions.
   /// </summary>
   CertificateOfConformity = 2,

   // ...

   /// <summary>
   /// Document/message by means of which a buyer initiates a
   /// transaction with a seller involving the supply of goods
   /// or services as specified, according to conditions set out
   /// in an offer, or otherwise known to the buyer.
   /// </summary>
   Order = 220,
}