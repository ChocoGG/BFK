using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace bfk
{
    class Parameter
    {
        //  Creates String Property for currentPath -> Used to cut off path in Output
        private string currPath { get; set; } = Directory.GetCurrentDirectory();
      
        //  Creates String Property for Directories -> Fill it with Directories @CurrentDirectory
        private string[] Directories = Directory.GetDirectories(@Directory.GetCurrentDirectory());

        //  Creates String Property for Files -> Fill it with Files @CurrentDirectory
        private string[] Files = Directory.GetFiles(@Directory.GetCurrentDirectory());      

        public void List()
        {

            //  Directories Output : 
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Directories : ");
            Console.BackgroundColor = ConsoleColor.Black;

            //  If Array is empty -> Error
            if (Directories.Length < 1)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("###No Directories in current Folder###\n");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            //  Else -> Output
            else
            {
                foreach (var dItem in Directories)
                {
                    Console.WriteLine("<DIR>" + dItem.Remove(0, currPath.Length));
                }
            }

            //  Files Output :
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Files : ");
            Console.BackgroundColor = ConsoleColor.Black;

            //  If Array is empty -> Error
            if (Files.Length < 1)
            {
                Console.WriteLine("No Files in current Directory.\n");
            }

            //  Else -> Ouput + cut off Path
            foreach (var fItem in Files)
            {
                Console.WriteLine(fItem.Remove(0, currPath.Length));
            }
        }

        public void Listtype(string secondPar)
        {
            //  Output + search for ending .secondPar
         string[] extDirectories = Directory.GetFiles(@Directory.GetCurrentDirectory(), "*." + secondPar);
            if (extDirectories.Length < 1)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No Files found with File extension : {0}", secondPar);
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Files found with the extension '{0}' :", secondPar);
                Console.BackgroundColor = ConsoleColor.Black;
                foreach (var extItem in extDirectories)
                {
                    Console.WriteLine(extItem.Remove(0, currPath.Length));
                }
            }

        }
        public void listname(string secondPar)
        {

            //  Output what the user entered + results afterwards
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Files starting with '{0}' found : ", secondPar);
            Console.BackgroundColor = ConsoleColor.Black;

            //  foreach item in Directories (Declared at top) ->
            foreach (var foundItem in Files)
            {
                //  If founditem without path starts with second Parameter 
                if (foundItem.Remove(0, currPath.Length + 1).StartsWith(secondPar))
                {
                    //  Output every File left:
                    Console.WriteLine(foundItem.Remove(0, currPath.Length));
                }
            }
        }
         public void backup(string secondPar)
        {
            //  Modifies String :
            string backupPath = Directory.GetCurrentDirectory() + "/";
     
            if (!Directory.Exists(secondPar))
            {
                //   Creates Directory at current Path + Second Parameter entered
                Directory.CreateDirectory(backupPath + secondPar);

                Console.WriteLine("Backup Folder sucessfully created.");
                //  Modifies String:
                Console.WriteLine(backupPath);
               
                foreach (string s in Files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    string fileName = System.IO.Path.GetFileName(s);
                    string destFile = System.IO.Path.Combine(backupPath + secondPar, fileName);
                    System.IO.File.Copy(s, destFile, true);
                }
                //  Success Message:
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Backup sucessfully!");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                //  If Directory already exists -> Error Message :
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Error, there is already a Directory named : '{0}'",secondPar);
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
        public void Join(string secondPar, string thirdPar, string destFileName)
        {
            //  Checks if file exists
            if (File.Exists(destFileName))
            {
                //  If already exits -> Asks what to do
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"Destination File called '{destFileName}' already exists.");
                Console.WriteLine("Do you wish to : \n (A)dd the Text to the existing one \n (O)verwrite it? \n or \n (E)nter a new Name?");
                //  Get choice :
                string choice = Console.ReadLine();
                //  If Choice = Overwrite
                if (choice == "O" || choice == "o")
                {
                    //  Delete File + Output
                    File.Delete(destFileName);
                    Console.WriteLine("File renewed.");
                }
                //  If choice = Enter new name:
                if (choice == "E" || choice == "e")
                {
                    //  Asks for new name + chances var
                    Console.WriteLine("Enter new destination File Name : ");
                    destFileName = Console.ReadLine();
                    Console.WriteLine("File name changed to {0}", destFileName);
                }
                Console.BackgroundColor = ConsoleColor.Black;
            }
            //  Actual joining together : 
            //  Combines source strings to Array for better useability
             string[] srcFileNames = { secondPar, thirdPar };
                
                //  Uses Stream -> Set to destinationFileName
                using (Stream destinationStream = File.OpenWrite(destFileName))
                {
                    //  for each File
                    foreach (string sourceFileName in srcFileNames)
                    {
                        //Copy Text to destination Stream (File)
                        using (Stream sourceStream = File.OpenRead(sourceFileName))
                        {
                            sourceStream.CopyTo(destinationStream);
                        }
                    }
                }
                //  Sucess Message
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Text sucessfully joined together | Saved in : {0}", destFileName);
            Console.BackgroundColor = ConsoleColor.Black;
        }    
}}

