using System;

public interface IVehicle
{
    string Brand { get; set; }
    string Model { get; set; }
}

public interface ITransport : IVehicle
{
    void Move();
    void FuelUp();
}

public abstract class Transport : ITransport
{
    public string Brand { get; set; }
    public string Model { get; set; }

    public abstract void Move();
    public abstract void FuelUp();
}

public class Car : Transport
{
    public override void Move()
    {
        Console.WriteLine($"The car {Brand} {Model} is driving on the road.");
    }

    public override void FuelUp()
    {
        Console.WriteLine($"The car {Brand} {Model} is being refueled with gasoline.");
    }
}

public class Motorcycle : Transport
{
    public override void Move()
    {
        Console.WriteLine($"The motorcycle {Brand} {Model} is speeding down the highway.");
    }

    public override void FuelUp()
    {
        Console.WriteLine($"The motorcycle {Brand} {Model} is being refueled with gasoline.");
    }
}

public class Plane : Transport
{
    public override void Move()
    {
        Console.WriteLine($"The plane {Brand} {Model} is flying in the sky.");
    }

    public override void FuelUp()
    {
        Console.WriteLine($"The plane {Brand} {Model} is being refueled with aviation fuel.");
    }
}

public class Bike : Transport
{
    public override void Move()
    {
        Console.WriteLine($"The bike {Brand} {Model} is being pedaled on the road.");
    }

    public override void FuelUp()
    {
        Console.WriteLine($"The bike {Brand} {Model} does not require fuel, just check the tires.");
    }
}

public abstract class TransportFactory
{
    public abstract Transport CreateTransport();
}

public class CarFactory : TransportFactory
{
    public override Transport CreateTransport()
    {
        return new Car { Brand = "Toyota", Model = "Corolla" };
    }
}

public class MotorcycleFactory : TransportFactory
{
    public override Transport CreateTransport()
    {
        return new Motorcycle { Brand = "Yamaha", Model = "MT-07" };
    }
}

public class PlaneFactory : TransportFactory
{
    public override Transport CreateTransport()
    {
        return new Plane { Brand = "Boeing", Model = "747" };
    }
}

public class BikeFactory : TransportFactory
{
    public override Transport CreateTransport()
    {
        return new Bike { Brand = "Giant", Model = "Defy" };
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the type of transport (car, motorcycle, plane, bike):");
        string transportType = Console.ReadLine()?.ToLower();

        TransportFactory factory = null;

        switch (transportType)
        {
            case "car":
                factory = new CarFactory();
                break;
            case "motorcycle":
                factory = new MotorcycleFactory();
                break;
            case "plane":
                factory = new PlaneFactory();
                break;
            case "bike":
                factory = new BikeFactory();
                break;
            default:
                Console.WriteLine("Invalid transport type.");
                return;
        }

        Transport transport = factory.CreateTransport();
        transport.Move();
        transport.FuelUp();
    }
}
