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

namespace bets.Service
{
    class WebScrapingService
    {
        public Bookmaker scrapHelabet()
        {
            List<Match> listOfMatches = new List<Match>();
            // TODO add constant
            Bookmaker bookmaker = new Bookmaker("helabet", listOfMatches);

            String responseWithIds = sendRequest("https://helabet.co.ke/LineFeed/GetSportsShortZip?lng=en");
            List<String> listOfSportId = HelabetUtil.parseSportIds(responseWithIds);
            foreach(String sportId in listOfSportId)
            {
                // TODO remove it after testing
                if (sportId != "1") continue;
                String responseWithMatches = sendRequest(String.Format("https://helabet.co.ke/LineFeed/Get1x2_VZip?sports={0}&count=50&lng=en&tf=3000000&tz=2&mode=4&partner=237&getEmpty=true", sportId));
                List<Match> matches = HelabetUtil.parseMatches(responseWithMatches, 0);
                listOfMatches.AddRange(matches);

                // TODO do something with thread.sleep
                Thread.Sleep(2000);
                // TODO after testing remove break
                break;
            }
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
