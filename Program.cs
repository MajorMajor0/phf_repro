
using Microsoft.VisualBasic;
using Phf;
using Phf.Net;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Generate 43 choose 7 strings


ThisHangs();


void ThisHangs()
{
    int i = 0;
    int n = 43_000_000;
    string[] keys = new string[n];

    Stopwatch watch = Stopwatch.StartNew();

    // for (char c0 = '0'; c0 < '0' + 7; c0++) // This permutes string[0]
        for (char c1 = '0'; c1 < '0' + 43; c1++) // This permutes string[1]
            for (char c2 = '0'; c2 < '0' + 10; c2++)
                for (char c3 = '0'; c3 < '0' + 10; c3++)
                    for (char c4 = '0'; c4 < '0' + 10; c4++)
                        for (char c5 = '0'; c5 < '0' + 10; c5++)
                            for (char c6 = '0'; c6 < '0' + 10; c6++)
                                for (char c7 = '0'; c7 < '0' + 10; c7++)

                                    keys[i++] = $"{c1}{c2}{c3}{c4}{c5}{c6}{c7}";

    Console.WriteLine($"Enumerated {i} strings: {watch.ElapsedMilliseconds} ms ");
    watch.Restart();

    var hs = keys.ToHashSet();
    Console.WriteLine($"Hashset: {hs.Count - n} keys short: {watch.ElapsedMilliseconds} ms ");
    hs = null;
    watch.Restart();

    PerfectHashFunction phf = PerfectHashFunction.Create(keys, new());

    Console.WriteLine($"Hashed {i} strings: {watch.ElapsedMilliseconds} ms ");
}
