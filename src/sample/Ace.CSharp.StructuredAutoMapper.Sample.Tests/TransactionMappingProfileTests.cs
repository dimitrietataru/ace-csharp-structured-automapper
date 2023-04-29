using Ace.CSharp.StructuredAutoMapper.Abstractions.Test;
using Ace.CSharp.StructuredAutoMapper.Sample.Dtos;
using Ace.CSharp.StructuredAutoMapper.Sample.Entities;
using Ace.CSharp.StructuredAutoMapper.Sample.MappingProfiles;

namespace Ace.CSharp.StructuredAutoMapper.Sample.Tests;

public sealed class TransactionMappingProfileTests
    : BaseTwoWayProfileTests<TransactionMappingProfile, TransactionEntity, TransactionDto>
{
    protected sealed override Func<TransactionEntity> Left =>
        () =>
            new TransactionEntity
            {
                Id = 1,
                OperatorId = Guid.Empty,
                ProcessedAt = DateTimeOffset.UtcNow,
                Amount = 1.2345D
            };

    protected sealed override Func<TransactionDto> Right =>
        () =>
            new TransactionDto
            {
                Id = 1,
                ProcessedAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                Amount = 9.8765D
            };

    protected sealed override Action<TransactionEntity, TransactionDto>? LeftToRightAssertions =>
        (entity, dto) =>
        {
            dto.Id.Should().Be(entity.Id);
            dto.ProcessedAt.Should().Be(entity.ProcessedAt.ToUnixTimeMilliseconds());
            dto.Amount.Should().Be(entity.Amount);
        };

    protected sealed override Action<TransactionDto, TransactionEntity>? RightToLeftAssertions =>
        (dto, entity) =>
        {
            entity.Id.Should().Be(dto.Id);
            entity.OperatorId.Should().BeEmpty();
            entity.ProcessedAt.Should().Be(DateTimeOffset.FromUnixTimeMilliseconds(dto.ProcessedAt));
            entity.Amount.Should().Be(dto.Amount);
        };

    [Fact]
    public sealed override void GivenMapFromLeftToRightWhenSourceIsNullThenHandlesGracefully()
    {
        base.GivenMapFromLeftToRightWhenSourceIsNullThenHandlesGracefully();
    }

    [Fact]
    public sealed override void GivenMapFromLeftToRightWhenSourceIsNotNullThenMapsData()
    {
        base.GivenMapFromLeftToRightWhenSourceIsNotNullThenMapsData();
    }

    [Fact]
    public sealed override void GivenMapFromRightToLeftWhenSourceIsNullThenHandlesGracefully()
    {
        base.GivenMapFromRightToLeftWhenSourceIsNullThenHandlesGracefully();
    }

    [Fact]
    public sealed override void GivenMapFromRightToLeftWhenSourceIsNotNullThenMapsData()
    {
        base.GivenMapFromRightToLeftWhenSourceIsNotNullThenMapsData();
    }
}
