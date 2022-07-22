using StudentProject.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using UglyToad.PdfPig;

namespace StudentProject
{
    public class Program
    {
        static void Main()
        {
            List<Employee> lst = new List<Employee>();
            string sourcePath = "D:\\Venkat123\\sourcePath";
            string desPath = "D:\\Venkat123\\desPath";
            string archivePath = "D:\\Venkat123\\archivePath";
            // Check the sourcePath exist
            if (!Directory.Exists(sourcePath))
                Directory.CreateDirectory(sourcePath);
            // Check the desPath exist
            if (!Directory.Exists(desPath))
                Directory.CreateDirectory(desPath);
            // Check the archivePath exist
            if (!Directory.Exists(archivePath))
                Directory.CreateDirectory(archivePath);
            string fileName = null;
            // Normal text to Write into txt file
            //string txt = "Hello Venky & Abid! in new branch";
            //if (!File.Exists(sourcePath + "\\" + fileName))
            //    File.WriteAllText(sourcePath + "\\" + fileName, txt);
            // Getting files from sourcePath
            DirectoryInfo objDirInfo = new DirectoryInfo(sourcePath);
            FileInfo[] objInputFiles = objDirInfo.GetFiles();
            foreach (var item in objInputFiles)
            {
                fileName = item.Name;
                //if (fileName.Contains(".zip"))
                //{
                //// File Copy
                //if (!File.Exists(desPath + "\\" + fileName))
                //    File.Copy(sourcePath + "\\" + fileName, desPath + "\\" + fileName);

                // File Move
                if (!File.Exists(desPath + "\\" + fileName))
                    File.Move(sourcePath + "\\" + fileName, desPath + "\\" + fileName);
                // Zip extract
                if (fileName.Contains(".zip"))
                    ZipFile.ExtractToDirectory(desPath + "\\" + fileName, desPath, true);
                // Get Files from path
                DirectoryInfo oDirInfo = new DirectoryInfo(desPath);
                FileInfo[] oFCol = new FileInfo[0];
                if (fileName.Contains(".zip"))
                    oFCol = oDirInfo.GetFiles("*.pdf");
                else
                    oFCol = oDirInfo.GetFiles();
                int totalFiles = oFCol.Count();
                string txt = null;
                foreach (var item1 in oFCol)
                {
                    Employee mdl = new Employee();
                    if (item1.Name.Contains(".pdf"))
                    {
                        txt = ExtractTextFromPdf(item1.FullName);
                        if (fileName.Contains(".zip"))
                            File.WriteAllText(item1.FullName.Replace(".pdf", ".txt"), txt);
                    }
                    else if (item1.Name.Contains(".txt"))
                    {
                        txt = File.ReadAllText(desPath + "\\" + fileName);
                    }
                    else if (item1.Name.Contains(".doc"))
                    {
                        txt = File.ReadAllText(desPath + "\\" + fileName);
                    }
                    else if (item1.Name.Contains(".csv"))
                    {
                        txt = File.ReadAllText(desPath + "\\" + fileName);
                    }
                    string[] res = txt.Split(" ");
                    mdl.FirstName = res[99];
                    mdl.LastName = res[100];
                    mdl.Code = Convert.ToInt32(res[182]);
                    mdl.Gender = res[135];
                    mdl.Age = Convert.ToInt32(res[136]);
                    mdl.PolicyNo = res[49];
                    mdl.ValidUp = res[204];
                    mdl.Insurence = res[7] + res[8] + res[9];
                    // File Move from dest path to archive Path
                    if (!File.Exists(archivePath + "\\" + fileName))
                        File.Move(desPath + "\\" + fileName, archivePath + "\\" + fileName);
                    lst.Add(mdl);
                }
                //// File Read
                //string readText = File.ReadAllText(desPath + "\\" + fileName);
                //string[] readAllText = readText.Split(" "); 
                // Thre is no comma in the above text, so we splited by single space only.

                //Console.WriteLine(readText);
                //}
            }
            Console.ReadLine();
        }

        public static string ExtractTextFromPdf(string path)
        {
            using (var stream = File.OpenRead(path))
            using (PdfDocument document = PdfDocument.Open(stream))
            {
                StringBuilder text = new StringBuilder();
                for (int i = 1; i <= document.NumberOfPages; i++)
                {
                    var page = document.GetPage(i);
                    text.Append(string.Join(" ", page.GetWords()));
                }
                return text.ToString();
            }
        }
    }
}
