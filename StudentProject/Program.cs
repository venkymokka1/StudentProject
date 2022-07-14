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
            string sourcePath = "D:\\Venkat\\Hvrad\\Premier\\From Premier To Gebbs";
            string desPath = "D:\\Venkat\\Hvrad\\Premier\\POSITION-BY_Rpt\\FTP";
            string test = "Hello Venky & Abid! in new branch";
            // text write
            File.WriteAllText(sourcePath + "\\Test.txt", test);
            // text Read
            string readText = File.ReadAllText(sourcePath + "\\Test.txt");
            Console.WriteLine("txt file Read & Write");
        }
    }
}
