using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO; // need to use input and output functions 
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
        
               // Console.WriteLine("Please enter the date you need (Please use yyyymmdd Format):");
               // int dateSelect = Convert.ToInt32(Console.ReadLine());
               // string rundate = dateSelect;
               // String rootSource=Directory.GetCurrentDirectory();
                string sourceDire1 = @"C:\Users\yahon\source\repos\ConsoleAppCombinedLetters\CombinedLetters\Input\Admission\20220125";
                string sourceDire2 = @"C:\Users\yahon\source\repos\ConsoleAppCombinedLetters\CombinedLetters\Input\Scholarship\20220125";
                string archiveDirectory = @"C:\Users\yahon\source\repos\ConsoleAppCombinedLetters\CombinedLetters\Archive";
                string destinationDire = @"C:\Users\yahon\source\repos\ConsoleAppCombinedLetters\CombinedLetters\Output";
                int numCombinedLetters = 0;
                Queue<string> qForStID = new Queue<string>();
            try
                {
                    var inputFiles1 = Directory.EnumerateFiles(sourceDire1, "*.txt");
                    var inputFiles2 = Directory.EnumerateFiles(sourceDire2, "*.txt");
                //var outputFile = Directory.EnumerateFiles(archiveDirectory, "*.txt");

                foreach (string admissionLetter in inputFiles1)
                {
                    string adfileName = admissionLetter.Substring(sourceDire1.Length + 1);


                    foreach (string scholarLetter in inputFiles2)
                    {

                        string scfileName = scholarLetter.Substring(sourceDire2.Length + 1);

                        int result = String.Compare(adfileName, 10, scfileName, 12, 8);
                        string stID = adfileName.Substring(10, 8);

                        if (result == 0)
                        {
                            numCombinedLetters++;
                            qForStID.Enqueue(stID);
                            using (var output = File.Create(Path.Combine(destinationDire, stID + ".txt")))
                            {
                                using (var cont1 = File.OpenRead(admissionLetter))
                                {
                                    cont1.CopyTo(output);
                                }
                                //File.AppendAllText(Path.Combine(destinationDire, stID + ".txt"), "\n");
                                //string alineToInsert = "";
                                //alineToInsert.CopyTo(output);

                                // type cast 
                                //output.WriteByte((byte)'\n');



                                using (var cont2 = File.OpenRead(scholarLetter))
                                {
                                    cont2.CopyTo(output);
                                }


                            }

                            Console.WriteLine(adfileName + "   " + scfileName);

                        }
                    }


                    //readline must be outside of the {}
                    //Console.ReadLine();
                }
                //using (var reportContent = File.Create(Path.Combine(destinationDire, "Report.txt")))

                //StreamWriter report = new StreamWriter(reportContent);
                if (qForStID.Count() != 0)
                {
                    StreamWriter report = new StreamWriter(Path.Combine(destinationDire, "Report.txt"), append: true);
                    report.WriteLine("01/25/2022 Report: ");

                    report.WriteLine("_____________");
                    report.WriteLine("Number of Combined Letters: " + numCombinedLetters);
                    while (qForStID.Count() != 0)
                    {
                        report.WriteLine(qForStID.Dequeue());
                    }

                    //Must have a 
                    report.Close();
                }

                //move files from admission folder to archieve folder

                foreach (var file in new DirectoryInfo(sourceDire1).GetFiles())
                {
                    file.MoveTo($@"{archiveDirectory}\{file.Name}");
                }

                //move files from scholarship folder to archieve folder

                foreach (var file in new DirectoryInfo(sourceDire2).GetFiles())
                {
                    file.MoveTo($@"{archiveDirectory}\{file.Name}");
                }

                //  Directory.Move(sourceDire1, Path.Combine(archiveDirectory, inputFiles1));
                // Directory.Move(sourceDire2, Path.Combine(archiveDirectory, inputFiles2));


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
