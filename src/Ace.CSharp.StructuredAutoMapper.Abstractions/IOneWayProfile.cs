namespace Ace.CSharp.StructuredAutoMapper.Abstractions;

public interface IOneWayProfile<in TLeft, in TRight>
    where TLeft : class
    where TRight : class
{
    void ConfigureLeftToRightMapping();
}
