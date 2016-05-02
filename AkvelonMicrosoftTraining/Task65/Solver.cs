using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task65
{
    /// <summary>
    /// 65.Given a singly linked list, print out its contents in reverse order. Can you do it without using any extra space?
    /// </summary>
    public static class Solver
    {
        private static void Invert(ref Node head)
        {
            Node current = head;
            Node previous = null;
            while (current != null)
            {
                var previousNext = current.Next;
                current.Next = previous;
                previous = current;
                current = previousNext;
            }
            head = previous;
        }
        public static void PrintReverseOrder(TextWriter output, Node node)
        {
            if (output == null)
            {
                throw new ArgumentNullException("output");
            }
            Invert(ref node);
            var current = node;
            while (current != null)
            {
                output.Write("{0} ", current.Value);
                current = current.Next;
            }
            Invert(ref node);
        }
    }
}
