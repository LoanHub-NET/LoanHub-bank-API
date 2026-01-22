using LoanHub.Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoanHub.Bank.Infrastructure.Persistence;

public class BankDbContext : DbContext
{
    public BankDbContext(DbContextOptions<BankDbContext> options)
        : base(options)
    {
    }

    public DbSet<Quote> Quotes => Set<Quote>();
}
