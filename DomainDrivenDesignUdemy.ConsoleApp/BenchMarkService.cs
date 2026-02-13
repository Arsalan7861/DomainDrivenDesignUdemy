using BenchmarkDotNet.Attributes;

namespace DomainDrivenDesignUdemy.ConsoleApp
{
    public class BenchMarkService
    {
        [Benchmark(Baseline = true)] // this attribute indicates that this method is the baseline for comparison with other benchmark methods. The results of other benchmark methods will be compared to this method to determine their relative performance.
        public void Equals()
        {
            int id = 1;
            Test1 t1 = new() { Id = id };
            Test1 t2 = new() { Id = id };
            Console.WriteLine(t1.Equals(t2));
        }

        [Benchmark]
        public void IEquatable()
        {
            int id = 1;
            Test2 t1 = new() { Id = id };
            Test2 t2 = new() { Id = id };
            Console.WriteLine(t1.Equals(t2));
        }
    }

    public class Test1
    {
        public int Id { get; set; }
        public override bool Equals(object? obj) // override the default implementation of Equals method to compare entities based on their Id because in DDD, entities are defined by their identity rather than their attributes
        {
            if (obj == null) return false;

            if (obj is not Test1 test1) return false;

            if (obj.GetType() != GetType()) return false;

            return test1.Id == Id;
        }
    }

    public class Test2 : IEquatable<Test2>
    {
        public int Id { get; set; }
        public override bool Equals(object? obj) // override the default implementation of Equals method to compare entities based on their Id because in DDD, entities are defined by their identity rather than their attributes
        {
            if (obj == null) return false;

            if (obj is not Test2 test2) return false;

            if (obj.GetType() != GetType()) return false;
            return test2.Id == Id;
        }

        public bool Equals(Test2? other)
        {
            if (other == null) return false;

            if (other is not Test2 test2) return false;

            if (other.GetType() != GetType()) return false;
            return test2.Id == Id;
        }
    }
}
