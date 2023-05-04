using Ace.CSharp.StructuredAutoMapper.Abstractions.Test;
using Ace.CSharp.StructuredAutoMapper.Sample.Dtos;
using Ace.CSharp.StructuredAutoMapper.Sample.Entities;
using Ace.CSharp.StructuredAutoMapper.Sample.MappingProfiles;

namespace Ace.CSharp.StructuredAutoMapper.Sample.Tests;

public sealed class BarMappingProfileTests
    : BaseOneWayProfileTests<BarMappingProfile, BarEntity, BarDto>
{
    protected sealed override Func<BarEntity> Left =>
        () => new BarEntity(Guid.NewGuid(), "bar");

    protected sealed override Action<BarEntity, BarDto> LeftToRightAssertions =>
        (entity, dto) =>
        {
            // FluentAssertions
            dto.Id.Should().Be(entity.Id);
            dto.Value.Should().Be(entity.Value);

            // xUnit Assertions
            Assert.Equal(entity.Id, dto.Id);
            Assert.Equal(entity.Value, dto.Value);
        };

    [Fact]
    public sealed override void GivenMapFromLeftToRightWhenSourceIsNotNullThenMapsData()
    {
        base.GivenMapFromLeftToRightWhenSourceIsNotNullThenMapsData();
    }

    [Fact]
    public sealed override void GivenMapFromLeftToRightWhenSourceIsNullThenHandlesGracefully()
    {
        base.GivenMapFromLeftToRightWhenSourceIsNullThenHandlesGracefully();
    }

    [Fact]
    public sealed override void GivenMapFromRightToLeftWhenMappingIsNotConfiguredThenThrowsException()
    {
        base.GivenMapFromRightToLeftWhenMappingIsNotConfiguredThenThrowsException();
    }
}
