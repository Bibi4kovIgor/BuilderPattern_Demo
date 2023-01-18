using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarEntity car = CarEntity.Builder()
                .CarId("1234")
                .CarName("Some name")
                .CarNumber(11112)
                .Build();

            Console.WriteLine(car);

            Console.ReadKey();
        }
    }
}
