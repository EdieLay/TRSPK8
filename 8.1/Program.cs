// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

Bencher<ArrayList, int> bench_al_int = new();
Bencher<ArrayList, string> bench_al_string = new();
Bencher<List<int>, int> bench_list_int = new();
Bencher<List<string>, string> bench_list_string = new();

Console.WriteLine("Running benchmark on ArrayList with ints");
bench_al_int.RunTest(10000000, 10000000, new(), 10);

Console.WriteLine("\nRunning benchmark on ArrayList with strings");
bench_al_string.RunTest(10000000, 10000000, new(), "something");

Console.WriteLine("\nRunning benchmark on List with ints");
bench_list_int.RunTest(10000000, 10000000, new(), 10);

Console.WriteLine("\nRunning benchmark on List with strings");
bench_list_string.RunTest(10000000, 10000000, new(), "something");

public class Bencher<TContainer, TValue> where TContainer : IList
{
    public void RunTest(int add_count, int indexing_count, TContainer container, TValue default_val)
    {
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < add_count; i++) container.Add(default_val);
        sw.Stop();
        Console.WriteLine($"Added {add_count} elements in {sw.ElapsedMilliseconds} ms");
        sw.Restart();

        for (int i = 0; i < indexing_count; i++) _ = container[Random.Shared.Next(add_count)];
        sw.Stop();
        Console.WriteLine($"Indexed {indexing_count} elements in {sw.ElapsedMilliseconds} ms");
    }
}