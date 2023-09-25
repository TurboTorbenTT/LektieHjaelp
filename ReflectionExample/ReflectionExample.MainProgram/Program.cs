using System.Reflection;
using ReflectionExample.Abstraction;
using ReflectionExample.MainProgram.Models;

// Initialize collection of the compile time known printers.
var allConsolePrinters = new List<ConsolePrinter>();
allConsolePrinters.Add(new GoodOldConsolePrinter());

// This is the path to the import files relative to this program 
var relativeImportPath = "ImportFiles\\ReflectionExample.NewDLL.dll";

// It has to be converted to an absolute path so we convert it via the Path class.
// GetFullPath finds the absolute path relative to the current assembly, thus it is more versatile
var absoluteImportDllPath = Path.GetFullPath(relativeImportPath);

// Load the dll file, currently fails if no file is found, and only loads the one file.
var dll = Assembly.LoadFile(absoluteImportDllPath);

// Retrieve the public classes from the DLL to check for any ConsolePrinter classes
var types = dll.ExportedTypes;
foreach (var type in types)
{
  Console.WriteLine("Found a type to import! \n type: " + type + "\n BaseType: " + type.BaseType);
  
  // First verifies that the type is a class, as type is not necessarily a class
  // Then we check if the base type is a ConsolePrinter, as this is the common abstraction of our console printers
  if (type.IsClass && type.BaseType == typeof(ConsolePrinter))
  {
    Console.WriteLine("Type is a console printer!");
    
    // Create an instance of the type and cast it as the abstraction so it can be added to the collection of printers.
    var instance = (ConsolePrinter)Activator.CreateInstance(type)!;
    allConsolePrinters.Add(instance);
  }
}

PrintToAllConsoles("This message is super important and you should reflect on this", allConsolePrinters);

void PrintToAllConsoles(string message, List<ConsolePrinter> consolePrinters)
{
  // Simple iteration through all printers calling the exposed Print() method.
  foreach (var printer in consolePrinters)
  {
    printer.Print(message);
  }
}
