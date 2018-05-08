using System.Collections.Generic;
using ATM_Classes.Data;

namespace ATM_Classes.Interfaces
{
    public interface ITrackReceiver
    {
        void ReceiveTracks(List<TrackData> tracks);
    }
}
