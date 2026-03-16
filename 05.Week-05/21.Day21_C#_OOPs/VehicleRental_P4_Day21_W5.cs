
class Vehicle
{
    public string Brand { get; set; }
    public double RentalPerDay { get; set; }

    public virtual double CalculateRental(int days)
    {
        return RentalPerDay * days;
    }
}

class Car : Vehicle
{
    public override double CalculateRental(int days)
    {
        if (days <= 0)
        {
            Console.WriteLine("Invalid rental days");
            return 0;
        }

        double total = RentalPerDay * days;
        return total + 500;
    }
}

class Bike : Vehicle
{
    public override double CalculateRental(int days)
    {
        if (days <= 0)
        {
            Console.WriteLine("Invalid rental days");
            return 0;
        }

        double total = RentalPerDay * days;
        double discount = total * 0.05;
        return total - discount;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Vehicle car = new Car();
        car.Brand = "Car";
        car.RentalPerDay = 2000;

        int days = 3;

        Console.WriteLine("Total Rental = " + car.CalculateRental(days));
    }
}