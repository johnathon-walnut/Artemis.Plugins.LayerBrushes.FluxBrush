using Artemis.Core.LayerBrushes;
using Artemis.UI.Shared.Services.PropertyInput;
using Artemis.Plugins.LayerBrushes.FluxBrush.LayerBrushes;

namespace Artemis.Plugins.LayerBrushes.FluxBrush;

public class FluxBrushLayerBrushProvider : LayerBrushProvider
{
    public override void Enable()
    {
        RegisterLayerBrushDescriptor<FluxBrushLayerBrush>("f.lux brush", "yeah", "Lightbulb");
    }

    public override void Disable()
    {
    }
}