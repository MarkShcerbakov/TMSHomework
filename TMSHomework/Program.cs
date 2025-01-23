namespace TMSHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var opManager = new OperationManager(20, 10);
            var opResult = opManager.Execute(Operation.Addition);
            Console.WriteLine($"The result of the operation in OperationManager is {opResult}.");
            Console.ReadKey();
        }
    }
}
