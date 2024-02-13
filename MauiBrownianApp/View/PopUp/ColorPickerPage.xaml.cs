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
    private async void Back_Tapped(object sender, TappedEventArgs e)
    {
        if (!_isBusy)
        {
            _isBusy = true;

            await Navigation.PopModalAsync();

            _isBusy = false;
        }
    }

    void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
    }
}
