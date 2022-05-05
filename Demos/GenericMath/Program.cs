
Half[] halves = { (Half)123, (Half)123 };
int[] ints = { 123, 123 };

Console.WriteLine($"Linq sum int: { ints.Sum()}");
//Console.WriteLine($"Linq sum half: {halves.Sum()}");









































// Show source: Enumerable.cs https://github.com/microsoft/referencesource/blob/master/System.Core/System/Linq/Enumerable.cs


































// Workaround, create own extension. With casting to int and back to half

/*
 * HalfExtensions.cs
 * 
 * 
namespace GenericMath
{
    public static class HalfExtensions
    {
        public static Half Sum(this IEnumerable<Half> source)
        {
            Half result = (Half)0;
            foreach (Half h in source)
            {
                result = (Half)((int)result + (int)h);
            }

            return result;
        }
    }
}

 */

// Add using to ensure extension is found and try again
// using GenericMath;















































/*
static T Sum<T>(IEnumerable<T> values)
    where T : INumber<T>
{
    T result = T.Zero;

    foreach (var value in values)
    {
        result += value;
    }

    return result;
}



Console.WriteLine($"Generic maths sum int: {Sum(ints)}");
Console.WriteLine($"Generic maths sum half: {Sum(halves)}");
*/



























Half half1 = (Half)123;
Half half2 = (Half)123;
//Console.WriteLine(half1 + half2);




