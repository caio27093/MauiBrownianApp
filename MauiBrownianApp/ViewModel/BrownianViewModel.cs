﻿
using System.Collections.ObjectModel;
using MauiBrownianApp.Model;

namespace MauiBrownianApp.ViewModel;

public class BrownianViewModel : BaseViewModel
{
    private BrownianModel _data = new BrownianModel();
    public BrownianModel DataPoints
    {
        get => _data;
        set => SetProperty(ref _data, value);
    }

    private double _sigma;
    public double Sigma
    {
        get => _sigma;
        set => SetProperty(ref _sigma, value);
    }

    private double _mean;
    public double Mean
    {
        get => _mean;
        set => SetProperty(ref _mean, value);
    }

    private double _initialPrice;
    public double InitialPrice
    {
        get => _initialPrice;
        set => SetProperty(ref _initialPrice, value);
    }

    private int _numDays;
    public int NumDays
    {
        get => _numDays;
        set => SetProperty(ref _numDays, value);
    }

    private string _hexColor = "#000000";
    public string HexColor
    {
        get => _hexColor;
        set => SetProperty(ref _hexColor, value);
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
        DataPoints.DataValue = GenerateBrownianMotion().ToList();
    }

    internal string ValidaCampos()
    {
        //unico campo que se estiver vazio quebra o método que foi dado
        if (NumDays == 0)
            return "O tempo deve ser superior a zero dias";

        return "";
    }

    internal void SetColor(string obj)
    {
        HexColor = obj;
        DataPoints.ColorHex = obj;
    }
}