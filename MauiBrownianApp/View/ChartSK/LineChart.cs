


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
        _canvas.Clear();
        _info = e.Info;
        _drawRect = new SKRect(0, 0, _info.Width, _info.Height);

        if (Data.Count == 0)
            return;

        float width = _info.Width;
        float height = _info.Height;

        using (SKPaint paint = new SKPaint())
        {

            // Encontrar os valores mínimo e máximo na lista de dados
            double minValue = Data.Min();
            double maxValue = Data.Max();

            // Calcular a escala vertical com base nos valores mínimo e máximo
            float scaleY = (float)(height / (maxValue - minValue));

            // Calcular o deslocamento vertical para garantir que o menor valor fique na borda inferior
            float yOffset = (float)(-minValue * scaleY);

            paint.Color = SKColors.Blue;
            paint.StrokeWidth = 2;
            paint.Style = SKPaintStyle.Stroke;

            float scaleX = width / (Data.Count - 1);
            float pointWidth = 5; // Largura ajustável dos pontos

            for (int i = 0; i < Data.Count; i++)
            {
                float x = i * scaleX;
                float y = (float)Data[i] * scaleY + yOffset;

                // Desenhar cada ponto no gráfico
                _canvas.DrawCircle(x, y, pointWidth / 2, paint);

                // Conectar os pontos com linhas
                if (i > 0)
                {
                    float prevX = (i - 1) * scaleX;
                    float prevY = (float)Data[i - 1] * scaleY + yOffset;

                    _canvas.DrawLine(prevX, prevY, x, y, paint);
                }
            }
        }



    }

}