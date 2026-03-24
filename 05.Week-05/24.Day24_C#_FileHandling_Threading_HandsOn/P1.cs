using System;
using System.IO;

class Program
{
    static void Main()
    {
        string path = "log.txt";

        try
        {
            Console.Write("Enter message: ");
            string msg = Console.ReadLine();

            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);

            byte[] data = System.Text.Encoding.UTF8.GetBytes(msg + "\n");

            fs.Write(data, 0, data.Length);
            fs.Close();

            Console.WriteLine("Message saved successfully!");
        }
        catch
        {
            Console.WriteLine("Error while writing file");
        }
    }
}