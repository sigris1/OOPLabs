namespace ResultTypes;

public abstract record ResultType
{
    private ResultType()
    { }

    public record GoodResult(long Balance, string? Operations) : ResultType
    {
        public long Balance { get; init; } = Balance;

        public string? Operations { get; init; } = Operations;
    }

    public record BadResultWrongCommand() : ResultType
    {
        public bool GetResult()
        {
            return false;
        }

        public string GetDescription()
        {
            return "Bad command";
        }
    }

    public record BadResultNonExistentUser() : ResultType
    {
        public bool GetResult()
        {
            return false;
        }

        public string GetDescription()
        {
            return "This user doesn't exist";
        }
    }

    public record BadResultExceedBalance() : ResultType
    {
        public bool GetResult()
        {
            return false;
        }

        public string GetDescription()
        {
            return "User have exceeded the balance";
        }
    }

    public record BadResultInvalidPin() : ResultType
    {
        public bool GetResult()
        {
            return false;
        }

        public string GetDescription()
        {
            return "Get invalid pin";
        }
    }

    public record BadResultAccountAlreadyExists() : ResultType
    {
        public bool GetResult()
        {
            return false;
        }

        public string GetDescription()
        {
            return "Account already exists";
        }
    }

    public record BadResultWrongAdministratorPassword() : ResultType
    {
        public bool GetResult()
        {
            return false;
        }

        public string GetDescription()
        {
            return "Wrong administrator password";
        }
    }

    public record BadResultUserIsNotAAdministrator() : ResultType
    {
        public bool GetResult()
        {
            return false;
        }

        public string GetDescription()
        {
            return "User is not an administrator";
        }
    }
}