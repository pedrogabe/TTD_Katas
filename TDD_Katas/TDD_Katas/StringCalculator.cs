using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TDD_Katas
{
    public class StringCalculator
    {
        private const string CustomDelimiterPattern = @"^\/\/(.+?)\n(.*)";

        public static int Add(params string[] args)
        {
            string inputString = string.Concat(args);
            int[] numbers = GetNumbers(inputString);

            ValidateAmountOfNumbers(numbers);
            return numbers.Sum();
        }

        private static void ValidateAmountOfNumbers(in int[] numbers)
        {
            if (numbers.Length > 2)
                throw new TooManyNumbersException(numbers.Length);
        }



        #region PrivateMethods
        private static int[] GetNumbers(in string inputString)
        {
            
            (string delimiter, string numbersString) = GetDelimiterAndNumbersString(inputString);

            Stack<int> numbers = new();
            string[] segments = numbersString.Split(delimiter);
            foreach(string segment in segments)
            {
                numbers.Push(GetNumericValueOfSegment(segment));
            }

            return numbers.ToArray();
        }

        private static (string, string) GetDelimiterAndNumbersString(in string inputString)
        {
            if (inputString == null)
                throw new ArgumentNullException(nameof(inputString));

            Match match = Regex.Match(inputString, CustomDelimiterPattern);

            if (match.Success)
                return (match.Groups[1].Value, match.Groups[2].Value);
            else
                return (",", inputString);
        }

        private static int GetNumericValueOfSegment(in string segment)
        {
            if (string.IsNullOrWhiteSpace(segment))
                return 0;
            if (int.TryParse(segment, out int number))
                return number;
            else
                throw new NonNumericContentException();
        }


        #endregion

        #region Exceptions
        public class TooManyNumbersException : Exception
        {
            public TooManyNumbersException(int numbers):base($"Up to 2 numbers were expected but {numbers} were given")
            { }
        }

        public class NonNumericContentException : Exception
        {
            public NonNumericContentException(){ }
        }
        #endregion
    }
}
