namespace TMSHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TMS Lesson12-Task1-GenericStackImitator");
            Console.WriteLine("Приложение реализует обобщенный стек");

            var stackVarType = new MyStack<int>();
            stackVarType.Push(1);
            stackVarType.Push(2);
            stackVarType.Push(3);
            Console.WriteLine(stackVarType.Peek());
            Console.WriteLine(stackVarType.Pop());
            Console.WriteLine(stackVarType.Peek());
            Console.WriteLine(stackVarType.Pop());
            Console.WriteLine(stackVarType.Peek());
            Console.WriteLine(stackVarType.Pop());

            var stackRefType = new MyStack<string>();
            stackRefType.Push("1");
            stackRefType.Push("2");
            stackRefType.Push("3");
            Console.WriteLine(stackRefType.Peek());
            Console.WriteLine(stackRefType.Pop());
            Console.WriteLine(stackRefType.Peek());
            Console.WriteLine(stackRefType.Pop());
            Console.WriteLine(stackRefType.Peek());
            Console.WriteLine(stackRefType.Pop());
            Console.WriteLine(stackRefType.Peek());
        }
    }
}
