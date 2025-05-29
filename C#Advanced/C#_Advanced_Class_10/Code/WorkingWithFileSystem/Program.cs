string currentDirectoy = Directory.GetCurrentDirectory();
Console.WriteLine($"Current Directory: {currentDirectoy}");

string appPath = @"..\..\..\";  // relative path to the console app folder

// check if this path exists: ..\..\..\myFolder (check if three levels above there is a folder named myFolder)
bool myFolderExist = Directory.Exists(appPath + "myFolder");
Console.WriteLine($"myFolder Exist: {myFolderExist}");


string newFolderPath = appPath + "newFolder";
if (!Directory.Exists(newFolderPath)) // if this folder does not exist at this location(this path)
{
    Directory.CreateDirectory(newFolderPath); // here we send the path where we want to create the new directory(folder)
    Console.WriteLine($"Successfully created new folder: {newFolderPath}");
}

Console.WriteLine(Directory.Exists(newFolderPath)); // now it should be true

if (Directory.Exists(newFolderPath)) // always check if folder exists
{
    Directory.Delete(newFolderPath); // here we send the path where we want to delete the new directory(folder)
    Console.WriteLine($"Successfully deleted new folder: {newFolderPath}");
}

////working with files

if (!Directory.Exists(appPath + "myFolder"))
{
    Directory.CreateDirectory(appPath + "myFolder");
}

//// Check if a file test.txt exists in the myFolder directory
bool testtxtExists = File.Exists(appPath + @"myFolder/test.txt");
Console.WriteLine(testtxtExists); // false

if (!testtxtExists)
{
    File.Create(appPath + @"myFolder\test.txt").Close(); // Create returns a FileStream that we need to close
}

if (File.Exists(appPath + @"myFolder/test.txt"))  //check if the file was successfully created
{
    // overrite the content of the file
    File.WriteAllText(appPath + @"myFolder\test.txt", "Hello G6!"); // write to the file
}

if (File.Exists(appPath + @"myFolder/test.txt"))
{
    // overrite the content of the file
    File.WriteAllText(appPath + @"myFolder\test.txt", "Another text written in txt");
}

if (File.Exists(appPath + @"myFolder/test.txt"))
{
    // this will append the text to the content of test.txt
    File.AppendAllText(appPath + @"myFolder\test.txt", Environment.NewLine + "Goodbye G6");
}

if (File.Exists(appPath + @"myFolder/test.txt"))
{

    File.AppendAllText(appPath + @"myFolder\test.txt", Environment.NewLine + "See you next Tuesday");
}

if (File.Exists(appPath + @"myFolder/test.txt"))
{
    // read the content of the file
    string fileContent = File.ReadAllText(appPath + @"myFolder\test.txt");
    Console.WriteLine(fileContent);
}

if (File.Exists(appPath + @"myFolder/test.txt"))
{
    File.Delete(appPath + @"myFolder\test.txt");
}
