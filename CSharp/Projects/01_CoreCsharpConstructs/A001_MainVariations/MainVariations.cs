using System;
using System.Threading.Tasks;

namespace A001_MainVariations
{
    // Using variations of the Main() method
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Program2
    {
        static int Main(string[] args)
        {
            return 0;
        }
    }

    class Program3
    {
        static void Main()
        {

        }
    }

    class Program4
    {
        static int Main()
        {
            return 0;
        }
    }

    class Program5
    {
        static Task Main()
        {
            return new Task(() => { });
        }
    }

    class Program6
    {
        static Task<int> Main()
        {
            return new Task<int>(Method);
        }

        static int Method()
        {
            return 0;
        }
    }

    class Program7
    {
        static Task Main(string[] args)
        {
            return new Task(() => { });
        }
    }

    class Program8
    {
        static Task<int> Main(string[] args)
        {
            return new Task<int>(Method);
        }

        static int Method()
        {
            return 0;
        }
    }
}
