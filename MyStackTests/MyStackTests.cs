using TMSHomework;

namespace MyStackTests
{
    public class MyStackTests
    {
        public MyStack<int> Stack = new();

        [Fact]
        public void Push_Test()
        {
            Stack.Push(1);

            Assert.Equal(1, Stack.Peek());
        }

        [Fact]
        public void Pop()
        {
            Stack.Push(1);
            Stack.Push(2);

            Assert.Equal(2, Stack.Pop());
            Assert.Equal(1, Stack.Peek());
        }

        [Fact]
        public void Peek()
        {
            Stack.Push(1);
            Stack.Push(2);

            Assert.Equal(2, Stack.Peek());
        }

        [Fact]
        public void Pop_ShouldEmptyStackExceptionThrows()
        {
            Stack.Push(1);
            Stack.Pop();
            Assert.Throws<EmptyStackException>(() => Stack.Pop());
        }

        [Fact]
        public void Peek_ShouldEmptyStackExceptionThrows()
        {
            Stack.Push(1);
            Stack.Pop();
            Assert.Throws<EmptyStackException>(() => Stack.Peek());
        }
    }
}