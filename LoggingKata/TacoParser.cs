namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // make into array of strings separating lat, long, and name
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null
                // Do not fail if one record parsing fails, return null
                return null; // TODO Implement
            }

            var latitude = double.Parse(cells[0]);

            var longitude = double.Parse(cells[1]);

            var name = cells[2];

            var chain = new TacoBell() { Name = name, Location = new Point() { Latitude = latitude, Longitude = longitude } };

            return chain;   //conforms to ITrackable
        }
    }
}