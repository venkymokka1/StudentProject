using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace StudentProject
{
    public class Program
    {
        static void Main()
        {
            string sourcePath = "D:\\Venkat123\\sourcePath";
            string desPath = "D:\\Venkat123\\desPath";
            // Check the sourcePath exist
            if (!Directory.Exists(sourcePath))
                Directory.CreateDirectory(sourcePath);
            // Check the desPath exist
            if (!Directory.Exists(desPath))
                Directory.CreateDirectory(desPath);



            //string txt = "Hello Venky & Abid! in new branch";
            string fileName = "Test.txt";
            //// File Write
            //if (!File.Exists(sourcePath + "\\" + fileName))
            //    File.WriteAllText(sourcePath + "\\" + fileName, txt);
            // Getting files from sourcePath
            DirectoryInfo objDirInfo = new DirectoryInfo(sourcePath);
            FileInfo[] objInputFiles = objDirInfo.GetFiles();
            foreach (var item in objInputFiles)
            {
                fileName = item.Name;
                if (fileName.Contains(".zip"))
                {
                    //// File Copy
                    //if (!File.Exists(desPath + "\\" + fileName))
                    //    File.Copy(sourcePath + "\\" + fileName, desPath + "\\" + fileName);

                    // File Move
                    if (!File.Exists(desPath + "\\" + fileName))
                        File.Move(sourcePath + "\\" + fileName, desPath + "\\" + fileName);
                    ZipFile.ExtractToDirectory(desPath + "\\" + fileName, desPath, true);
                    DirectoryInfo oDirInfo = new DirectoryInfo(desPath);
                    FileInfo[] oFCol = new FileInfo[0];
                    oFCol = oDirInfo.GetFiles("*.pdf");
                    int totalFiles = oFCol.Count();
                    foreach (var item1 in oFCol)
                    {
                        File.WriteAllText(desPath + "\\" + item1.Name.Replace(".pdf", ".txt"), item1.Name);
                    }
                    //// File Read
                    //string readText = File.ReadAllText(desPath + "\\" + fileName);
                    //string[] readAllText = readText.Split(" "); // Thre is no comma in the above text, so we splited by single space only.

                    //Console.WriteLine(readText);
                }
            }
            Console.ReadLine();
        }
    }
}
