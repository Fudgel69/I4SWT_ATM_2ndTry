using System;
using System.Collections.Generic;
using ATM_Classes.Data;

namespace ATM_Classes.Interfaces
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
