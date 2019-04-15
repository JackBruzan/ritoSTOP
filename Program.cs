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
            Summoner summoner = new Summoner("SneakyFreaky");
            LiveGame liveGame = new LiveGame(summoner.id);

            liveGame.GetSummonerRanks();

            //Game game = new Game(2936546794);
        }
    }
}
