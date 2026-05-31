using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///Author James Sabila
///Practical Project 1
///<summary>
///This is the File Helper to check for the file and extension
///</summary>
namespace Project1
{
    internal class FileHelper
    {
        //get current path of the directory
        string currentFolder = Directory.GetCurrentDirectory();

        //check if file extensinon match
        private string IsExtensionFileValid(string fileName)
        {
            if (!fileName.EndsWith(".csv"))
            {
                fileName = fileName + ".csv";
            }

            return fileName;
        }

        //method to check if file exist
        public bool FileExists(string fileName)
        {
            fileName = IsExtensionFileValid(fileName);

            string path = Path.Combine(currentFolder, fileName);

            return File.Exists(path);
        }
    }
}
