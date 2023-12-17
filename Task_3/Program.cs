using System;


interface IScreen { }
interface IProcessor { }
interface ICamera { }


class AMOLED : IScreen { }
class LCD : IScreen { }

class Snapdragon : IProcessor { }
class MediaTek : IProcessor { }

class DualCamera : ICamera { }
class SingleCamera : ICamera { }


interface IDeviceFactory
{
    IScreen CreateScreen();
    IProcessor CreateProcessor();
    ICamera CreateCamera();
}


class SmartphoneFactory : IDeviceFactory
{
    public IScreen CreateScreen()
    {
        return new AMOLED();
    }

    public IProcessor CreateProcessor()
    {
        return new Snapdragon();
    }

    public ICamera CreateCamera()
    {
        return new DualCamera();
    }
}

class TabletFactory : IDeviceFactory
{
    public IScreen CreateScreen()
    {
        return new LCD();
    }

    public IProcessor CreateProcessor()
    {
        return new MediaTek();
    }

    public ICamera CreateCamera()
    {
        return new SingleCamera();
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Select the type of product to create:");
        Console.WriteLine("1. Smartphone");
        Console.WriteLine("2. Tablet");

        string choice = Console.ReadLine();

        IDeviceFactory factory;

        if (choice == "1")
        {
            factory = new SmartphoneFactory();
        }
        else if (choice == "2")
        {
            factory = new TabletFactory();
        }
        else
        {
            Console.WriteLine("Invalid choice. Exiting...");
            return;
        }

        
        IScreen screen = factory.CreateScreen();
        IProcessor processor = factory.CreateProcessor();
        ICamera camera = factory.CreateCamera();

        Console.WriteLine("Product created:");
        Console.WriteLine("Screen: " + screen.GetType().Name);
        Console.WriteLine("Processor: " + processor.GetType().Name);
        Console.WriteLine("Camera: " + camera.GetType().Name);

        Console.ReadLine();
    }
}