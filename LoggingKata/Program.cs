using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable; //to compare locations

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            // DON'T FORGET TO LOG YOUR STEPS

            ITrackable firstLocation = null;
            ITrackable secondLocation = null;
            double distance = 0;

            foreach(ITrackable location in locations)
            {
                //var corA = location.Location;
                var corA = new GeoCoordinate(location.Location.Latitude, location.Location.Longitude);

                foreach(ITrackable location2 in locations)
                {
                    var corB = new GeoCoordinate(location2.Location.Latitude, location2.Location.Longitude);
                    var distanceTemp = corA.GetDistanceTo(corB);

                    if(distanceTemp > distance)
                    {
                        distance = distanceTemp;
                        firstLocation = location;
                        secondLocation = location2;
                    }
                }



            }
            Console.WriteLine($"LocationA: {firstLocation.Name}: ({firstLocation.Location.Latitude}, {firstLocation.Location.Longitude})" +
                $"\nLocationB: {secondLocation.Name }: ({secondLocation.Location.Latitude}, {secondLocation.Location.Longitude})\n" +
                $"Distance: {distance}");

        }
    }
}
