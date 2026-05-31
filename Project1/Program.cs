using Project1;

///Author James Sabila
///Practical Project 1
///<summary>
///This is the main program of the console app
///</summary>
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Author: James Sabila");
        Console.WriteLine("Practical Project 1\n\n");

        //instantiate CSVHelper
        CSVHelper helper = new CSVHelper();

        //call displayData on CSVHelper
        helper.displayData();
        Console.ReadKey();

    }
}