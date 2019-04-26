using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace riot
{
    public partial class LiveGame
    {
        public string accountId { get; }
        public bool live { get; }
        public List<CurrentGameParticipant> currentGameParticipants = new List<CurrentGameParticipant>();
        public List<BannedChampion> bannedChampions = new List<BannedChampion>();

        public LiveGame(object accountId)
        {
            HttpClient client = new HttpClient();
            var t = client.GetAsync($"https://na1.api.riotgames.com/lol/spectator/v4/active-games/by-summoner/{accountId}?api_key={API.apiKey}");
            HttpResponseMessage response = t.Result;

            if (response.Content.ToString().Contains("404"))
                live = false;

            else
            {
                dynamic liveGameJson = JObject.Parse(t.Result.Content.ReadAsStringAsync().Result.ToString());

                dynamic currentParticipantsJson = JArray.Parse(liveGameJson.participants.ToString());
 
                List<GameCustomizationObject> gameCustomizationObjects = new List<GameCustomizationObject>();
                foreach (var participant in currentParticipantsJson)
                {
                    dynamic participantGameCusomizationObjectsJson = JArray.Parse(participant.gameCustomizationObjects.ToString());
                    foreach(var gameCustomizaionObjectJson in participantGameCusomizationObjectsJson){
                        GameCustomizationObject gameCustomizationObject = new GameCustomizationObject(gameCustomizaionObjectJson.category.Value.ToString(), gameCustomizaionObjectJson.content.Value.ToString());
                        gameCustomizationObjects.Add(gameCustomizationObject);
                    }
                    
                    CurrentGameParticipant currentGameParticipant = new CurrentGameParticipant(participant.summonerName.Value.ToString(), participant.championId.Value.ToString(), participant.summonerId.Value.ToString(), gameCustomizationObjects);
                    currentGameParticipants.Add(currentGameParticipant);
                }

                dynamic bannedChampionsJson = JArray.Parse(liveGameJson.bannedChampions.ToString());
                foreach (var ban in bannedChampionsJson)
                {
                    BannedChampion bannedChampion = new BannedChampion(ban.championId.Value.ToString(), ban.teamId.Value.ToString(), (Int32)ban.pickTurn.Value);
                    bannedChampions.Add(bannedChampion);
                }
                live = true;
            }
        }

        public class CurrentGameParticipant
        {
            public CurrentGameParticipant(string _summonerName, string _championId, string _summonerId, List<GameCustomizationObject> _gameCustomizationObjects)
            {
                summonerName = _summonerName;
                championId = _championId;
                summonerId = _summonerId;
                gameCustomizationObjects = _gameCustomizationObjects;
            }

            public string summonerName { get; }
            public string championId { get; }
            public string summonerId { get; }
            public List<GameCustomizationObject>  gameCustomizationObjects;
        }

        public class GameCustomizationObject
        {
            public string category { get; }
            public string content { get; }
            public GameCustomizationObject(string _category, string _content){
                category = _category;
                content = _content;
            }
        }



        public void GetSummonerRanks()
        {
            foreach (var participant in currentGameParticipants)
            {
                Summoner summoner = new Summoner(participant.summonerName);
                Console.WriteLine($"{summoner.summonerName}: {summoner.league.tier} {summoner.league.rank}");
            }
            return;
        }
    }
}