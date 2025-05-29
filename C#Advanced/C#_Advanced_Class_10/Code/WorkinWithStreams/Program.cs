string appPath = @"..\..\..\";  // relative path to the console app folder
string myFolder = appPath + "myFolder";
string txtPath = myFolder + @"\test.txt";

if(!Directory.Exists(myFolder))
{
    Directory.CreateDirectory(myFolder);
}

// if the test.txt file does not exist, stream writer creates it for us
using(StreamWriter sw = new StreamWriter(txtPath))
{
    sw.WriteLine("Hello G6!");
    sw.WriteLine("We are writing from stream writer");
    sw.WriteLine("Goodbye G6");
}
// sw only exists and can be used inside the using block{}
// after the } sw object is disposed of and the connection to the file is closed

using (StreamWriter sw = new StreamWriter(txtPath))
{
    sw.WriteLine("Another text");
    sw.WriteLine("This is another line");
    sw.WriteLine("This is YET another line");
}

//if we want to append to the file instead of overwriting it, we can pass a second parameter as true
using (StreamWriter sw = new StreamWriter(txtPath, true))
{
    sw.WriteLine("This is appended  text");
}

//reading
using(StreamReader sr = new StreamReader(txtPath))
{
    string firstLine = sr.ReadLine();
    Console.WriteLine("First line: " + firstLine);
    string secondLine = sr.ReadLine();
    Console.WriteLine("Second line: " + secondLine);
    // read the rest of the file line by line
    string restOfTheText = sr.ReadToEnd();
    Console.WriteLine("Reading the rest of the file:" + restOfTheText);

    string line;
    while ((line = sr.ReadLine()) != null)
    {
        Console.WriteLine(line);
    }
}

using (StreamReader sr = new StreamReader(txtPath))
{
    string line;
    while ((line = sr.ReadLine()) != null)
    {
        Console.WriteLine(line);
    }
}