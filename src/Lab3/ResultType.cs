namespace Itmo.ObjectOrientedProgramming.Lab3;

public abstract record ResultType
{
    private ResultType() { }

    public record GoodResult : ResultType;

    public record BadResultLowMessageImportanceLevel() : ResultType
    {
        public bool GetResult()
        {
            return false;
        }

        public string GetDescription()
        {
            return "Message have low importance level for this addressee";
        }
    }

    public record BadResultMessageAlreadyHasBeenRead() : ResultType
    {
        public bool GetResult()
        {
            return false;
        }

        public string GetDescription()
        {
            return "Message has already been read";
        }
    }

    public record BadResultAddresseeDidntReceiveSuchMessage() : ResultType
    {
        public bool GetResult()
        {
            return false;
        }

        public string GetDescription()
        {
            return "Addressee didn't receive such message";
        }
    }
}