using System;

namespace riot{
    public class MatchParticipantFrameDto{
        int totalGold{ get; }
        int teamScore{ get; }
        int participantId{ get; }
        int level{ get; }
        int currentGold{ get; }
        int minionsKilled{ get; }
        int dominionScore{ get; }
        MatchPositionDto position{ get; }
        int xp{ get; }
        int jungleMinionsKilled{ get; }
    }
}