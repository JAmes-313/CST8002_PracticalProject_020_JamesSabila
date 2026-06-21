namespace Project2.Services
{
    public class FileHelper
    {
        string currentFolder = Directory.GetCurrentDirectory();

        public static bool IsExtensionFileValid(string fileName)
        {
            if (fileName.EndsWith(".csv"))
            {
                return true;
            }

            return false;
        }

        public static String GetFilePath(IWebHostEnvironment _env, String fileName)
        {
            return Path.Combine(_env.WebRootPath, "data", fileName);
        }

        //method to check if file exist
        //public static bool FileExists(string fileName)
        //{
        //    if (!IsExtensionFileValid(fileName))
        //    {
        //        return false;
        //    }

        //    string path = Path.Combine(currentFolder, fileName);

        //    return File.Exists(path);
        //}
    }
}
