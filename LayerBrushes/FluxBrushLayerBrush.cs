using Artemis.Core.LayerBrushes;
using Artemis.Plugins.LayerBrushes.FluxBrush.PropertyGroups;
using SkiaSharp;
using System;
using System.IO;
using System.Net;

namespace Artemis.Plugins.LayerBrushes.FluxBrush.LayerBrushes;

public class FluxBrushLayerBrush : LayerBrush<FluxBrushPropertyGroup>
{
    public override void EnableLayerBrush()
    {
        FluxServer.Instance.Start();
    }

    public override void DisableLayerBrush()
    {
        FluxServer.Instance.Stop();
    }

    public override void Update(double deltaTime)
    {

    }

    public override void Render(SKCanvas canvas, SKRect bounds, SKPaint paint)
    {
        float t = FluxServer.Instance.GetKelvin() / 10000f;

        paint.Color = Properties.KelvinGradient.CurrentValue.GetColor(t);

        canvas.DrawRect(bounds, paint);
    }
}