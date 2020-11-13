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
                            if (marketNameToken.ToString() == "3 Way")
                            {
                                JToken sel = market["selections"];
                                if (sel != null)
                                {
                                    JToken first = sel[0];
                                    JToken draw = sel[1];
                                    JToken second = sel[2];
                                    if (first != null && draw != null && second != null)
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
                                    foreach (var total in sel)
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
                                        if (handicap["shortName"].ToString() == "1")
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
                                matchInfo.Url = "https://www.sportpesa.com/games/" + matchInfo.MatchId + "/markets?sportId=1&section=highlights";

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
