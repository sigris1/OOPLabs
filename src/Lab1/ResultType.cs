namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract record ResultType
{
    private ResultType() { }

    public record GoodResult : ResultType;

    public record BadResultBigPower() : ResultType
    {
        public bool GetResult()
        {
            return false;
        }

        public string GetDescription()
        {
            return "Big power for train";
        }
    }

    public record BadResultBigRouteSpeed : ResultType
    {
        public bool GetResult()
        {
            return false;
        }

        public string GetDescription()
        {
            return "Big Route Speed";
        }
    }

    public record BadResultBigStationSpeed : ResultType
    {
        public bool GetResult()
        {
            return false;
        }

        public string GetDescription()
        {
            return "Big Station Speed";
        }
    }

    public record BadResultTrainStoppedOnRoute : ResultType
    {
        public bool GetResult()
        {
            return false;
        }

        public string GetDescription()
        {
            return "Big Station Speed";
        }
    }
}