using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace riot
{
    class Program
    {
        static void Main(string[] args)
        {
            //Summoner summoner = new Summoner("unfeasib");
            //LiveGame liveGame = new LiveGame(summoner.id);

            //liveGame.GetSummonerRanks();
            MatchTimeLineDto matchTimeLineDto = new MatchTimeLineDto(2936546794);
            //Game game = new Game(2936546794);
        }
    }
}
