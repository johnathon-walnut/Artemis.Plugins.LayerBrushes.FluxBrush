# Artemis.Plugins.LayerBrushes.FluxBrush

Set server in f.lux:
1. Right click f.lux in system tray
2. Click "Options and Smart Lighting..."
3. Go to the "Connected Lighting" tab
4. In the text box for "Post to this URL when f.lux changes settings" enter:
   `http://localhost:4077/flux`
5. Also ensure that "Poll once a minute" is checked
6. Press Done

It can take up to a minute for the plugin to start working as it relies on f.lux sending a request to localhost:4077/flux with the current temperature.

Gradient goes from 0 to 10000, though it shows as decimal in Artemis so 1.0 = 10000K, 0.5 = 5000K, etc.

Brush is called f.lux brush and has a lightbulb icon. Suggest you use multiply blending to make it act like a color filter.