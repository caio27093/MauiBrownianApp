
using MauiBrownianApp.ViewModel;

namespace MauiBrownianApp;

public partial class MainPage : ContentPage
{
	bool _isBusy;
    BrownianViewModel _vm;
	public MainPage()
	{
        InitializeComponent();
        _vm = new BrownianViewModel();
        this.BindingContext = _vm;
    }

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		if (!_isBusy)
        {
            _isBusy = true;

            var resultValidacao = _vm.ValidaCampos();

            if (string.IsNullOrEmpty(resultValidacao))
                _vm.UpdateChart();
            else
                await DisplayAlert("Alerta", resultValidacao, "OK");

            _isBusy = false;
        }
    }

}