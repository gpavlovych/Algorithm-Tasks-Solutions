namespace Task8
{
    /// <summary>
    /// 8. Given a LinkedList like 1->2->3->4->5->6. Modify it as: 1->6->2->5->3->4.
    /// </summary>
    public static class Solver
    {
        public static void Modify(ref Node head)
        {
            if (head == null)
            {
                return;
            }

            var fast = head;
            var slow = head;
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            var head1 = head;
            var head2 = slow.Next;
            slow.Next = null;
            ReverseList(ref head2);

            // 4) Merge alternate nodes
            head = new Node(0); // Assign dummy Node

            // curr is the pointer to this dummy Node, which will
            // be used to form the new list
            Node current = head;
            while (head1 != null || head2 != null)
            {
                // First add the element from list
                if (head1 != null)
                {
                    current.Next = head1;
                    current = current.Next;
                    head1 = head1.Next;
                }

                // Then add the element from second list
                if (head2 != null)
                {
                    current.Next = head2;
                    current = current.Next;
                    head2 = head2.Next;
                }
            }

            head = head.Next;
        }

        private static void ReverseList(ref Node head)
        {
            Node prev = null;
            Node current = head;
            while (current != null)
            {
                var next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            head = prev;
        }
    }
}