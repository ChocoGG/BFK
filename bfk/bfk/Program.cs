using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace bfk
{
    class Program
    {
        static void Main(string[] args)
        {

            //  If no Parameter entered :
            Parameter classParameter = new Parameter();
            if (args.Length < 1)
            {
                //  Throw Error :
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Error");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("Enter Parameters : ");
                Console.WriteLine(" -list \n -listtype \n -listname \n -backup \n -xml \n -join \n -attrib \n");
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Session terminated.");
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ReadKey();
            }
            else
            {
                switch (args[0])
                {
                    /// List Case
                    case "list":
                        classParameter.List();
                        break;

                    ///    Listtype Case
                    case "listtype":
                        //  If second Parameter (args[1] entered ->
                        try
                        {
                            classParameter.Listtype(args[1]);
                        }
                        //  Else -> Execute List()
                        catch
                        {
                            classParameter.List();
                        }
                        break;

                    ///  Listname Case
                    case "listname":
                        //  If second Parameter (args[1] entered ->
                        try
                        {
                            classParameter.listname(args[1]);
                        }
                        //  Else -> Execute List()
                        catch
                        {
                            classParameter.List();
                        }
                        break;

                    ///  backup Case
                    case "backup":
                        try
                        {
                            classParameter.backup(args[1]);
                        }
                        catch
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Error! Please enter a name for the Backup");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        break;

                    case "join":
                        try
                        {
                            classParameter.Join(args[1], args[2], args[3]);
                        }
                        catch
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Error! Please enter the Name of the two Files you want to join together + new Filename as shown below :");
                            Console.WriteLine("bfk.exe join file1.txt file2.txt myNewFile");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        break;

                }
                Console.ReadKey();
            }

        }
    }
}