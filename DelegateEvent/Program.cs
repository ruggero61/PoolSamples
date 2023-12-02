//namespace DelegateEvent;

//public class Program
//{
//  static void Main_000(string[] args)
//  {
//    IPublisher discount = new Discount();
//    Subscriber subscriber = new Subscriber(discount);
//    discount.PublisherEvent += () =>
//      Console.WriteLine($"Io, Main, Sono a conoscenza del discount event...");
//    discount.PublisherEvent += new Person().Method1;
//    discount.PublisherEvent += subscriber.Method;
//    discount.RaisePublisherEvent();

//    VoidHandlerVoid myDel = new Person().Method1;
//    myDel += () =>
//      Console.WriteLine($"Io, Main, Sono a conoscenza del discount event...");
//    myDel += new Person().Method2;

//    myDel?.Invoke();

//    Console.ReadKey();
//  }
//}

//public interface IPerson
//{
//  public string Name { get; set; }
//}

//public class Person : IPerson
//{
//  public string Name { get; set; }

//  public void Method1()
//  {
//    Console.WriteLine($"Test Method of Person Class...");
//  }
//  public void Method2()
//  {
//    Console.WriteLine($"Test Method of Person Class...");
//  }
//  public void Method3()
//  {
//    Console.WriteLine($"Test Method of Person Class...");
//  }
//  public void Method4(VoidHandlerVoid myDel)
//  {
//    myDel += () => Console.WriteLine($"da metodo...");
//    myDel.Invoke();
//    Console.WriteLine($"Test Method of Person Class...");
//  }
//}



//public delegate void VoidHandlerVoid();

//public delegate string StringHandlerVoid();

//public delegate Person PersonHandlerVoid();

//public delegate int IntHandlerIntIntInt(int i, int j, int k);

//public delegate string StringHandlerIntString(int i, string str);


//public interface IPublisher
//{
//  public event VoidHandlerVoid? PublisherEvent;
//  public void RaisePublisherEvent();
//}

//public class Discount : IPublisher
//{
//  //private VoidHandlerVoid? DiscountHandler;

//  /*
//  public event VoidHandlerVoid DiscountEvent
//  {
//    add { DiscountHandler += value; }
//    remove { DiscountHandler -= value; }
//  }
//  */

//  public event VoidHandlerVoid? PublisherEvent;

//  public void RaisePublisherEvent()
//  {
//    PublisherEvent?.Invoke();
//  }
//}

//public class Subscriber
//{
//  private IPublisher? _discount;

//  public Subscriber(IPublisher discount)
//  {
//    _discount = discount;
//    _discount.PublisherEvent += () => Console.WriteLine($"Io, Subscriber, Sono a conoscenza del discount event...");
//  }
//  public void Method()
//  {
//    Console.WriteLine($"Io, Subscriber, Sono a conoscenza del discount event...");
//  }
//}








