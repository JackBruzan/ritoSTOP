namespace riot
{
    public partial class LiveGame
    {
        public class BannedChampion
        {
            int pickTurn;
            long championid;
            long teamId;

            public BannedChampion(int inPickTurn, long inChampionid, long inTeamId)
            {
                pickTurn = inPickTurn;
                championid = inChampionid;
                teamId = inTeamId;
            }
        }
    }
}