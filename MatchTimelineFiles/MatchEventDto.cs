using System;
using System.Collections.Generic;

namespace riot
{
    internal class MatchEventDto
    {
        string eventType { get; }
        string towerType { get; }
        int teamId { get; }
        string ascendedType { get; }
        int killerId { get; }
        string levelUpType { get; }
        string pointCaptured { get; }
        List<Int32> assistingParticipants { get; }
        string wardType { get; }
        string monsterType { get; }
        string type { get; }
        int skillSlot { get; }
        int victimId { get; }
        long timestamp { get; }
        int afterId { get; }
        string monsterSubType { get; }
        string laneType { get; }
        int itemId { get; }
        int participantId { get; }
        string buildingType { get; }
        int creatorId { get; }
        MatchPositionDto position { get; }
        int beforeId { get; }
    }
}