using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace client
{
    class Compression
    {
        public static string Compress(string filePath, string destPath, string fileName)
        {
            byte[] raw = File.ReadAllBytes(filePath);
            byte[] zipped = null;
            using (MemoryStream memory = new MemoryStream())
            {
                using (GZipStream gzip = new GZipStream(memory,
                    CompressionMode.Compress, true))
                {
                    gzip.Write(raw, 0, raw.Length);
                }
                zipped = memory.ToArray();
            }
            // Write compressed data.
            string directory = Path.Combine(destPath, Path.GetFileNameWithoutExtension(fileName) + ".gz");
            File.WriteAllBytes(directory, zipped);
            File.Delete(filePath);
            return directory;
        }
        public static string Decompress(string filePath, string destPath, string fileName)
        {
            byte[] gzip = File.ReadAllBytes(filePath);
            byte[] unzip = null;
            // Create a GZIP stream with decompression mode.
            // ... Then create a buffer and write into while reading from the GZIP stream.
            using (GZipStream stream = new GZipStream(new MemoryStream(gzip),
                CompressionMode.Decompress))
            {
                const int size = 4096;
                byte[] buffer = new byte[size];
                using (MemoryStream memory = new MemoryStream())
                {
                    int count = 0;
                    do
                    {
                        count = stream.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            memory.Write(buffer, 0, count);
                        }
                    }
                    while (count > 0);
                    unzip = memory.ToArray();
                }
            }
            string directory = Path.Combine(destPath, fileName);
            File.WriteAllBytes(directory, unzip);
            File.Delete(filePath);
            return directory;

        }
    }
}
