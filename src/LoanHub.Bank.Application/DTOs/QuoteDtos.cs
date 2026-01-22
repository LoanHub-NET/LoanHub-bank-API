using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanHub.Bank.Application.DTOs;

public record CreateQuoteRequestDto(MoneyDto RequestedAmount, int InstalmentNumber);

public record MoneyDto(decimal Amount, string CurrencyCode);

public record QuoteResponseDto(
    Guid QuoteId,
    MoneyDto InstalmentAmount,
    DateTime CreateDate
);
