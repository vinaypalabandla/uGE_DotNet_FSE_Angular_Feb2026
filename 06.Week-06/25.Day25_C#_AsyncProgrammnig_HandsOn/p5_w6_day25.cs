using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {

        TextWriterTraceListener listener =
            new TextWriterTraceListener("trace_log.txt");

        Trace.Listeners.Add(listener);
        Trace.AutoFlush = true;

        Trace.WriteLine("Order Processing Started...");

        try
        {
            ValidateOrder();
            ProcessPayment();
            UpdateInventory();
            GenerateInvoice();

            Trace.TraceInformation("Order processed successfully!");
        }
        catch (Exception ex)
        {
            Trace.WriteLine("ERROR: " + ex.Message);
        }

        Trace.WriteLine("Order Processing Ended.");

        Console.WriteLine("Process completed. Check trace_log.txt file.");

        Trace.Close();
    }


    static void ValidateOrder()
    {
        Trace.WriteLine("Step 1: Validating Order...");
    }


    static void ProcessPayment()
    {
        Trace.WriteLine("Step 2: Processing Payment...");

        throw new Exception("Payment Failed!");
    }


    static void UpdateInventory()
    {
        Trace.WriteLine("Step 3: Updating Inventory...");
    }

    static void GenerateInvoice()
    {
        Trace.WriteLine("Step 4: Generating Invoice...");
    }
}