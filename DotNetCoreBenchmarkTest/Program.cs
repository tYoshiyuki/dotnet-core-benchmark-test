using BenchmarkDotNet.Running;

namespace DotNetCoreBenchmarkTest
{
    class Program
    {
        static void Main()
        {
            BenchmarkRunner.Run<BenchmarkMain>();
        }
    }
}
