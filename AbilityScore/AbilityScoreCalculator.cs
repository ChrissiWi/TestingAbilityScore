namespace AbilityScore;
public class AbilityScoreCalculator(int rollResult, double divideBy, int addAmount, int minimum)
{
    public int RollResult { get; set; } = rollResult;
    public double DivideBy { get; set; } = divideBy;
    public int AddAmount { get; set; } = addAmount;
    public int Minimum { get; set; } = minimum;

    public int CalculateAbilityScore()
    {
      return CalculateAbilityScore(RollResult, DivideBy, AddAmount, Minimum);
    }

    public int CalculateAbilityScore(int rollResult, double divideBy, int addAmount, int minimum)
    {
        //Divide the roll result by the DivideBy factor
        double divided = rollResult / divideBy;

        //Add the AddAmount to the result
        int added = addAmount + (int)divided;

        //If the result is too low, return the Minimum value
        if (added < minimum)
        {
            return minimum;
        }
        return added;
    }
}