namespace Tests
{
    public class SearcherTest
    {
        private Searcher Searcher { get; set; }
        [SetUp]
        public void SetUp()
        {
            var testDataset = "Paris, Budapest, Skopje, Rotterdam, Valencia, Vancouver, Amsterdam, Vienna, Sydney, New York City, London, Bangkok, Hong Kong, Dubai, Rome, Istanbul".Split(", ");
            Searcher = new Searcher(testDataset);
        }

        [Test]
        public void GivenLessThanTwoCharactersToLookFor_ShallNotReturnAnyResults()
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
        public void GivenNullStringToSearch_ShallThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => { Searcher.Search(null); });
        }

        [Test]
        public void GivenValidStringToSearchButNoMatchesExistInDataset_ShallNotReturnAnyResults()
        {
            string[] validTextsWithNoMatch = { "skoooje", "jajajaja", "fffff" };
            Assert.Multiple(() =>
            {
                foreach (var shortText in validTextsWithNoMatch)
                {
                    Assert.That(Searcher.Search(shortText).Count, Is.EqualTo(0));
                }
            });
        }
    }
}
