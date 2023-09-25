using ReflectionExample.Abstraction;

namespace ReflectionExample.MainProgram.Models;
/// <summary>
/// The good old trusty console printer. Prints everything with no fancy lingo.
/// </summary>
public class GoodOldConsolePrinter : ConsolePrinter
{
  public override void Print(string input)
  {
    Console.WriteLine("This is the good old trusty method: " + input);
  }
}