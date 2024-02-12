
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
            _vm.UpdateChart();
            _isBusy = false;
        }
    }

    void Entry_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.NewTextValue))
        {
            // Verifica se o texto inserido contém apenas números
            foreach (char c in e.NewTextValue)
            {
                if (!char.IsDigit(c))
                {
                    // Se um caractere não for um dígito, limpa o texto inserido
                    ((Entry)sender).Text = e.OldTextValue ?? string.Empty;
                    break;
                }
            }
        }
    }
}