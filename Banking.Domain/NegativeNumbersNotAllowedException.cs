
namespace Banking.Domain;
public class NegativeValuesNotAllowedException : ArgumentOutOfRangeException
{
    private void GuardAgainstNegativeNumbers(decimal amount)
    {
        if (amount < 0) throw new NegativeValuesNotAllowedException();
    }
}




