using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace riot
{

    public class Summoner
    {
        public string summonerName;
        public Summoner(string summoner)
        {
            HttpClient client = new HttpClient();
            summonerName = summoner;
            string summonerAPI = "https://na1.api.riotgames.com/lol/summoner/v4/summoners/by-name/";
            string apiKey = "?api_key=RGAPI-57bd5937-cc40-4088-a10a-a077c2113b46";
            string fullAPI = $"{summonerAPI}{summoner}{apiKey}";

            var t = client.GetAsync($"{fullAPI}");

            dynamic gameJson = JObject.Parse(t.Result.Content.ReadAsStringAsync().Result.ToString());

            profileIconId = gameJson.profileIconId;
            name = gameJson.name;
            puuid = gameJson.puuid;
            summonerLevel = gameJson.summonerLevel;
            revisionDate = gameJson.revisionDate;
            id = gameJson.id;
            accountId = gameJson.accountId;
        }

        int profileIconId { get; }
        string name { get; }
        string puuid { get; }
        long summonerLevel { get; }
        long revisionDate { get; }
        string id { get; }
        string accountId { get; }

    }
}