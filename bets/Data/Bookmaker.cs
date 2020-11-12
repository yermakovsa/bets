using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bets.Data
{
    class Bookmaker
    {

        private string name;
        private List<Match> listOfMatches;

        public Bookmaker(string name, List<Match> listOfMatches)
        {
            this.name = name;
            this.listOfMatches = listOfMatches;
        }

        public string Name { get => name; set => name = value; }
        internal List<Match> ListOfMatches { get => listOfMatches; set => listOfMatches = value; }
    }
}
