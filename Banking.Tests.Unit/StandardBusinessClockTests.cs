
namespace Banking.Tests.Unit;

public class StandardBusinessClockTests
{
    // During business days (9-5 local time)

    [Fact]
    public void At900WeAreOpen()
    {
        var stubbedClock = new Mock<ISystemTime>();
        IProvideTheBusinessClock clock = new StandardBusinessClock(stubbedClock.Object);
        stubbedClock.Setup(c => c.GetCurrent()).Returns(new DateTime(2022, 7, 29, 9, 00, 00));


        Assert.True(clock.IsDuringBusinessHour());
    }
    [Fact]
    public void At500WeAreClosed()
    {
        var stubbedClock = new Mock<ISystemTime>();
        IProvideTheBusinessClock clock = new StandardBusinessClock(stubbedClock.Object);
        stubbedClock.Setup(c => c.GetCurrent()).Returns(new DateTime(2022, 7, 29, 17, 00, 00));


        Assert.False(clock.IsDuringBusinessHour());
    }

    // We are closed on the following days:
    // Weekends (Saturday and Sunday)
    // 7/4 - Fourth of July
    // 12/25 - Christmas
    // 4/20 - Jeff's Birthday

    
}
