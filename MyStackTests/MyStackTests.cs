using TMSHomework;

namespace MyStackTests
{
    public class MyStackTests
    {
        public MyStack<int> ValueTypeStack = new();
        public MyStack<string> ReferenceTypeStack = new();

        [Fact]
        public void Push_Test()
        {
            ValueTypeStack.Push(1);
            ReferenceTypeStack.Push("1");

            Assert.Equal(1, ValueTypeStack.Peek());
            Assert.Equal("1", ReferenceTypeStack.Peek());
        }

        [Fact]
        public void Pop()
        {
            ValueTypeStack.Push(1);
            ValueTypeStack.Push(2);
            ReferenceTypeStack.Push("1");
            ReferenceTypeStack.Push("2");

            Assert.Equal(2, ValueTypeStack.Pop());
            Assert.Equal(1, ValueTypeStack.Peek());
            Assert.Equal("2", ReferenceTypeStack.Pop());
            Assert.Equal("1", ReferenceTypeStack.Peek());
        }

        [Fact]
        public void Peek()
        {
            ValueTypeStack.Push(1);
            ValueTypeStack.Push(2);
            ReferenceTypeStack.Push("1");
            ReferenceTypeStack.Push("2");

            Assert.Equal(2, ValueTypeStack.Peek());
            Assert.Equal("2", ReferenceTypeStack.Peek());
        }

        [Fact]
        public void Pop_ShouldEmptyStackExceptionThrows()
        {
            ValueTypeStack.Push(1);
            ValueTypeStack.Pop();
            ReferenceTypeStack.Push("1");
            ReferenceTypeStack.Pop();
            Assert.Throws<EmptyStackException>(() => ValueTypeStack.Pop());
            Assert.Throws<EmptyStackException>(() => ReferenceTypeStack.Pop());
        }

        [Fact]
        public void Peek_ShouldEmptyStackExceptionThrows()
        {
            ValueTypeStack.Push(1);
            ValueTypeStack.Pop();
            ReferenceTypeStack.Push("1");
            ReferenceTypeStack.Pop();
            Assert.Throws<EmptyStackException>(() => ValueTypeStack.Peek());
            Assert.Throws<EmptyStackException>(() => ReferenceTypeStack.Peek());
        }
    }
}