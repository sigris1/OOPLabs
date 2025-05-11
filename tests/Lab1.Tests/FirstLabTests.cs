using Itmo.ObjectOrientedProgramming.Lab1;
using Xunit;

namespace Lab1.Tests;

public class FirstLabTests
{
    private readonly Train _ourTrain = new Train(1, 239, 1);

    [Fact]
    public void RouteMaxSpeedTest()
    {
        var basicMPath = new BasicMagneticPath(10);
        var powerPath = new PowerMagneticPath(10, 20);
        var plots = new Plot[] { powerPath, basicMPath };
        var route = new Route(plots, 20, _ourTrain);
        Assert.True(route.DoRoute() is ResultType.GoodResult);
    }

    [Fact]
    public void MoreThanRouteMaxSpeedTest()
    {
        var basicMPath = new BasicMagneticPath(10);
        var powerPath = new PowerMagneticPath(10, 20);
        var plots = new Plot[] { powerPath, basicMPath };
        var route = new Route(plots, 10, _ourTrain);
        Assert.True(route.DoRoute() is ResultType.BadResultBigRouteSpeed);
    }

    [Fact]
    public void StationMaxSpeedTest()
    {
       var basicMPath = new BasicMagneticPath(10);
       var powerPath = new PowerMagneticPath(10, 20);
       var station = new Station(20);
       var plots = new Plot[] { powerPath, basicMPath, station, basicMPath };
       var route = new Route(plots, 20, _ourTrain);
       Assert.True(route.DoRoute() is ResultType.GoodResult);
    }

    [Fact]
    public void MoreThanStationMaxSpeedTest()
    {
        var basicMPath = new BasicMagneticPath(10);
        var powerPath = new PowerMagneticPath(10, 20);
        var station = new Station(10);
        var plots = new Plot[] { powerPath, station, basicMPath };
        var route = new Route(plots, 20, _ourTrain);
        Assert.True(route.DoRoute() is ResultType.BadResultBigStationSpeed);
    }

    [Fact]
    public void MoreThanRouteMaxSpeedButStationValidTest()
    {
        var basicMPath = new BasicMagneticPath(10);
        var powerPath = new PowerMagneticPath(10, 20);
        var station = new Station(20);
        var plots = new Plot[] { powerPath, basicMPath, station, basicMPath };
        var route = new Route(plots, 10, _ourTrain);
        Assert.True(route.DoRoute() is ResultType.BadResultBigRouteSpeed);
    }

    [Fact]
    public void TransitionFromUnacceptableSpeedToAcceptableTest()
    {
        var basicMPath = new BasicMagneticPath(10);
        var powerPath1 = new PowerMagneticPath(10, 20);
        var powerPath2 = new PowerMagneticPath(10, -10);
        var powerPath3 = new PowerMagneticPath(20, -10);
        var station = new Station(10);
        var plots = new Plot[] { powerPath1, basicMPath, powerPath2, station, basicMPath, powerPath1, basicMPath, powerPath3 };
        var route = new Route(plots, 20, _ourTrain);
        Assert.True(route.DoRoute() is ResultType.GoodResult);
    }

    [Fact]
    public void ZeroAccelerationTest()
    {
        var basicMPath = new BasicMagneticPath(10);
        var plots = new Plot[] { basicMPath };
        var route = new Route(plots, 10, _ourTrain);
        Assert.True(route.DoRoute() is ResultType.BadResultTrainStoppedOnRoute);
    }

    [Fact]
    public void SpeedLessThanZeroTest()
    {
        var powerPath1 = new PowerMagneticPath(300, 20);
        var powerPath2 = new PowerMagneticPath(300, -40);
        var plots = new Plot[] { powerPath1, powerPath2 };
        var route = new Route(plots, 10, _ourTrain);
        Assert.True(route.DoRoute() is ResultType.BadResultTrainStoppedOnRoute);
    }
}