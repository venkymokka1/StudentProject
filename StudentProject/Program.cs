using System;
using System.IO;

namespace StudentProject
{
    public class Program
    {
        static void Main()
        {
            string sourcePath = "C:\\Venkat\\sourcePath";
            string desPath = "C:\\Venkat\\desPath";
            // Check the sourcePath exist
            if (!Directory.Exists(sourcePath))
                Directory.CreateDirectory(sourcePath);
            // Check the desPath exist
            if (!Directory.Exists(desPath))
                Directory.CreateDirectory(desPath);

            string txt = "Hello Venky & Abid! in new branch";
            string fileName = "Test.txt";
            // File Write
            if (!File.Exists(sourcePath + "\\" + fileName))
                File.WriteAllText(sourcePath + "\\" + fileName, txt);
            // Getting files from sourcePath
            DirectoryInfo objDirInfo = new DirectoryInfo(sourcePath);
            FileInfo[] objInputFiles = objDirInfo.GetFiles();
            foreach (var item in objInputFiles)
            {
                fileName = item.Name;

                // File Copy
                if (!File.Exists(desPath + "\\" + fileName))
                    File.Copy(sourcePath + "\\" + fileName, desPath + "\\" + fileName);

                // File Move
                if (!File.Exists(desPath + "\\" + fileName))
                    File.Move(sourcePath + "\\" + fileName, desPath + "\\" + fileName);
                // File Read
                string readText = File.ReadAllText(desPath + "\\" + fileName);
                string[] readAllText = readText.Split(" "); // Thre is no comma in the above text, so we splited by single space only.

                Console.WriteLine(readText);
            }
            Console.ReadLine();
        }
    }
}
