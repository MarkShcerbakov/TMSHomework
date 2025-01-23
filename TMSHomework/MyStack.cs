using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    public class MyStack<T>
    {
        private List<T> _stack;

        public MyStack()
        {
            _stack = new();
        }

        public void Push(T pushItem)
        {
            _stack.Add(pushItem);
        }

        public T Pop()
        {
            CheckEmptyStack();
            var popItem = _stack.Last();
            _stack.RemoveAt(_stack.Count - 1);
            return popItem;
        }

        public T Peek()
        {
            CheckEmptyStack();
            return _stack.Last();
        }

        private bool IsEmpty()
        {
            return _stack.Count == 0;
        }

        private void CheckEmptyStack()
        {
            if (IsEmpty())
            {
                throw new EmptyStackException("Невозможно выполнить операцию! Стек пуст!");
            }
        }
    }
}
