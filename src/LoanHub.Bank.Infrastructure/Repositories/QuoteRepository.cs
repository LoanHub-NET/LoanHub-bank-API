using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoanHub.Bank.Domain.Entities;
using LoanHub.Bank.Domain.Interfaces;
using LoanHub.Bank.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LoanHub.Bank.Infrastructure.Repositories;

public class QuoteRepository : IQuoteRepository
{
    private readonly BankDbContext _context;

    public QuoteRepository(BankDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Quote quote, CancellationToken cancellationToken = default)
    {
        await _context.Quotes.AddAsync(quote, cancellationToken);
    }

    public async Task<Quote?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Quotes
           .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}