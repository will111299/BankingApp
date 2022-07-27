
namespace Banking.Tests.Unit;

public class MakingWithdrawals
{
    [Fact]
    public void WithdrawalsDecreaseTheBalance()
    {
        var account = new Account();
        var openingBalance = account.GetBalance();
        var amountToWithdraw = 100M;

        account.Withdraw(amountToWithdraw);

        Assert.Equal(openingBalance - amountToWithdraw,
           account.GetBalance());
    }

    [Fact]
    public void OverdraftDoesNotReduceBalance()
    {
        var account = new Account();
        var openingBalance = account.GetBalance();
        var amountToWithdraw = openingBalance + 1;

        try
        {
            account.Withdraw(amountToWithdraw);
        }
        catch (OverdraftException)
        {

            // ignore 
        }
        finally
        {
            Assert.Equal(openingBalance, account.GetBalance());
        }
    }

    [Fact]
    public void OverdraftThrows()
    {

        var account = new Account();

        Assert.Throws<OverdraftException>(
            () =>  account.Withdraw(account.GetBalance() + 1)
        );


    }



    [Fact]
    public void ShouldBeAllowedToTakeTheEntireBalance()
    {

        var account = new Account();

        account.Withdraw(account.GetBalance());

        Assert.Equal(0, account.GetBalance());
    }

}
