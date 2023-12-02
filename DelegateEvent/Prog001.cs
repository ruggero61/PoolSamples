using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DelegateEvent;

public class Prog001
{
  public static void Main()
  {
    Publisher publisher = new Publisher();
    publisher.DiscountHandler += () => Console.WriteLine($"Io, Main, Sono a conoscenza del discount event...");
    publisher.RaiseDiscountEvent();
  }
}

public delegate void VoidHandlerVoid();

public class Publisher
{
  private VoidHandlerVoid? _discountHandler;

  public event VoidHandlerVoid DiscountHandler
  {
    add
    {
      _discountHandler += value;
    }
    remove
    {
      _discountHandler -= value;
    }
  }

  public void RaiseDiscountEvent()
  {
    _discountHandler?.Invoke();
  }
}

public class Subscriber
{
  private Publisher? _publisher;
  private Master? _master;

  public Subscriber(Publisher publisher, Master? master)
  {
    _publisher = publisher;
    _publisher.DiscountHandler += () => Console.WriteLine($"Io, Subscriber, Sono a conoscenza del discount event...");
    _master = master;
    _master.MasterHandler += () => Console.WriteLine($"Io, Subscriber, Sono a conoscenza del master event...");
  }
  public void Method()
  {
    Console.WriteLine($"Io, Subscriber.Method, Sono a conoscenza del discount event...");
  }
}

public class Student
{
  private Teacher? _teacher;
  public Student(Teacher teacher)
  {
    _teacher = teacher;
    _teacher.TeacherHandler += () => Console.WriteLine($"Io, Student, Sono a conoscenza del teacher event...");
  }

  public void Method()
  {
    Console.WriteLine($"Io, Student.Method, Sono a conoscenza del teacher event...");
  }
}


public class Master
{
  private VoidHandlerVoid? _masterHandler;

  public event VoidHandlerVoid MasterHandler
  {
    add
    {
      _masterHandler += value;
    }
    remove
    {
      _masterHandler -= value;
    }
  }

  public void RaiseMasterEvent()
  {
    _masterHandler?.Invoke();
  }
}


public class Teacher
{
  public event VoidHandlerVoid? TeacherHandler;

  public void RaiseTeacherEvent()
  {
    TeacherHandler?.Invoke();
  }
}

public class Administrator
{
  public Action AdministratorHandler;

  public void RaiseAdministratorEvent()
  {
    AdministratorHandler?.Invoke();
  }
}

public class Person
{
  public string Name { get; set; }
  public string Surname { get; set; }
  public int Age { get; set; }
  private Administrator? _administrator;
  public Person(string name, string surname, int age, Administrator administrator)
  {
    Name = name;
    Surname = surname;
    Age = age;
    _administrator = administrator;
    _administrator.AdministratorHandler += () => Console.WriteLine($"Io, Person, Sono a conoscenza del administrator event...");
  }
}

