using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Katas
{
    public class Searcher
    {
        private readonly IEnumerable<string> Dataset;
        public Searcher(IEnumerable<string> dataset)
        {
            this.Dataset = dataset;
        }

        public List<string> Search(string textToSearch)
        {
            if (textToSearch == null)
                throw new ArgumentNullException(nameof(textToSearch));
            if (textToSearch.Length < 2)
                return new List<string>();
            return Dataset.Where(x=>x.Contains(textToSearch)).ToList();
        }
    }
}
