using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AlcoCalc.Values;

public abstract class CalculatorValuesBase : INotifyPropertyChanged
{
    private double? _result;
    public double? Result { get => _result; set => SetProperty(ref _result, value); }

    public virtual void Reset()
    {
        _result = null;
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
