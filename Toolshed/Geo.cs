namespace Toolshed;

public static class Geo
{
    /// <summary>
    /// Earth's radius in kilometers.
    /// </summary>
    public const double RADIUS_EARTH_KM = 6371.0;

    /// <summary>
    /// Earth's radius in miles.
    /// </summary>
    public const double RADIUS_EARTH_MI = 3958.8;

    /// <summary>
    /// Returns the distance between two coordinates in the specified unit.
    /// </summary>
    /// <param name="lat1"></param>
    /// <param name="lon1"></param>
    /// <param name="lat2"></param>
    /// <param name="lon2"></param>
    /// <param name="unit"></param>
    /// <returns></returns>
    public static double DistanceBetweenCoordinates(double lat1, double lon1, double lat2, double lon2, string unit = "M")
    {


        // Convert degrees to radians
        double dLat = ToRadians(lat2 - lat1);
        double dLon = ToRadians(lon2 - lon1);

        // Apply Haversine formula
        double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                   Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                   Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        // Return distance in the specified unit
        return unit == "M" ? RADIUS_EARTH_MI * c : RADIUS_EARTH_KM * c;
    }        
    private static double ToRadians(double degrees)
    {
        return degrees * (Math.PI / 180);
    }
}
