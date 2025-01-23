using TMSHomework;

namespace OperationManagerTests
{
    public class OperationManagerTests
    {
        public OperationManager opManager = new(6, 2);

        [Fact]
        public void Addition_Test()
        {
            var result = opManager.Execute(Operation.Addition);
            Assert.Equal(8, result);
        }

        [Fact]
        public void Substraction_Test()
        {
            var result = opManager.Execute(Operation.Subtraction);
            Assert.Equal(4, result);
        }

        [Fact]
        public void Multiplication_Test()
        {
            var result = opManager.Execute(Operation.Multiplication);
            Assert.Equal(12, result);
        }

        [Fact]
        public void Division_Test()
        {
            var result = opManager.Execute(Operation.Division);
            Assert.Equal(3, result);
        }
    }
}