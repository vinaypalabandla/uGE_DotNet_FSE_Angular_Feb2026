using System;

namespace OCPExample
{
    // 1. Interface
    interface IDiscountStrategy
    {
        double CalculateDiscount(double amount);
    }

    // 2. Regular Customer
    class RegularCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.10;
        }
    }

    // Premium Customer
    class PremiumCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.20;
        }
    }

    // VIP Customer
    class VipCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.30;
        }
    }

    // 3. Final Price Calculator
    class DiscountCalculator
    {
        public double GetFinalPrice(double amount, IDiscountStrategy discountStrategy)
        {
            double discount = discountStrategy.CalculateDiscount(amount);
            return amount - discount;
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            DiscountCalculator calculator = new DiscountCalculator();

            double amount = 1000;

            IDiscountStrategy regular = new RegularCustomerDiscount();
            IDiscountStrategy premium = new PremiumCustomerDiscount();
            IDiscountStrategy vip = new VipCustomerDiscount();

            Console.WriteLine("Regular Final Price: " + calculator.GetFinalPrice(amount, regular));
            Console.WriteLine("Premium Final Price: " + calculator.GetFinalPrice(amount, premium));
            Console.WriteLine("VIP Final Price: " + calculator.GetFinalPrice(amount, vip));

            Console.ReadLine();
        }
    }
}