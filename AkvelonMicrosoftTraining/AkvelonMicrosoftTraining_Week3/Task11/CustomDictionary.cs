using System;

namespace Task11
{
    /// <summary>
    /// 11.Implement dictionary insert method from scratch.
    /// </summary>
    /// <remarks>What should be the key/value types? how should it handle multiple insertions of the same key? how should it handle missing key? can setter of this[TKey key] operator be used to replace Insert?</remarks>
    public class CustomDictionary<TKey, TValue>
    {
        private const int BUCKET_ARRAY_SIZE = 256;

        private Node<TKey, TValue>[] bucketArray = new Node<TKey, TValue>[BUCKET_ARRAY_SIZE];

        public void Insert(TKey key, TValue value)
        {
            var hash = GetHash(key);
            var entry = new Node<TKey, TValue>(key) { Value = value };

            if (bucketArray[hash] == null)
            {
                // No collision detected
                bucketArray[hash] = entry;
            }
            else
            {
                // Collision detected. We must place the node at the end of the linked list.
                var current = bucketArray[hash];
                do
                {
                    // Check if the key already exists
                    if (current.Key.Equals(entry.Key))
                    {
                        // Replace the keys value with the new one 
                        // or sth. like THROW NEW EXCEPTION at this point if necessary
                        current.Value = entry.Value;
                        return;
                    }

                    current = current.Next;
                }
                while (current.Next != null);

                // When the code gets here current.next == null
                // Insert the node 
                current.Next = entry;
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                // Get the hash 
                var hash = GetHash(key);

                // Search for key in linked list */
                var n = bucketArray[hash];

                // Traverse linked list */
                while (n != null)
                {
                    if (n.Key.Equals(key))
                    {
                        return n.Value;
                    }
                    n = n.Next;
                }

                // Not found? then return null
                throw new ArgumentOutOfRangeException("not found");
            }
        }

        private static int GetHash(TKey key)
        {
            var result = key.GetHashCode() % BUCKET_ARRAY_SIZE;
            if (result < 0)
            {
                result = -result;
            }

            return result;
        }
    }
}
