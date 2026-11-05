using AlcoCalc.Values;

namespace AlcoCalc.Services;

public class Calculator1B_1 : CalculatorBase<CalculatorValues1B_1>
{
    public const string CalculatorName = "1B-1";

    public static double DensityMin => 780;
    public static double DensityMax => 1000;

    public static double TemperatureOfMeasurementMin => 0; //-20 / 0
    public static double TemperatureOfMeasurementMax => 30; //40 / 30

    protected override void DoCalc(CalculatorValues1B_1 values)
    {
        values.Result = null;
        if (IsEmpty(values.Density)) return;
        if (IsEmpty(values.TemperatureOfMeasurement)) return;

        ValidateRange(values.Density, nameof(values.Density), "Density", DensityMin, DensityMax, CalculatorName);
        ValidateRange(values.TemperatureOfMeasurement, nameof(values.TemperatureOfMeasurement), "Temperature", TemperatureOfMeasurementMin, TemperatureOfMeasurementMax, CalculatorName);

        var correctedDensity = values.Density!.Value * (1 + (0.000025 * (20 - values.TemperatureOfMeasurement!.Value)));

        double min = 0;
        double max = 100;
        double mid = 50;
        int iterationCount = 0;

        var _1A_1Values = new CalculatorValues1A_1
        {
            AlcoholTemperature = values.TemperatureOfMeasurement
        };

        while ((max - min) > 0.0001 && iterationCount < 1000)
        {
            iterationCount++;
            mid = (min + max) / 2.0;
            _1A_1Values.EthanolMassFraction = mid;

            Calculator1A_1.DoCalcWithoutPreCheck(_1A_1Values);

            if (_1A_1Values.Result is null)
                throw new InvalidOperationException($"{CalculatorName}: cannot calculate further");

            // Hustota klesá s rastúcim množstvom etanolu
            if (_1A_1Values.Result.Value > correctedDensity)
                min = mid;
            else
                max = mid;
        }

        if (iterationCount >= 1000)
            throw new InvalidOperationException($"{CalculatorName}: iteration limit reached");

        // Prepočet zlomku na objemovú koncentráciu pri 20 °C
        _1A_1Values.EthanolMassFraction = mid;
        _1A_1Values.AlcoholTemperature = 20;
        Calculator1A_1.DoCalcWithoutPreCheck(_1A_1Values);

        if (_1A_1Values.Result is null)
            throw new InvalidOperationException($"{CalculatorName}: cannot calculate further");

        var volumeConcentration = mid * _1A_1Values.Result.Value / Constants.EthanolDensity;

        if (volumeConcentration < 0 || volumeConcentration > 100)
            throw new InvalidOperationException($"{CalculatorName}: result out of range");

        values.Result = volumeConcentration;
    }
}