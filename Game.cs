using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace riot
{

    public class Game
    {
        public Game(uint gameID)
        {
            HttpClient client = new HttpClient();

            //string apiKey = "RGAPI-7bdf5f7e-bc68-4741-b9a2-0d470ee3d62b";
            var t = client.GetAsync($"https://na1.api.riotgames.com/lol/match/v4/matches/{gameID}?api_key={API.apiKey}");
            dynamic gameJson = JObject.Parse(t.Result.Content.ReadAsStringAsync().Result.ToString());

            seasonId = gameJson.seasonId;
            queueId = gameJson.queueId;
            gameId = gameJson.gameId;
            gameVersion = gameJson.gameVersion;
            platformId = gameJson.platformId;
            gameMode = gameJson.gameMode;
            mapId = gameJson.mapId;
            gameType = gameJson.gameType;
            gameDuration = gameJson.gameDuration;
            gameCreation = gameJson.gameCreation;
        }
        int seasonId { get; }
        int queueId { get; }
        uint gameId { get; }
        List<ParticipantIdentityDto> participantIdentities { get; }
        string gameVersion { get; }
        string platformId { get; }
        string gameMode { get; }
        int mapId { get; }
        string gameType { get; }
        List<TeamStatsDto> teams { get; }
        List<Participants> participants { get; }
        float gameDuration { get; }
        float gameCreation { get; }
    }
}