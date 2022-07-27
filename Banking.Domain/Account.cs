namespace Banking.Domain;

public enum AccountStatus { Standard, Gold };

public class Account
{
    private decimal _balance = 5000M;

    public AccountStatus Status { get; set; } = AccountStatus.Standard;
    public decimal GetBalance()
    {
        return _balance;
    }

    public void Deposit(decimal amountToDeposit)
    {
        decimal bonus = this.Status == AccountStatus.Gold ? amountToDeposit * .10M : 0;
        _balance += amountToDeposit + bonus;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        if (amountToWithdraw > _balance)
        {

            throw new OverdraftException();
        }
        else
        {
            _balance -= amountToWithdraw;
        }
    }
}

public class OverdraftException : ArgumentOutOfRangeException { }