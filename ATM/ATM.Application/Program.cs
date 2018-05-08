using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ATM.Classes.Data;
using ATM.Classes.Decoding;
using TransponderReceiver;

namespace ATM.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            ITransponderReceiver transponderDataReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();

            var decoder = new Decoding(transponderDataReceiver);

            decoder.TrackDataReady += (o, trackArgs) => PrintTracks(trackArgs.TrackData);

            System.Console.ReadLine();
        }

        private static void PrintTracks(List<TrackData> tracks)
        {
            Console.Clear();
            System.Console.WriteLine("=================================================");
            Console.SetCursorPosition(0, Console.CursorTop);
            foreach (var track in tracks)
            {
                System.Console.WriteLine(track);                
            }
            System.Console.WriteLine("=================================================");
        }

        
    }
}
