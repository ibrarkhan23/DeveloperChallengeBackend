using DeveloperChallenge.Models.Dtos.OutputDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperChallenge.Services.Interfaces
{
    public interface IQuotableService
    {
        Task<QuotableOutputDto> GetRandomQuote();
        Task<List<QuotableActualOutputDto>> GetQuotesByAuthor();
    }
}
