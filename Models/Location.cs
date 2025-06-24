namespace DeKruik.Models
{
    public class Location
    {
        public string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public Location(string name, float latitude, float longitude)
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }

        public List<Route> Routes { get; set; } = new List<Route>();

        public override string ToString()
        {
            return Name;
        }
    }
}
