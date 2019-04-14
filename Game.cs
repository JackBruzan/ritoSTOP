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

            string apiKey = "RGAPI-bad88fd9-3467-4052-af01-7fce08dbeee4";
            var t = client.GetAsync($"https://na1.api.riotgames.com/lol/match/v4/matches/{gameID}/?api_key={apiKey}");
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