using System;
using System.IO;
using AtomTest.UserComparison;
using NUnit.Framework;

[TestFixture]
public class ProgramTests
{
    private StringWriter consoleOutput;
    private TextWriter originalConsoleOut;
    private TextReader originalConsoleIn;

    [SetUp]
    public void Setup()
    {
        consoleOutput = new StringWriter();
        originalConsoleOut = Console.Out;
        Console.SetOut(consoleOutput);
        originalConsoleIn = Console.In;
    }

    [TearDown]
    public void TearDown()
    {
        Console.SetOut(originalConsoleOut);
        consoleOutput.Dispose();
        Console.SetIn(originalConsoleIn);
    }
    
    [Test]
    public void TestUserInputAndOutput_IdenticalUsers()
    {
        string inputString = "Иванов Иван Иванович\n1234567890\n01 02 1985\nИванов Иван Иванович\n1234567890\n01 02 1985\n";
        StringReader input = new StringReader(inputString);
        Console.SetIn(input);
        ComparisonLogic.Compare(null);
        string output = consoleOutput.ToString();
        StringAssert.Contains("Пользователи идентичны.", output);
    }
}
