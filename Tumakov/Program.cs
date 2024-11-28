using System.Text;

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

        static void MatrixOutput(int[,] matrix)
        {
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
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
            if(!int.TryParse(Console.ReadLine(),out int rowValue2) && rowValue2>0)
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
            if(rowValue1!=columnValue2 && rowValue2 != columnValue1)
            {
                Console.WriteLine("Произвести умножение двух матриц можно, только " +
                    "если количество столбцов одной матрицы равно количеству строк второй матрицы");
                return;
            }
            MatrixMultiplication(matrix1,matrix2,out int[,] matrix3);
            Console.WriteLine("Результат:");
            MatrixOutput(matrix3);
        }
        
        static void Main(string[] args)
        {
            int argsIndex = 0;
            Unicode_Utf8();
            //если не работает русский язык в консоли
            try
            {
                Exersice1(args[argsIndex]);
                argsIndex++;
            }
            catch (Exception IndexOutOfRangeException)
            {
                Console.WriteLine("Не указано имя файла как аргумент Main");
                Console.WriteLine("Считаем text.txt как дефолт");
                Exersice1("text.txt");
            }
            Exersise2();
        }
    }
}