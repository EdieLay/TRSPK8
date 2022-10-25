using System.Globalization;
using System.IO;
using System.Text;

int ind1 = 101010;
string pass1 = "Qwerty123";

double ind2 = 123.456;
object pass2 = "zXcvb567";

MyStruct ind3 = new MyStruct(909, 'd');
MyClass pass3 = new MyClass("ABC", 444);

Person<int, string> a = new Person<int, string>(ind1, pass1);
Console.WriteLine($"Person A:\n{a.GetInformation()}\n");

Person<double, object> b = new Person<double, object>(ind2, pass2);
Console.WriteLine($"Person B:\n{b.GetInformation()}\n");

Person<MyStruct, MyClass> c = new Person<MyStruct, MyClass>(ind3, pass3);
Console.WriteLine($"Person C:\n{c.GetInformation()}\n");


class Person<T, K>
    where T : struct //ограничение типа-значения
    where K : class //ограничение типа-ссылки
{
    public T Id { get; set; }
    public K Password { get; set; }
    public Person(T id, K password)
    {
        Id = id;
        Password = password;
    }
    public string GetInformation()
    {
        return $"Id: {Id}; Password: {Password}";
    }
}

class MyClass
{
    public string Letters { get; set; } = "";
    public int Numbers { get; set; } = 0;
    public MyClass(string letters, int numbers)
    {
        Letters = letters;
        Numbers = numbers;
    }
    public override string ToString()
    {
        return $"{Letters}@{Numbers}";
    }
}

struct MyStruct
{
    public int Value { get; set; }
    public char C { get; set; }
    public MyStruct(int value, char c)
    {
        Value = value;
        C = c;
    }
    public override string ToString()
    {
        return $"{C}@{Value}";
    }
}