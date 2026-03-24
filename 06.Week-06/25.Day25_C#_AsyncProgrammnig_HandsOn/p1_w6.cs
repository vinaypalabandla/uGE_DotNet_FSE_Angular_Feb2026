//using System;
//using System.Threading.Tasks;

//class Program
//{
//    //async method
//    public static async Task WriteLogAsync(string message)
//    {
//        Console.WriteLine("Writing log: " + message);

//        // file delay 2 sec
//        await Task.Delay(2000);

//        Console.WriteLine("Log written: " + message);
//    }

//    static async Task Main(string[] args)
//    {
//        Console.WriteLine("Application Started...\n");


//        Task t1 = WriteLogAsync("User logged in");
//        Task t2 = WriteLogAsync("Data loaded");
//        Task t3 = WriteLogAsync("File uploaded");

//        Console.WriteLine("\nMain thread is free to do other work...\n");

//        // Wait for all tasks to complete
//        await Task.WhenAll(t1, t2, t3);

//        Console.WriteLine("\nAll logs completed!");
//    }
//}