namespace Itmo.ObjectOrientedProgramming.Lab1;

public class PowerMagneticPath : Plot
{
    private readonly int _magneticPower;

    public PowerMagneticPath(int length, int power)
    {
        PlotLength = length;
        _magneticPower = power;
    }

    public override ResultType DoPlot(Train train)
    {
        int instantGrowthUponEntry = train.InstantGrowing(_magneticPower);
        if (train.TrainSpeed + instantGrowthUponEntry > 0 && train.CrossingPlot(PlotLength, _magneticPower))
        {
            return new ResultType.GoodResult();
        }
        else
        {
            return new ResultType.BadResultTrainStoppedOnRoute();
        }
    }
}