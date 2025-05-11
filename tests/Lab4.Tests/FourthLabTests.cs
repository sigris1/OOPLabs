using Itmo.ObjectOrientedProgramming.Lab4;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Xunit;

namespace Lab4.Tests;

public class FourthLabTests
{
    private readonly Parser _testParser = new Parser();

    [Fact]
    public void ParseConnectCommand()
    {
        ICommand? command = _testParser.GetCommand("connect PathToDirectory -m local");
        var connectCommand = new ConnectCommand("PathToDirectory", "local");
        Assert.True(connectCommand.Equals(command));
    }

    [Fact]
    public void ParseDisconnectCommand()
    {
        ICommand? command = _testParser.GetCommand("disconnect");
        var disconnectCommand = new DisconnectCommand();
        Assert.True(disconnectCommand.Equals(command));
    }

    [Fact]
    public void ParseTreeGoToCommand()
    {
        ICommand? command = _testParser.GetCommand("tree goto PathToDirectory");
        var treeGotoCommand = new TreeGotoCommand("PathToDirectory");
        Assert.True(treeGotoCommand.Equals(command));
    }

    [Fact]
    public void ParseTreeListCommand()
    {
        ICommand? command = _testParser.GetCommand("tree list -d 10");
        var treeListCommand = new TreeListCommand(10);
        Assert.True(treeListCommand.Equals(command));
    }

    [Fact]
    public void ParseFileShowCommand()
    {
        ICommand? command = _testParser.GetCommand("file show PathToDirectory -m console");
        var fileShowCommand = new FileShowCommand("PathToDirectory", "console");
        Assert.True(fileShowCommand.Equals(command));
    }

    [Fact]
    public void ParseFileMoveCommand()
    {
        ICommand? command = _testParser.GetCommand("file move PathFromDirectory PathToDirectory");
        var fileMoveCommand = new FileMoveCommand("PathFromDirectory", "PathToDirectory");
        Assert.True(fileMoveCommand.Equals(command));
    }

    [Fact]
    public void ParseFileCopyCommand()
    {
        ICommand? command = _testParser.GetCommand("file copy PathFromDirectory PathToDirectory");
        var fileCopyCommand = new FileCopyCommand("PathFromDirectory", "PathToDirectory");
        Assert.True(fileCopyCommand.Equals(command));
    }

    [Fact]
    public void ParseFileDeleteCommand()
    {
        ICommand? command = _testParser.GetCommand("file delete PathToDirectory");
        var fileDeleteCommand = new FileDeleteCommand("PathToDirectory");
        Assert.True(fileDeleteCommand.Equals(command));
    }

    [Fact]
    public void ParseFileRenameCommand()
    {
        ICommand? command = _testParser.GetCommand("file rename PathToDirectory newName");
        var fileRenameCommand = new FileRenameCommand("PathToDirectory", "newName");
        Assert.True(fileRenameCommand.Equals(command));
    }
}