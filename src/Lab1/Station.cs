namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Station : Plot
{
    private readonly int _stationLoading;
    private readonly int _stationUploading;
    private readonly int _stationMaxSpeed;

    public Station(int stationMaxSpeed)
    {
        _stationMaxSpeed = stationMaxSpeed;
    }

    public Station(int stationLoading, int stationUnloading, int stationMaxSpeed)
    {
        PlotLength = 0;
        _stationLoading = stationLoading;
        _stationUploading = stationUnloading;
        _stationMaxSpeed = stationMaxSpeed;
    }

    public override ResultType DoPlot(Train train)
    {
        if (train.TrainSpeed > _stationMaxSpeed)
            return new ResultType.BadResultBigStationSpeed();
        train.CrossingStation(_stationLoading, _stationUploading);
        return new ResultType.GoodResult();
    }
}