


using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;

namespace MauiBrownianApp.View.ChartSK;

public class LineChart : SKCanvasView
{
    private SKCanvas _canvas;
    private SKRect _drawRect;
    private SKImageInfo _info;

    #region 
    public List<double> Data
    {
        get => (List<double>)GetValue(DataProperty);
        set => SetValue(DataProperty, value);
    }

    public static readonly BindableProperty DataProperty = BindableProperty.Create(
        nameof(Data), typeof(List<double>), typeof(LineChart), new List<double>(), propertyChanged: OnBindablePropertyChanged);

    #endregion

    private static void OnBindablePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((LineChart)bindable).InvalidateSurface();
    }

    protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
    {
        base.OnPaintSurface(e);

        _canvas = e.Surface.Canvas;
        _canvas.Clear(); // clears the canvas for every frame
        _info = e.Info;
        _drawRect = new SKRect(0, 0, _info.Width, _info.Height);
        Data = new List<double>() { 100, 101, 80, 120, 150 };


        float width = _info.Width;
        float height = _info.Height;

        using (SKPaint paint = new SKPaint())
        {
            paint.IsAntialias = true;
            paint.Color = SKColors.Black;

            // Desenhar eixos X e Y
            _canvas.DrawLine(0, height / 2, width, height / 2, paint);
            _canvas.DrawLine(width / 2, 0, width / 2, height, paint);

            // Desenhar os pontos do gráfico
            paint.Color = SKColors.Blue;
            paint.StrokeWidth = 2;
            paint.Style = SKPaintStyle.Stroke;

            SKPath path = new SKPath();
            path.MoveTo(0, (float)Data[0]);

            float scaleX = width / (Data.Count - 1);
            float scaleY = height / 2;

            for (int i = 1; i < Data.Count; i++)
            {
                float x = i * scaleX;
                float y = (float)Data[i] * scaleY + height / 2;
                path.LineTo(x, y);
            }

            _canvas.DrawPath(path, paint);
        }
    }

}