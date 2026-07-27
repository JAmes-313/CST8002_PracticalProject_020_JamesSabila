namespace Project2.Services


///<summary>
///Author: James Sabila
///Subject: Prgramming Language Research - Practical Project 2
///Link: [1] Microsoft Learn (n.d.) ASP.NET MVC Controllers Overview (C#). learn.microsoft.com. [online] Available at: https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/aspnet-mvc-controllers-overview-cs [Accessed on June 21, 2026].
//////
///Dataset Source:Fisheries and Oceans Canada. (Nov 29, 2024). Spatiotemporal variation in anadromous Arctic char (Salvelinus alpinus) foraging ecology and its influence on muscle pigmentation along western Hudson Bay, Nunavut, Canada. open.canada.ca. [online] Available at https://open.canada.ca/data/en/dataset/9cbcf710-a2a1-11ef-8ccf-55cc7f028297 [last accessed April 30, 2026]
///Dataset file name: Prey collection & analysis - raw data.csv
///Contains information licensed under the Open Government Licence – Canada. https://open.canada.ca/en/open-government-licence-canada
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
