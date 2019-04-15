namespace riot
{
    public partial class LiveGame
    {
        public class BannedChampion
        {
            int pickTurn;
            string championid;
            string teamId;

            public BannedChampion(string _championid, string _teamId, int _pickTurn)
            {
                pickTurn = _pickTurn;
                championid = _championid;
                teamId = _teamId;
            }
        }
    }
}