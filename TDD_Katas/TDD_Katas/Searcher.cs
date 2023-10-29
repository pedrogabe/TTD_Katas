using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Katas
{
    public class Searcher
    {
        private static readonly int MinSearchLength = 2;
        private readonly IEnumerable<string> Dataset;
        public Searcher(IEnumerable<string> dataset)
        {
            Dataset = dataset;
        }

        public List<string> Search(string textToSearch)
        {
            ValidateArgumentIsNotNull(textToSearch, nameof(textToSearch));
            if (textToSearch == "*")
                return Dataset.ToList();
            if (TextToSearchIsTooShort(textToSearch))
                return new List<string>();
            var results = GetFilteredDataSet(textToSearch);
            return results;
        }

        private List<string> GetFilteredDataSet(string textToSearch)
        {
            return Dataset.Where(element => element.ToLower().Contains(textToSearch.ToLower())).ToList();
        }

        private static bool TextToSearchIsTooShort(in string textToSearch)
        {
            return textToSearch.Length < MinSearchLength;
        }

        private void ValidateArgumentIsNotNull(in object nullable, string name)
        {
            if(nullable==null)
                throw new ArgumentNullException(name);
        }
    }
}
