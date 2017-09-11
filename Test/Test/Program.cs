using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = {1, 3, 5, 7, 9, 11};
            int[] arr = {5, -9, 6, -2, 3};
            int[] maxArray = {4, 5, 2, 1, 7, 9};
            int[] minArray = {-6, -2, -3, -8, -1, -4};

            Console.WriteLine("\tДвоичный (бинарный) поиск!!!\n");

            Console.WriteLine("Ищем -1: {0}", BinarySearch(array, -1));
            Console.WriteLine("Ищем  3: {0}", BinarySearch(array, 3));
            Console.WriteLine("Ищем  6: {0}", BinarySearch(array, 6));
            Console.WriteLine("Ищем  9: {0}", BinarySearch(array, 9));
            Console.WriteLine("Ищем 11: {0}", BinarySearch(array, 11));
            Console.WriteLine("Ищем 20: {0}", BinarySearch(array, 20));

            Console.WriteLine("\n\tПоиск максимальной непрерывной подпоследовательности!!!\n");

            Console.WriteLine("Максимальное значение массива: {0}", GetMaxSum(arr));
            Console.WriteLine("Максимальное значение отрицательных элементов массива: {0}", GetMaxSum(minArray));
            Console.WriteLine("Максимальное значение положительныъ элементов массива: {0}", GetMaxSum(maxArray));

            Console.WriteLine("\nНажмите любую клавишу для завершения программы....");
            Console.ReadKey();
        }

        /// <summary>
        /// Бинарный поиск в массиве.
        /// </summary>
        /// <param name="array"> Массив типа int[] </param>
        /// <param name="value"> Искомый элемент. </param>
        /// <returns></returns>
        public static int BinarySearch(int[] array, int value)
        {
            // Проверить, имеет ли смыл вообще выполнять поиск:
            // - если длина массива равна нулю - искать нечего.
            if (array.Length == 0)
            {
                throw new ArgumentOutOfRangeException("array", "Массив должен содержать, как минимум, один элемент.");
            }
            
            // Номер первого элемента в массиве.
            var firstIndex = 0;

            // Номер элемента массива, СЛЕДУЮЩЕГО за последним
            var lastIndex = array.Length - 1;

            // Eсли искомый элемент меньше первого элемента массива, значит, вернем первый элемент.
            if (array[firstIndex] >= value)
                return firstIndex;

            // Eсли искомый элемент больше последнего элемента массива, значит, вернем последний элемент.
            if (array[lastIndex] <= value)
                return lastIndex;

            // Приступить к поиску.
            // Если просматриваемый участок не пуст, first <= last
            while (firstIndex <= lastIndex)
            {
                var middle = (firstIndex + lastIndex) / 2;

                if (value < array[middle])
                {
                    lastIndex = middle - 1;
                }
                else if (value > array[middle])
                {
                    firstIndex = middle + 1;
                }
                else
                {
                    return middle;
                }
            }
            return firstIndex;
        }

        /// <summary>
        /// Поиск максимальной непрерывной подпоследовательности.
        /// </summary>
        /// <param name="array"> Массив типа int[] </param>
        /// <returns></returns>
        public static int GetMaxSum(int[] array)
        {
            int sum = 0;
            int maxSum = 0;

            foreach (var item in array)
            {
                if (int.MaxValue - sum < item)
                    throw new Exception("Сумма элементов подмассива слишком велика.");

                sum += item;

                if (sum < 0)
                {
                    sum = 0;
                }
                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }

            return maxSum;
        }
    }
}
