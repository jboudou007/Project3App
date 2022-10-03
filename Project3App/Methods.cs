///////////////////////////////////////////////////////////////////////////////
//
//  Author: Jean Bilong, bilong@etsu.edu
//         
//  Course: CSCI-2210-001 - Data Structures
//  Assignment: Project 3
//  Description: Searching and Sorting
//    
//  
///////////////////////////////////////////////////////////////////////////////








using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3App
{

    /// <summary>
    /// The Class Methods will contain all the useful basic methods the user will need
    /// </summary>
    public class Methods
    {

        
        /// <summary>
        /// ReadString method to take user input as a string
        /// </summary>
        /// <param name="promptUser">"PromptUser refers to what the user is supposed to end eg: Readstring("Enter your name: ")"</param>
        /// <returns>The method will return a trimmed string from the input entered by the user</returns>
        public static string ReadString(string promptUser)  //Method to read the user input (string)
        {
            string value = "";
            Console.Write(promptUser);
            string? valueStr = Console.ReadLine();
            if (valueStr != null)
            {
                value = valueStr.Trim();

            }
            return value;

        }

        /// <summary>
        /// Jagged Array File Opener Method takes a jagged array the user defined and the input from the user
        /// Using regular expression the method will then open the file and read the data then will put the data in the jagged array line by line
        /// </summary>
        /// <param name="jaggedarray"> jagged array in which the user want to store the data from the file </param>
        /// <param name="input"> if the input is like a pathfile then the method will open the file </param>
        /// <returns> The method will return the jagged array filled with the data </returns>

        public static int[][] JaggedArrayOpener(int[][] jaggedarray,string input)
        {
            
            
            string pattern = @"(^([a-z]|[A-Z]):(?=\\(?![\0-\37<>:""/\\|?*])|\/(?![\0-\37<>:""/\\|?*])|$)|^\\(?=[\\\/][^\0-\37<>:""    
               /\\|?*]+)|^(?=(\\|\/)$)|^\.(?=(\\|\/)$)|^\.\.(?=(\\|\/)$)|^(?=(\\|\/)[^\0-\37<>:""/\\|?*]+)|^\.(?=(\\|\/)[^\0-\37<>:""
               /\\|?*]+)|^\.\.(?=(\\|\/)[^\0-\37<>:""/\\|?*]+))((\\|\/)[^\0-\37<>:""/\\|?*]+|(\\|\/)$)*()$"; // found this regular expression on stackOverflow https://stackoverflow.com/questions/6416065/c-sharp-regex-for-file-paths-e-g-c-test-test-exe

            int[][] result = new int[jaggedarray.Length][];

            if(input != pattern && !File.Exists(input))
            {
                return Array.Empty<int[]>();

            }
            try
            {
                string? line;
                StreamReader sr = new(input);
                for(int i = 0; i < result.Length; i++)
                {
                    line = sr.ReadLine();
                    
                    result[i] = line.Split(',').Select(int.Parse).ToArray();
                    
                    
                    
                }
                sr.Close();
                
                return result;


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Array.Empty<int[]>();
        }

        /// <summary>
        /// The print array method will only print a one dimention array on the console using a foorloop
        /// </summary>
        /// <param name="array"> the array the user wants to print goes as parameter </param>

        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.Write("\n");
        }

        /// <summary>
        /// The Print Jagged Array Method takes a jagged array as a parameter then print each index of the jagged array line by line
        /// </summary>
        /// <param name="jaggedArray"> The method needs the jagged the user wants to print as parameter </param>
        public static void PrintJaggedArray(int[][] jaggedArray)
        {
            for (int i = 0; i < jaggedArray.Length; i++)
            {   //for each plane

                for (int j = 0; j < jaggedArray[i].GetLength(0); j++)
                {    //for each row

                    Console.Write($"{jaggedArray[i][j]} ");


                }
                Console.Write("\n");
            }
        }

       




    }
}
