using System;
using System.Threading.Tasks;

class Program
{
   static async Task Main(string[] args)
   {
       Console.WriteLine("Order Processing Started...");

       await ProcessOrderAsync();

       Console.WriteLine("Order Processing Completed");
   }

   static async Task ProcessOrderAsync()
   {
       await VerifyPaymentAsync();
       await CheckInventoryAsync();
       await ConfirmOrderAsync();
   }

   static async Task VerifyPaymentAsync()
   {
       Console.WriteLine("Verifying Payment...");
       await Task.Delay(2000);
       Console.WriteLine("Payment Verified \n");
   }


   static async Task CheckInventoryAsync()
   {
       Console.WriteLine("Checking Inventory...");
       Console.WriteLine("Inventory Available \n");
   }


   static async Task ConfirmOrderAsync()
   {
       Console.WriteLine("Confirming Order...");
       await Task.Delay(1000);
       Console.WriteLine("Order Confirmed \n");
   }
}
