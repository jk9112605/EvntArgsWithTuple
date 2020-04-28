using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEventArgsWithTuple
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass foo = new MyClass();

            foo.MyEvent += Foo_MyEvent; 
            
            //lambda
            foo.MyEvent += (o, e) =>
            {
                Console.WriteLine($"Hello, sender is {o.ToString()}! message is {e.message}, ID is {e.ID}, and count is {e.count}. "); //string int
            };


            foo.Run();
            Console.ReadLine();
        }

        private static void Foo_MyEvent(object sender, (string message, string ID, int count) e)
        {
            //Console.WriteLine("Foo event raised: class name: {0}")
            // String interpolation:
            Console.WriteLine($"Hello, sender is {sender.ToString()}! message is {e.message}, ID is {e.ID}, and count is {e.count}. "); //string int
        }
    }
    class MyClass
    {
        public event EventHandler<(string message, string ID, int count)> MyEvent;
        public void Run()
        {
            //do something
            MyEvent?.Invoke(this, (message: "running", ID: "1", count:1));
        }
    }
}
