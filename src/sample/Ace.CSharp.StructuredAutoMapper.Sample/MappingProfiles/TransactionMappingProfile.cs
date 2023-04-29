using Ace.CSharp.StructuredAutoMapper.Sample.Dtos;
using Ace.CSharp.StructuredAutoMapper.Sample.Entities;

namespace Ace.CSharp.StructuredAutoMapper.Sample.MappingProfiles;

public sealed class TransactionMappingProfile : TwoWayProfile<TransactionEntity, TransactionDto>
{
    public sealed override void ConfigureLeftToRightMapping()
    {
        _ = CreateMap<TransactionEntity, TransactionDto>()
            .ForMember(
                dto => dto.Id,
                options => options.MapFrom(entity => entity.Id))
            .ForMember(
                dto => dto.ProcessedAt,
                options => options.MapFrom(entity => entity.ProcessedAt.ToUnixTimeMilliseconds()))
            .ForMember(
                dto => dto.Amount,
                options => options.MapFrom(entity => entity.Amount));
    }

    public sealed override void ConfigureRightToLeftMapping()
    {
        _ = CreateMap<TransactionDto, TransactionEntity>()
            .ForMember(
                entity => entity.Id,
                options => options.MapFrom(dto => dto.Id))
            .ForMember(
                entity => entity.OperatorId,
                options => options.Ignore())
            .ForMember(
                entity => entity.ProcessedAt,
                options => options.MapFrom(dto => DateTimeOffset.FromUnixTimeMilliseconds(dto.ProcessedAt)))
            .ForMember(
                entity => entity.Amount,
                options => options.MapFrom(dto => dto.Amount));
    }
}
