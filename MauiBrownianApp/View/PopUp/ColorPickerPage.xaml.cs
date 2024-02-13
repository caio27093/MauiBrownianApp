using MauiBrownianApp.ViewModel;

namespace MauiBrownianApp.View.PopUp;

public partial class ColorPickerPage : ContentPage
{
    ColorPickerViewModel _vm;
    bool _isBusy;
    public ColorPickerPage()
	{
		InitializeComponent();
        _vm = new ();
        this.BindingContext = _vm;
    }
    public event EventHandler<string> SelectedColor;

    private async void Back_Tapped(object sender, TappedEventArgs e)
    {
        if (!_isBusy)
        {
            _isBusy = true;

            await Navigation.PopModalAsync();

            _isBusy = false;
        }
    }

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        if (!_isBusy)
        {
            _isBusy = true;

            SelectedColor?.Invoke(this, _vm.HexColor);
            await Navigation.PopModalAsync();

            _isBusy = false;
        }
    }
}
