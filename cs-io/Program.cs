using System;
using System.IO;
using System.Linq;


namespace cs_io
{
    class Program
    {
        static void Main(string[] args)
        {
            //StreamWriterToOutputFileOnly();
            //StreamWriterSetInFirstThenOutput();
            //ReadInputSpecificLocation();
            //ReadInputSpecificLocation_CombinedCurrentDir();
            //string textReaderText = "debugInput.txt";
            string textReaderText = @"C:\Users\GMunion\Documents\Visual Studio 2017\Projects\cs-algorithms\cs-io\rootInput.txt";
            //InternetExample(textReaderText);

            //InternetExample_ReadAllLines(textReaderText); //works
            //InternetExample_ReadLines(textReaderText);    
            //InternetExample();    //works

            string csvRootPath = @"C:\Users\GMunion\Documents\Visual Studio 2017\Projects\cs-algorithms\cs-io\rootInput.csv";
            ParseCsvWithLinq(csvRootPath);

            string csvRootPath2 = @"C:\Users\GMunion\Documents\Visual Studio 2017\Projects\cs-algorithms\cs-io\rootInput2.csv";
            ParseCsvWithLinq2(csvRootPath);

            Console.ReadKey();

        }

        static void StreamWriterToOutputFileOnly ()
        {
            //see path location:  cs-algorithms\cs-io\bin\Debug\netcoreapp2.0\output.txt
            TextWriter tw = new StreamWriter("output.txt");
            tw.Write("test");
            tw.Flush();
            tw.Close();
        }

        static void StreamWriterSetInFirstThenOutput()
        {
            //System.IO.FileNotFoundException: 'Could not find file 'C:\Users\GMunion\Documents\Visual Studio 2017\Projects\cs-algorithms\cs-io\bin\Debug\netcoreapp2.0\input.txt'.'
            //so i manually added to the project the file located that deep.
            Console.SetIn(new StreamReader("input.txt", true));
            TextWriter tw = new StreamWriter("output.txt");
            tw.Write("test");
            tw.Flush();
            tw.Close();
        }

        static void ReadInputSpecificLocation()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            Console.WriteLine(Environment.CurrentDirectory);
            string path = System.IO.Path.Combine(Environment.CurrentDirectory,
                                     @"..\..\..\rootInput.xml");
            Console.WriteLine(path);
            TextReader tr = new StreamReader(path);

            string line;
            while ( (line = tr.ReadLine()) != null )
            {
                string input = tr.ReadLine();
                Console.WriteLine(input);
            }

            tr.Close();
        }

        static void ReadInputSpecificLocation_CombinedCurrentDir()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            Console.WriteLine(Environment.CurrentDirectory);
            string filename = "debugInput.txt";
            Console.WriteLine(filename);

            string combinedPath1 = Path.Combine(Directory.GetCurrentDirectory(), filename);
            Console.WriteLine(combinedPath1);

            TextReader tr = new StreamReader(combinedPath1);

            string line;
            while ((line = tr.ReadLine()) != null)
            {
                string input = tr.ReadLine();
                Console.WriteLine(input);
            }

            tr.Close();
        }

        static void InternetExample (string textReaderText)
        {
            //https://msdn.microsoft.com/en-us/library/system.io.stringreader.readline(v=vs.110).aspx

            // From textReaderText, create a continuous paragraph 
            // with two spaces between each sentence.
            string aLine, aParagraph = null;
            StringReader strReader = new StringReader(textReaderText);
            while (true)
            {
                aLine = strReader.ReadLine();
                if (aLine != null)
                {
                    aParagraph = aParagraph + aLine + " ";
                }
                else
                {
                    aParagraph = aParagraph + "\n";
                    break;
                }
            }
            Console.WriteLine("Modified text:\n\n{0}", aParagraph);


        }
    
        static void InternetExample_ReadAllLines (string textReaderText)
        {
            // The files used in this example are created in the topic
            // How to: Write to a Text File. You can change the path and
            // file name to substitute text files of your own.

            // Example #1
            // Read the file as one string.
            string text = System.IO.File.ReadAllText(textReaderText);

            // Display the file contents to the console. Variable text is a string.
            System.Console.WriteLine("Contents of WriteText.txt = {0}", text);

            // Example #2
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(textReaderText);

            // Display the file contents by using a foreach loop.
            System.Console.WriteLine("Contents of WriteLines2.txt = ");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();

        }

        static void InternetExample_ReadLines(string textReaderText)
        {
            foreach (var line in File.ReadLines(textReaderText))
            {
                Console.WriteLine(line);
            }

        }

        static void InternetExample ()
        {
            //https://support.microsoft.com/en-ca/help/816149/how-to-read-from-and-write-to-a-text-file-by-using-visual-c
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\eula.1028.txt");

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the lie to console window
                    Console.WriteLine(line);
                    //Read the next line
                    line = sr.ReadLine();
                }

                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        /// <summary>
        /// <param name="csvFilePath">Used to access file path</param>
        /// </summary>
        static void ParseCsvWithLinq(string csvFilePath)
        {
            TextReader tr = new StreamReader(csvFilePath);
            string line;
            string[] array = new string[0];
            while ( (line = tr.ReadLine()) != null )
            {
                array = line.Split(", ");
                //Console.WriteLine(array);     //yucky
                array.ToList().ForEach(s => Console.WriteLine(s));  //great!
            }
        }

        static void ParseCsvWithLinq2(string csvFilePath)
        {
            var stuff = from l in File.ReadAllLines(csvFilePath)
                        let x = l.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(s => int.Parse(s))
                        select new
                        {
                            Sum = x.Sum(),
                            Average = x.Average()
                        };
            Console.WriteLine(stuff);
        }
    }
}
