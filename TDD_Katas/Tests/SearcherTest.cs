using System.Linq;

namespace Tests
{
    public class SearcherTest
    {
        private Searcher Searcher { get; set; }
        private string[] TestDataset { get; set; }
        [SetUp]
        public void SetUp()
        {
            TestDataset = "Paris, Budapest, Skopje, Rotterdam, Valencia, Vancouver, Amsterdam, Vienna, Sydney, New York City, London, Bangkok, Hong Kong, Dubai, Rome, Istanbul".Split(", ");
            Searcher = new Searcher(TestDataset);
        }

        [Test]
        public void WhenSearchingLessThanTwoCharacters_ShallNotReturnAnyResults()
        {
            string[] shortTexts = { "", ",", "V", "a" };
            Assert.Multiple(() =>
            {
                foreach (var shortText in shortTexts)
                {
                    Assert.That(Searcher.Search(shortText).Count, Is.EqualTo(0));
                }
            });
        }

        [Test]
        public void WhenSearchingNullString_ShallThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => { Searcher.Search(null); });
        }

        [Test]
        public void WhenSearchingValidStringButNoMatchesExistInDataset_ShallReturnEmptyList()
        {
            string[] validTextsWithNoMatch = { "skoooje", "jajajaja", "fffff" };
            Assert.Multiple(() =>
            {
                foreach (var shortText in validTextsWithNoMatch)
                {
                    Assert.That(Searcher.Search(shortText), Is.Empty);
                }
            });
        }

        [Test]
        public void WhenSearchingSomeValidString_ShallReturnTextsStartingWithSameText()
        {
            string textToSearch = "Va";
            List<string> expectedResult = new() { "Valencia", "Vancouver" };

            var orderedResult = Searcher.Search(textToSearch).OrderBy(el => el);
            CollectionAssert.AreEqual(orderedResult, expectedResult);
        }

        [Test]
        public void WhenSearchingSameStringWithDifferentCapitalization_ShallReturnSameResults()
        {
            List<string> textsToSearch = new() { "Val", "vAL", "VAL" },
                    expectedResult = new() { "Valencia" };

            Assert.Multiple(() =>
            {
                foreach (var textToSearch in textsToSearch)
                    Assert.That(Searcher.Search(textToSearch), Is.EqualTo(expectedResult));
            });
        }

        [Test]
        public void WhenSearchingSomeValidString_ShallReturnTextsThatContainItJustAsAPart()
        {
            string textToSearch = "ape";
            List<string> expectedResult = new() { "Budapest" };

            Assert.That(Searcher.Search(textToSearch), Is.EqualTo(expectedResult));
        }

        [Test]
        public void WhenSearchingAsterisk_ShallReturnWholeDataset()
        {
            string textToSearch = "*";

            Assert.That(Searcher.Search(textToSearch), Is.EqualTo(TestDataset));
        }
    }
}
