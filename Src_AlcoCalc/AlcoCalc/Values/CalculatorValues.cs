using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AlcoCalc.Values;

public class CalculatorValues : INotifyPropertyChanged
{
    private CalculatorValues1A_1 __1A_1 = new();
    public CalculatorValues1A_1 _1A_1 { get => __1A_1; set => SetProperty(ref __1A_1, value); }

    private CalculatorValues1A_2 __1A_2 = new();
    public CalculatorValues1A_2 _1A_2 { get => __1A_2; set => SetProperty(ref __1A_2, value); }

    private CalculatorValues1A_3 __1A_3 = new();
    public CalculatorValues1A_3 _1A_3 { get => __1A_3; set => SetProperty(ref __1A_3, value); }

    private CalculatorValues1A_4 __1A_4 = new();
    public CalculatorValues1A_4 _1A_4 { get => __1A_4; set => SetProperty(ref __1A_4, value); }

    private CalculatorValues1A_5 __1A_5 = new();
    public CalculatorValues1A_5 _1A_5 { get => __1A_5; set => SetProperty(ref __1A_5, value); }

    private CalculatorValues1A_6 __1A_6 = new();
    public CalculatorValues1A_6 _1A_6 { get => __1A_6; set => SetProperty(ref __1A_6, value); }

    private CalculatorValues1A_7 __1A_7 = new();
    public CalculatorValues1A_7 _1A_7 { get => __1A_7; set => SetProperty(ref __1A_7, value); }

    private CalculatorValues1A_8 __1A_8 = new();
    public CalculatorValues1A_8 _1A_8 { get => __1A_8; set => SetProperty(ref __1A_8, value); }


    private CalculatorValues1B_1 __1B_1 = new();
    public CalculatorValues1B_1 _1B_1 { get => __1B_1; set => SetProperty(ref __1B_1, value); }

    private CalculatorValues1B_2 __1B_2 = new();
    public CalculatorValues1B_2 _1B_2 { get => __1B_2; set => SetProperty(ref __1B_2, value); }


    private CalculatorValues2_1 __2_1 = new();
    public CalculatorValues2_1 _2_1 { get => __2_1; set => SetProperty(ref __2_1, value); }

    private CalculatorValues2_2 __2_2 = new();
    public CalculatorValues2_2 _2_2 { get => __2_2; set => SetProperty(ref __2_2, value); }

    private CalculatorValues2_3 __2_3 = new();
    public CalculatorValues2_3 _2_3 { get => __2_3; set => SetProperty(ref __2_3, value); }

    private CalculatorValues2_4 __2_4 = new();
    public CalculatorValues2_4 _2_4 { get => __2_4; set => SetProperty(ref __2_4, value); }

    public void Reset()
    {
        __1A_1.Reset();
        __1A_2.Reset();
        __1A_3.Reset();
        __1A_4.Reset();
        __1A_5.Reset();
        __1A_6.Reset();
        __1A_7.Reset();
        __1A_8.Reset();

        __1B_1.Reset();
        __1B_2.Reset();

        __2_1.Reset();
        __2_2.Reset();
        __2_4.Reset();
    }

    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
    #endregion
}
