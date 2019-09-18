using DotNetCoreBenchmarkTest.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCoreBenchmarkTest.Repository
{
    public class SampleRepository
    {
        private readonly List<Sample> _samples = new List<Sample>
        {
            new Sample{ Id = 1, Name = "One"},
            new Sample{ Id = 2, Name = "Two"},
            new Sample{ Id = 3, Name = "Three"}
        };

        public Sample GetByLambda(int id)
        {
            return _samples.FirstOrDefault(_ => _.Id == id);
        }

        public Sample GetByExtension(int id)
        {
            return _samples.FirstOrDefault((x, state) => x.Id == state, id);
        }

        public Sample GetByLocalFunction(int id)
        {
            bool Func(Sample s) => s.Id == id;
            return _samples.FirstOrDefault(Func);
        }
    }

    public class Sample
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
