using ResultTypes;
using Users;
using Xunit;

namespace Lab5.Tests;

public class FifthLabTests
{
    [Fact]
    public void WithdrawalWithASufficientBalance()
    {
        var now = new User(0, "mew");
        now.DepositMoney(100);
        now.WithdrawMoney(50);
        Assert.Equal(50, now.Balance);
    }

    [Fact]
    public void WithdrawalWithANotSufficientBalance()
    {
        var now = new User(0, "mew");
        now.DepositMoney(100);
        Assert.True(now.WithdrawMoney(150) is ResultType.BadResultExceedBalance);
    }

    [Fact]
    public void DepositBalance()
    {
        var now = new User(0, "mew");
        now.DepositMoney(100);
        Assert.Equal(100, now.Balance);
    }
}