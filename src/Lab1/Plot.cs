namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Plot
{
    protected int PlotLength { get; set; }

    public virtual ResultType DoPlot(Train train)
    {
        return new ResultType.GoodResult();
    }
}
