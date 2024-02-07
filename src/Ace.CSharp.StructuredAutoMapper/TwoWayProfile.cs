using Ace.CSharp.StructuredAutoMapper.Abstractions;

namespace Ace.CSharp.StructuredAutoMapper;

public abstract class TwoWayProfile<TLeft, TRight> : AbstractTwoWayProfile<TLeft, TRight>
    where TLeft : class
    where TRight : class
{
    public override void ConfigureLeftToRightMapping()
    {
        CreateMap<TLeft, TRight>();
    }

    public override void ConfigureRightToLeftMapping()
    {
        CreateMap<TRight, TLeft>();
    }
}
