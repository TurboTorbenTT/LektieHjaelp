using ReflectionExample.Abstraction;

namespace ReflectionExample.NewDLL;

/// <summary>
/// The new console printer for use in all future printings, should be loaded from the exported dll.
/// </summary>
public class NewConsolePrinter : ConsolePrinter
{
  public override void Print(string input)
  {
    Console.WriteLine("This is the new wacky method lol xd: " + input);
  }
}