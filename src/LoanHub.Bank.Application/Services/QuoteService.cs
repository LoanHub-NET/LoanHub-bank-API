using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanHub.Bank.Application.DTOs;
using LoanHub.Bank.Application.Interfaces;
using LoanHub.Bank.Domain.Entities;
using LoanHub.Bank.Domain.Interfaces;

namespace LoanHub.Bank.Application.Services;

public class QuoteService : IQuoteService
{
    private readonly IQuoteRepository _repository;

    public QuoteService(IQuoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<QuoteResponseDto> CreateQuoteAsync(CreateQuoteRequestDto request)
    {
        var quote = new Quote(
            request.RequestedAmount.Amount,
            request.RequestedAmount.CurrencyCode,
            request.InstalmentNumber
        );

        await _repository.AddAsync(quote);
        await _repository.SaveChangesAsync();

        return new QuoteResponseDto(
            quote.Id,
            new MoneyDto(quote.MonthlyInstallment, quote.Currency),
            quote.CreatedDate
        );
    }

    public async Task<QuoteResponseDto?> GetQuoteAsync(Guid id)
    {
        var quote = await _repository.GetByIdAsync(id);
        if (quote == null) return null;

        return new QuoteResponseDto(
            quote.Id,
            new MoneyDto(quote.MonthlyInstallment, quote.Currency),
            quote.CreatedDate
        );
    }
}