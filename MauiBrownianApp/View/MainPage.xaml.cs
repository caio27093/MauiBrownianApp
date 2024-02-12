
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

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		if (!_isBusy)
        {
            _isBusy = true;
            _vm.GenerateBrownianMotion(initialPrice:100, numDays:252, sigma: 20, mean: 1);
            ctLine.InvalidateSurface();
            _isBusy = false;
        }
    }
}