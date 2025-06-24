namespace DeKruik.Models
{
    public class Route
    {
        public int Id { get; set; } = 0;
        public Location From { get; set; }
        public Location To { get; set; }
        public float Distance { get; set; }
        public int Traveltime { get; set; }

        public Route(int id, Location from, Location to, float distance, int traveltime)
        {
            Id = id;
            From = from;
            To = to;
            Distance = distance;
            Traveltime = traveltime;
        }

        public override string ToString()
        {
            return From.ToString() + "->" + To.ToString() + " " + Distance.ToString();
        }
    }
}
