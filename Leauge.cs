using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace riot
{
    public class League
    {
        public string tier { get; }
        public string rank { get; }
        public int leaguePoints { get; }
        public League(string summonerId)
        {

            HttpClient client = new HttpClient();

            var t = client.GetAsync($"https://na1.api.riotgames.com/lol/league/v4/positions/by-summoner/{summonerId}?api_key={API.apiKey}");
            dynamic leagueJsons = JArray.Parse(t.Result.Content.ReadAsStringAsync().Result.ToString());

            foreach (var json in leagueJsons)
            {
                dynamic leagueJson = JObject.Parse(json.ToString());
                if (leagueJson.queueType == "RANKED_SOLO_5x5")
                {
                    tier = leagueJson.tier;
                    rank = leagueJson.rank;
                    leaguePoints = leagueJson.leaguePoints;
                }
            }
        }
    }
}
