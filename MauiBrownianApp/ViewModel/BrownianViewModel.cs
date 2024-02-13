
using System.Collections.ObjectModel;

namespace MauiBrownianApp.ViewModel;

public class BrownianViewModel : BaseViewModel
{
    public List<double> _data = new List<double>();
    public List<double> DataPoints
    {
        get => _data;
        set => SetProperty(ref _data, value);
    }

    public double _sigma;
    public double Sigma
    {
        get => _sigma;
        set => SetProperty(ref _sigma, value);
    }

    public double _mean;
    public double Mean
    {
        get => _mean;
        set => SetProperty(ref _mean, value);
    }

    public double _initialPrice;
    public double InitialPrice
    {
        get => _initialPrice;
        set => SetProperty(ref _initialPrice, value);
    }

    public int _numDays;
    public int NumDays
    {
        get => _numDays;
        set => SetProperty(ref _numDays, value);
    }

    private double[] GenerateBrownianMotion()
	{
        Random rand = new ();
		double[] prices = new double[NumDays];
		prices[0] = InitialPrice;

		for (int i = 1; i < NumDays; i++)
        {
            double u1 = 1.0 - rand.NextDouble();
            double u2 = 1.0 - rand.NextDouble();
			double z = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);

			double retornoDiario = Mean + Sigma * z;

			prices[i] = prices[i - 1] * Math.Exp(retornoDiario);
        }
        return prices;
	}

    internal void UpdateChart()
    {
        DataPoints = GenerateBrownianMotion().ToList();
    }

    internal string ValidaCampos()
    {
        //unico campo que se estiver vazio quebra o método que foi dado
        if (NumDays == 0)
            return "O tempo deve ser superior a zero dias";

        return "";
    }
}