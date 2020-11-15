using bets.Data;
using bets.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static bets.Util.SportpesaUtil;

namespace bets.Service
{
    class WebScrapingService
    {
        public Bookmaker scrapHelabet()
        {
            List<Match> listOfMatches = new List<Match>();
            // TODO add constant
            Bookmaker bookmaker = new Bookmaker("helabet", listOfMatches);

            List<String> listOfSportId = getHelabetSportIdSportNameMap().Keys.ToList();
            foreach(String sportId in listOfSportId)
            {
                // TODO remove it after testing
                if (sportId != "1") continue;
                listOfMatches.AddRange(getHelabetMatchesBySportId(sportId));

                // TODO do something with thread.sleep
                Thread.Sleep(2000);
                // TODO after testing remove break
                break;
            }
            return bookmaker;
        }
        public List<Match> getHelabetMatchesBySportId(String sportId)
        {
            String responseWithMatches = sendRequest(String.Format("https://helabet.co.ke/LineFeed/Get1x2_VZip?sports={0}&count=50&lng=en&tf=3000000&tz=2&mode=4&partner=237&getEmpty=true", sportId));
            List<Match> matches = HelabetUtil.parseMatches(responseWithMatches, 0);
            return matches;
        }
        public Dictionary<String, String> getHelabetSportIdSportNameMap()
        {
            String responseWithIds = sendRequest("https://helabet.co.ke/LineFeed/GetSportsShortZip?lng=en");
            Thread.Sleep(2000);
            Dictionary<String, String> sportIdSportNameMap = HelabetUtil.parseSportIds(responseWithIds);
            return sportIdSportNameMap;
        }

        public Bookmaker scrapeSportpesa()
        {
            List<Match> listOfMatches = new List<Match>();
            // TODO add constant
            Bookmaker bookmaker = new Bookmaker("sportpesa", listOfMatches);
            String responseWithIds = sendRequest("https://www.sportpesa.com/api/upcoming/games?type=prematch&sportId=1&o=startTime&pag_count=10");
            List<MatchInfo> matchesInfo = SportpesaUtil.ParseIds(responseWithIds);
            String matchRequestUrl = SportpesaUtil.createRequestMatchesUrl(matchesInfo);
            String responseWithMatches = sendRequest(matchRequestUrl);
            listOfMatches.AddRange(SportpesaUtil.Parse(responseWithMatches, matchesInfo));
            return bookmaker;
        }

        private string sendRequest(string requestUrl)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
            httpWebRequest.Method = "GET";
            httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.97 Safari/537.36";
            HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream());
            return streamReader.ReadToEnd();
        }
    }
}
