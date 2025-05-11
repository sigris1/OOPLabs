namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Route(Plot[] plots, int routeMaxSpeed, Train train)
{
    public ResultType DoRoute()
    {
        foreach (Plot current in plots)
        {
            if (train.DoPlot(current) is not ResultType.GoodResult)
            {
                return train.DoPlot(current);
            }
        }

        if (train.TrainSpeed <= routeMaxSpeed)
        {
            return new ResultType.GoodResult();
        }
        else
        {
            return new ResultType.BadResultBigRouteSpeed();
        }
    }
}