using BrainGames.CLI.Engine;
using System.Data;
namespace BrainGames.Tests;
using System.Reflection;

public class TestsCalc
{
    private Calc CalcModule { get; set; } = new Calc();
    
    public void TestCalcModule()
    {
        var question = CalcModule.GetQuestion();
        var text = question.Split(new char[]{'?'},2);
        StringAssert.StartsWith("What is result of expression", text[0]);

        var answer = new DataTable().Compute(text[1], null);
        // Assert.IsTrue(CalcModule.ValidateAnswer(answer.ToString()));
        Assert.IsInstanceOf<int>(answer);
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

public class TestsEven
{
    private Even even { get; set; } = new Even();

    [Test]
    public void TestEvenModule()
    {
        var question = even.GetQuestion();
        var text = question.Split(new char[] { '?' }, 2);
        StringAssert.StartsWith("Is value even(Y/N)", text[0]);
        var num = int.Parse(text[1]);
        Assert.IsInstanceOf<int>(num);
    }
    
    [Test]
    public void TestValidateEven()
    {
        var propertyInfo = typeof(Even).GetProperty("Answer", BindingFlags.NonPublic | BindingFlags.Instance);
        
        propertyInfo.SetValue(even, true);
        
        Assert.IsTrue(even.ValidateAnswer("Y"));
        Assert.IsTrue(even.ValidateAnswer("y"));
        foreach (var q in new Char[] { 'N', 'n', 'q', ' '})
        {
            Assert.IsFalse(even.ValidateAnswer("N"));    
        }
        
    }
}