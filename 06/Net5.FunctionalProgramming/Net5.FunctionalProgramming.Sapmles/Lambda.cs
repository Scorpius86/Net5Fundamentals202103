using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.FunctionalProgramming.Sapmles
{
    public class Lambda
    {
        delegate int operationDalegate(int x, int y);
        private int suma(int a , int b)
        {
            return a + b;
        }
        public void DoWork()
        {
            Print(5, 5, suma);
            Print(5, 5, (a,b) =>
            {
                return a + b;
            });
            Print(5, 5, (a, b) => a + b);
            Print(4, 2, (x, y) => x * y);
            Print(6, 6, (a, b) => a + b);
            Print(144, 666, (x, y) => x * y);

            FunctionDelegate();
            ActionDelegate();
        }

        private void Print(int a, int b,operationDalegate operation)
        {
            int result = operation(a, b);
            Console.WriteLine($"Imprimiendo : {result}");
        }

        private void FunctionDelegate()
        {
            //Func<string, string> selector = ToUpper;
            Func<string, string> selector = (str) => str.ToUpper();
            List<string> words = new List<string> { "Naranja", "Manzana", "Articulo", "Elefante" };
            //List<string> aWords = words.Select(ToUpper).ToList();
            //IEnumerable<String> aWods = words.Select((str)=> {
            //    return str.ToUpper();
            //});
            //IEnumerable<String> aWods = words.Select((str) => str.ToUpper());
            List<string> aWords = words.Select(selector).ToList();
            aWords.ForEach(w =>
            {
                Console.WriteLine(w);
            });
        }

        private void ActionDelegate()
        {
            Action<string> messageTarget;
            string param = "";

            if (param.Length > 1)
            {
                messageTarget = ShowWindowsMessage;
            }
            else
            {
                messageTarget = Console.WriteLine;
            }

            messageTarget("Hola Mundo");
        }

        private string ToUpper (string s)
        {
            return s.ToUpper();
        }

        private void ShowWindowsMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
