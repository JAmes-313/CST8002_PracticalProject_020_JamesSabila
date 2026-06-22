namespace Project2.Services

///<summary>
///Author: James Sabila
///Subject: Prgramming Language Research - Practical Project 2
///Link: [1] Microsoft Learn (n.d.) ASP.NET MVC Controllers Overview (C#). learn.microsoft.com. [online] Available at: https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/aspnet-mvc-controllers-overview-cs [Accessed on June 21, 2026].
///</summary>
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
    }
}
