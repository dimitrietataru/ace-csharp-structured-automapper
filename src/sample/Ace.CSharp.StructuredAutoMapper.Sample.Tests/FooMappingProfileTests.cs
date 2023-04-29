using Ace.CSharp.StructuredAutoMapper.Abstractions.Test;
using Ace.CSharp.StructuredAutoMapper.Sample.Dtos;
using Ace.CSharp.StructuredAutoMapper.Sample.Entities;
using Ace.CSharp.StructuredAutoMapper.Sample.MappingProfiles;

namespace Ace.CSharp.StructuredAutoMapper.Sample.Tests;

public sealed class FooMappingProfileTests
    : BaseTwoWayProfileTests<FooMappingProfile, FooEntity, FooDto>
{
    protected sealed override Func<FooEntity> Left =>
        () => new FooEntity(Guid.NewGuid(), "foo");

    protected sealed override Func<FooDto> Right =>
        () => new FooDto(Guid.NewGuid(), "foo-dto");

    protected sealed override Action<FooEntity, FooDto>? LeftToRightAssertions =>
        (entity, dto) =>
        {
            dto.Id.Should().Be(entity.Id);
            dto.Value.Should().Be(entity.Value);
        };

    protected sealed override Action<FooDto, FooEntity>? RightToLeftAssertions =>
        (dto, entity) =>
        {
            entity.Id.Should().Be(dto.Id);
            entity.Value.Should().Be(dto.Value);
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
