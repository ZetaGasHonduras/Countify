using AutoMapper;
using Countify.Application.Features.JournalEntries.Commands.CreateJournalEntry;
using Countify.Application.Features.JournalEntries.Commands.UpdateJournalEntry;
using Countify.Application.Features.JournalEntries.DTOs;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Enums;

namespace Countify.Application.Features.JournalEntries.Profiles;

public class JournalEntryProfile : Profile
{
    public JournalEntryProfile()
    {
        CreateMap<JournalEntry, JournalEntryDto>()
            .ForMember(d => d.Gid, o => o.MapFrom(s => s.EntryGid))
            .ForMember(d => d.TypeName, o => o.MapFrom(s => s.Type != null ? s.Type.Name : string.Empty));

        CreateMap<JournalEntryLine, JournalEntryLineDto>()
            .ForMember(d => d.Gid, o => o.MapFrom(s => s.LineGid))
            .ForMember(d => d.AccountCode, o => o.MapFrom(s => s.Account != null ? s.Account.Code : string.Empty))
            .ForMember(d => d.AccountName, o => o.MapFrom(s => s.Account != null ? s.Account.Name : string.Empty))
            .ForMember(d => d.EntryConceptType,
                o => o.MapFrom(s => s.EntryConceptType.HasValue
                    ? (int)s.EntryConceptType.Value
                    : (int?)null));

        CreateMap<JournalEntryLineRequest, JournalEntryLine>()
            .ForMember(d => d.EntryConceptType,
                o => o.MapFrom(s => s.EntryConceptType.HasValue
                    ? (EntryConceptType?)s.EntryConceptType.Value
                    : (EntryConceptType?)null));

        CreateMap<CreateJournalEntryCommand, JournalEntry>()
            .ForMember(d => d.Period, o => o.Ignore())
            .ForMember(d => d.Type, o => o.Ignore())
            .ForMember(d => d.Lines, o => o.Ignore());

        CreateMap<UpdateJournalEntryCommand, JournalEntry>()
            .ForMember(d => d.Period, o => o.Ignore())
            .ForMember(d => d.Type, o => o.Ignore())
            .ForMember(d => d.Lines, o => o.Ignore());
    }
}