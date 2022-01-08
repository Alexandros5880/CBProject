using System.IO;

namespace CBProject.HelperClasses
{
    public static class File
    {
        public static void DeleteFile(string path)
        {
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
        }

        public static void CreateFile(string path)
        {
            FileInfo file = new FileInfo(path);
            if (!file.Exists)
            {
                FileStream fs = file.Create();
                fs.Close();
            }
        }
    }
}