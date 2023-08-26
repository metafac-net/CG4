using MetaFac.CG4.Attributes;
using System;

namespace MetaFac.CG4.ModelReader.Tests.ComplexModel2
{
    /// <summary>
    /// A model with multiple hidden base types that are 
    /// provided by the end developer.
    /// </summary>

    [Entity(1, ModelState.Reserved, "Hidden")]
    public class AccountType
    {
        [Member(1)] string? AccountId { get; }
    }

    [Entity(2, ModelState.Reserved, "Hidden")]
    public class TransactionType
    {
        [Member(1)] Guid TxId { get; }
    }

    [Entity(11)]
    public class SavingsAccount : AccountType
    {
        [Member(11)] string? AccountName { get; }
    }

    [Entity(12)]
    public class Withdrawl : TransactionType
    {
        [Member(11)] string? SourceAccountId { get; }
        [Member(12)] string? TargetAccountId { get; }
        [Member(13)] decimal Amount { get; }
        [Member(14)] string? CurrencyCode3 { get; }
    }

}
