namespace Task49
{
    using System;

    public class Node<T> where T: IComparable<T>
    {
        public T Value { get; set; }
        public Node<T> Previous { get; set; }
        public Node<T> Next { get; set; }     
    }
}