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
            string apiKey = "RGAPI-7bdf5f7e-bc68-4741-b9a2-0d470ee3d62b";

            var t = client.GetAsync($"https://na1.api.riotgames.com/lol/summoner/v4/summoners/by-name/{summoner}?api_key={API.apiKey}");
            dynamic summonerJson = JObject.Parse(t.Result.Content.ReadAsStringAsync().Result.ToString());

            profileIconId = summonerJson.profileIconId;
            accountId = summonerJson.accountId;
            name = summonerJson.name;
            puuid = summonerJson.puuid;
            summonerLevel = summonerJson.summonerLevel;
            revisionDate = summonerJson.revisionDate;
            id = summonerJson.id;
            league = new League(id);
        }

        int profileIconId { get; }
        string name { get; }
        string puuid { get; }
        long summonerLevel { get; }
        long revisionDate { get; }
        public string id { get; }
        public string accountId { get; }
        public League league{get;}
    }
}