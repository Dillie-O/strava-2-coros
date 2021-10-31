using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using StravaGPXReaderLib;

namespace strava_2_coros
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lets do this! Loading sample file...");

            try
            {
                XDocument myGPX = XDocument.Load("sample.gpx");

                XmlNamespaceManager r = new XmlNamespaceManager(new NameTable());
                r.AddNamespace("p", "http://www.topografix.com/GPX/1/1");

                StravaGPXReaderLib.GPXReader gPXReader = new StravaGPXReaderLib.GPXReader(myGPX, r);

                Console.WriteLine("Name: " + gPXReader.GetGPXName());
                Console.WriteLine("Activity Type: " + gPXReader.GetActivityType());
                Console.WriteLine("Avg Elevation: " + gPXReader.GetElevation(StravaGPXReaderLib.GPXReader.ElevationType.Avg));
                Console.WriteLine("Min Elevation: " + gPXReader.GetElevation(StravaGPXReaderLib.GPXReader.ElevationType.Min));
                Console.WriteLine("Max Elevation: " + gPXReader.GetElevation(StravaGPXReaderLib.GPXReader.ElevationType.Max));
                Console.WriteLine("Start Date: " + gPXReader.GetStartDt());
                Console.WriteLine("End Date: " + gPXReader.GetEndDt());
                Console.WriteLine("Duration: " + gPXReader.GetDuration());
                Console.WriteLine("Distance: " + gPXReader.GetDistance());

                Console.WriteLine("Printing complete list of latitude - longitude with details");

                // List<StravaGPXReaderLib.Models.GPXCoordinates> coordinates = gPXReader.GetGPXCoordinates();
                // for (int i = 0; i < coordinates.Count; i++)
                // {
                //     Console.WriteLine($"lat: {coordinates[i].Latitude} - lon: {coordinates[i].Longitude}");
                // }

                // StravaGPXReaderLib.Models.GPXAltimetry altimetry = gPXReader.GetGPXAltimetry();
                // foreach (StravaGPXReaderLib.Models.Altimetry altimetryItem in altimetry.Altimetries)
                // {
                //     Console.WriteLine($"Altimetry value: Meters:{altimetryItem.Elevation} - KM:{altimetryItem.Kilometers}");
                // }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing file: {ex.Message}");
            }

            Console.WriteLine("Process Complete.");
        }
    }
}
