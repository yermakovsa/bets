using bets.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bet.Functions
{
    class MatchInfo
    {
        public string matchId;
        public string matchName;
        public long timestamp;

        public MatchInfo(string id, string name, long tstamp)
        {
            matchId = id;
            matchName = name;
            timestamp = tstamp;
        }

        public string MatchId { get => matchId; set => matchId = value; }
        public string MatchName { get => matchName; set => matchName = value; }
        public long Timestamp { get => timestamp; set => timestamp = value; }
    }

    class Sportpesa
    {
        public static string pathToFile = AppDomain.CurrentDomain.BaseDirectory + '\\';
        public static List<Match> listOfMatches;
        public static string period;
        public static List<Match> Parse(string res, List<MatchInfo> matchesInfo)
        {
            List<Match> listOfMatches = new List<Match>();

            JObject json = JObject.Parse(res);
            foreach (MatchInfo info in matchesInfo)
            {
                JToken mtch = json[info.MatchId];
                if(mtch != null)
                {
                    List<Bet> listOfBets = new List<Bet>();
                    Match match = new Match("1", listOfBets);
                    match.MatchName = info.MatchName;
                    
                    DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    dtDateTime = dtDateTime.AddMilliseconds(info.Timestamp).ToLocalTime();
                    match.DateTime = dtDateTime;
                    match.Url = "https://www.sportpesa.com/games/" + info.MatchId + "/markets?sportId=1&section=highlights";


                    foreach (var market in mtch)
                    {
                        JToken marketNameToken = market["name"];
                        if (marketNameToken != null)
                        {
                            if (marketNameToken.ToString() == "3 Way")
                            {
                                JToken sel = market["selections"];
                                if(sel != null)
                                {
                                    JToken first = sel[0];
                                    JToken draw = sel[1];
                                    JToken second = sel[2];
                                    if(first != null && draw != null && second != null)
                                    {
                                        match.ListOfBets.Add(new Bet("1", double.Parse(first["odds"].ToString())));
                                        match.ListOfBets.Add(new Bet("X", double.Parse(draw["odds"].ToString())));
                                        match.ListOfBets.Add(new Bet("2", double.Parse(second["odds"].ToString())));
                                    }
                                }
                            }
                            else if (marketNameToken.ToString() == "Over/Under")
                            {
                                JToken sel = market["selections"];
                                if (sel != null)
                                {
                                    foreach(var total in sel)
                                    {
                                        if (total["name"].ToString().Contains("OVER"))
                                        {
                                            match.ListOfBets.Add(new Bet("Total Over " + total["specValue"].ToString().Trim().Replace(',', '.'),
                                                double.Parse(total["odds"].ToString())));
                                        }
                                        else if (total["name"].ToString().Contains("UNDER"))
                                        {
                                            match.ListOfBets.Add(new Bet("Total Under " + total["specValue"].ToString().Trim().Replace(',', '.'),
                                                double.Parse(total["odds"].ToString())));
                                        }
                                    }
                                }
                            }
                            else if (marketNameToken.ToString() == "Euro Handicap")
                            {
                                JToken sel = market["selections"];
                                if (sel != null)
                                {
                                    foreach (var handicap in sel)
                                    {
                                        if(handicap["shortName"].ToString() == "1")
                                        {
                                            double val = double.Parse(handicap["specValue"].ToString());
                                            val -= 0.5;
                                            string valStr = val.ToString();
                                            if (valStr[0] != '-')
                                            {
                                                valStr = "+" + valStr;
                                            }

                                            match.ListOfBets.Add(new Bet("H1 " + valStr.Trim().Replace(',', '.'),
                                                double.Parse(handicap["odds"].ToString())));
                                        }
                                        else if (handicap["shortName"].ToString() == "2")
                                        {
                                            double val = double.Parse(handicap["specValue"].ToString());
                                            val *= -1;
                                            val -= 0.5;
                                            string valStr = val.ToString();
                                            if (valStr[0] != '-')
                                            {
                                                valStr = "+" + valStr;
                                            }

                                            match.ListOfBets.Add(new Bet("H2 " + valStr.Trim().Replace(',', '.'),
                                                double.Parse(handicap["odds"].ToString())));
                                        }

                                    }
                                }
                            }
                        }
                    }
                    listOfMatches.Add(match);
                }
            }
            return listOfMatches;
        }

        public static string Request(string url)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.97 Safari/537.36";
            //   httpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
            // httpWebRequest.Headers.Add("accept-encoding", "gzip, deflate, br");
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
                return responseText;
            }
        }

        public static List<MatchInfo> ParseIds(string res)
        {
            List<MatchInfo> result = new List<MatchInfo>();
            res = "{\"value\":" + res;
            res += "}";
            JObject json = JObject.Parse(res);
            JToken mainToken = json["value"];
            if(mainToken != null)
            {
                foreach(var match in mainToken)
                {
                    JToken idToken = match["id"];
                    JToken compToken = match["competitors"];
                    JToken timeToken = match["dateTimestamp"];
                    if(compToken != null && timeToken != null)
                    {
                        JToken fToken = compToken[0];
                        JToken sToken = compToken[1];
                        if (fToken != null && sToken != null)
                        {
                            JToken fnameToken = fToken["name"]; 
                            JToken snameToken = sToken["name"]; 
                            if (idToken != null && fnameToken != null && snameToken != null)
                            {
                                result.Add(new MatchInfo(idToken.ToString(), fnameToken.ToString() + " v " + snameToken.ToString(), 
                                    long.Parse(timeToken.ToString())));
                            }
                        }
                    }
                }
            }
            return result;
        }

        public static string MakeReq(List<MatchInfo> matchesId)
        {
            string result = "https://www.sportpesa.com/api/games/markets?games=";
            if(matchesId.Count > 0)
            {
                foreach(MatchInfo info in matchesId)
                {
                    result += info.MatchId;
                    result += ',';
                }
                result = result.Substring(0, result.Length - 1);
            }
            else
            {
                result += '1';
            }
            result += "&markets=all";
            return result;
        }

        public static void StartLocal()
        {
            List<MatchInfo> matchesInfo = ParseIds(Request("https://www.sportpesa.com/api/upcoming/games?type=prematch&sportId=1&o=startTime&pag_count=10"));
            string req = MakeReq(matchesInfo);
            List<Match> LocalLitOfMatches = Parse(Request(req), matchesInfo);
            //Console.WriteLine("list of matches count: " + LocalLitOfMatches.Count());
            foreach (Match tmp in LocalLitOfMatches)
            {
                listOfMatches.Add(tmp);
            }
            //Console.WriteLine("1xbet end local: " + DateTime.Now.ToLongTimeString());
            //Console.WriteLine("LIST: " + listOfMatches.Count());
        }
        public static void Start()
        {
            listOfMatches = new List<Match>();
            StartLocal(); 
            //Console.WriteLine("1xbet end: " + DateTime.Now.ToLongTimeString());
        }
        public static Bookmaker GetSportpesa()
        {
            Bookmaker bookmaker = new Bookmaker("sportpesa", listOfMatches);
            return bookmaker;
        }
    }
    
}
