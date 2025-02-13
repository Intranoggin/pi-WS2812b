using System.Device.Spi;
using System.Drawing;
using Iot.Device.Ws28xx;

Console.WriteLine("VS - Hello, Color!");

SpiConnectionSettings settings = new(0, 0)
{
    ClockFrequency = 100000,
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

    for (int count = 0; count<25;count++)
    {
        var color = count % 2 == 0 ? Color.DarkSlateBlue : Color.DarkRed;
        Console.WriteLine("Count: " + count);
        Console.WriteLine("Color: " + color.Name);
        img.Clear(color);
        // for (var x = 0; x < width; x++)
        // {
        //     for (var y = 0; y < height; y++)
        //     {
        //         //Console.WriteLine("X: " + x + " Y: " + y);
        //         //var color = new Color();
        //         img.SetPixel(x, y, color);
        //     }

        // }
        Console.WriteLine("Update");
        ledStrip.Update();
        Console.WriteLine("Sleep");
        Thread.Sleep(1000);
        Console.WriteLine("Continue");
    }
}
