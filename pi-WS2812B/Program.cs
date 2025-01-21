using System.Device.Spi;
using System.Drawing;
using Iot.Device.Ws28xx;

Console.WriteLine("VS - Hello, Color!");

SpiConnectionSettings settings = new(0, 0)
{
    ClockFrequency = 2_400_000,
    Mode = SpiMode.Mode0,
    DataBitLength = 8    
};
var height = 8;
var width = 32;
var ledCount = height * width;
//var r = 0;
//var g = 0;
//var b = 0;

using (SpiDevice spi = SpiDevice.Create(settings))
{
    var ledStrip = new Ws2812b(spi, width, height);

    RawPixelContainer img = ledStrip.Image;
    
    Console.WriteLine("Width: " + img.Width);
    Console.WriteLine("Height: " + img.Height);

    for (int count = 0; count<500;count++)
    {
        var color = count % 2 == 0 ? Color.RebeccaPurple : Color.Aqua;
        Console.WriteLine("Count: " + count);
        Console.WriteLine("Color: " + color.Name);
        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                //var color = new Color();
                img.SetPixel(x, y, Color.RebeccaPurple);

            }

            ledStrip.Update();
        }
        Thread.Sleep(1000);
    }
}
