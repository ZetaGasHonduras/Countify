using AutoMapper;
using Countify.Application.Features.FiscalControls.Commands.CreateFiscalControl;
using Countify.Application.Features.FiscalControls.Commands.UpdateFiscalControl;
using Countify.Application.Features.FiscalControls.DTOs;
using Countify.Domain.Entities.Accounting;

namespace Countify.Application.Features.FiscalControls.Profiles;

public class FiscalControlProfile : Profile
{
    public FiscalControlProfile()
    {
        CreateMap<FiscalControl, FiscalControlDto>()
            .ForMember(d => d.DocumentTypeName, o => o.MapFrom(s => s.DocumentType.ToString()));

        CreateMap<CreateFiscalControlCommand, FiscalControl>();
        CreateMap<UpdateFiscalControlCommand, FiscalControl>();
    }
}
