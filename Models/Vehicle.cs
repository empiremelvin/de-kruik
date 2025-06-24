namespace DeKruik.Models
{
    public class Vehicle
    {
        public int PassengerCapacity { get; set; }
        public int WheelchairCapacity { get; set; }

        public Vehicle(int passengercapacity, int wheelchaircapacity)
        {
            PassengerCapacity = passengercapacity;
            WheelchairCapacity = wheelchaircapacity;
        }
    }
}
