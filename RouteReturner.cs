using DeKruik.Models;

namespace DeKruik
{
    public class RouteReturner
    {
        public float NearestNeighbor(List<Location> locations)
        {
            float optimalRouteDistance = 0;
            Location startinglocation = locations[0], currentLocation = locations[0];
            List<Location> visited = new List<Location>() { startinglocation };

            while (visited.Count < locations.Count)
            {
                Route nearest = currentLocation.Routes.OrderBy(r => r.Distance).Where(r => r.Distance != 0 && !visited.Contains(r.To)).First();

                optimalRouteDistance += nearest.Distance;
                visited.Add(nearest.To);
                currentLocation = nearest.To;
            }

            Route returnRoute = currentLocation.Routes.Where(r => r.To == startinglocation).First();

            optimalRouteDistance += returnRoute.Distance;

            return optimalRouteDistance;
        }

        public float BruteForce(List<Location> locations)
        {
            float optimalRouteDistance = float.MaxValue;
            Location startingLocation = locations[0];

            List<Location> otherLocations = locations.Skip(1).ToList();
            IEnumerable<List<Location>> permutations = GetPermutations(otherLocations, otherLocations.Count);

            foreach (var perm in permutations)
            {
                float totalDistance = 0f;
                Location current = startingLocation;

                foreach (var next in perm)
                {
                    Route route = current.Routes.First(r => r.To == next);
                    if (route == null)
                    {
                        totalDistance = float.MaxValue;
                        break;
                    }
                    totalDistance += route.Distance;
                    current = next;
                }

                Route returnRoute = current.Routes.First(r => r.To == startingLocation);

                if (returnRoute != null)
                    totalDistance += returnRoute.Distance;

                if (totalDistance < optimalRouteDistance)
                    optimalRouteDistance = totalDistance;
            }

            return optimalRouteDistance;
        }

        public static IEnumerable<List<T>> GetPermutations<T>(List<T> list, int length)
        {
            if (length == 1)
                return list.Select(t => new List<T> { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                            (t1, t2) => t1.Append(t2).ToList());
        }
    }
}
