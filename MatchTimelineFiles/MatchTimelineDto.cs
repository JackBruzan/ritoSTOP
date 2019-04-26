using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;


namespace riot{
    class MatchTimeLineDto{
        List<MatchFrame> matchFrames = new List<MatchFrame>();
        public MatchTimeLineDto(uint _matchId){
            HttpClient client = new HttpClient();
            var t = client.GetAsync($"https://na1.api.riotgames.com/lol/match/v4/timelines/by-match/{_matchId}?api_key={API.apiKey}");
            dynamic matchFramesJson = JObject.Parse(t.Result.Content.ReadAsStringAsync().Result.ToString());
            
            List<MatchFrame> matchFrames = new List<MatchFrame>();
            foreach(var matchFrameJson in matchFramesJson.frames){
                MatchFrame matchFrame = new MatchFrame();
            }
        }
    }
}