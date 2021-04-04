﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Net5.Fundamentals.ListAndThread
{
    public class ListAndThread
    {
        public void ArraySample()
        {
            Console.WriteLine("Array");
            Console.WriteLine("=====");

            int[] array = new int[5];

            for (int i = 0; i < 5; i++)
            {
                array[i] = i;
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"array[{i}] : {array[i]}");
            }
            Console.WriteLine($"Size : {array.Length}");
            
            Console.WriteLine($"Inicializacion y asignacion");
            int[] array2 = new int[] { 1, 2, 3, 4, 5 };
            int[] array3 = { 6, 7, 8, 9, 10 };
            
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"array3[{i}] : {array3[i]}");
            }

            Console.WriteLine($"Arreglo multi-dimensional");
            int[,] multidimensionalArray = { { 1, 2, 3 }, { 4, 5, 6 } };

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine($"multidimensionalArray[{i},{j}] : {multidimensionalArray[i, j]}");
                }
            }

            int[][] matrix = new int[6][];
            matrix[0] = new int[] { 1, 2, 3, 4, 5 };
            matrix[1] = new int[] { 1, 2, 3, 4, 5, 6 };
            matrix[2] = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            //matrix[3]
            //matrix[4]
            //matrix[5]

            for (int i = 0; i < 6; i++)
            {
                if (matrix[i] == null) continue;

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.WriteLine($"matrix[{i}],[{j}] : {matrix[i][j]}");
                }
            }

            Console.WriteLine("String Array");
            string[] weekDays = new string[] {"Lunes","Martes","Miercoles","Jueves","Viernes" };
            for (int i = 0; i < weekDays.Length; i++)
            {
                Console.WriteLine(weekDays[i]);
            }
        }

        public void ListSample()
        {
            Console.WriteLine("List");
            Console.WriteLine("====");

            List<int> numberList = new List<int>();
            numberList.Add(1);
            numberList.Add(3);
            numberList.Add(5);
            numberList.Add(7);
                        
            numberList.ForEach(num =>
            {
                Console.WriteLine($"Numbers : {num}");
            });

            List<string> cities = new List<string>()
            {
                "Lima",
                "Villa el Salvador",
                "Rimac",
                "Callao",
                "Jesus Maria",
                "San Juan De Lurigancho",
                "Miraflores",
                "San Isidro",
                "Villa Maria del Triunfo"
            };

            cities.ForEach(city =>
            {
                Console.WriteLine($"Cities : {city}");
            });

            Console.WriteLine("Ciudades de tamaño menor o igual a 6");
            cities.Where(city => city.Length <= 6).ToList().ForEach(c =>
            {
                Console.WriteLine($"Cities : {c}");
            });

            List<Person> people = new List<Person>
            {
                new Person{Name = "Erick",Age=38,Sex="M"},
                new Person{Name = "Jorge",Age=30,Sex="M"},
                new Person{Name = "Azucena",Age=22,Sex="F"},
                new Person{Name = "Jeniffer",Age=21,Sex="F"}
            };

            Console.WriteLine("Mujeres del salon de clase");
            people.Where(person => person.Sex == "F").ToList().ForEach(p =>Console.WriteLine(p.Name));
            
            Console.WriteLine($"La suma de las edades es : {people.Sum(p=>p.Age)}");
        }

        public void DictionarySample()
        {
            Console.WriteLine("Dictionary");
            Console.WriteLine("==========");

            Dictionary<string, Person> people = new Dictionary<string, Person>();

            people.Add("12345678", new Person { DNI= "12345678", Name = "Erick", Age = 38, Sex = "M" });
            people.Add("56428632", new Person { DNI= "56428632", Name = "Jorge", Age = 30, Sex = "M" });
            people.Add("41635163", new Person { DNI= "41635163", Name = "Azucena", Age = 22, Sex = "F" });
            people.Add("88382238", new Person { DNI= "88382238", Name = "Jeniffer", Age = 21, Sex = "F" });

            Console.WriteLine($"Azucena : {people.Where(kvp => kvp.Value.Name == "Azucena").Select(s => s.Key).First()} ");
            Console.WriteLine($"Key : 56428632, value {people["56428632"].Name}");
        }

        public void SortedListSample()
        {
            Console.WriteLine("SortedList");
            Console.WriteLine("==========");

            SortedList<string, Person> people = new SortedList<string, Person>();

            people.Add("12345678", new Person { DNI= "12345678", Name = "Erick", Age = 38, Sex = "M" });
            people.Add("56428632", new Person { DNI= "56428632", Name = "Jorge", Age = 30, Sex = "M" });
            people.Add("41635163", new Person { DNI= "41635163", Name = "Azucena", Age = 22, Sex = "F" });
            people.Add("88382238", new Person { DNI= "88382238", Name = "Jeniffer", Age = 21, Sex = "F" });

            Console.WriteLine($"Azucena : {people.Where(kvp => kvp.Value.Name == "Azucena").Select(s => s.Key).First()} ");
            Console.WriteLine($"Key : 56428632, value {people["56428632"].Name}");

            people.Select(people=>people.Key).ToList().ForEach(k=>Console.WriteLine($"Key : {k}"));
        }
        public void HashTableSample()
        {
            Console.WriteLine("HashList");
            Console.WriteLine("==========");

            Dictionary<string, Person> people = new Dictionary<string, Person>();

            people.Add("12345678", new Person { DNI= "12345678", Name = "Erick", Age = 38, Sex = "M" });
            people.Add("56428632", new Person { DNI= "56428632", Name = "Jorge", Age = 30, Sex = "M" });
            people.Add("41635163", new Person { DNI= "41635163", Name = "Azucena", Age = 22, Sex = "F" });
            people.Add("88382238", new Person { DNI= "88382238", Name = "Jeniffer", Age = 21, Sex = "F" });

            Hashtable ht = new Hashtable(people); 

            Console.WriteLine($"Key Hash : 56428632, Nombre {((Person)ht["56428632"]).Name}");
        }

        public void StackSample()
        {
            Console.WriteLine("Stack (LIFO)");
            Console.WriteLine("============");

            Stack<Person> people = new Stack<Person>();

            people.Push(new Person { DNI= "12345678", Name = "Erick", Age = 38, Sex = "M" });
            people.Push(new Person { DNI= "56428632", Name = "Jorge", Age = 30, Sex = "M" });
            people.Push(new Person { DNI= "41635163", Name = "Azucena", Age = 22, Sex = "F" });
            people.Push(new Person { DNI= "88382238", Name = "Jeniffer", Age = 21, Sex = "F" });
            
            int count = people.Count;
            
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Elementos en el Stack : {people.Count}");
                Console.WriteLine($"Extraer el elemento del Stack : {people.Peek().Name}");
                Console.WriteLine($"Eliminar el elemento del Stack : {people.Pop()}");
            }
        }
        public void QueueSample()
        {
            Console.WriteLine("Queue (FIFO)");
            Console.WriteLine("============");

            Queue<Person> people = new Queue<Person>();

            people.Enqueue(new Person { DNI= "12345678", Name = "Erick", Age = 38, Sex = "M" });
            people.Enqueue(new Person { DNI= "56428632", Name = "Jorge", Age = 30, Sex = "M" });
            people.Enqueue(new Person { DNI= "41635163", Name = "Azucena", Age = 22, Sex = "F" });
            people.Enqueue(new Person { DNI= "88382238", Name = "Jeniffer", Age = 21, Sex = "F" });
            
            int count = people.Count;
            
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Elementos en el Stack : {people.Count}");
                Console.WriteLine($"Extraer el elemento del Stack : {people.Peek().Name}");
                Console.WriteLine($"Eliminar el elemento del Stack : {people.Dequeue()}");
            }
        }
        public void TupleSample()
        {
            Console.WriteLine("Tuple");
            Console.WriteLine("=====");

            List<Tuple<string,string,Tuple<string,string,int, string>>> people = new List<Tuple<string, string, Tuple<string, string, int, string>>>();

            Tuple<string,string,int, string> erick = new Tuple<string, string, int, string>("12345678","Erick",39,"M");
            Tuple<string,string,int, string> jorge = new Tuple<string, string, int, string>("56428632","Jorge",30,"M");
            
            Tuple<string,string,Tuple<string,string,int, string>> e = new Tuple<string, string, Tuple<string, string, int, string>>("12345678","Erick",erick);
            Tuple<string,string,Tuple<string,string,int, string>> j = new Tuple<string, string, Tuple<string, string, int, string>>("56428632","Jorge",jorge);

            people.Add(e);
            people.Add(j);

            Console.WriteLine(e.Item1);
            Console.WriteLine(e.Item3.Item2);

            Console.WriteLine(people[0].Item1);
            Console.WriteLine(people[0].Item3.Item2);
        }
        public void ValueTupleSample()
        {
            Console.WriteLine("ValueTuple");
            Console.WriteLine("==========");

            (string,string,int,string) person = ("12345678","Erick",39,"M");

            Console.WriteLine(person.Item1);
            Console.WriteLine(person.Item2);
            Console.WriteLine(person.Item3);
            Console.WriteLine(person.Item4);
        }
        public void ThreadSample()
        {
            Console.WriteLine("Thread");
            Console.WriteLine("======");
            ParallelProcess parallelProcess = new ParallelProcess();

            Thread th1 = new Thread(new ThreadStart(parallelProcess.WriteProcess01));
            Thread th2 = new Thread(new ThreadStart(parallelProcess.WriteProcess02));

            th1.Start();
            th2.Start();

            th1.Join();
            th2.Join();
        }

        public void TaskSample()
        {
            Console.WriteLine("Task");
            Console.WriteLine("====");
            ParallelProcess parallelProcess = new ParallelProcess();

            Task[] tasks = new Task[2];
            string taskName01 = "Tarea 01";
            string taskName02 = "Tarea 02";

            tasks[0] = Task.Factory.StartNew((Object obj) => {                
                TaskParameter param = (TaskParameter)obj;
                parallelProcess.WriteProcess01(param.Name);
            },new TaskParameter{Name = taskName01});

            tasks[1] = Task.Factory.StartNew((Object obj) => {                
                TaskParameter param = (TaskParameter)obj;
                parallelProcess.WriteProcess02(param.Name);
            },new TaskParameter{Name = taskName02});

            Task.WaitAll(tasks);
        }

        public void StreamReaderSample()
        {
            Console.WriteLine("StreanReader");
            Console.WriteLine("============");

            StreamReader sr = new StreamReader("Sample.txt");

            string line = sr.ReadLine();

            while(line != null){
                Console.WriteLine(line);
                line = sr.ReadLine();
            }
        }

        public void StreamWriterSample()
        {
            Console.WriteLine("StreanWriter");
            Console.WriteLine("============");

            StreamWriter sw = new StreamWriter("Writer.txt");
            sw.WriteLine("Texto 01");
            sw.WriteLine("Texto 02");
            sw.WriteLine("Texto 03");

            sw.Close();
        }
        public class ParallelProcess{
            public void WriteProcess01(){
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Escribiendo desde el proceso 01 {i} -> : {i}");
                    Random rnd = new Random();
                    int waitTime = rnd.Next(1,100);
                    Thread.Sleep(waitTime * 100);
                }
            }

            public void WriteProcess01(string name){
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Escribiendo desde la {name} {i} -> : {i}");
                    Random rnd = new Random();
                    int waitTime = rnd.Next(1,100);
                    Thread.Sleep(waitTime * 100);
                }
            }

            public void WriteProcess02(){
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Escribiendo desde el proceso 02 {i} -> : {i}");
                    Random rnd = new Random();
                    int waitTime = rnd.Next(1,100);
                    Thread.Sleep(waitTime * 100);
                }
            }

            public void WriteProcess02(string name){
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Escribiendo desde la {name} {i} -> : {i}");
                    Random rnd = new Random();
                    int waitTime = rnd.Next(1,100);
                    Thread.Sleep(waitTime * 100);
                }
            }
        }

        public class TaskParameter{
            public string Name { get; set; }
        }
    }
}
