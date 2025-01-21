using TMSHomework;

namespace ExecutionManagerTests
{
    public class ExecutionManagerTests
    {
        public ExecutionManager exManager = new(6, 2);

        [Fact]
        public void Addition_Test()
        {
            var result = exManager.Execute(Operation.Addition);
            Assert.Equal(8, result);
        }

        [Fact]
        public void Substraction_Test()
        {
            var result = exManager.Execute(Operation.Subtraction);
            Assert.Equal(4, result);
        }

        [Fact]
        public void Multiplication_Test()
        {
            var result = exManager.Execute(Operation.Multiplication);
            Assert.Equal(12, result);
        }

        [Fact]
        public void Division_Test()
        {
            var result = exManager.Execute(Operation.Division);
            Assert.Equal(3, result);
        }
    }
}