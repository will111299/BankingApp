
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
    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(30)]
    [InlineData(31)]
    public void ClosedOnWeekends(int dayOfJuly2022)
    {
        var stubbedClock = new Mock<ISystemTime>();
        IProvideTheBusinessClock clock = new StandardBusinessClock(stubbedClock.Object);
        stubbedClock.Setup(c => c.GetCurrent()).Returns(new DateTime(2022, 7, dayOfJuly2022, 12, 00, 00));


        Assert.False(clock.IsDuringBusinessHour());
    }

    // 7/4 - Fourth of July
    [Fact]
    public void ClosedOnFourthOfJuly()
    {
        var stubbedClock = new Mock<ISystemTime>();
        IProvideTheBusinessClock clock = new StandardBusinessClock(stubbedClock.Object);
        stubbedClock.Setup(c => c.GetCurrent()).Returns(new DateTime(2022, 7, 4, 12, 00, 00));


        Assert.False(clock.IsDuringBusinessHour());
    }

    // 12/25 - Christmas
    [Fact]
    public void ClosedOnChristmas()
    {
        var stubbedClock = new Mock<ISystemTime>();
        IProvideTheBusinessClock clock = new StandardBusinessClock(stubbedClock.Object);
        stubbedClock.Setup(c => c.GetCurrent()).Returns(new DateTime(2022, 12, 25, 12, 00, 00));


        Assert.False(clock.IsDuringBusinessHour());
    }

    // 4/20 - Jeff's Birthday
    [Fact]
    public void ClosedOnJeffsBirthday()
    {
        var stubbedClock = new Mock<ISystemTime>();
        IProvideTheBusinessClock clock = new StandardBusinessClock(stubbedClock.Object);
        stubbedClock.Setup(c => c.GetCurrent()).Returns(new DateTime(2022, 4, 20, 12, 00, 00));


        Assert.False(clock.IsDuringBusinessHour());
    }

}
