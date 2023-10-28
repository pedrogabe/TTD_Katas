using NUnit.Framework.Constraints;
using System;

namespace Tests
{
    public class StringCalculatorTest
    {
        [Test]
        public void GivenTooManyNumbers_ShallThrowTooManyNumbersException()
        {
            Assert.Throws<StringCalculator.TooManyNumbersException>(() => { StringCalculator.Add("1,2,3"); });
        }

        [Test]
        public void GivenNullString_ShallThrowNullArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() => { StringCalculator.Add(null); });
        }

        [Test]
        public void GivenStringWithMoreThanNumbersAndCommas_ShallThrowNonNumericContentException()
        {
            Assert.Multiple(() =>
            {
                Assert.Throws<StringCalculator.NonNumericContentException>(() => { StringCalculator.Add("something,2"); });
                Assert.Throws<StringCalculator.NonNumericContentException>(() => { StringCalculator.Add(" ,2,2something"); });
                Assert.Throws<StringCalculator.NonNumericContentException>(() => { StringCalculator.Add(",2,2something"); });
                Assert.Throws<StringCalculator.NonNumericContentException>(() => { StringCalculator.Add("2,2something"); });
            });
        }

        [Test]
        public void GivenStringWithOnlyNumbersAndCommas_ShallNotBreak()
        {
            StringCalculator.Add("1,2");
            StringCalculator.Add(" , ");
            StringCalculator.Add("");
        }

        [Test]
        public void GivenEmptyString_ShallReturnZero()
        {
            Assert.That(StringCalculator.Add(String.Empty), Is.EqualTo(0));
        }

        [Test]
        public void GivenWhiteSpace_ShallReturnZero()
        {
            Assert.That(StringCalculator.Add("   "), Is.EqualTo(0));
        }

        [Test]
        public void GivenOneNumber_ShallReturnTheSame()
        {
            (string, int)[] samples =
            {
                ("1",1),("3",3),("12",12),("-115",-115)
            };

            Assert.Multiple(() =>
            {
                foreach (var (input, output) in samples)
                {
                    Assert.That(StringCalculator.Add(input), Is.EqualTo(output));
                }
            });
        }

        [Test]
        public void GivenACoupleOfNumbers_ShallReturnTheirSum()
        {
            (string, int)[] samples =
            {
                ("1,5",6),("3,-3",0),("12,-30",-18),("-110,200",90)
            };

            Assert.Multiple(() =>
            {
                foreach (var (coupleOfNumbers, sumOfThem) in samples)
                {
                    Assert.That(StringCalculator.Add(coupleOfNumbers), Is.EqualTo(sumOfThem));
                }
            });
        }

        [Test]
        public void GivenANumberAndABlankSpace_ShallReturnTheNumber()
        {
            (string, int)[] samples =
            {
                ("1,  ",1),(",-3",-3),("  ,-30",-30),("2,",2)
            };

            Assert.Multiple(() =>
            {
                foreach (var (coupleOfNumbers, sumOfThem) in samples)
                {
                    Assert.That(StringCalculator.Add(coupleOfNumbers), Is.EqualTo(sumOfThem));
                }
            });
        }

        [Test]
        public void GivenManyArguments_ShallNotBreak()
        {
            StringCalculator.Add("1", "2");
            StringCalculator.Add("1", "2","","");
        }

        [Test]
        public void GivenAPattern_ShouldConsiderCustomSeparator()
        {
            //Pattern is //[delimiter]\n[numbers]
            (string, int)[] samples =
            {
                ("//;\n1;3",4),
                ("//|\n1|23",24),
                ("//sep\n2sep5",7)
            };
            Assert.Multiple(() =>
            {
                foreach (var (input, sumOfTheNumbers) in samples)
                {
                    Assert.That(StringCalculator.Add(input), Is.EqualTo(sumOfTheNumbers));
                }
            });
        }
    }
}
