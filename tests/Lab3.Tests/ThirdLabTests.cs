using Itmo.ObjectOrientedProgramming.Lab3;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Xunit;

namespace Lab3.Tests;

public class ThirdLabTests
{
    [Fact]
    public void GetUnreadMessage()
    {
        var log = new ConsoleLogger();
        var myUser = new User();
        var user = new UserAddressee(myUser, log);
        var mes = new Message(1, "Hello", 2);
        ICollection<ProxyAddressee> addressees = new[] { new ProxyAddressee(user, 1) };
        var topic = new Topic(addressees, "Test");
        topic.TakeMessage(mes);
        Assert.True(user.ReadMessage(mes) is ResultType.GoodResult);
    }

    [Fact]
    public void ReadUnReadMessage()
    {
        var log = new ConsoleLogger();
        var myUser = new User();
        var user = new UserAddressee(myUser, log);
        var mes = new Message(1, "Hello", 2);
        ICollection<ProxyAddressee> addressees = new[] { new ProxyAddressee(user, 1) };
        var topic = new Topic(addressees, "Test");
        topic.TakeMessage(mes);
        Assert.True(user.ReadMessage(mes) is ResultType.GoodResult);
    }

    [Fact]
    public void ReadAlmostReadMessage()
    {
        var log = new ConsoleLogger();
        var myUser = new User();
        var user = new UserAddressee(myUser, log);
        var mes = new Message(1, "Hello", 2);
        ICollection<ProxyAddressee> addressees = new[] { new ProxyAddressee(user, 1) };
        var topic = new Topic(addressees, "Test");
        topic.TakeMessage(mes);
        user.ReadMessage(mes);
        Assert.True(user.ReadMessage(mes) is ResultType.BadResultMessageAlreadyHasBeenRead);
    }

    [Fact]
    public void LowImportanceMessageNotTaken()
    {
        var log = new ConsoleLogger();
        var myUser = new User();
        var user = new UserAddressee(myUser, log);
        var mes = new Message(1, "Hello", 0);
        ICollection<ProxyAddressee> addressees = new[] { new ProxyAddressee(user, 1) };
        var topic = new Topic(addressees, "Test");
        Assert.True(topic.TakeMessage(mes) is ResultType.BadResultLowMessageImportanceLevel);
    }

    [Fact]
    public void DoLogMessage()
    {
        var log = new StringLoggerForTests();
        var mes = new Message(1, "Hello", 3);
        log.LogMessage(mes);
        Assert.Equal("Hello", log.Log);
    }

    [Fact]
    public void TakeOnlyOneMessage()
    {
        var log = new ConsoleLogger();
        var myUser = new User();
        var firstUser = new UserAddressee(myUser, log);
        var secondUser = new UserAddressee(myUser, log);
        var mes = new Message(1, "Hello", 2);
        ICollection<ProxyAddressee> addressees = new[] { new ProxyAddressee(firstUser, 1), new ProxyAddressee(secondUser, 2) };
        var topic = new Topic(addressees, "Test");
        topic.TakeMessage(mes);
        Assert.Equal(1, myUser.Count);
    }
}