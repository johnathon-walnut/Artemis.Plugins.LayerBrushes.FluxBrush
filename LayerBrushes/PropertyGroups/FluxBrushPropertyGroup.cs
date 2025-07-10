using Artemis.Core;
using SkiaSharp;

namespace Artemis.Plugins.LayerBrushes.FluxBrush.PropertyGroups;

public class FluxBrushPropertyGroup : LayerPropertyGroup
{
    [PropertyDescription(Name = "Kelvin Gradient", Description = "Scales from 0 to 10000")]
    public ColorGradientLayerProperty KelvinGradient { get; set; } = null!;

    protected override void PopulateDefaults()
    {
        KelvinGradient.DefaultValue = new ColorGradient
        {
            new ColorGradientStop(SKColors.Red, 0.1f),
            new ColorGradientStop(SKColors.Orange, 0.4f),
            new ColorGradientStop(SKColors.White, 0.65f),
        };
    }

    protected override void EnableProperties()
    {
    }

    protected override void DisableProperties()
    {
    }
}