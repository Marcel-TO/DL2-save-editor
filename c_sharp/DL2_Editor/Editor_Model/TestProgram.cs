using Editor_Model.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor_Model
{
    public class TestProgram
    {
        private static void Main(string[] args)
        {
            string filePath = "M:\\Marcel\\Desktop\\GitHub\\DL2-save-editor\\c_sharp\\DL2_Editor\\Reference\\save_main_0.sav";
            FileAnalizer fileAnalizer = new FileAnalizer();

            try
            {
                // Open the file for reading in binary mode
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    // Create a byte array to hold the file contents
                    byte[] fileContents = new byte[fs.Length];

                    // Read the binary data from the file into the byte array
                    fs.Read(fileContents, 0, (int)fs.Length);

                    //// the fileContents byte array contains the binary data from the file
                    //this.FileContents = BitConverter.ToString(fileContents).Replace("-", " ");
                    fileAnalizer.AnalyzeUnlockableItemsData(fileContents);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            
        }
    }
}
