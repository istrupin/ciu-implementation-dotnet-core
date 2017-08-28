using System;
using System.Collections.Generic;

namespace Implementation.DataStructures
{
    public class BalancedParenCheck
    {
        private Stack<char> _stk;
        private char[] _open, _close;

        public BalancedParenCheck()
        {
            _open = new char[] {'(', '{', '['};
            _close = new char[] {')', '}', ']'};
            _stk = new Stack<Char>();
        }
        
        public bool Balanced(string input)
        {
            foreach (var item in input)
            {
                if (Array.IndexOf(_open, item) >= 0)
                {
                    _stk.Push(item);
                }
                else if (Array.IndexOf(_close, item) >= 0)
                {
                    if (item == _close[Array.IndexOf(_open,_stk.Peek())])
                    {
                        _stk.Pop();
                    }
                    else return false;
                }
                else return false;
            }
            return _stk.Count == 0;
        }
    }
}