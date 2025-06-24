using ClosedXML.Excel;
using DeKruik.Factories;
using DeKruik.Models;

namespace DeKruik
{
    public class Parser
    {
        private List<Location> locations { get; set; } = new List<Location>();
        private List<Route> routes { get; set; } = new List<Route>();

        public List<Location> getLocations() => locations;
        public List<Route> getRoutes() => routes;

        public Parser() { }

        public void Parse(string filePath)
        {
            locations.Clear();

            try
            {
                var factory = new Factory();

                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1);
                    int xOffset = 3;
                    int yOffset = 3;

                    //locations
                    for (int i = 0 + yOffset; i < 10 + yOffset; i++)
                    {
                        var name = worksheet.Cell($"B{i}").Value;
                        var latitude = worksheet.Cell($"C{i}").Value;
                        var longitude = worksheet.Cell($"D{i}").Value;

                        Location location = factory.CreateLocation((string)name, (float)latitude, (float)longitude);

                        locations.Add(location);
                    }

                    //Passenger https://www.youtube.com/watch?v=RBumgq5yVrA
                    int passengerYOffset = 13;

                    for (int i = 0; i < 10; i++)
                    {
                        string name = (string)worksheet.Cell($"B{i + passengerYOffset + yOffset}").Value;
                        bool wheelchair = (string)worksheet.Cell($"C{i + passengerYOffset + yOffset}").Value == "Ja";

                        factory.CreatePassenger(name, wheelchair);
                    }


                    //routes
                    xOffset = 7;
                    int traveltimeYOffset = 14;
                            int id = 0;

                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            float traveldistance = (float)worksheet.Cell(i + yOffset, j + xOffset).Value;
                            int traveltime = (int)worksheet.Cell(i + yOffset + traveltimeYOffset, j + xOffset).Value;
                            Route route = factory.CreateRoute(id, locations[i], locations[j], traveldistance, traveltime);
                            locations[i].Routes.Add(route);
                            routes.Add(route);
                            id++;
                        }
                    }

                    //Vehicles
                    int vehicleYOffset = 26;

                    for (int i = 0; i < 3; i++)
                    {
                        int passengercapacity = (int)worksheet.Cell($"C{i + vehicleYOffset + yOffset}").Value;
                        int wheelchaircapacity = (int)worksheet.Cell($"D{i + vehicleYOffset + yOffset}").Value;

                        factory.CreateVehicle(passengercapacity, wheelchaircapacity);
                    }

                    workbook.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading the Excel file: " + ex.Message);
            }
        }
    }
}
