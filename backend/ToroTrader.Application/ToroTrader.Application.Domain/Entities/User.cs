using ToroTrader.Application.Domain.Entities.Base;

namespace ToroTrader.Application.Domain.Entities;

public class User : Entity
{
    public User(string name, decimal balance, string documentNumber, string accountId = null, string clientId = null)
    {
        this.Name = name ?? throw new ArgumentNullException(nameof(Name));
        this.AccountId = accountId ?? "0";
        this.ClientId = clientId ?? "0";
        this.Balance = balance;
        this.DocumentNumber = documentNumber ?? throw new ArgumentNullException(nameof(DocumentNumber));
        //this.SetLastAccess();
    }

    public string Name { get; private set; }

    public string AccountId { get; private set; }

    public string ClientId { get; private set; }

    public decimal Balance { get; private set; }

    public string DocumentNumber { get; private set; }

    public DateTime LastAccess { get; private set; }

    public void SetLastAccess(DateTime date)
    {
        this.LastAccess = date;
    }

    public void Debit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("O valor a ser debitado deve ser maior que zero.");

        if (Balance < amount)
            throw new InvalidOperationException("Saldo insuficiente para realizar a operação.");

        Balance -= amount;
    }
}
