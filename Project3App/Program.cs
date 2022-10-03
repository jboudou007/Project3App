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
using System.Runtime.InteropServices;

namespace Project3App
{
    public class Program
    {
        /// <summary>
        /// The program will ask the user to enter the path of the file he's looking for 
        /// if the file is found, it will read the file and store the data as a jagged array and then it will search sort and print
        /// If the path is incorrect the user will be asked to close the app then try again
        /// </summary>
        static void Main()
        {

                

           
                string userInput = Methods.ReadString($"Please enter the path of the file 'inputJagged.csv': ");
            
            
                Console.WriteLine();

                int[][] jaggedArray = new int[20][];

                int[][] jaggedArrayFromFile = Methods.JaggedArrayOpener(jaggedArray, userInput);

                if (jaggedArrayFromFile != Array.Empty<int[]>())
                {
                    Methods.PrintJaggedArray(jaggedArrayFromFile);

                    Console.WriteLine();

                    Console.WriteLine("\n\n-------------------------------------\n\n");

                    PrintTheSearchedAndSortedArrays(jaggedArrayFromFile);
                }

                else
                {
                    Console.WriteLine("File not found. Close the app then try again");
                }

            
        }

        /// <summary>
        /// Merge Sort is called recursively. The condition to stop is that the left boundary is 
        /// greater or equal to the right boundary of the array
        /// </summary>
        /// <param name="array"> the array we want to sort goes as parameter</param>
        /// <param name="left"> left boundary of the array usually index 0 </param>
        /// <param name="right"> right boundary or end of the array usually array.lenght - 1 </param>

       static void MergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;

                MergeSort(array, left, middle);  //Call mergesort on the left subarray which is from the left to middle of the orinal array
                MergeSort(array, middle + 1, right);     //Call mergesort on the right subarray which is from the middle to righ of the original array

                Merge(array, left, middle, right);


            }



        }

        /// <summary>
        /// Merge method will be responsible to merge the splitted array. It will take the array, left, middle and right as parameters
        /// Look at the documentation below for more details
        /// </summary>
        /// <param name="array"> The array that needs to be sorted </param>
        /// <param name="left"> left boundary of the array </param>
        /// <param name="middle"> the middle of the array </param>
        /// <param name="right"> the end of the array </param>

        static void Merge(int[] array, int left, int middle, int right) //array we want to sort, left most boundary, right most boundary and middle
        {
            int i, j, k; //The merge function uses 3 pointers and splits the original array into 2 array left and right to sort

            int leftArrayLenght = middle - left + 1;

            int rightArrayLenght = right - middle;

            int[] leftArray = new int[leftArrayLenght];   //Define left array

            int[] rightArray = new int[rightArrayLenght]; //Define right array

            for (i = 0; i < leftArrayLenght; i++)  //Populate left array with the left part of the original array
            {
                leftArray[i] = array[left + i];
            }
            for (j = 0; j < rightArrayLenght; j++) //Populate right array with the right part of the original array
            {
                rightArray[j] = array[middle + 1 + j];
            }

            i = 0; j = 0; k = left;          // i is the current element of the left array, j is the current element of the right array and 

            while (i < leftArrayLenght && j < rightArrayLenght) //Compare left element of the left array to the left element of the right array as long as we did not reach the end of the array
            {
                if (leftArray[i] <= rightArray[j])   //left element is smaller then
                {
                    array[k] = leftArray[i];      // add the left element to the final sorted array
                    i++;
                }
                else  // else right element is smaller
                {
                    array[k] = rightArray[j];   // then add the right element to the final sorted array and move on to the next
                    j++;
                }
                k++;

            }
            while (i < leftArrayLenght) // after the while loop finishes one of the array still has elements that have not been copied
            {
                //left array is done and we need to copy from the right array

                array[k] = leftArray[i];
                i++;
                k++;

            }
            while (j < rightArrayLenght)
            {
                //right array is done and we need to copy from the left array

                array[k] = rightArray[j];
                j++;
                k++;

            }







        }

        /// <summary>
        /// The methods prints the Merge sorted jagged array from its first index to last 
        /// line by line then it searchs for the number 256 at index i
        /// </summary>
        /// <param name="jaggedArray"> The method takes the jagged array the user wants to print as parameter </param>

        static void PrintTheSearchedAndSortedArrays(int[][] jaggedArray)
        {
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine($"Given Array{i}");
                Methods.PrintArray(jaggedArray[i]);

                MergeSort(jaggedArray[i], 0, jaggedArray[i].Length - 1);
                Console.WriteLine($"\nSorted array{i}");
                Methods.PrintArray(jaggedArray[i]);

                int indexBinaryIndex = BinarySearch(jaggedArray[i], 256);

                Console.WriteLine($"Index of the number 256 is at index: {indexBinaryIndex}");
                Console.WriteLine("\n\n-------------------------------------\n\n");

                
            }
            Console.Write("\n");
        }

        /// <summary>
        /// Binary search takes for this program takes an int array and a int key as parameters.
        /// While the left boundary is not greater to the right boundary the start starts in the middle
        /// if not found it will search right then will search right
        /// 
        /// </summary>
        /// <param name="array"> The array the user wants to search </param>
        /// <param name="key"> key reffers to what number the user id looking for in the array </param>
        /// <returns> The Binary search will return the index of the key if found. Otherwise it will return a -1 if not found</returns>

        public static int BinarySearch(int[] array, int key)
        {

            const int NotFound = -1;
            int index = NotFound;

            int left = 0, right = array.Length - 1, mid;
            while (left <= right)
            {
                mid = (left + right) / 2;

                if (key == array[mid])
                {
                    index = mid;
                    break;
                }
                else if (key > array[mid])
                {
                    //Search right
                    left = mid + 1;
                }
                else
                {
                    //Search left
                    right = mid - 1;
                }
            }

            return index;
        }


    }
}