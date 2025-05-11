namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Train(int weight, int trainMaxPower, int trainAccuracy)
{
    public int TrainSpeed { get; set; }

    private int _trainAcceleration;

    private int _trainTimer = 0;

    private int _trainPath = 0;

    public ResultType DoPlot(Plot plot)
    {
        return plot.DoPlot(this);
    }

    public bool CrossingPlot(int length)
    {
        while (length > 0)
        {
            length -= TrainSpeed;
            _trainPath += TrainSpeed;
            _trainTimer++;
            if (_trainPath % trainAccuracy == 0)
                DoIteration();
        }

        return true;
    }

    public bool CrossingPlot(int length, int power)
    {
        if (Math.Abs(power) > trainMaxPower)
            return false;
        AddPower(power);
        while (length > 0)
        {
            if (_trainTimer % trainAccuracy == 0)
            {
                DoIteration();
                if (TrainSpeed <= 0)
                    return false;
            }

            length -= TrainSpeed;
            _trainPath += TrainSpeed;
            _trainTimer++;
        }

        RemovePower(power);
        return true;
    }

    public void CrossingStation(int loadDelay, int uploadDelay)
    {
        int temp = TrainSpeed;
        TrainSpeed = 0;
        int summaryTime = loadDelay + uploadDelay;
        while (summaryTime > 0)
        {
            summaryTime--;
            TrainSpeed++;
            if (_trainTimer % trainAccuracy == 0)
                DoIteration();
        }

        TrainSpeed = temp;
    }

    public int InstantGrowing(int power)
    {
        return power / weight;
    }

    private void DoIteration()
    {
        TrainSpeed += _trainAcceleration * trainAccuracy;
        _trainPath = TrainSpeed * trainAccuracy;
    }

    private void AddPower(int power)
    {
        _trainAcceleration += power / weight;
    }

    private void RemovePower(int power)
    {
        _trainAcceleration -= power / weight;
    }
}