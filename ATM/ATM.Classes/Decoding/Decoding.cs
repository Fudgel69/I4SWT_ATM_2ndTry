using System;
using System.Collections.Generic;
using ATM.Classes.Data;
using ATM.Classes.Interfaces;
using TransponderReceiver;

namespace ATM.Classes.Decoding
{
    public class Decoding : ITrackDecoding
    {
        private List<TrackData> trackList;
        public event EventHandler<TrackDataEventArgs> TrackDataReady;

        public Decoding(ITransponderReceiver rawReceiver)
        {
            rawReceiver.TransponderDataReady += OnRawData;

            trackList = new List<TrackData>();
        }

        public void OnRawData(object o, RawTransponderDataEventArgs args)
        {
            trackList.Clear();

            foreach (var data in args.TransponderData)
            {
                trackList.Add(Convert(data));
            }

            if (trackList.Count != 0)
            {
                var handler = TrackDataReady;
                handler?.Invoke(this, new TrackDataEventArgs(trackList));
            }
        }

        private TrackData Convert(string data)
        {
            TrackData track = new TrackData();
            var words = data.Split(';');
            track.Tag = words[0];
            track.X = int.Parse(words[1]);
            track.Y = int.Parse(words[2]);
            track.Altitude = int.Parse(words[3]);
            track.Timestamp = DateTime.ParseExact(words[4], "yyyyMMddHHmmssfff",
                System.Globalization.CultureInfo.InvariantCulture);
            track.Course = 0;
            track.Velocity = 0;

            return track;
        }

    }
}
