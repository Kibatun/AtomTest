using System;
using System.IO;
using AtomTest.UserComparison;
using Microsoft.VisualStudio.TestPlatform.TestHost;
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
        // Перенаправляем стандартный вывод в StringWriter, чтобы перехватить его
        consoleOutput = new StringWriter();
        originalConsoleOut = Console.Out;
        Console.SetOut(consoleOutput);

        // Перенаправляем стандартный ввод на стандартный ввод для тестов
        originalConsoleIn = Console.In;
    }

    [TearDown]
    public void TearDown()
    {
        // Восстанавливаем стандартный вывод
        Console.SetOut(originalConsoleOut);
        consoleOutput.Dispose();

        // Восстанавливаем стандартный ввод
        Console.SetIn(originalConsoleIn);
    }

    [Test]
    public void TestUserInputAndOutput_IdenticalUsers()
    {
        // Подготовка ввода пользователя для теста (идентичные пользователи)
        string inputString = "Иванов Иван Иванович\n1234567890\n01 02 1985\nИванов Иван Иванович\n1234567890\n01 02 1985\n";
        StringReader input = new StringReader(inputString);

        // Подменяем стандартный ввод
        Console.SetIn(input);

        // Запуск программы
        ComparisonLogic.Compare(null);

        // Получение вывода программы
        string output = consoleOutput.ToString();

        // Проверка, что вывод программы содержит сообщение об идентичных пользователях
        StringAssert.Contains("Пользователи идентичны.", output);
    }
}
