using bets.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bets.Util
{
    class SportpesaUtil
    {
        public static string pathToFile = AppDomain.CurrentDomain.BaseDirectory + '\\';
        //public static string period;

        public static List<Match> Parse(string res, List<Match> listOfMatches)
        {

            JObject json = JObject.Parse(res);
            foreach (Match match in listOfMatches)
            {
                JToken mtch = json[match.MatchId];
                if (mtch != null)
                {
                    List<Bet> listOfBets = new List<Bet>();
                    foreach (var market in mtch)
                    {
                        JToken marketNameToken = market["name"];
                        if (marketNameToken != null)
                        {
                            string marketName = marketNameToken.ToString();
                            string period = "_";
                            if(marketName.Contains(" - Full Time"))
                            {
                                marketName = marketName.Replace(" - Full Time", "");
                            }
                            else if (marketName.Contains(" - First Half"))
                            {
                                period = "1_";
                                marketName = marketName.Replace(" - First Half", "");
                            }
                            else if(marketName.Contains("Second Half"))
                            {
                                period = "2_";
                                marketName = marketName.Replace(" - Second Half", "");
                            }

                            if (marketName == "3 Way")
                            {
                                JToken sel = market["selections"];
                                if (sel != null)
                                {
                                    JToken first = sel[0];
                                    JToken draw = sel[1];
                                    JToken second = sel[2];
                                    if (first != null && draw != null && second != null)
                                    {
                                        match.Way3 = true;
                                        match.ListOfBets.Add(new Bet(period + "1", double.Parse(first["odds"].ToString())));
                                        match.ListOfBets.Add(new Bet(period + "X", double.Parse(draw["odds"].ToString())));
                                        match.ListOfBets.Add(new Bet(period + "2", double.Parse(second["odds"].ToString())));
                                    }
                                }
                            }
                            else if (marketName == "Over/Under")
                            {
                                JToken sel = market["selections"];
                                if (sel != null)
                                {
                                    foreach (var total in sel)
                                    {
                                        if (total["name"].ToString().Contains("OVER"))
                                        {
                                            match.ListOfBets.Add(new Bet(period + "Total Over " + total["specValue"].ToString().Trim().Replace(',', '.'),
                                                double.Parse(total["odds"].ToString())));
                                        }
                                        else if (total["name"].ToString().Contains("UNDER"))
                                        {
                                            match.ListOfBets.Add(new Bet(period + "Total Under " + total["specValue"].ToString().Trim().Replace(',', '.'),
                                                double.Parse(total["odds"].ToString())));
                                        }
                                    }
                                }
                            }
                            else if (marketName == "Euro Handicap")
                            {
                                JToken sel = market["selections"];
                                if (sel != null)
                                {
                                    foreach (var handicap in sel)
                                    {
                                        if (handicap["shortName"].ToString() == "1")
                                        {
                                            double val = double.Parse(handicap["specValue"].ToString());
                                            val -= 0.5;
                                            string valStr = val.ToString();
                                            if (valStr[0] != '-')
                                            {
                                                valStr = "+" + valStr;
                                            }

                                            match.ListOfBets.Add(new Bet(period + "H1 " + valStr.Trim().Replace(',', '.'),
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

                                            match.ListOfBets.Add(new Bet(period + "H2 " + valStr.Trim().Replace(',', '.'),
                                                double.Parse(handicap["odds"].ToString())));
                                        }

                                    }
                                }
                            }
                            else if (marketName == "Double Chance")
                            {
                                JToken sel = market["selections"];
                                if (sel != null)
                                {
                                    JToken first_or_draw = sel[0];
                                    JToken second_or_draw = sel[1];
                                    JToken not_drow = sel[2];
                                    if (first_or_draw != null && second_or_draw != null && not_drow != null)
                                    {
                                        match.ListOfBets.Add(new Bet(period + "1X", double.Parse(first_or_draw["odds"].ToString())));
                                        match.ListOfBets.Add(new Bet(period + "X2", double.Parse(second_or_draw["odds"].ToString())));
                                        match.ListOfBets.Add(new Bet(period + "12", double.Parse(not_drow["odds"].ToString())));
                                    }
                                }
                            }
                            else if(marketName == "Total Goals Over/Under Home Team")
                            {
                                JToken sel = market["selections"];
                                if (sel != null)
                                {
                                    foreach (var total in sel)
                                    {
                                        if (total["name"].ToString().Contains("OVER"))
                                        {
                                            match.ListOfBets.Add(new Bet(period + "Total1 Over " + total["specValue"].ToString().Trim().Replace(',', '.'),
                                                double.Parse(total["odds"].ToString())));
                                        }
                                        else if (total["name"].ToString().Contains("UNDER"))
                                        {
                                            match.ListOfBets.Add(new Bet(period + "Total1 Under " + total["specValue"].ToString().Trim().Replace(',', '.'),
                                                double.Parse(total["odds"].ToString())));
                                        }
                                    }
                                }
                            }
                            else if (marketName == "Total Goals Over/Under Away Team")
                            {
                                JToken sel = market["selections"];
                                if (sel != null)
                                {
                                    foreach (var total in sel)
                                    {
                                        if (total["name"].ToString().Contains("OVER"))
                                        {
                                            match.ListOfBets.Add(new Bet(period + "Total1 Over " + total["specValue"].ToString().Trim().Replace(',', '.'),
                                                double.Parse(total["odds"].ToString())));
                                        }
                                        else if (total["name"].ToString().Contains("UNDER"))
                                        {
                                            match.ListOfBets.Add(new Bet(period + "Total1 Under " + total["specValue"].ToString().Trim().Replace(',', '.'),
                                                double.Parse(total["odds"].ToString())));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return listOfMatches;
        }

        public static List<Match> ParseIds(string res)
        {
            List<Match> result = new List<Match>();
            res = "{\"value\":" + res;
            res += "}";
            JObject json = JObject.Parse(res);
            JToken mainToken = json["value"];
            if (mainToken != null)
            {
                foreach (var match in mainToken)
                {
                    JToken idToken = match["id"];
                    JToken compToken = match["competitors"];
                    JToken timeToken = match["dateTimestamp"];
                    if (compToken != null && timeToken != null)
                    {
                        JToken fToken = compToken[0];
                        JToken sToken = compToken[1];
                        if (fToken != null && sToken != null)
                        {
                            JToken fnameToken = fToken["name"];
                            JToken snameToken = sToken["name"];
                            if (idToken != null && fnameToken != null && snameToken != null)
                            {
                                Match matchInfo = new Match("1", new List<Bet>());
                                matchInfo.MatchName = fnameToken.ToString() + " v " + snameToken.ToString();
                                matchInfo.MatchId = idToken.ToString();
                                matchInfo.Url = "https://www.sportpesa.com/games/" + matchInfo.MatchId + "/markets?sportId=1";

                                DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                                dtDateTime = dtDateTime.AddMilliseconds(long.Parse(timeToken.ToString())).ToLocalTime();
                                matchInfo.DateTime = dtDateTime;

                                result.Add(matchInfo);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public static string createRequestMatchesUrl(List<Match> matchesId)
        {
            string result = "https://www.sportpesa.com/api/games/markets?games=";
            if (matchesId.Count > 0)
            {
                foreach (Match info in matchesId)
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
    }
}
