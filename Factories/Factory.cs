using DeKruik.Models;

namespace DeKruik.Factories
{
    public class Factory 
    {
        public Location CreateLocation(string name, float latitude, float longitude) => new Location(name, latitude, longitude);
        public Route CreateRoute(int id, Location from, Location to, float distance, int traveltime) => new Route(id,from, to, distance, traveltime);
        public Passenger CreatePassenger(string name, bool wheelchair) => new Passenger(name, wheelchair);
        public Vehicle CreateVehicle(int passengercapacity, int wheelchaircapacity) => new Vehicle(passengercapacity, wheelchaircapacity);
    }
}
