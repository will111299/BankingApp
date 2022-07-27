namespace Banking.Domain;

public class Account
{
    private decimal _balance = 5000M;
    public decimal GetBalance()
    {
        return _balance;
    }

    public void Deposit(decimal amountToDeposit)
    {
       _balance += amountToDeposit;
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