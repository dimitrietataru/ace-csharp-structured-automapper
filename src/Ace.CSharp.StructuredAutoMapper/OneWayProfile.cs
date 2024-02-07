using Ace.CSharp.StructuredAutoMapper.Abstractions;

namespace Ace.CSharp.StructuredAutoMapper;

public abstract class OneWayProfile<TLeft, TRight> : AbstractOneWayProfile<TLeft, TRight>
    where TLeft : class
    where TRight : class
{
    public override void ConfigureLeftToRightMapping()
    {
        CreateMap<TLeft, TRight>();
    }
}
