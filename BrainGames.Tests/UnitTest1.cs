using BrainGames.CLI.Engine;
using System.Data;
namespace BrainGames.Tests;
using System.Reflection;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestCalc()
    {
        var calc = new Calc();
        var question = calc.GetQuestion();
        var text = question.Split(new char[]{'?'},2);
        StringAssert.StartsWith("What is result of expression", text[0]);

        var answer = new DataTable().Compute(text[1], null);
        Assert.IsTrue(calc.ValidateAnswer(answer.ToString()));
    }

    [Test]
    public void TestValidateCalc()
    {
        var calc = new Calc();
        var propertyInfo = typeof(Calc).GetProperty("Answer", BindingFlags.NonPublic | BindingFlags.Instance);
        
        propertyInfo.SetValue(calc, 12);
        Assert.IsTrue(calc.ValidateAnswer("12"));
    }
}