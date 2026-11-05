using AlcoCalc.Values;

namespace AlcoCalc.Services;

public class Calculator2_4 : CalculatorBase<CalculatorValues2_4>
{
    public const string CalculatorName = "2-4";

    public static double VolumeOfEthanolMin => 0;
    public static double VolumeOfEthanolMax => double.MaxValue;

    public static double MeterReadingDifferenceMin => 0;
    public static double MeterReadingDifferenceMax => double.MaxValue;

    public static double NotRecordedVolumeMin => 0;
    public static double NotRecordedVolumeMax => double.MaxValue;

    public static double ThermalExpansionCorrectionFactorMin => 0;
    public static double ThermalExpansionCorrectionFactorMax => 2;

    public static double AlcoholMeterCorrectionFactorMin => 0;
    public static double AlcoholMeterCorrectionFactorMax => 2;

    public static double KvCoefficientMin => 0;
    public static double KvCoefficientMax => double.MaxValue;

    protected override void DoCalc(CalculatorValues2_4 values)
    {
        values.Result = null;
        if (IsEmpty(values.VolumeOfEthanol)) return;
        if (IsEmpty(values.MeterReadingDifference)) return;
        if (IsEmpty(values.NotRecordedVolume)) return;
        if (IsEmpty(values.ThermalExpansionCorrectionFactor)) return;
        if (IsEmpty(values.AlcoholMeterCorrectionFactor)) return;
        if (IsEmpty(values.KvCoefficient)) return;

        ValidateRange(values.VolumeOfEthanol, nameof(values.VolumeOfEthanol), "Volume of ethanol", VolumeOfEthanolMin, VolumeOfEthanolMax, CalculatorName);
        ValidateRange(values.MeterReadingDifference, nameof(values.MeterReadingDifference), "Meter reading difference", MeterReadingDifferenceMin, MeterReadingDifferenceMax, CalculatorName);
        ValidateRange(values.NotRecordedVolume, nameof(values.NotRecordedVolume), "Not recorded volume", NotRecordedVolumeMin, NotRecordedVolumeMax, CalculatorName);
        ValidateRange(values.ThermalExpansionCorrectionFactor, nameof(values.ThermalExpansionCorrectionFactor), "Thermal expansion correction factor", ThermalExpansionCorrectionFactorMin, ThermalExpansionCorrectionFactorMax, CalculatorName);
        ValidateRange(values.AlcoholMeterCorrectionFactor, nameof(values.AlcoholMeterCorrectionFactor), "Alcohol meter correction factor", AlcoholMeterCorrectionFactorMin, AlcoholMeterCorrectionFactorMax, CalculatorName);
        ValidateRange(values.KvCoefficient, nameof(values.KvCoefficient), "Kv coefficient", KvCoefficientMin, KvCoefficientMax, CalculatorName);

        values.Result = values.KvCoefficient!.Value * ((values.VolumeOfEthanol!.Value + values.MeterReadingDifference!.Value) * values.ThermalExpansionCorrectionFactor!.Value * values.AlcoholMeterCorrectionFactor!.Value + values.NotRecordedVolume!.Value);
    }


}