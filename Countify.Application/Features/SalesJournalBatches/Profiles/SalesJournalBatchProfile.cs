using AutoMapper;
using Countify.Application.Features.SalesJournalBatches.DTOs;
using Countify.Domain.Entities.Billing;

namespace Countify.Application.Features.SalesJournalBatches.Profiles;

public class SalesJournalBatchProfile : Profile
{
    public SalesJournalBatchProfile()
    {
        CreateMap<SalesJournalBatch, SalesJournalBatchDto>()
            .ForMember(d => d.EntryNumber, o => o.MapFrom(s => s.JournalEntry != null ? s.JournalEntry.EntryNumber : (int?)null));
    }
}
