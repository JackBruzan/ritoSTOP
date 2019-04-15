using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace riot
{
    public partial class LiveGame
    {
        string accountId;
        bool live { get; }

        public LiveGame(object accountId)
        {
            HttpClient client = new HttpClient();

            //string apiKey = "RGAPI-7bdf5f7e-bc68-4741-b9a2-0d470ee3d62b";

            var t = client.GetAsync($"https://na1.api.riotgames.com/lol/spectator/v4/active-games/by-summoner/{accountId}?api_key={API.apiKey}");
            HttpResponseMessage response = t.Result;

            if (response.Content.ToString().Contains("404"))
                live = false;

            else{
                dynamic liveGameJson = JObject.Parse(t.Result.Content.ReadAsStringAsync().Result.ToString());

                live = true;
            }
        }

        public class CurrentGameParticipant{
            public string summonerName{get;}
            public string championId{get;}
            public string summonerId{get;}
        }
        public Dictionary<string, string> GetSummonerRanks(List<CurrentGameParticipant> currentGameParticipants){
            Dictionary<string, string> results = new Dictionary<string, string>();            

            foreach(var participant in currentGameParticipants){
                Summoner summoner = new Summoner(participant.summonerName);
                //Tuple<summonerName: string, summonerRank: string>  summonerAndRank = summoner.GetRank()


                Console.WriteLine($"{summoner.summonerName}: {summoner.league.rank} {summoner.league.tier}");
            }

            return results;
        }
    }
}