namespace Ace.CSharp.StructuredAutoMapper.Sample.Entities;

public sealed class TransactionEntity
{
    public int Id { get; set; }
    public Guid OperatorId { get; set; }

    public DateTimeOffset ProcessedAt { get; set; }
    public double Amount { get; set; }
}
