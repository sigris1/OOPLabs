namespace Itmo.ObjectOrientedProgramming.Lab1;

public class BasicMagneticPath : Plot
{
    public BasicMagneticPath(int length)
    {
        PlotLength = length;
    }

    public override ResultType DoPlot(Train train)
    {
        if (train.TrainSpeed <= 0)
            return new ResultType.BadResultTrainStoppedOnRoute();
        train.CrossingPlot(PlotLength);
        return new ResultType.GoodResult();
    }
}