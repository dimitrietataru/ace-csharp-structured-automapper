using AutoMapper;
using FluentAssertions;

namespace Ace.CSharp.StructuredAutoMapper.Abstractions.Test;

public abstract class BaseOneWayProfileTests<TProfile, TLeft, TRight>
    where TProfile : class, IOneWayProfile<TLeft, TRight>
    where TLeft : class
    where TRight : class
{
    private readonly IMapper mapper;

    protected BaseOneWayProfileTests()
    {
        var configuration = new MapperConfiguration(
            config => config.AddProfile(typeof(TProfile)));

        mapper = configuration.CreateMapper();
    }

    protected abstract Func<TLeft> Left { get; }

    protected abstract Action<TLeft, TRight>? LeftToRightAssertions { get; }

    public virtual void GivenMapFromLeftToRightWhenSourceIsNullThenHandlesGracefully()
    {
        // Arrange
        var left = (TLeft?)null;

        // Act
        var right = mapper.Map<TRight>(left);

        // Assert
        right.Should().BeNull();
    }

    public virtual void GivenMapFromLeftToRightWhenSourceIsNotNullThenMapsData()
    {
        // Arrange
        var left = Left.Invoke();

        // Act
        var right = mapper.Map<TRight>(left);

        // Assert
        left.Should().NotBeNull();
        right.Should().NotBeNull().And.BeOfType<TRight>();
        LeftToRightAssertions?.Invoke(left, right!);
    }

    public virtual void GivenMapFromRightToLeftWhenMappingIsNotConfiguredThenThrowsException()
    {
        // Arrange
        var left = Left.Invoke();

        // Act
        var right = mapper.Map<TRight>(left);
        var action = () => mapper.Map<TLeft>(right);

        // Assert
        action.Should().Throw<AutoMapperMappingException>();
    }
}
