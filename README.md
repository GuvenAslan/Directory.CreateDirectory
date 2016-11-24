# Directory.CreateDirectory
A simple Directory.CreateDirectory example

 static void Main(string[] args)
        {
            string folderPath = @"c:\testFolder";

            string subPath = System.IO.Path.Combine(folderPath, "subFolder");

            System.IO.Directory.CreateDirectory(subPath);

            string fileName = System.IO.Path.GetRandomFileName();

            subPath = System.IO.Path.Combine(subPath, fileName);

            if (!System.IO.File.Exists(subPath))
            {
                using (System.IO.FileStream fileStream = System.IO.File.Create(subPath))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fileStream.WriteByte(i);
                    }
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
            }
            Console.ReadKey();
        }
