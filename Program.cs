using DeKruik;

string filePath = "casus.xlsx";

Parser parser = new Parser();
parser.Parse(filePath);

Console.WriteLine("Calculating route...");
float optimalBFRoute = new RouteReturner().BruteForce(parser.getLocations());
float optimalNNRoute = new RouteReturner().NearestNeighbor(parser.getLocations());


Console.WriteLine("Brute force:");
Console.WriteLine(optimalBFRoute);
Console.WriteLine("Nearest Neighbor:");
Console.WriteLine(optimalNNRoute);

Console.ReadLine();