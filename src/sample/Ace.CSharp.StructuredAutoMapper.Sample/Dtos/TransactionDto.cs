namespace Ace.CSharp.StructuredAutoMapper.Sample.Dtos;

public sealed class TransactionDto
{
    public int Id { get; set; }

    public long ProcessedAt { get; set; }
    public double Amount { get; set; }
}
