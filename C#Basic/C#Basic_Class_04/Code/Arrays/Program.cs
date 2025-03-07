//Console.WriteLine(indexOfTrue);

//int indexOf8 = Array.IndexOf(arrayOfShorts, (short)8);
//Console.WriteLine(indexOf8);

using System;

double[] doubleArray = new double[] {3.2, 1.2, 4.78, 6, 0.54 };  // five elements in the array

Console.WriteLine("Number of elements in the doubleAray: " + doubleArray.Length);

//doubleArray[5] = 6.1; -. not alowed! we need to Resie the array first
// Resize
Array.Resize(ref doubleArray, 7);  // I want to change the doubleArray size, so that now it can fit 7 elements
Console.WriteLine(doubleArray.Length);
Console.WriteLine(doubleArray[5]);

doubleArray[5] = 6.1;
doubleArray[6] = 3.23;

for(int i = 0; i < doubleArray.Length; i++)
{
    Console.WriteLine(doubleArray[i]);
}

// FOR EACH LOOP

foreach (double doubleElement in doubleArray)
{
    Console.WriteLine(doubleElement);
}

string[] names = new string[] { "Sinisha", "Viktor", "Ivan", "Olgica" };
foreach(string name in names)
{
    Console.WriteLine(name);
}
Console.WriteLine("===============Reeversed=====================");

Array.Reverse(names);
foreach(string name in names)
{
    Console.WriteLine(name);
}

// Array of arrays
int[][] matrix = new int[][]
    {
    new int[] { 1, 2 },
    new int[] { 3, 4 },
    new int[] { 5, 6 }
};
              // [row][column]
Console.WriteLine(matrix[2][0]); // 5
Console.WriteLine(matrix[1][1]);  // 4
Console.WriteLine(matrix[0][1]);  // 2

//foreach(int[] row in matrix) { 
//    foreach(var item in items)
//    {
//        Console.WriteLine(item);
//    }
//}

foreach (int[] row in matrix)  // row  = int[] {1,2}; int[] {3,4}; int[] {5,6}
{
    Console.WriteLine(row);  // we have three arrays in the matrix 

    // we can iterate through the rows (the arrys of the array) with another foreach
    // this way we wil iterate through {1,2} in the first iteration, {3,4} in the second iteration and {5,6} in the third iteration
    foreach (int element in row)
    {
        Console.WriteLine(element);
    }
}

// if we want to iterate only in one element of the matrix:
foreach(int element in matrix[0])
{
    Console.WriteLine(element);  // 1 2
}