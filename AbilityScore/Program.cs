using AbilityScore;

// Initialize calculator with default values
var calculator = new AbilityScoreCalculator(14, 1.75, 2, 3);

// Main program loop
while (true)
{
    // Get user input for each calculator parameter, using current values as defaults
    calculator.RollResult = ReadValue(calculator.RollResult, "Starting 4d6 roll");
    calculator.DivideBy = ReadValue(calculator.DivideBy, "Divide by");
    calculator.AddAmount = ReadValue(calculator.AddAmount, "Add amount");
    calculator.Minimum = ReadValue(calculator.Minimum, "Minimum");

    // Calculate and display the ability score
    int score = calculator.CalculateAbilityScore();
    Console.WriteLine("Calculated ability score: " + score);
    
    // Check if user wants to quit
    Console.WriteLine("Press Q to quit, any other key to continue");
    char key = Console.ReadKey().KeyChar;
    if (key == 'Q' || key == 'q')
    {
        return;
    }
}

/// <summary>
/// Reads a value from the console with a default value fallback.
/// </summary>
/// <typeparam name="T">The type of value to read (must be a value type that implements IConvertible)</typeparam>
/// <param name="lastUsedValue">The default value to use if parsing fails</param>
/// <param name="prompt">The prompt to display to the user</param>
/// <returns>The parsed value or the default value if parsing fails</returns>
static T ReadValue<T>(T lastUsedValue, string prompt) where T : struct, IConvertible
{
    // Display prompt with current value in brackets
    Console.WriteLine(prompt + " [" + lastUsedValue + "]: ");
    string? input = Console.ReadLine();
    
    // Try to parse the input
    if (TryParse<T>(input, out T value))
    {
        Console.WriteLine("   using value " + value);
        return value;
    }
    else
    {
        // If parsing fails, use the default value
        Console.WriteLine("   using default value " + lastUsedValue);
        return lastUsedValue;
    }
}

/// <summary>
/// Attempts to parse a string input into the specified type.
/// </summary>
/// <typeparam name="T">The type to parse into (must be a value type that implements IConvertible)</typeparam>
/// <param name="input">The string to parse</param>
/// <param name="value">The parsed value if successful</param>
/// <returns>True if parsing was successful, false otherwise</returns>
static bool TryParse<T>(string? input, out T value) where T : struct, IConvertible
{
    value = default;
    if (string.IsNullOrEmpty(input)) return false;
    
    try
    {
        // Attempt to convert the input string to the target type
        value = (T)Convert.ChangeType(input, typeof(T));
        return true;
    }
    catch
    {
        return false;
    }
}