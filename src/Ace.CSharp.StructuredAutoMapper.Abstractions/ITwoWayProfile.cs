namespace Ace.CSharp.StructuredAutoMapper.Abstractions;

public interface ITwoWayProfile<in TLeft, in TRight>
    where TLeft : class
    where TRight : class
{
    void ConfigureLeftToRightMapping();
    void ConfigureRightToLeftMapping();
}
