using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal an = new Animal();
            Cat cat = new Cat();
            Animal ca = new Cat();
            an.printValue();
            cat.printValue();
            ca.printValue();
            Console.ReadKey();
        }
    }
    abstract public class Animal
    {
        int i = 0;
        virtual public void printValue()
        {
            Console.WriteLine("Ai = "+i);
        }
    }
    public class Cat : Animal
    {
        int i = 0;
        override public void printValue()
        {
            Console.WriteLine("Mii = "+i);
        }
    }
    public class Dog : Animal
    {
        int i = 0;
        override public void printValue()
        {
            Console.WriteLine("Mii = "+i);
        }
    }
}
