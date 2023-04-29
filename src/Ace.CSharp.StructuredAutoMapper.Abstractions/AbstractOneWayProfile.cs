using AutoMapper;

namespace Ace.CSharp.StructuredAutoMapper.Abstractions;

public abstract class AbstractOneWayProfile<TLeft, TRight>
    : Profile, IOneWayProfile<TLeft, TRight>
    where TLeft : class
    where TRight : class
{
    protected AbstractOneWayProfile()
    {
        ConfigureLeftToRightMapping();
    }

    public abstract void ConfigureLeftToRightMapping();
}
