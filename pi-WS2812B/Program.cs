using System.Device.Gpio;
using System.Threading;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("VS - Hello, World!");

GpioController controller = new GpioController(PinNumberingScheme.Logical);

var pin = 5;
var lightTime = 300;

controller.OpenPin(pin, PinMode.Output);

try
{
    while (true)
    {
        Console.WriteLine("Light on");
        controller.Write(pin, PinValue.High);
        Thread.Sleep(lightTime);
        Console.WriteLine("Light off");
        controller.Write(pin, PinValue.Low);
        Thread.Sleep(lightTime);
    }
}
finally
{
    controller.ClosePin(pin);
}