using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanHub.Bank.Application.DTOs;

namespace LoanHub.Bank.Application.Interfaces;

public interface IQuoteService
{
    Task<QuoteResponseDto> CreateQuoteAsync(CreateQuoteRequestDto request);
    Task<QuoteResponseDto?> GetQuoteAsync(Guid id);
}