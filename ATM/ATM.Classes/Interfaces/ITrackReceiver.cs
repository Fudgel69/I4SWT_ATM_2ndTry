using System.Collections.Generic;
using ATM.Classes.Data;

namespace ATM.Classes.Interfaces
{
    public interface ITrackReceiver
    {
        void ReceiveTracks(List<TrackData> tracks);
    }
}
