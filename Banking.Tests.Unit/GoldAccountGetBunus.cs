using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Tests.Unit;

public class GoldAccountsGetBonus
{
    [Fact]
    public void GoldAccountsGetBonusOnDeposit()
    {
        // Given
        var account = new Account();
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100M;
        account.Status = AccountStatus.Gold;
        // When

        account.Deposit(amountToDeposit);


        // Then
        Assert.Equal(openingBalance + amountToDeposit + 10M, account.GetBalance());

    }
}