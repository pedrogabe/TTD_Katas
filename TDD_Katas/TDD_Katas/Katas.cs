using System.Runtime.CompilerServices;

namespace TDD_Katas
{
    public static class Katas
    {
        public static string FizzBuzz(int value)
        {
            return FizzBuzz(Convert.ToDouble(value));
        }

        public static string FizzBuzz(double value)
        {
            string initial = String.Empty;
            string result = initial;
            if (value.IsMultipleOf(3))
                result += "Fizz";
            if (value.IsMultipleOf(5))
                result += "Buzz";
            if (result == initial)
                result = value.ToString();
            return result;
        }

        private static bool IsMultipleOf(this double self, double multiple)
        {
            return self % multiple == 0;
        }
    }
}