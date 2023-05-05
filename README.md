# Ace.CSharp.StructuredAutoMapper

[![build](https://github.com/dimitrietataru/ace-csharp-structured-automapper/actions/workflows/build.yml/badge.svg?branch=ace)](https://github.com/dimitrietataru/ace-csharp-structured-automapper/actions/workflows/build.yml)
[![release](https://github.com/dimitrietataru/ace-csharp-structured-automapper/actions/workflows/release.yml/badge.svg)](https://github.com/dimitrietataru/ace-csharp-structured-automapper/actions/workflows/release.yml)

[![Nuget | Ace.CSharp.StructuredAutoMapper](https://img.shields.io/nuget/v/AceCSharp.StructuredAutoMapper)](https://www.nuget.org/packages/AceCSharp.StructuredAutoMapper)
[![Nuget | Ace.CSharp.StructuredAutoMapper.Abstractions](https://img.shields.io/nuget/v/AceCSharp.StructuredAutoMapper.Abstractions)](https://www.nuget.org/packages/AceCSharp.StructuredAutoMapper.Abstractions)
[![Nuget | Ace.CSharp.StructuredAutoMapper.Abstractions.Test](https://img.shields.io/nuget/v/AceCSharp.StructuredAutoMapper.Abstractions.Test)](https://www.nuget.org/packages/AceCSharp.StructuredAutoMapper.Abstractions.Test)

## Usage

### One-way Mapping Profile
``` csharp
record BarEntity(Guid Id, string Value);
record BarDto(Guid Id, string Value);

class BarMappingProfile : OneWayProfile<BarEntity, BarDto>
{
}
```

### Two-way Mapping Profile
``` csharp
record FooEntity(Guid Id, string Value);
record FooDto(Guid Id, string Value);

class FooMappingProfile : TwoWayProfile<FooEntity, FooDto>
{
}
```

### Two-way Mapping Profile (Explicit)
``` csharp
class TransactionEntity
{
    public int Id { get; set; }
    public Guid OperatorId { get; set; }

    public DateTimeOffset ProcessedAt { get; set; }
    public double Amount { get; set; }
}

class TransactionDto
{
    public int Id { get; set; }

    public long ProcessedAt { get; set; }
    public double Amount { get; set; }
}

class TransactionMappingProfile : TwoWayProfile<TransactionEntity, TransactionDto>
{
    public override void ConfigureLeftToRightMapping()
    {
        CreateMap<TransactionEntity, TransactionDto>()
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

    public override void ConfigureRightToLeftMapping()
    {
        CreateMap<TransactionDto, TransactionEntity>()
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
```

## Tests
https://github.com/dimitrietataru/ace-csharp-structured-automapper/blob/c6ea69337be410cbaa96df3db9c57e6d01308b07/src/sample/Ace.CSharp.StructuredAutoMapper.Sample.Tests/BarMappingProfileTests.cs#L8-L43
https://github.com/dimitrietataru/ace-csharp-structured-automapper/blob/c6ea69337be410cbaa96df3db9c57e6d01308b07/src/sample/Ace.CSharp.StructuredAutoMapper.Sample.Tests/FooMappingProfileTests.cs#L8-L54
https://github.com/dimitrietataru/ace-csharp-structured-automapper/blob/c6ea69337be410cbaa96df3db9c57e6d01308b07/src/sample/Ace.CSharp.StructuredAutoMapper.Sample.Tests/TransactionMappingProfileTests.cs#L8-L70

### See also
* [AutoMapper](https://github.com/AutoMapper/AutoMapper)
* [FluentAssertions](https://github.com/fluentassertions/fluentassertions)

### License
AceCSharp.StructuredAutoMapper is Copyright © 2023 [Dimitrie Tataru](https://github.com/dimitrietataru) and other contributors under the [MIT license](https://github.com/dimitrietataru/ace-csharp-structured-automapper/blob/ace/LICENSE).
