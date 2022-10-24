// See https://aka.ms/new-console-template for more information

GenericMethods<int> intMethods = new GenericMethods<int>();
int intObj = intMethods.Sum(1, 2, 3, 4, 5);
Console.WriteLine($"Сумма int от 1 до 5: {intObj}");
intObj = intMethods.Max(1, 2, 3, 4, 5);
Console.WriteLine($"Максимальный из int от 1 до 5: {intObj}");
intObj = intMethods.Min(1, 2, 3, 4, 5);
Console.WriteLine($"Минимальный из int от 1 до 5: {intObj}");
int a = 5, b = 10;
Console.WriteLine($"a = {a}, b = {b}");
intMethods.Swap(ref a, ref b);
Console.WriteLine($"После swap: a = {a}, b = {b}");
intObj = intMethods.Avg(3, 6, 2, 7, 10);
Console.WriteLine($"Среденее значение чисел 3, 6, 2, 7, 10: {intObj}");

Console.WriteLine();

GenericMethods<double> doubleMethods = new GenericMethods<double>();
double doubleObj = doubleMethods.Sum(1, -2.31, 3.51, 4.1, 5.86);
Console.WriteLine($"Сумма double 1, -2.31, 3.51, 4.1, 5.86: {doubleObj}");
doubleObj = doubleMethods.Max(1, -2.31, 3.51, 4.1, 5.86);
Console.WriteLine($"Максимальный из double 1, -2.31, 3.51, 4.1, 5.86: {doubleObj}");
doubleObj = doubleMethods.Min(1, -2.31, 3.51, 4.1, 5.86);
Console.WriteLine($"Минимальный из double 1, -2.31, 3.51, 4.1, 5.86: {doubleObj}");
double c = 5.135, d = 10.753;
Console.WriteLine($"c = {c}, d = {d}");
doubleMethods.Swap(ref c, ref d);
Console.WriteLine($"После swap: c = {c}, d = {d}");
doubleObj = doubleMethods.Avg(3, 6, 2, 7, 10);
Console.WriteLine($"Среденее значение чисел 3, 6, 2, 7, 10: {doubleObj}");

Console.WriteLine();

//GenericMethods<MyStruct> MyStructMethods = new GenericMethods<MyStruct>();
//MyStruct my1 = new MyStruct();
//MyStruct my2 = new MyStruct(10);
//MyStruct myObj = MyStructMethods.Sum(my1, my2);
//Console.WriteLine($"Сумма MyStruct 0 и 10: {myObj}");



class GenericMethods<T> where T : struct
{
    public T Sum(params T[] list)
    {
        T sum = default(T);
        for (int i = 0; i < list.Length; i++)
            sum += (dynamic)list[i];
        return sum;
    }
    public T Max(params T[] list)
    {
        T max = list[0];
        for (int i = 1; i < list.Length; i++)
            if ((dynamic)list[i] > max)
                max = list[i];
        return max;
    }
    public T Min(params T[] list)
    {
        T min = list[0];
        for (int i = 1; i < list.Length; i++)
            if ((dynamic)list[i] < min)
                min = list[i];
        return min;
    }
    public void Swap(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    public T Avg(params T[] list)
    {
        T avg = default(T);
        for (int i = 0; i < list.Length; i++)
            avg += (dynamic)list[i];
        avg /= (dynamic)list.Length;
        return avg;
    }
}

struct MyStruct
{
    public int a { get; set; }
    public MyStruct()
    {
        a = 0;
    }
    public MyStruct(int a)
    {
        this.a = a;
    }
}