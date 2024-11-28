namespace FifthHomeWork
{
    public class Tasks
    {
        static void StartTask(int n)
        {
            Console.WriteLine("Задача {0}", n);
        }
        static void Task1()
        {
            StartTask(1);
            Console.WriteLine("213");
        }
        static void Main(string[] args)
        {
            Task1();
        }
    }
}