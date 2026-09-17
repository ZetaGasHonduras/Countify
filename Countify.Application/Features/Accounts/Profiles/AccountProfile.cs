using AutoMapper;
using Countify.Application.Features.Accounts.Commands.CreateAccount;
using Countify.Application.Features.Accounts.Commands.UpdateAccount;
using Countify.Application.Features.Accounts.DTOs;
using Countify.Domain.Entities.Accounting;

namespace Countify.Application.Features.Accounts.Profiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<Account, AccountDto>();

        CreateMap<CreateAccountCommand, Account>();

        CreateMap<UpdateAccountCommand, Account>();
    }
}