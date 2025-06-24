namespace DeKruik.Models
{
    public class Passenger
    {
        public string Name { get; set; }
        public bool Wheelchair { get; set; } = false;

        public Passenger(string name, bool wheelchair)
        {
            Name = name;
            Wheelchair = wheelchair;
        }
    }
}
