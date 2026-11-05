namespace AlcoCalc.Services;

public static class On66Interpolator
{
    public static double Interpolate(double temperature, double alcoholometerReading)
    {
        var x1 = Math.Truncate(temperature);
        var x2 = x1 + 1;

        var y1 = Math.Truncate(alcoholometerReading * 10) / 10.0;
        var y2 = y1 + 0.1;

        var lx1 = (int)Math.Truncate(x1 + 2.00001);
        var lx2 = (int)Math.Truncate(x2 + 2.00001);

        var ly1 = (int)Math.Truncate(y1 * 10 + 1.00001);
        var ly2 = (int)Math.Truncate(y2 * 10 + 1.00001);

        var x1y1 = GetOn66(lx1, ly1);
        var x1y2 = GetOn66(lx1, ly2);
        var x2y1 = GetOn66(lx2, ly1);
        var x2y2 = GetOn66(lx2, ly2);

        // Ak je niektorá bunka mimo tabuľky
        if (x1y1 < 0 || x1y2 < 0 || x2y1 < 0 || x2y2 < 0)
        {
            // Predvolená hodnota mimo rozsahu
            var result = alcoholometerReading > 50 ? 100.0 : 0.0;

            // Teplota mimo tabuľky
            if (x2 > 30.00001 &&
                y2 < 100.00001 &&
                x1y1 >= 0 &&
                x1y2 >= 0)
            {
                result =
                    x1y2 -
                    ((x1y2 - x1y1) *
                     ((y2 - alcoholometerReading) / (y2 - y1)));
            }

            // Hustota/koncentrácia mimo tabuľky
            if (x2 < 30.00001 &&
                y2 > 100.00001 &&
                x1y1 >= 0 &&
                x2y1 >= 0)
            {
                result =
                    x2y1 -
                    ((x2y1 - x1y1) *
                     ((x2 - temperature) / (x2 - x1)));
            }

            // Teplota aj koncentrácia mimo tabuľky
            if (x2 > 30.00001 &&
                y2 > 100.00001 &&
                x1y1 >= 0)
            {
                result = x1y1;
            }

            return result;
        }

        // Bilineárna interpolácia
        return
            (((temperature - x1) * (alcoholometerReading - y1)) * x2y2
                / ((x2 - x1) * (y2 - y1)))
            +
            (((temperature - x1) * (alcoholometerReading - y2)) * x2y1
                / ((x2 - x1) * (y1 - y2)))
            +
            (((temperature - x2) * (alcoholometerReading - y1)) * x1y2
                / ((x1 - x2) * (y2 - y1)))
            +
            (((temperature - x2) * (alcoholometerReading - y2)) * x1y1
                / ((x1 - x2) * (y1 - y2)));
    }

    private static double GetOn66(int x, int y)
    {
        if (x < 1 || x > 32 || y < 1 || y > 1001)
            return -1;

        return Constants.On66[x - 1, y - 1];
    }
}