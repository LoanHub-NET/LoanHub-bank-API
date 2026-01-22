using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanHub.Bank.Domain.Entities;

public class Quote
{
    public Guid Id { get; private set; }
    public decimal RequestedAmount { get; private set; }
    public string Currency { get; private set; }
    public int InstallmentCount { get; private set; }
    public decimal MonthlyInstallment { get; private set; }
    public DateTime CreatedDate { get; private set; }

    private Quote() { }

    public Quote(decimal amount, string currency, int installmentCount)
    {
        Id = Guid.NewGuid();
        RequestedAmount = amount;
        Currency = currency;
        InstallmentCount = installmentCount;
        CreatedDate = DateTime.UtcNow;

        CalculateInstallment();
    }

    private void CalculateInstallment()
    {
        // Prosta logika: Kwota + 10% / liczba rat
        var totalAmount = RequestedAmount * 1.10m;
        MonthlyInstallment = Math.Round(totalAmount / InstallmentCount, 2);
    }
}