using System.Threading.Channels;
using System.IO;

namespace ConsoleApp1;

internal class Program
{

  public static async Task Main(string[] args)
  {
    Console.WriteLine("One");
    Console.WriteLine("Two");

    Task tB = Task.Run(async () =>
    {
      Console.WriteLine("BTask");

      Task<string> tS = Task.Run(() =>
      {
        for (int i = 0; i < 20; i++)
        {
          Console.WriteLine("BTask: " + i);
        }
        return "Threeeeee";
      });
      await tS;
      Console.WriteLine("BTask: " + tS.Result);
    });


    try
    {
      Person person = new Person();
      await person.DoSomething();
    }
    catch (Exception ex)
    {
      await Console.Out.WriteLineAsync(ex.Message); ;
    }


    Customer customer = new Customer();
    string st = await customer.DoSomeStuffForCustomer();
    await Console.Out.WriteLineAsync(st);


    Console.WriteLine("Four");
    WriteToFile writeToFile = new WriteToFile();
    await writeToFile.WriteAsync();

    Console.WriteLine("Five");
    Console.WriteLine("Six");

    customer.Method();

  }
}


public class Person
{
  public string Name { get; set; }
  public async Task DoSomething()
  {
    throw new Exception("Exception in DoSomething");
    Task<int> tt = Task.Run(() => { Console.WriteLine("DoSomething"); return 34; });
    await tt;
    Console.WriteLine("DoSomething: " + tt.Result);
  }
}


public class Customer
{
  public async Task<string> DoSomeStuffForCustomer()
  {
    return await Task.Run(() => { Console.WriteLine("DoSomeStuffForCustomer"); return "Customer Name Eras Tour Taylor Swift..."; });
  }

  public async void Method()
  {
    Task<Person> t = Task.Run(() => { Console.WriteLine("Person involved in customer test"); return new Person() { Name = "Taylor Swift" }; });
    await t;
    Console.WriteLine("Person involved in customer test: " + t.Result.Name);
  }

}



public class WriteToFile
{
  public async Task<bool> WriteAsync()
  {
    string text = "Write to file asyncrono ma bloccante...";
    await File.WriteAllTextAsync("./test.txt", text);
    Console.WriteLine("Write to file: ");
    return true;
  }
}

