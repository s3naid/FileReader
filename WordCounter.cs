using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter
{
    internal class WordCounter
    {
        public string word { get; set; }
        public int occurences { get; set; }

        public WordCounter(string word, int occurences)
        {
            this.word = word;
            this.occurences = occurences;
        }
    }
}
