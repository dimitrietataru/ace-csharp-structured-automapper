using AutoMapper;
using FluentAssertions;

namespace Ace.CSharp.StructuredAutoMapper.Abstractions.Test;

public abstract class BaseTwoWayProfileTests<TProfile, TLeft, TRight>
    where TProfile : class, ITwoWayProfile<TLeft, TRight>
    where TLeft : class
    where TRight : class
{
    private readonly IMapper mapper;

    protected BaseTwoWayProfileTests()
    {
        var configuration = new MapperConfiguration(
            config => config.AddProfile(typeof(TProfile)));

        mapper = configuration.CreateMapper();
    }

    protected abstract Func<TLeft> Left { get; }
    protected abstract Func<TRight> Right { get; }

    protected abstract Action<TLeft, TRight>? LeftToRightAssertions { get; }
    protected abstract Action<TRight, TLeft>? RightToLeftAssertions { get; }

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
        LeftToRightAssertions?.Invoke(left, right);
    }

    public virtual void GivenMapFromRightToLeftWhenSourceIsNullThenHandlesGracefully()
    {
        // Arrange
        var right = (TRight?)null;

        // Act
        var left = mapper.Map<TLeft>(right);

        // Assert
        left.Should().BeNull();
    }

    public virtual void GivenMapFromRightToLeftWhenSourceIsNotNullThenMapsData()
    {
        // Arrange
        var right = Right.Invoke();

        // Act
        var left = mapper.Map<TLeft>(right);

        // Assert
        right.Should().NotBeNull();
        left.Should().NotBeNull().And.BeOfType<TLeft>();
        RightToLeftAssertions?.Invoke(right, left);
    }
}
