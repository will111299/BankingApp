
namespace Banking.Domain;

public class StandardBusinessClock : IProvideTheBusinessClock
{
    private readonly ISystemTime _clock;

    public StandardBusinessClock(ISystemTime clock)
    {
        _clock = clock;
    }

    bool IProvideTheBusinessClock.IsDuringBusinessHour()
    {
        return _clock.GetCurrent().Hour >= 9 && _clock.GetCurrent().Hour < 17;
    }
}
