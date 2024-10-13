namespace Fibonacci_search
{
    internal class Program
    {
        // Функция за Фибоначи търсене
        static int FibonacciSearch(int[] arr, int x)
        {
            int n = arr.Length;

            // Инициализиране на Фибоначи числа
            int fib2 = 0;  // (n-2)-то Фибоначи число
            int fib1 = 1;  // (n-1)-то Фибоначи число
            int fibM = fib1 + fib2;  // n-то Фибоначи число

            // Намиране на най-малкото Фибоначи число >= n
            while (fibM < n)
            {
                fib2 = fib1;
                fib1 = fibM;
                fibM = fib1 + fib2;
            }

            // Маркиране на отрязък
            int offset = -1;

            // Докато има елементи за проверка
            while (fibM > 1)
            {
                // Проверка на валиден индекс
                int i = Math.Min(offset + fib2, n - 1);

                // Ако елементът е по-малък, премахваме лявата част
                if (arr[i] < x)
                {
                    fibM = fib1;
                    fib1 = fib2;
                    fib2 = fibM - fib1;
                    offset = i;
                }
                // Ако елементът е по-голям, премахваме дясната част
                else if (arr[i] > x)
                {
                    fibM = fib2;
                    fib1 = fib1 - fib2;
                    fib2 = fibM - fib1;
                }
                // Ако намерим елемента
                else
                {
                    return i;
                }
            }

            // Проверка на последния оставащ елемент
            if (fib1 == 1 && arr[offset + 1] == x)
            {
                return offset + 1;
            }

            // Елементът не е намерен
            return -1;
        }

        static void Main(string[] args)
        {
            // Четене на размера на масива
            int nesto = int.Parse(Console.ReadLine());

            // Създаване и попълване на масива
            int[] arr = new int[nesto];
            for (int i = 0; i < nesto; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            // Четене на числото, което ще търсим
            int n = int.Parse(Console.ReadLine());

            // Извикване на функцията за Фибоначи търсене и отпечатване на резултата
            int result = FibonacciSearch(arr, n);
            Console.WriteLine(result);
        }
    }
}

