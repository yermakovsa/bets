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
    class Helabet
    {
        public static string pathToFile = AppDomain.CurrentDomain.BaseDirectory + '\\';
        public static List<Match> listOfMatches;
        public static string period;
        public static List<Match> Parse(string s)
        {
            //Console.WriteLine("ssss");
            List<Match> listOfMatches = new List<Match>();
            JObject json = JObject.Parse(s);
            var value = json["Value"];
            foreach (var mch in value)
            {
                List<Bet> listOfBets = new List<Bet>();
                Match match = new Match("1", listOfBets);
                //match.date = "";
                JToken t2 = mch["O2"];
                string team1, team2;
                if (t2 != null)
                {
                    team1 = mch["O1"].ToString();
                    team2 = mch["O2"].ToString();
                    match.MatchName = team1 + " v " + team2;
                }
                else
                {
                    team1 = mch["O1"].ToString();
                    match.MatchName = team1 + " v empty";
                }
                string matchID = mch["CI"].ToString();
                string matchName = match.MatchName.Replace(" v ", " ").Replace(" ", "-").Replace(".", "");
                string champID = mch["LI"].ToString();
                string champName = mch["L"].ToString().Replace(" ", "-").Replace(".", "");
                string sportName = mch["SN"].ToString();
                if (sportName.ToLower().Contains("table")) sportName = "Table-Tennis";
                champName = champName.Replace(":", "");
                string tmpUrl = "ua-1x-bet.com/en/line/" + sportName + "/" + champID + "-" + champName + "/";
                tmpUrl += matchID + "-" + matchName + "/";
                string url = "";
                foreach(char x in tmpUrl)
                {
                    if ((x >= 'a' && x <= 'z') || (x >= 'A' && x <= 'Z') || (x >= '0' && x <= '9') || 
                        x == '-' || x == '/' || x == '.' || x == ':' || x == '-') url += x;
                }
                match.Url = url;
                int sec;
                sec = int.Parse(mch["S"].ToString());
                DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddSeconds(sec).ToLocalTime();
                match.DateTime = dtDateTime;
                //string date = dtDateTime.Day + "/" + dtDateTime.Month;
                string date = "";
                if (dtDateTime.Day <= 9)
                {
                    date += "0" + dtDateTime.Day + "/";
                }
                else
                {
                    date += dtDateTime.Day + "/";
                }
                if (dtDateTime.Month <= 9)
                {
                    date += "0" + dtDateTime.Month;
                }
                else
                {
                    date += dtDateTime.Month.ToString();
                }
                //match.date = date;
                var bets = mch["E"];
                Bet b1 = null;
                Bet b2 = null;
                Bet b3 = null;
                foreach (var bet in bets)
                {
                    JToken tmp = bet["T"];
                    if (tmp != null)
                    {
                        if (bet["T"].ToString() == "7" || bet["T"].ToString() == "2826")
                        {
                            JToken token = bet["P"];
                            string betName = "H1 ";
                            if (token != null)
                            {
                                if (token.ToString().Contains("-"))
                                {
                                    betName += token.ToString().Trim().Replace(',', '.');
                                }
                                else
                                {
                                    betName += "+" + token.ToString().Trim().Replace(',', '.');
                                }
                            }
                            else
                            {
                                betName += "0";
                            }
                            listOfBets.Add(new Bet(period + betName, double.Parse(bet["C"].ToString())));
                        }
                        else if (bet["T"].ToString() == "8" || bet["T"].ToString() == "2827")
                        {
                            JToken token = bet["P"];
                            string betName = "H2 ";
                            if (token != null)
                            {
                                if (token.ToString().Contains("-"))
                                {
                                    betName += token.ToString().Trim().Replace(',', '.');
                                }
                                else
                                {
                                    betName += "+" + token.ToString().Trim().Replace(',', '.');
                                }
                            }
                            else
                            {
                                betName += "0";
                            }
                            listOfBets.Add(new Bet(period + betName, double.Parse(bet["C"].ToString())));
                        }
                        else if (bet["T"].ToString() == "9" || bet["T"].ToString() == "2824")
                        {
                            listOfBets.Add(new Bet(period + "Total Over " + bet["P"].ToString().Trim().Replace(',', '.'), double.Parse(bet["C"].ToString())));
                        }
                        else if (bet["T"].ToString() == "10" || bet["T"].ToString() == "2825")
                        {
                            listOfBets.Add(new Bet(period + "Total Under " + bet["P"].ToString().Trim().Replace(',', '.'), double.Parse(bet["C"].ToString())));
                        }
                        else if (bet["T"].ToString() == "11")
                        {
                            listOfBets.Add(new Bet(period + "Total1 Over " + bet["P"].ToString().Trim().Replace(',', '.'), double.Parse(bet["C"].ToString())));
                        }
                        else if (bet["T"].ToString() == "12")
                        {
                            listOfBets.Add(new Bet(period + "Total1 Under " + bet["P"].ToString().Trim().Replace(',', '.'), double.Parse(bet["C"].ToString())));
                        }
                        else if (bet["T"].ToString() == "13")
                        {
                            listOfBets.Add(new Bet(period + "Total2 Over " + bet["P"].ToString().Trim().Replace(',', '.'), double.Parse(bet["C"].ToString())));
                        }
                        else if (bet["T"].ToString() == "14")
                        {
                            listOfBets.Add(new Bet(period + "Total2 Under " + bet["P"].ToString().Trim().Replace(',', '.'), double.Parse(bet["C"].ToString())));
                        }
                        else if(bet["T"].ToString() == "1")
                        {
                            b1 = new Bet(period + "1", double.Parse(bet["C"].ToString()));
                        }
                        else if (bet["T"].ToString() == "2")
                        {
                            b2 = new Bet(period + "X", double.Parse(bet["C"].ToString()));
                        }
                        else if (bet["T"].ToString() == "3")
                        {
                            b3 = new Bet(period + "2", double.Parse(bet["C"].ToString()));
                        }
                    }
                }
                if(b1 != null && b2 == null && b3 != null)
                {
                    listOfBets.Add(b1);
                    listOfBets.Add(b3);
                }
                listOfMatches.Add(match);
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

        public static void StartLocal()
        {
            List<Match> LocalLitOfMatches = Parse(Request("https://helabet.co.ke/LineFeed/Get1x2_VZip?sports=4&count=10&lng=en&tf=3000000&tz=2&mode=7&partner=237&getEmpty=true"));
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
        public static Bookmaker GetHelabet()
        {
            Bookmaker bookmaker = new Bookmaker("helabet", listOfMatches);
            return bookmaker;
        }
    }
    
}
