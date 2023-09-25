namespace ReflectionExample.Abstraction;
/// <summary>
/// This is the base console printer. All console printers should inherit from this method.
/// </summary>
public abstract class ConsolePrinter
{
  public virtual void Print(string input)
  {
    Console.WriteLine("This is the default print method: " + input);
  }
}