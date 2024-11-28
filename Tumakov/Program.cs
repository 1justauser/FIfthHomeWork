using Microsoft.VisualBasic.FileIO;
using System.Data;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace FifthHomeWork
{
    public class Tumakov
    {
        static void Unicode_Utf8()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
        }

        static bool IsCharInString(char letter, string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (letter == word[i])
                {
                    return true;
                }
            }
            return false;
        }

        static void CountVowelConsonant(string word, out int vowelCount, out int consonantCount)
        {

            string vowelEnumarion = "aeiouауоиэыяюеёAEIOUАУОИЭЫЯЮЕЁ";
            vowelCount = 0;
            consonantCount = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (char.IsLetter(word[i]))
                {
                    if (IsCharInString(word[i], vowelEnumarion))
                    {
                        vowelCount++;
                    }
                    else
                    {
                        consonantCount++;
                    }
                }
            }
        }
        static void CountVowelConsonant(List<char> word, out int vowelCount, out int consonantCount)
        {

            string vowelEnumarion = "aeiouауоиэыяюеёAEIOUАУОИЭЫЯЮЕЁ";
            vowelCount = 0;
            consonantCount = 0;
            for (int i = 0; i < word.Count; i++)
            {
                if (char.IsLetter(word[i]))
                {
                    if (IsCharInString(word[i], vowelEnumarion))
                    {
                        vowelCount++;
                    }
                    else
                    {
                        consonantCount++;
                    }
                }
            }
        }
        static void Exersice1(string fileName)
        {
            //Упражнение 6.1 Написать программу, которая вычисляет число гласных и согласных букв в
            //файле.Имя файла передавать как аргумент в функцию Main. Содержимое текстового файла
            //заносится в массив символов.Количество гласных и согласных букв определяется проходом
            //по массиву.Предусмотреть метод, входным параметром которого является массив символов.
            ///Метод вычисляет количество гласных и согласных букв.
            Console.WriteLine("Упражнение 6.1");
            Console.WriteLine("Необходимо заполнить текстовый документ, чтобы посчитать количество");
            Console.WriteLine("гласных и согласных");
            string fileContent = File.ReadAllText(fileName);
            CountVowelConsonant(fileContent, out int vowelCount, out int consonantCount);
            Console.WriteLine($"Файл {fileName} содержит {vowelCount} гласных и {consonantCount} согласных");
        }
        static void MatrixMultiplication(int[,] matrix1, int[,] matrix2, out int[,] matrix3)
        {
            if (matrix1.GetLength(1) == matrix2.GetLength(0))
            {
                matrix3 = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
                for (int i = 0; i < matrix3.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix3.GetLength(1); j++)
                    {
                        matrix3[i, j] = 0;
                        for (int r = 0; r < matrix1.GetLength(1); r++)
                        {
                            matrix3[i, j] += matrix1[i, r] * matrix2[r, j];
                        }
                    }
                }
            }
            else
            {
                matrix3 = new int[matrix1.GetLength(1), matrix2.GetLength(0)];
                for (int i = 0; i < matrix3.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix3.GetLength(1); j++)
                    {
                        matrix3[i, j] = 0;
                        for (int r = 0; r < matrix1.GetLength(0); r++)
                        {
                            matrix3[i, j] += matrix1[i, r] * matrix2[r, j];
                        }
                    }
                }
            }
        }

        static void MatrixMultiplication(LinkedList<LinkedList<int>> matrix1,
            LinkedList<LinkedList<int>> matrix2, out LinkedList<LinkedList<int>> matrix3,
            int rowValue1, int rowValue2, int columnValue1, int columnValue2)
        {
            matrix3 = new LinkedList<LinkedList<int>>();
            if (columnValue1 == rowValue2)
            {
                for (int i = 0; i < matrix1.Count; i++)
                {
                    matrix3.AddLast(new LinkedList<int>());
                }
                foreach (LinkedList<int> row in matrix3)
                {
                    for (int i = 0; i < columnValue2; i++)
                    {
                        int sum = 0;
                        for (int r = 0; r < columnValue1; r++)
                        {
                            int firstValue = 0;
                            int firstRowIndex = 0;
                            foreach (LinkedList<int> firstRow in matrix1)
                            {
                                if (firstRowIndex == i)
                                {
                                    int firstColumnIndex = 0;
                                    foreach (int firstColumn in firstRow)
                                    {
                                        if (firstColumnIndex == r)
                                        {
                                            firstValue = firstColumn;
                                            break;
                                        }
                                        firstColumnIndex++;
                                    }
                                }
                                firstRowIndex++;
                            }
                            int secondValue = 0;
                            int secondRowIndex = 0;
                            foreach (LinkedList<int> secondRow in matrix2)
                            {
                                if (secondRowIndex == r)
                                {
                                    int secondColumnIndex = 0;
                                    foreach (int secondColumn in secondRow)
                                    {
                                        if (secondColumnIndex == i)
                                        {
                                            secondValue = secondColumn;
                                            break;
                                        }
                                        secondColumnIndex++;
                                    }
                                }
                                secondRowIndex++;
                            }
                            sum += firstValue * secondValue;
                        }
                        row.AddLast(sum);
                    }
                }
            }
            else
            {
                for (int i = 0; i < matrix2.Count; i++)
                {
                    matrix3.AddLast(new LinkedList<int>());
                }
                foreach (LinkedList<int> row in matrix3)
                {
                    for (int i = 0; i < columnValue1; i++)
                    {
                        int sum = 0;
                        for (int r = 0; r < columnValue2; r++)
                        {
                            int firstValue = 0;
                            int firstRowIndex = 0;
                            foreach (LinkedList<int> firstRow in matrix2)
                            {
                                if (firstRowIndex == i)
                                {
                                    int firstColumnIndex = 0;
                                    foreach (int firstColumn in firstRow)
                                    {
                                        if (firstColumnIndex == r)
                                        {
                                            firstValue = firstColumn;
                                            break;
                                        }
                                        firstColumnIndex++;
                                    }
                                }
                                firstRowIndex++;
                            }
                            int secondValue = 0;
                            int secondRowIndex = 0;
                            foreach (LinkedList<int> secondRow in matrix1)
                            {
                                if (secondRowIndex == r)
                                {
                                    int secondColumnIndex = 0;
                                    foreach (int secondColumn in secondRow)
                                    {
                                        if (secondColumnIndex == i)
                                        {
                                            secondValue = secondColumn;
                                            break;
                                        }
                                        secondColumnIndex++;
                                    }
                                }
                                secondRowIndex++;
                            }
                            sum = firstValue * secondValue;
                        }
                        row.AddLast(sum);
                    }
                }
            }
        }

        static void MatrixOutput(LinkedList<LinkedList<int>> matrix)
        {
            foreach (LinkedList<int> row in matrix)
            {
                foreach (int element in row)
                {
                    Console.Write($"{element} ");
                }
                Console.WriteLine();
            }
        }

        static void MatrixOutput(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        static void Exersise2()
        {
            Console.WriteLine("Укажите количество строк первой матрицы");
            if (!int.TryParse(Console.ReadLine(), out int rowValue1) && rowValue1 > 0)
            {
                Console.WriteLine("Ошибка нужно натуральное число");
                return;
            }
            Console.WriteLine("Укажите количество столбцов первой матрицы");
            if (!int.TryParse(Console.ReadLine(), out int columnValue1) && columnValue1 > 0)
            {
                Console.WriteLine("Ошибка нужно натуральное число");
                return;
            }
            Console.WriteLine("Укажите количество строк второй матрицы");
            if (!int.TryParse(Console.ReadLine(), out int rowValue2) && rowValue2 > 0)
            {
                Console.WriteLine("Ошибка нужно натуральное число");
                return;
            }
            Console.WriteLine("Укажите количество столбцов второй матрицы");
            if (!int.TryParse(Console.ReadLine(), out int columnValue2) && columnValue2 > 0)
            {
                Console.WriteLine("Ошибка нужно натуральное число");
                return;
            }
            int[,] matrix1 = new int[rowValue1, columnValue1];
            int[,] matrix2 = new int[rowValue2, columnValue2];
            Console.WriteLine("Введите значения элементов матриц");
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    Console.WriteLine($"Введите значение для {i + 1} {j + 1} значения первой Матрицы");
                    if (!int.TryParse(Console.ReadLine(), out matrix1[i, j]))
                    {
                        Console.WriteLine("Нужно целочисленное число");
                        return;
                    }
                }
            }
            for (int i = 0; i < matrix2.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    Console.WriteLine($"Введите значение для {i + 1} {j + 1} значения второй Матрицы");
                    if (!int.TryParse(Console.ReadLine(), out matrix2[i, j]))
                    {
                        Console.WriteLine("Нужно целочисленное число");
                        return;
                    }
                }
            }
            Console.WriteLine("Перемножим две матрицы");
            if (rowValue1 != columnValue2 && rowValue2 != columnValue1)
            {
                Console.WriteLine("Произвести умножение двух матриц можно, только " +
                    "если количество столбцов одной матрицы равно количеству строк второй матрицы");
                return;
            }
            MatrixMultiplication(matrix1, matrix2, out int[,] matrix3);
            Console.WriteLine("Результат:");
            MatrixOutput(matrix3);
        }

        static void MonthAverageTemperature(int[,] temperature, out int[] monthAverageTemperature)
        {
            monthAverageTemperature = new int[12];
            for (int i = 0; i < monthAverageTemperature.Length; i++)
            {
                for (int j = 0; j < temperature.GetLength(1); j++)
                {
                    monthAverageTemperature[i] += temperature[i, j];
                }
                monthAverageTemperature[i] = monthAverageTemperature[i] / 30;
            }
        }
        static void MonthAverageTemperature(int[,] temperature, Dictionary<string, int> monthAverageTemperature)
        {
            monthAverageTemperature["январь"] = 0;
            for (int j = 0; j < temperature.GetLength(1); j++)
            {
                monthAverageTemperature["январь"] += temperature[0, j];
            }
            monthAverageTemperature["январь"] = monthAverageTemperature["январь"] / 30;
            monthAverageTemperature["февраль"] = 0;
            for (int j = 0; j < temperature.GetLength(1); j++)
            {
                monthAverageTemperature["февраль"] += temperature[1, j];
            }
            monthAverageTemperature["февраль"] = monthAverageTemperature["февраль"] / 30;
            monthAverageTemperature["март"] = 0;
            for (int j = 0; j < temperature.GetLength(1); j++)
            {
                monthAverageTemperature["март"] += temperature[2, j];
            }
            monthAverageTemperature["март"] = monthAverageTemperature["март"] / 30;
            monthAverageTemperature["апрель"] = 0;
            for (int j = 0; j < temperature.GetLength(1); j++)
            {
                monthAverageTemperature["апрель"] += temperature[3, j];
            }
            monthAverageTemperature["апрель"] = monthAverageTemperature["апрель"] / 30;
            monthAverageTemperature["май"] = 0;
            for (int j = 0; j < temperature.GetLength(1); j++)
            {
                monthAverageTemperature["май"] += temperature[4, j];
            }
            monthAverageTemperature["май"] = monthAverageTemperature["май"] / 30;
            monthAverageTemperature["июнь"] = 0;
            for (int j = 0; j < temperature.GetLength(1); j++)
            {
                monthAverageTemperature["июнь"] += temperature[5, j];
            }
            monthAverageTemperature["июнь"] = monthAverageTemperature["июнь"] / 30;
            monthAverageTemperature["июль"] = 0;
            for (int j = 0; j < temperature.GetLength(1); j++)
            {
                monthAverageTemperature["июль"] += temperature[6, j];
            }
            monthAverageTemperature["июль"] = monthAverageTemperature["июль"] / 30;
            monthAverageTemperature["август"] = 0;
            for (int j = 0; j < temperature.GetLength(1); j++)
            {
                monthAverageTemperature["август"] += temperature[7, j];
            }
            monthAverageTemperature["август"] = monthAverageTemperature["август"] / 30;
            monthAverageTemperature["сентябрь"] = 0;
            for (int j = 0; j < temperature.GetLength(1); j++)
            {
                monthAverageTemperature["сентябрь"] += temperature[8, j];
            }
            monthAverageTemperature["сентябрь"] = monthAverageTemperature["сентябрь"] / 30;
            monthAverageTemperature["октябрь"] = 0;
            for (int j = 0; j < temperature.GetLength(1); j++)
            {
                monthAverageTemperature["октябрь"] += temperature[9, j];
            }
            monthAverageTemperature["октябрь"] = monthAverageTemperature["октябрь"] / 30;
            monthAverageTemperature["ноябрь"] = 0;
            for (int j = 0; j < temperature.GetLength(1); j++)
            {
                monthAverageTemperature["ноябрь"] += temperature[10, j];
            }
            monthAverageTemperature["ноябрь"] = monthAverageTemperature["ноябрь"] / 30;
            monthAverageTemperature["декабрь"] = 0;
            for (int j = 0; j < temperature.GetLength(1); j++)
            {
                monthAverageTemperature["декабрь"] += temperature[11, j];
            }
            monthAverageTemperature["декабрь"] = monthAverageTemperature["декабрь"] / 30;
        }
        static void Exersice3()
        {
            //Упражнение 6.3 Написать программу, вычисляющую среднюю
            //температуру за год. Создать двумерный рандомный массив temperature[12, 30], в
            //котором будет храниться температура для каждого дня месяца(предполагается,
            //что в каждом месяце 30 дней).Сгенерировать значения температур случайным
            //образом.Для каждого месяца распечатать среднюю температуру. Для этого
            //написать метод, который по массиву temperature[12, 30] для каждого месяца
            //вычисляет среднюю температуру в нем, и в качестве результата возвращает
            //массив средних температур.Полученный массив средних температур
            //отсортировать по возрастанию.
            Console.WriteLine("Упражнение 6.3");
            int[,] temperature = new int[12, 30];
            Random rand = new Random();
            for (int i = 0; i < temperature.GetLength(0); i++)
            {
                for (int j = 0; j < temperature.GetLength(1); j++)
                {
                    temperature[i, j] = rand.Next(0, 30);
                }
            }
            MonthAverageTemperature(temperature, out int[] monthAverageTemperature);
            Console.WriteLine("Средние значения для каждого месяца");
            for (int i = 0; i < monthAverageTemperature.Length; i++)
            {
                Console.Write($"{monthAverageTemperature[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine("Средние отсортированные значения для каждого месяца");
            Array.Sort(monthAverageTemperature);
            for (int i = 0; i < monthAverageTemperature.Length; i++)
            {
                Console.Write($"{monthAverageTemperature[i]} ");
            }
        }
        static void HomeWork3()
        {
            //Домашнее задание 6.3 Написать программу для упражнения 6.3, использовав класс
            //Dictionary<TKey, TValue>.В качестве ключей выбрать строки – названия месяцев, а в
            //качестве значений – массив значений температур по дням.
            Console.WriteLine("Упражнение 6.3");
            int[,] temperature = new int[12, 30];
            Random rand = new Random();
            for (int i = 0; i < temperature.GetLength(0); i++)
            {
                for (int j = 0; j < temperature.GetLength(1); j++)
                {
                    temperature[i, j] = rand.Next(0, 30);
                }
            }
            Dictionary<string, int> monthAverageTemperature = new Dictionary<string, int>();
            MonthAverageTemperature(temperature, monthAverageTemperature);
            Console.WriteLine("Средние значения для каждого месяца");
            foreach(string key in monthAverageTemperature.Keys)
            {
                Console.WriteLine($"{key} - {monthAverageTemperature[key]}");
            }
            Console.WriteLine();
        }
        static void HomeWork1(string fileName)
        {
            //Домашнее задание 6.1 Упражнение 6.1 выполнить с помощью коллекции
            //List<T>.
            Console.WriteLine("Домашнее задание 6.1");
            Console.WriteLine("Необходимо заполнить текстовый документ, чтобы посчитать количество");
            Console.WriteLine("гласных и согласных");
            List<char> fileContent = new List<char>();
            foreach (char fileChar in File.ReadAllText(fileName))
            {
                fileContent.Add(fileChar);
            }
            CountVowelConsonant(fileContent, out int vowelCount, out int consonantCount);
            Console.WriteLine($"Файл {fileName} содержит {vowelCount} гласных и {consonantCount} согласных");
        }
        static void HomeWork2()
        {
            //Домашнее задание 6.2 Упражнение 6.2 выполнить с помощью коллекций
            //LinkedList<LinkedList<T>>.
            Console.WriteLine("Укажите количество строк первой матрицы");
            if (!int.TryParse(Console.ReadLine(), out int rowValue1) && rowValue1 > 0)
            {
                Console.WriteLine("Ошибка нужно натуральное число");
                return;
            }
            Console.WriteLine("Укажите количество столбцов первой матрицы");
            if (!int.TryParse(Console.ReadLine(), out int columnValue1) && columnValue1 > 0)
            {
                Console.WriteLine("Ошибка нужно натуральное число");
                return;
            }
            Console.WriteLine("Укажите количество строк второй матрицы");
            if (!int.TryParse(Console.ReadLine(), out int rowValue2) && rowValue2 > 0)
            {
                Console.WriteLine("Ошибка нужно натуральное число");
                return;
            }
            Console.WriteLine("Укажите количество столбцов второй матрицы");
            if (!int.TryParse(Console.ReadLine(), out int columnValue2) && columnValue2 > 0)
            {
                Console.WriteLine("Ошибка нужно натуральное число");
                return;
            }
            LinkedList<LinkedList<int>> matrix1 = new LinkedList<LinkedList<int>>();
            LinkedList<LinkedList<int>> matrix2 = new LinkedList<LinkedList<int>>();
            Console.WriteLine("Введите значения элементов матриц");
            for (int i = 0; i < rowValue1; i++)
            {
                matrix1.AddLast(new LinkedList<int>());
            }
            int rowCount = 0;
            foreach (LinkedList<int> row in matrix1)
            {
                rowCount++;
                for (int i = 0; i < columnValue1; i++)
                {
                    Console.WriteLine($"Введите значение для {rowCount} {i + 1} значения первой Матрицы");
                    int element;
                    if (!int.TryParse(Console.ReadLine(), out element))
                    {
                        Console.WriteLine("Нужно целочисленное число");
                        return;
                    }
                    row.AddLast(element);
                }
            }
            rowCount = 0;
            for (int i = 0; i < rowValue2; i++)
            {
                matrix2.AddLast(new LinkedList<int>());
            }
            foreach (LinkedList<int> row in matrix2)
            {
                rowCount++;
                for (int i = 0; i < columnValue2; i++)
                {
                    Console.WriteLine($"Введите значение для {rowCount} {i + 1} значения второй Матрицы");
                    int element;
                    if (!int.TryParse(Console.ReadLine(), out element))
                    {
                        Console.WriteLine("Нужно целочисленное число");
                        return;
                    }
                    row.AddLast(element);
                }
            }
            Console.WriteLine("Перемножим две матрицы");
            if (rowValue1 != columnValue2 && rowValue2 != columnValue1)
            {
                Console.WriteLine("Произвести умножение двух матриц можно, только " +
                    "если количество столбцов одной матрицы равно количеству строк второй матрицы");
                return;
            }
            MatrixMultiplication(matrix1, matrix2, out LinkedList<LinkedList<int>> matrix3, rowValue1, rowValue2, columnValue1, columnValue2);
            Console.WriteLine("Результат:");
            MatrixOutput(matrix3);
        }
        static void Main(string[] args)
        {
            int argsIndex = 0;
            //Unicode_Utf8();
            //если не работает русский язык в консоли
            try
            {
                Exersice1(args[argsIndex]);
                argsIndex++;
            }
            catch (Exception IndexOutOfRangeException)
            {
                try
                {
                    Console.WriteLine("Не указано имя файла как аргумент Main");
                    Console.WriteLine("Считаем text.txt как дефолт");
                    Exersice1("text.txt");
                }
                catch (Exception FileNotFoundException)
                {
                    Console.WriteLine("Перенесите файл text.txt в net8.0");
                }
            }
            Exersise2();
            Exersice3();
            try
            {
                HomeWork1(args[argsIndex]);
                argsIndex++;
            }
            catch (Exception IndexOutOfRangeException)
            {
                try
                {
                    Console.WriteLine("Не указано имя файла как аргумент Main");
                    Console.WriteLine("Считаем text.txt как дефолт");
                    HomeWork1("text.txt");
                }
                catch (Exception FileNotFoundException)
                {
                    Console.WriteLine("Перенесите файл text.txt в net8.0");
                }
            }
            HomeWork2();
            HomeWork3();
            HomeWork2();
        }
    }
}
