using System;

namespace directory
{
    class Program
    {
        static void Nomal()
        {
            var directory_mydoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string[] files = Directory.GetFiles(directory_mydoc);
            string[] directories = Directory.GetDirectories(directory_mydoc);

            foreach (string file in files)
            {
                Console.WriteLine(file);
            }

            foreach (var directory in directories)
            {
                Console.WriteLine(directory);
            }
        }

        static void ListFileDirectory(string path)
        {
            string[] directories = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }

            foreach(var directory in directories)
            {
                Console.WriteLine(directory);
                ListFileDirectory(directory);
            }
        }

        static void Main(string[] args)
        {
            var directory_mydoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ListFileDirectory(directory_mydoc);
        }
    }
}