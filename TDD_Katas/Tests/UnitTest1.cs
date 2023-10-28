
namespace Tests
{
    public class FizzBuzzTest
    {
        [SetUp]
        public void Setup()
        {
        }

        #region Privates
        private void AssertFizzBuzzReturnsNonNullString(double number)
        {
            var result = Katas.FizzBuzz(number);
            Assert.That(result.GetType(), Is.EqualTo(typeof(string)));
            Assert.That(result, Is.Not.Null);
        }

        private int GetMultipleOf(int multiple)
        {
            int randomNumber = Random.Shared.Next(4, 1000);
            return randomNumber * multiple;
        }

        private double GetNonMultipleOf(int multiple)
        {
            if (multiple == 1)
                return 0.5;
            if (multiple == 0)
                throw new NotImplementedException("Is multiple of 0 possible");
            return GetMultipleOf(multiple) - 1;
        }
        #endregion

        #region Tests
        [Test]
        public void AfterFizzingAnInt_ShouldReturnAString()
        {
            int number = 2;
            var result = Katas.FizzBuzz(number);
            Assert.That(result.GetType()==typeof(string));
        }

        [Test]
        public void AfterFizzingAFraction_ShouldReturnAString()
        {
            double number = 2/3;
            AssertFizzBuzzReturnsNonNullString(number);
        }


        [Test]
        public void AfterFizzingExtremeNegative_ShouldReturnAString()
        {
            double number = double.MinValue;
            AssertFizzBuzzReturnsNonNullString(number);
        }

        [Test]
        public void AfterFizzingExtremePositive_ShouldReturnAString()
        {
            double number = double.MaxValue;
            AssertFizzBuzzReturnsNonNullString(number);
        }

        [Test]
        public void AfterFizzing3_ShouldReturnFizz()
        {
            Assert.That(Katas.FizzBuzz(3), Is.EqualTo("Fizz"));
        }

        [Test]
        public void AfterFizzing0_ShouldNotBreak()
        {
            Katas.FizzBuzz(0);
        }

        [Test]
        public void AfterFizzingFraction_ShoudNotReturnFizz()
        {
            double fraction = 1f / Random.Shared.Next(1, 100);
            Assert.That(Katas.FizzBuzz(fraction), Is.Not.EqualTo("Fizz"));
        }

        [Test]
        public void AfterFizzingMultipleOf3_ShouldReturnFizzOrFizzBuzz()
        {
            int multipleOf3 = GetMultipleOf(3);
            Assert.That(Katas.FizzBuzz(multipleOf3), Is.EqualTo("Fizz").Or.EqualTo("FizzBuzz"));
        }

        [Test]
        public void AfterFizzing6ShouldReturnFizzOrFizz()
        {;
            Assert.That(Katas.FizzBuzz(12), Is.EqualTo("Fizz"));
        }

        [Test]
        public void AfterFizzing2_ShoudNotReturnFizz()
        {
            Assert.That(Katas.FizzBuzz(2), Is.Not.EqualTo("Fizz"));
        }

        [Test]
        public void AfterFizzingNonMultipleOf3_ShoudNotReturnFizz()
        {
            var nonMultipleOf3 = GetNonMultipleOf(3);
            Assert.That(Katas.FizzBuzz(nonMultipleOf3), Is.Not.EqualTo("Fizz"));
        }

        [Test]
        public void AfterFizzingMultipleOf5_ShoudReturnBuzzOrFizzBuzz()
        {
            int multipleOf5 = GetMultipleOf(5);
            Assert.That(Katas.FizzBuzz(multipleOf5), Is.EqualTo("Buzz").Or.EqualTo("FizzBuzz"));
        }

        [Test]
        public void AfterFizzing10_ShouldReturnBuzz()
        {
            Assert.That(Katas.FizzBuzz(10), Is.EqualTo("Buzz"));
        }

        [Test]
        public void AfterFizzing15_ShouldReturnFizzBuzz()
        {
            Assert.That(Katas.FizzBuzz(15), Is.EqualTo("FizzBuzz"));
        }


        #endregion
    }
}