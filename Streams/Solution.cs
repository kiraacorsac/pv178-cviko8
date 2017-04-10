using System.IO;
using System.IO.Compression;
using Streams.SampleData;

namespace Streams
{
    public static class Solution
    {
        public static void Tasks()
        {
            /* TODO
                Pomocí třídy GZipStream zkomprimujte soubor text1.txt do 
                archivu text.gz, následně proveďte jeho dekomprimaci. 
             */

            var fileToCompress = new FileInfo(Paths.Text1);
            var compressedFilePath = fileToCompress.FullName.Remove(fileToCompress.FullName.LastIndexOf('.')) + ".gz";

            using (var originalFileStream = fileToCompress.OpenRead())
            {           
                using (var compressedFileStream = File.Create(compressedFilePath))
                {
                    using (var compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                    {
                        originalFileStream.CopyTo(compressionStream);
                    }
                }               
            }

            var fileToDecompress = new FileInfo(compressedFilePath);
            using (var originalFileStream = fileToDecompress.OpenRead())
            {
                using (var decompressedFileStream = File.Create(Paths.Text1))
                {
                    using (var decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                    }
                }
            }
        }
    }
}
