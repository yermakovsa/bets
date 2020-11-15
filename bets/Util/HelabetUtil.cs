using bets.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bets.Util
{
    class HelabetUtil
    {
        private static List<String> forbiddenIds = new List<String>() 
            { "2999","249","19","220","41","68","44","132","242","82","38","202","23","24","87","69","92","133","20","176" };
        public static List<Match> parseMatches(string s, string period)
        {
            List<Match> listOfMatches = new List<Match>();
            JObject json = JObject.Parse(s);
            var value = json["Value"];
            foreach (var mch in value)
            {
                JToken tg = mch["TG"];
                if(tg != null)
                {
                    //yellow cards and others
                    continue;
                }

                List<Bet> listOfBets = new List<Bet>();
                Match match = new Match("1", listOfBets);
                JToken t1 = mch["O1"];
                JToken t2 = mch["O2"];
                string team1, team2;
                if (t2 != null && t1 != null)
                {
                    team1 = mch["O1"].ToString();
                    team2 = mch["O2"].ToString();
                    match.MatchName = team1 + " v " + team2;
                }
                else
                {
                    continue;
                    //team1 = mch["O1"].ToString();
                    //match.MatchName = team1 + " v empty";
                }
                string matchID = mch["CI"].ToString();
                string matchName = match.MatchName.Replace(" v ", " ").Replace(" ", "-").Replace(".", "");
                string champID = mch["LI"].ToString();
                string champName = mch["L"].ToString().Replace(" ", "-").Replace(".", "");
                string sportName = mch["SN"].ToString();
                if (sportName.ToLower().Contains("table")) sportName = "Table-Tennis";
                champName = champName.Replace(":", "");
                // TODO change url
                string tmpUrl = "helabet.co.ke/line/" + sportName + "/" + champID + "-" + champName + "/";
                tmpUrl += matchID + "-" + matchName + "/";
                string url = "";
                foreach (char x in tmpUrl)
                {
                    if ((x >= 'a' && x <= 'z') || (x >= 'A' && x <= 'Z') || (x >= '0' && x <= '9') ||
                        x == '-' || x == '/' || x == '.' || x == ':' || x == '-') url += x;
                }
                match.Url = url;
                match.LeagueName = champName;
                match.MatchId = mch["I"].ToString();
                int sec;
                sec = int.Parse(mch["S"].ToString());
                DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddSeconds(sec).ToLocalTime();
                match.DateTime = dtDateTime;
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
                        else if (bet["T"].ToString() == "1" || bet["T"].ToString() == "7736" || bet["T"].ToString() == "401")
                        {
                            b1 = new Bet(period + "1", double.Parse(bet["C"].ToString()));
                        }
                        else if (bet["T"].ToString() == "2")
                        {
                            b2 = new Bet(period + "X", double.Parse(bet["C"].ToString()));
                        }
                        else if (bet["T"].ToString() == "3" || bet["T"].ToString() == "7737" || bet["T"].ToString() == "402")
                        {
                            b3 = new Bet(period + "2", double.Parse(bet["C"].ToString()));
                        }
                        else if (bet["T"].ToString() == "4")
                        {
                            listOfBets.Add(new Bet(period + "1X", double.Parse(bet["C"].ToString())));
                        }
                        else if (bet["T"].ToString() == "5")
                        {
                            listOfBets.Add(new Bet(period + "12", double.Parse(bet["C"].ToString())));
                        }
                        else if (bet["T"].ToString() == "6")
                        {
                            listOfBets.Add(new Bet(period + "X2", double.Parse(bet["C"].ToString())));
                        }
                    }
                }
                if (b1 != null && b2 != null && b3 != null)
                {
                    listOfBets.Add(b1);
                    listOfBets.Add(b2);
                    listOfBets.Add(b3);
                    match.Way3 = true;
                }
                else if(b1 != null && b2 == null && b3 != null)
                {
                    listOfBets.Add(b1);
                    listOfBets.Add(b3);
                    match.Way2 = true;
                }
                listOfMatches.Add(match);
            }
            return listOfMatches;
        }
        public static Dictionary<String, String> parseSportIds(String inputString)
        {
            Dictionary<String, String> keyValuePairs = new Dictionary<String, String>();
            JObject jObject = JObject.Parse(inputString);
            JArray idArray = (JArray)jObject["Value"];
            foreach (JToken idObject in idArray)
            {
                String sportId = idObject["I"].ToString();
                String sportName = idObject["N"].ToString();
                if (forbiddenIds.Contains(sportId)) continue;
                keyValuePairs.Add(sportId, sportName);
            }
            return keyValuePairs;
        }
    }
 
}
