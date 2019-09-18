using System;
using BenchmarkDotNet.Attributes;
using DotNetCoreBenchmarkTest.Repository;
using System.Linq;

namespace DotNetCoreBenchmarkTest
{
    public class BenchmarkMain
    {
        private readonly SampleRepository _sampleRepository;
        private readonly int[] _indexes;

        public BenchmarkMain()
        {
            _sampleRepository = new SampleRepository();
            _indexes = Enumerable.Range(0, 10000).ToArray();
        }

        [Benchmark]
        public void CaseLambda()
        {
            // 普通にラムダ式で呼び出し、変数のキャプチャ有り
            foreach (var i in _indexes)
            {
                var id = i % 3 + 1;
                var sample = _sampleRepository.GetByLambda(id);
                if (sample == null) Console.WriteLine("No data");
            }
        }

        [Benchmark]
        public void CaseExtension()
        {
            // 拡張メソッドを利用、変数のキャプチャ無し
            foreach (var i in _indexes)
            {
                var id = i % 3 + 1;
                var sample = _sampleRepository.GetByExtension(id);
                if (sample == null) Console.WriteLine("No data");
            }
        }

        [Benchmark]
        public void CaseLocalFunction()
        {
            // ローカル関数経由で呼び出し、変数のキャプチャ有り
            foreach (var i in _indexes)
            {
                var id = i % 3 + 1;
                var sample = _sampleRepository.GetByLocalFunction(id);
                if (sample == null) Console.WriteLine("No data");
            }
        }

    }
}
