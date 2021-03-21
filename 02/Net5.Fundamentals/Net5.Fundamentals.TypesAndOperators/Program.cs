using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Net5.Fundamentals.TypesAndOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = a + 2;

            bool test = true;

            //int c = a + test;

            float temperature;
            string name;
            MyClass myClass = new MyClass();

            char firstLetter = 'C';
            var limit =1;
            limit = 3333333;

            int[] source = { 1, 2, 3, 4, 5 };
            var query = from item in source where item <= item select item;
            
            myClass.MyProperty = 5;
            ChangeMyClass(myClass);            
            Console.WriteLine(myClass.MyProperty);

            ChangeValue(a);
            Console.WriteLine(a);

            int aa = 123;
            System.Int32 bb = 123;

            var c = aa + bb;
            var hexa = 0x2A;
            var binary = 0b_0010_1010;

            string cadena = "test";
            char letter = 'D';

            var characters = new[]
            {
                'j',
                '\u006A',
                '\x00A',
                (char)106
            };

            Console.WriteLine(string.Join(" ", characters));

            Console.WriteLine((int)Season.Autum);
            Console.WriteLine(Season.Autum.ToString());
            var error = ErrorCode.ConnectionLost;

            var test1 = ((ushort)ErrorCode.ConnectionLost == 100);
            var test2 = (ErrorCode.ConnectionLost == error);

            Coords coords = new Coords(1,2,3);

            (MyClass, string name, int,int,int,int,int) coord = (new MyClass(),"tr",5,4,4,4,4);
            Console.WriteLine(coord.name);

            bool? eval = null;
            int? num = null;
            int numNotNull = 0;
            string cad = null;
            MyClass myClass1 = null;

            //ChangeValue(num.Value);

            Dog dog = new Dog("Firulais","5");
            
            Console.WriteLine(dog.ToString());

            int numInt = 1234563865;
            long bigNumt = numInt;
            Derived derivade = new Derived();
            Base baseClass = derivade;

            Giraffe g = new Giraffe();
            Animal animal = g;

            Giraffe g2 = (Giraffe)animal;

            int i = 3;
            Console.WriteLine($"i = {i}");
            Console.WriteLine($"++i = {++i}");
            Console.WriteLine($"i = {i}");
                        
            if( !test && eval.Value)
            {

            }
            if (test)
            {
                a = 5;
            }
            else
            {
                a = 6;
            }

            a = (test ? 5 : (eval.Value ? 4 : 2));

            num = (num == null ? 5 : num);
            num = num ?? 5;

            string cadeNum = num?.ToString();

            List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6 };

            nums.ForEach(num =>            
            {
                Console.WriteLine(num);
                Console.WriteLine(num);
            });

            Employee employee = new Employee() {
                Name = "Erick"
            };
            //employee.Name = "Oscar";


        }

        static void ChangeMyClass(MyClass param)
        {
            param.MyProperty = 20;
        }

        static void ChangeValue(int param)
        {
            param = 20;
        }
    }
}
