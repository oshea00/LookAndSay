# Look-And-Say Kata
Create a function LookAndSay(int initialDigit, int nthTerm) that returns the Nth term in a "Look-and-say Sequence"

[Look-and-say Sequence](https://en.wikipedia.org/wiki/Look-and-say_sequence#targetText=1%2C%2011%2C%2021%2C%201211,groups%20of%20the%20same%20digit.)

# Approach
The look-and-say sequence can be approached like a runlength compression that expresses runs of a single character as a 
count followed by the repeated character inline with other non-repeated characters, except the counts themselves *are* 
characters in the next evolution. This effect causes the items in the sequence to increase in size fairly quickly.

The initial ```LookAndSay``` solution takes a somewhat naive approach in building up the sequence of strings using C# Substring(). 
As it turns out, this causes a lot of heap allocation and extra copying, as Substring() creates a new string and then
copies from the source string to the resulting string and this process is done in a tight loop of many steps.

This reminded me of the new (since C# 7.2) Span<> type, which has some nice features that apply specifically to string
parsing scenarios. It is a [ref struct](https://blogs.msdn.microsoft.com/mazhou/2018/03/02/c-7-series-part-9-ref-structs) value type that can only exist on the stack and provides a "window" over 
a block of memory containing value types. 

Using this Span<> type resulted in the ```LookAndSaySpan``` implementation, which is considerably faster and more memory efficient.

Another nice feature of this new type is the implicit conversion from string, 
allowing existing code to take advantage very easily of this new type with minimal adjustments. In fact, you'll notice
the tests for both these solutions are identical to each other. 

Running the tests of both solutions shows a large time savings:
!["Test Runner Summary"](https://raw.githubusercontent.com/oshea00/LookAndSay/master/images/TestRunnerTimes.png)

But knowing exactly how the two solutions differ in terms of time and space was made a lot easier by the use of a cool
tool I recently discovered called [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet). 

Using this tool (see ```sayit.bench``` project) I was able to easily profile both solutions and provide a comparison
of the two. The resulting savings in CPU time and memory are pretty impressive. For example, finding the 60th element
in look-and-say sequence takes about 4 minutes using the all string-based solution, as opposed to about 300ms using
the Span-enabled solution.

Here are those results (finding the 30th element):

## Benchmark.Net
```
BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=2.2.301
  [Host]     : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT


```
|         Method |     Mean |     Error |    StdDev | Ratio | RatioSD |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |---------:|----------:|----------:|------:|--------:|----------:|------:|------:|----------:|
| SayWithStrings | 3.234 ms | 0.0174 ms | 0.0154 ms |  1.00 |    0.00 | 9468.7500 |     - |     - |  18.96 MB |
|    SayWithSpan | 1.381 ms | 0.0289 ms | 0.0424 ms |  0.43 |    0.02 |  556.6406 |     - |     - |   1.11 MB |


Now, go have some fun playing with these tools and, even better, use them in your future projects!



