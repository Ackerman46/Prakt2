using System;

namespace Lib_12
{
    public class LibArr
    {
        /// <summary>
        /// Считает сумму чисел в диапозоне от 0 до n, где n - кол-во случ. значений
        /// </summary>
        /// <param name="generNumbers">Сгенерированные числа</param>
        /// <param name="n">Предел для диапозона случ. чисел</param>
        /// <returns>Сумму чисел</returns>
        public static int SumOfNumbers(out string generNumbers, int n) // метод к Практической работе №1
        {
            Random rnd = new Random();
            generNumbers = "";
            int randNum, sum = 0;
            for (int i = 0; i < n; i++)
            {
                randNum = rnd.Next(0, n);
                generNumbers = $"{randNum}" + " " + generNumbers;
                sum += randNum;
            }
            return sum;
        }
        /// <summary>
        /// Находит сумму чисел < 15
        /// </summary>
        /// <param name="arr">Массив(Одномерный)</param>
        /// <returns>Сумму чисел < 15</returns>
        public static int SumOfElem(int[] arr)// метод к практической работе №2
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] > 15)
                {
                    sum += arr[i];
                }
            }
            return sum;
        }
        /// <summary>
        /// Находит минимальный элемент среди максимальных элементов столбцов
        /// </summary>
        /// <param name="mas">Массив(Двумерный)</param>
        /// <returns>Минимальный элемент</returns>
        public static int MinOfMaxColumnArr(int[,] mas)// метод к практической работе №3
        {
            int[] tmp = new int[mas.GetLength(1)];
            int value_answer;
            for (int j = 0; j < mas.GetLength(1); j++)
            {
                int min = mas[0,j];
                for (int i = 0; i < mas.GetLength(0); i++)
                {
                    if (mas[i,j] > min)
                    {
                        min = mas[i,j];
                    }
                }
                tmp[j] = min;
            }
            value_answer = tmp[0];
            for (int i = 0; i < tmp.Length; i++)
            {

                if (tmp[i] <= value_answer)
                {
                    value_answer = tmp[i];
                }
            }
            return value_answer;
        }
    }
}
