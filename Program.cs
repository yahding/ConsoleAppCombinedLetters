using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleAppCombinedLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // string rootDire = @"C:\Users\yahon\OneDrive\Desktop\CombinedLetters";

            //this code can open all the folders in the CombinedLetters
            //get files from folders and subfolders
            // string[] dirs = Directory.GetDirectories(rootFolderPath,"*",SearchOption.AllDirectories);

            //foreach (string dir in dirs)
            //  var files = Directory.GetFiles(rootFolderPath, "*.*", SearchOption.AllDirectories);
            //  foreach (var file in files)

            //just get the files name only ,with extension just dont use the "withoutExtension"
            // Console.WriteLine(Path.GetFileNameWithoutExtension(file));
        
               // Console.WriteLine("Please enter the date you want:");
               // Console.ReadLine(int.)

               // string rundate = ("0220125");
               // String rootSource=Directory.GetCurrentDirectory();
                string sourceDire1 = @"C:\Users\yahon\source\repos\ConsoleAppCombinedLetters\CombinedLetters\Input\Admission\20220125";
                string sourceDire2 = @"C:\Users\yahon\source\repos\ConsoleAppCombinedLetters\CombinedLetters\Input\Scholarship\20220125";
                string archiveDirectory = @"C:\Users\yahon\source\repos\ConsoleAppCombinedLetters\CombinedLetters\Input\Archive";
                // string destinationDire = @"C:\Users\yahon\OneDrive\Desktop\CombinedLetters\Output";

                try
                {
                    var inputFiles1 = Directory.EnumerateFiles(sourceDire1, "*.txt");
                    var inputFiles2 = Directory.EnumerateFiles(sourceDire2, "*.txt");
                    
                    foreach (string admissionLetter in inputFiles1) 
                    {
                        string adfileName = admissionLetter.Substring(sourceDire1.Length + 1);
                        

                        foreach (string scholarLetter in inputFiles2)
                        {

                            string scfileName = scholarLetter.Substring(sourceDire2.Length + 1);
                        //Directory.Move(scholarLetter, Path.Combine(archiveDirectory, scfileName));
                        int result = String.Compare(adfileName, 10, scfileName, 12, 8);  
                       
                        
                        //if (result == 0)
                         
                           Console.WriteLine(adfileName + "   " + scfileName);
                        }
                        //readline must be outside of the {}
                            Console.ReadLine();

                    // Directory.Move(admissionLetter, Path.Combine(archiveDirectory, adfileName));
                }

                // tried to see if the admission files could move, then wrote to move the scholarship files,but found out the files couldn't move
                // then cpoied the codes from the previous code
                //  foreach (string scholarLetter in inputFiles2)
                //      {
                //          string scfileName = scholarLetter.Substring(sourceDire2.Length + 1);
                //            Directory.Move(scholarLetter, Path.Combine(archiveDirectory, scfileName));
                //      }


            }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
              }
         



            Console.ReadLine();
               // string fileToMove = rootFolderPath + file;
               // string moveTo = destinationPath + file;
                //moving file
               // File.Move(fileToMove, moveTo);
        }
        

    }
}
