using System;
using System.IO;

namespace StudentProject
{
    public class Program
    {
        static void Main()
        {

            Console.WriteLine("Hello Abid! in new branch");

            Console.WriteLine("Hello Venky & Abid! in new branch");
            Console.WriteLine("Hello Abid & Venky! in new branch");
            string sourcePath = "D:\\Venkat\\Test";
            string test = "Hello Venky & Abid! in new branch";
            // text write
            File.WriteAllText(sourcePath + ".txt", test);
            // text Read
            string readText = File.ReadAllText(sourcePath + ".txt");
        }
    }
}
