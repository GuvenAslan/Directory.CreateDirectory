using System;

namespace Directory.CreateDirectory
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            CreateDirectory();
            Console.ReadKey();
        }
        public static bool CreateDirectory()
        {
            string folderPath = @"c:\testFolder";

            if (!System.IO.Directory.Exists(folderPath))
                System.IO.Directory.CreateDirectory(folderPath);

            string subPath = System.IO.Path.Combine(folderPath, "subFolder");

            if (!System.IO.Directory.Exists(subPath))
                System.IO.Directory.CreateDirectory(subPath);


            string fileName = System.IO.Path.GetRandomFileName();

            subPath = System.IO.Path.Combine(subPath, fileName);

            if (!System.IO.File.Exists(subPath))
                using (System.IO.FileStream fileStream = System.IO.File.Create(subPath))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fileStream.WriteByte(i);
                    }
                }

            try
            {
                byte[] readBuffer = System.IO.File.ReadAllBytes(subPath);
                foreach (byte _byte in readBuffer)
                {
                    Console.WriteLine(_byte);
                }
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }
    }
}