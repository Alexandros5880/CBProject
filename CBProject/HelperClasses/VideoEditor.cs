using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using System;
using System.IO;

namespace CBProject.HelperClasses
{
    public static class VideoEditor
    {
        public static void CreateThambnail(string input, string output, int second)
        {
            var inputFile = new MediaFile { Filename = input };
            var outputFile = new MediaFile { Filename = output };
            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);
                var options = new ConversionOptions { Seek = TimeSpan.FromSeconds(second) };
                engine.GetThumbnail(inputFile, outputFile, options);
            }
            var img = System.Drawing.Image.FromFile(output);
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        public static TimeSpan Duration(string path)
        {
            var inputFile = new MediaFile { Filename = path };
            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);
            }
            return inputFile.Metadata.Duration;
        }
    }
}