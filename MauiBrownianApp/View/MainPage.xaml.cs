
using MauiBrownianApp.View.PopUp;
using MauiBrownianApp.ViewModel;

namespace MauiBrownianApp;

public partial class MainPage : ContentPage
{
	bool _isBusy;
    BrownianViewModel _vm;
	public MainPage()
	{
        InitializeComponent();
        _vm = new();
        this.BindingContext = _vm;
    }

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		if (!_isBusy)
        {
            _isBusy = true;

            var resultValidacao = _vm.ValidaCampos();

            if (string.IsNullOrEmpty(resultValidacao))
            {
                _vm.UpdateChart();
                ctLine.InvalidateSurface();
            }
            else
                await DisplayAlert("Alerta", resultValidacao, "OK");

            _isBusy = false;
        }
    }

    async void SelectColor(System.Object sender, System.EventArgs e)
    {
        if (!_isBusy)
        {
            _isBusy = true;

            var popUp = new ColorPickerPage();
            popUp.SelectedColor += (cl, obj) =>
            {
                _vm.SetColor(obj);
            };
            await Navigation.PushModalAsync( popUp);

            _isBusy = false;
        }
    }

    void Button_Clicked_1(System.Object sender, System.EventArgs e)
    {
        if (!_isBusy)
        {
            _isBusy = true;

            _vm.ClearChart();
            ctLine.InvalidateSurface();

            _isBusy = false;
        }
    }
}