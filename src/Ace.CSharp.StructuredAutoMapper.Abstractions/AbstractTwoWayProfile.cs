using AutoMapper;

namespace Ace.CSharp.StructuredAutoMapper.Abstractions;

public abstract class AbstractTwoWayProfile<TLeft, TRight>
    : Profile, ITwoWayProfile<TLeft, TRight>
    where TLeft : class
    where TRight : class
{
    protected AbstractTwoWayProfile()
    {
        ConfigureLeftToRightMapping();
        ConfigureRightToLeftMapping();
    }

    public abstract void ConfigureLeftToRightMapping();

    public abstract void ConfigureRightToLeftMapping();
}
