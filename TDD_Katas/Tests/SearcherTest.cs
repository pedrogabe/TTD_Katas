using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void Test()
        {

        }
    }
}
