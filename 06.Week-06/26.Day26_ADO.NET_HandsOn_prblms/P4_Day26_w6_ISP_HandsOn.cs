using System;

namespace ISPExample
{
    // Interfaces
    interface IPrinter
    {
        void Print();
    }

    interface IScanner
    {
        void Scan();
    }

    interface IFax
    {
        void Fax();
    }

    // Basic Printer
    class BasicPrinter : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("Printing...");
        }
    }

    // Advanced Printer
    class AdvancedPrinter : IPrinter, IScanner, IFax
    {
        public void Print()
        {
            Console.WriteLine("Printing...");
        }

        public void Scan()
        {
            Console.WriteLine("Scanning...");
        }

        public void Fax()
        {
            Console.WriteLine("Faxing...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BasicPrinter basic = new BasicPrinter();
            basic.Print();

            AdvancedPrinter adv = new AdvancedPrinter();
            adv.Print();
            adv.Scan();
            adv.Fax();

            Console.ReadLine();
        }
    }
}