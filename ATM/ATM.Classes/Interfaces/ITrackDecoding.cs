using System;
using System.Collections.Generic;
using ATM.Classes.Data;

namespace ATM.Classes.Interfaces
{
    public class TrackDataEventArgs : EventArgs
    {
        public List<TrackData> TrackData { get; }
        public TrackDataEventArgs(List<TrackData> trackData)
        {
            TrackData = trackData;
        }
    }

    public interface ITrackDecoding
    {
        event EventHandler<TrackDataEventArgs> TrackDataReady;
    }
}
