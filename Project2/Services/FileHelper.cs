namespace Project2.Services

///<summary>
///Author: James Sabila
///Subject: Prgramming Language Research - Practical Project 2
///Link: [1] Microsoft Learn (n.d.) ASP.NET MVC Controllers Overview (C#). learn.microsoft.com. [online] Available at: https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/aspnet-mvc-controllers-overview-cs [Accessed on June 21, 2026].
///</summary>
{
    /// <summary>
    /// a class for the file helper related
    /// </summary>
    public class FileHelper
    {
        string currentFolder = Directory.GetCurrentDirectory();

        /// <summary>
        /// a method to check if ectension is valid
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsExtensionFileValid(string fileName)
        {
            if (fileName.EndsWith(".csv"))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// a method to check if file path exist
        /// </summary>
        /// <param name="_env"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static String GetFilePath(IWebHostEnvironment _env, String fileName)
        {
            return Path.Combine(_env.WebRootPath, "data", fileName);
        }
    }
}
