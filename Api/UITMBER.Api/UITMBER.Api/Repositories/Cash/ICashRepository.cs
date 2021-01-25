using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Repositories.Cash.Dto;

namespace UITMBER.Api.Repositories.Cash
{
    public interface ICashRepository
    {
        Task<CashDto> GetMySaldo(DateTime startDate, DateTime endDate, long currentUserId);
        Task<CashDto> GetMyEarnings(DateTime startDate, DateTime endDate, long currentUserId);
    }
}
