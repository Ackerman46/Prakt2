using System;
using System.Data;
using System.IO;

namespace Libmas
{
    public class LibTask
    {
        /// <summary>
        /// Заполнение одномерного массива
        /// </summary>
        /// <param name="arr">Массив(одномерный)</param>
        /// <param name="maxValue">Максимальное значение для диапозона случ. чисел</param>
        public static void FillArr(ref int[] arr, int maxValue)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(0, maxValue);
            }
        }
        /// <summary>
        /// Заполнение двумерного массива
        /// </summary>
        /// <param name="arr">Массив(двумерный)</param>
        /// <param name="maxValue">Максимальное значение для диапозона случ. чисел</param>
        public static void FillArr(ref int[,] arr, int maxValue)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rnd.Next(0, maxValue);
                }
            }
        }
        /// <summary>
        /// Очистка одномерного массива
        /// </summary>
        /// <param name="arr">Массив(одномерный)</param>
        public static void ClearArr(ref int[] arr)
        {
            arr = null;
        }
        /// <summary>
        /// Очистка двумерного массива
        /// </summary>
        /// <param name="arr">Массив(двумерный)</param>
        public static void ClearArr(ref int[,] arr)
        {
            arr = null;
        }
        /// <summary>
        /// Сохранение одномерного массива
        /// </summary>
        /// <param name="arr">Массив(одномерный)</param>
        /// <param name="path">Путь который выбрал пользователь</param>
        public static void SaveArr(int[] arr, string path)
        {
            StreamWriter file = new StreamWriter(path);
            file.WriteLine(arr.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                file.WriteLine($"{arr[i]}");
            }
            file.Close();
        }
        /// <summary>
        /// Сохранение двумерного массива
        /// </summary>
        /// <param name="arr">Массив(двумерный)</param>
        /// <param name="path">Путь который выбрал пользователь</param>
        public static void SaveArr(int[,] arr, string path)
        {
            StreamWriter file = new StreamWriter(path);
            file.WriteLine(arr.GetLength(0));
            file.WriteLine(arr.GetLength(1));
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    file.WriteLine($"{arr[i, j]}");
                }
            }
            file.Close();
        }
        /// <summary>
        /// Заполнение одномерного массива с файла
        /// </summary>
        /// <param name="arr">Массив(одномерный)</param>
        /// <param name="path">Путь который выбрал пользователь</param>
        public static void UploadArr(ref int[] arr, string path)
        {
            StreamReader read = new StreamReader(path);
            int.TryParse(read.ReadLine(), out int len);
            arr = new int[len];
            for (int i = 0; i < arr.Length; i++)
            {
                int.TryParse(read.ReadLine(), out int value);
                arr[i] = value;
            }
            read.Close();
        }
        /// <summary>
        /// Заполнение двумерного массива с файла
        /// </summary>
        /// <param name="arr">Массив(двумерный)</param>
        /// <param name="path">Путь который выбрал пользователь</param>
        public static void UploadArr(ref int[,] arr, string path)
        {
            StreamReader read = new StreamReader(path);
            int.TryParse(read.ReadLine(), out int rows);
            int.TryParse(read.ReadLine(), out int columns);
            arr = new int[rows, columns];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    int.TryParse(read.ReadLine(), out int value);
                    arr[i, j] = value;
                }
            }
            read.Close();
        }
    }
    //Класс для связывания массива с элементом DataGrid
    //для визуализации данных 
    public static class VisualArray
    {
        //Метод для одномерного массива
        public static DataTable ToDataTable<T>(this T[] arr)
        {
            var res = new DataTable();
            for (int i = 0; i < arr.Length; i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }
            var row = res.NewRow();
            for (int i = 0; i < arr.Length; i++)
            {
                row[i] = arr[i];
            }
            res.Rows.Add(row);
            return res;
        }
        //Метод для двухмерного массива
        public static DataTable ToDataTable<T>(this T[,] matrix)
        {
            var res = new DataTable();
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row[j] = matrix[i, j];
                }

                res.Rows.Add(row);
            }

            return res;
        }
    }
}