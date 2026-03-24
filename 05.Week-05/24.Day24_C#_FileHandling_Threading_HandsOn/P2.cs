using System;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter foler path");
            string path = Console.ReadLine();

            if(!Directory.Exists(path))
            {
                Console.WriteLine("Invalid folder path");
                return;
            }
            string[] files = Directory.GetFiles(path);
            int count = 0;
            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);

                Console.WriteLine("\nFile Name: " + info.Name);
                Console.WriteLine("File Size: " + info.Length + " bytes");
                Console.WriteLine("created date" + info.CreationTime);
                count++;

            }
            }
            catch 
             {
            Console.WriteLine("Error while accessing folder");

            }
        } 
}
