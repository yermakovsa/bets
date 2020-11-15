using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bets.Data
{
    public class Match
    {
        private string matchName;

        private string leagueName;
        private string matchId;
        private string url;
        private DateTime dateTime;
        private List<Bet> listOfBets;
        private bool way3;
        private bool way2;

        public Match(string name, List<Bet> bets)
        {
            matchName = name;
            listOfBets = bets;
            url = "emptyUrl";
        }

        public string MatchName { get => matchName; set => matchName = value; }
        public string MatchId { get => matchId; set => matchId = value; }
        public string Url { get => url; set => url = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public string LeagueName { get => leagueName; set => leagueName = value; }
        internal List<Bet> ListOfBets { get => listOfBets; set => listOfBets = value; }
        public bool Way3 { get => way3; set => way3 = value; }
        public bool Way2 { get => way2; set => way2 = value; }
    }
}
