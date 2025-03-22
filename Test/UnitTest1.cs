using AbilityScore;

namespace TestAbilityScore;

[TestClass]
public class UnitTest1
{
    [DataRow(18, 1.5, 2, 8, 14)]    // Normal case: (18/1.5) + 2 = 14
    [DataRow(15, 1.5, 2, 8, 12)]    // Normal case: (15/1.5) + 2 = 12
    [DataRow(12, 1.5, 2, 8, 10)]    // Normal case: (12/1.5) + 2 = 10
    [DataRow(10, 1.5, 2, 8, 8)]     // Below minimum case: (10/1.5) + 2 = 8.67, but minimum is 8
    [DataRow(8, 1.5, 2, 8, 8)]      // Below minimum case: (8/1.5) + 2 = 7.33, but minimum is 8
    [DataRow(20, 2.0, 3, 8, 13)]    // Different division factor: (20/2.0) + 3 = 13
    [DataRow(16, 2.0, 3, 8, 11)]    // Different division factor: (16/2.0) + 3 = 11
    [TestMethod]
    public void TestAbilityScoreCalculator(int rollResult, double divideBy, int addAmount, int minimum, int expected)
    {
        var calculator = new AbilityScoreCalculator(rollResult, divideBy, addAmount, minimum);
        int actual = calculator.CalculateAbilityScore();
        Assert.AreEqual(expected, actual);
    }
}