using System;
using System.IO;

namespace file
{
    class FileApp
    {
     static void testWriteAlltext()
        {
            string filename = "file.txt";
            string content = "Xin chao moi nguoi lai la thanhvu dzai day, rat vui duoc gap moi nguoi!" +DateTime.Now.ToString();

            var directory_mydoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            var fullpath = Path.Combine(directory_mydoc, filename);
           
            if(File.Exists(fullpath))
            {
                File.AppendAllText(fullpath, content);
            }else
            File.WriteAllText(fullpath, content);

            Console.WriteLine($"File save in {directory_mydoc}{Path.DirectorySeparatorChar}{filename}");


            Console.WriteLine(fullpath);
            string s = File.ReadAllText(fullpath);
            Console.WriteLine(s);
        }

        static void Main(string[] args)
        {
            testWriteAlltext();
        }
    }
}