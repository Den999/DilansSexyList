using System;

namespace LinkedList
{
    class Program
    {
        /// <summary>
        /// Prints not equals error.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private static void PrintError(int a, int b)
        {
            Console.WriteLine($"Error: {a} not equals to {b}!");
        }

        /// <summary>
        /// Shortly log.
        /// </summary>
        /// <param name="message"></param>
        /// <typeparam name="T"></typeparam>
        private static void Log<T>(T message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Test our linked list.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var testList = new LinkedList<int>();
            Log(testList);
            int countOfTests = 10;
            for(var i = 0; i < countOfTests; i++)
            {
                testList.AddItem(i);
            }
            
            Log(testList);
            if(testList.Length != countOfTests)
            {
                PrintError(testList.Length, countOfTests);
                return;
            }
            
            testList.RemoveItem(0);
            if (testList.Length != countOfTests-1)
            {
                PrintError(testList.Length, 9);
                return;
            }
            
            for(var i = 0; i < countOfTests-1; i++)
            {
                if (testList[i] == i + 1) 
                    continue;
                
                PrintError(testList[i], i+1);
                return;
            }
            
            testList[3] = 100;
            while (!testList.IsEmpty())
            {
                testList.RemoveItem(0);
            }
            Log(testList);
            
            if (!testList.IsEmpty())
            {
                Log("Error: List should be empty!");
                return;
            }
            
            // Yeah!
            Log("Tests successfully completed!");
            Console.ReadLine();
        }
    }
}
