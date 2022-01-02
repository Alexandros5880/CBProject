using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using System;


namespace CBProject.HelperClasses
{
    public class VideoEditor
    {

        public void CreateThambnail(string input, string output)
        {
            var inputFile = new MediaFile { Filename = input };
            var outputFile = new MediaFile { Filename = output };

            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);

                // Saves the frame located on the 15th second of the video.
                var options = new ConversionOptions { Seek = TimeSpan.FromSeconds(15) };
                engine.GetThumbnail(inputFile, outputFile, options);
            }
        }

        public TimeSpan Duration(string path)
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