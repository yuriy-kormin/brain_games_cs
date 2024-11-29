using BrainGames.CLI.Engine;
using System.Data;
namespace BrainGames.Tests;
using System.Reflection;

public class TestsCalc
{
    private Calc CalcModule { get; set; }
    
    [SetUp]
    public void Setup()
    {
        CalcModule = new Calc();
    }

    public void TestCalcModule()
    {
        var question = CalcModule.GetQuestion();
        var text = question.Split(new char[]{'?'},2);
        StringAssert.StartsWith("What is result of expression", text[0]);

        var answer = new DataTable().Compute(text[1], null);
        Assert.IsTrue(CalcModule.ValidateAnswer(answer.ToString()));
    }

    [Test]
    public void TestCalc()
    {
        for (int i=0; i<5; i++)
        {
            TestCalcModule();
        }
    }
    
    [Test]
    public void TestValidateCalc()
    {
        var propertyInfo = typeof(Calc).GetProperty("Answer", BindingFlags.NonPublic | BindingFlags.Instance);
        
        propertyInfo.SetValue(CalcModule, 12);
        Assert.IsTrue(CalcModule.ValidateAnswer("12"));
    }
}