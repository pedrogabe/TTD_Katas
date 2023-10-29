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
            return new List<string>();
        }
    }
}
