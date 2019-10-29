using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Configuration
{
    public class FileConfig
    {
        private string filePath;

        public FileConfig(string newFilePath)
        {
            this.filePath = newFilePath;
        }

        public List<string> ReadConfig()
        {
            string[] readFileLines = File.ReadAllLines(filePath);

            List<string> res = new List<string>();

            foreach (string filePathComponent in readFileLines)
            {
                if (filePathComponent.Split("=").Length != 2)
                    throw new ArgumentException("must have two args");

                res.Add(filePathComponent);
            }

            return res;
        }

#pragma warning disable CA1822 // Mark members as static
        public void WriteConfig(string name, string? value)
#pragma warning restore CA1822 // Mark members as static
        {
            if (name != null || value != null || !value.Contains(" ") || !value.Contains("=") || !name.Contains(" ") || !name.Contains("="))
            {
                using (StreamWriter streamWriter = new StreamWriter(filePath, true))
                {
                    streamWriter.WriteLine($"{name}={value}");
                }
            }

            else Console.WriteLine("error in writing path contents");
        }


    }
}