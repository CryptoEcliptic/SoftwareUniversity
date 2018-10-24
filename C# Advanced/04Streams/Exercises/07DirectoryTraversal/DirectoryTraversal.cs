using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07DirectoryTraversal
{
    class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            Dictionary<string, List<FileInfo>> filesCollection = new Dictionary<string, List<FileInfo>>();
            string[] files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                string extension = fileInfo.Extension;

                if (!filesCollection.ContainsKey(extension))
                {
                    List<FileInfo> temp = new List<FileInfo>();
                    temp.Add(fileInfo);
                    filesCollection.Add(extension, temp);
                }
                else
                {
                    filesCollection[extension].Add(fileInfo);
                }
            }
            filesCollection = filesCollection
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullFileName = desktop + @"\report.txt";

            using (StreamWriter writer = new StreamWriter(fullFileName))
            {
                foreach (var file in filesCollection)
                {
                    string extension = file.Key;
                    writer.WriteLine(extension);

                    foreach (var info in file.Value.OrderByDescending(x => x.Length))
                    {
                        double fileSize = (double)info.Length / 1024;

                        writer.WriteLine($"--{info.Name} - {fileSize:f3} kb");
                    }
                }
            }
        }
    }
}
