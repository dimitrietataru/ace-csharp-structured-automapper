using Ace.CSharp.StructuredAutoMapper.Sample.Dtos;
using Ace.CSharp.StructuredAutoMapper.Sample.Entities;

namespace Ace.CSharp.StructuredAutoMapper.Sample.MappingProfiles;

public sealed class BarMappingProfile : OneWayProfile<BarEntity, BarDto>
{
}
