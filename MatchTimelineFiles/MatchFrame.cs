using System.Collections.Generic;

namespace riot
{
    internal class MatchFrame
    {
        long timestamp{get;}
        Dictionary<string, MatchParticipantFrameDto> participantFrames {get;}
    }
}