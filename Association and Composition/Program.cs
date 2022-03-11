public class Student    
{
    public string Name { get; set;}
    public Address address { get; set;} //Composition
}
public class Address       //Address is dependent on student
{
    public int Pin { get; set;}
    public string City { get; set;}
    public string Country { get; set;}
    public void Language()
    {
        Console.WriteLine("C# Language");
    }
}

public class Program
{
    public static void Main()
    {
        Address a = new Address();//Association
        a.Language();
        List<Student> students = new List<Student>()
      {
          new Student()
          {
             Name="Micky",address=new Address(){Pin=10020,City="Delhi",Country="India"}
          },
          new Student()
          {
             Name="Sam",address=new Address(){Pin=10020,City="Delhi",Country="India"}
          }
      };
         Console.WriteLine("Output");
        foreach(var item in students)
        {
            Console.WriteLine($"Name:{item.Name}\n Address \n City: {item.address.City} Country:{item.address.Country} Pin: {item.address.Pin}");
        }
    }
}







