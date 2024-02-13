using MauiBrownianApp.Model;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;

namespace MauiBrownianApp.View.ChartSK;

public class LineChart : SKCanvasView
{
    private SKCanvas _canvas;
    private SKImageInfo _info;

    #region 
    public List<BrownianModel> Data
    {
        get => (List<BrownianModel>)GetValue(DataProperty);
        set => SetValue(DataProperty, value);
    }

    public static readonly BindableProperty DataProperty = BindableProperty.Create(
        nameof(Data), typeof(List<BrownianModel>), typeof(LineChart), new List<BrownianModel>(), propertyChanged: OnBindablePropertyChanged);

    #endregion

    private static void OnBindablePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((LineChart)bindable).InvalidateSurface();
    }

    protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
    {
        base.OnPaintSurface(e);

        _canvas = e.Surface.Canvas;
        _canvas.Clear();
        _info = e.Info;

        if (!Data.Any())
            return;

        SKPaint paint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Black,
            StrokeWidth = 2
        };

        int width = e.Info.Width;
        int height = e.Info.Height;

        // Definindo as margens
        float marginLeft = 50;
        float marginTop = 50;
        float marginBottom = 50;
        float marginRight = 50;

        // Definindo a escala
        double maxHeight = GetMaxHeight();

        foreach (var item in Data)
        {
            var colorFromData = SKColor.TryParse(item.ColorHex, out SKColor newcolor);
            SKPaint paintLine = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = colorFromData ? newcolor : SKColors.Black,
                StrokeWidth = 2
            };


            double yScale = (height - marginTop - marginBottom) / maxHeight;
            double xScale = (width - marginLeft - marginRight) / (item.DataValue.Count - 1);

            // Desenhando os eixos x e y
            _canvas.DrawLine(marginLeft, marginTop, marginLeft, height - marginBottom, paint);
            _canvas.DrawLine(marginLeft, height - marginBottom, width - marginRight, height - marginBottom, paint);

            // Desenhando os pontos no gráfico
            for (int i = 0; i < item.DataValue.Count; i++)
            {
                float x = (float)(marginLeft + i * xScale);
                float y = (float)(height - marginBottom - item.DataValue[i] * yScale);
                _canvas.DrawCircle(x, y, 5, paintLine);

                if (i > 0)
                {
                    float prevX = (float)(marginLeft + (i - 1) * xScale);
                    float prevY = (float)(height - marginBottom - item.DataValue[i - 1] * yScale);
                    _canvas.DrawLine(prevX, prevY, x, y, paintLine);
                }
            }
        }

    }

    private double GetMaxHeight()
    {
        double max = double.MinValue;
        foreach (var item in Data)
        {
            foreach (double altura in item.DataValue)
            {
                if (altura > max)
                    max = altura;
            }
        }
        return max;
    }
}