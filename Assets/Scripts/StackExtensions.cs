using System;
using System.Collections.Generic;
namespace GreatDay
{
    public static class StackExtensions
    {
        public static bool TryPop<T>(this Stack<T> stack, out T result)
        {
            if (stack == null || stack.Count == 0)
            {
                result = default(T);
                return false;
            }

            result = stack.Pop();
            return true;
        }
    }
}