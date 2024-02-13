namespace MauiBrownianApp.ViewModel;

public class ColorPickerViewModel : BaseViewModel
{

    private int _red;
    public int Red
    {
        get { return _red; }
        set
        {
            if (_red != value)
            {
                _red = value;
                OnPropertyChanged(nameof(Red));
                OnPropertyChanged(nameof(HexColor));
            }
        }
    }

    private int _green;
    public int Green
    {
        get { return _green; }
        set
        {
            if (_green != value)
            {
                _green = value;
                OnPropertyChanged(nameof(Green));
                OnPropertyChanged(nameof(HexColor));
            }
        }
    }

    private int _blue;
    public int Blue
    {
        get { return _blue; }
        set
        {
            if (_blue != value)
            {
                _blue = value;
                OnPropertyChanged(nameof(Blue));
                OnPropertyChanged(nameof(HexColor));
            }
        }
    }

    public string HexColor
    {
        get { return $"#{Red:X2}{Green:X2}{Blue:X2}"; }
    }
}