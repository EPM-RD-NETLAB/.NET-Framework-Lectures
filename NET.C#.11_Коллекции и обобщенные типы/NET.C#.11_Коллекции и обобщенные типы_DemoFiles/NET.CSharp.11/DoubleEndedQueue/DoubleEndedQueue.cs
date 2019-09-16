using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoubleEndedQueue
{
    class DoubleEndedQueue<T> : ICollection<T>, IList<T>
    {
        // Define a List<T> object to store items that are added
        // to the collection.
        private List<T> items;

        // Add a constructor to the class.
        public DoubleEndedQueue()
        {
            items = new List<T>();
        }

        // Methods for enqueuing and dequeuing items.
        public void EnqueueItemAtStart(T item)
        {
            // The implementation details are not shown.
            //...
        }

        public T DeQueueItemFromStart()
        {
            // The implementation details are not shown.
            throw new NotImplementedException(); 
        }

        public void EnqueueItemAtEnd(T item)
        {
            // The implementation details are not shown.
            //...
        }

        public T DeQueueItemFromEnd()
        {
            // The implementation details are not shown.
            throw new NotImplementedException(); 
        }

        #region ICollection<T> Members

        // Define an Add method that adds an item to the collection.
        public void Add(T item)
        {
            items.Add(item);
        }

        // Define a Clear method that removes all items from the collection.
        public void Clear()
        {
            items.Clear();
        }

        // Define a Contains method that returns a bool object
        // according to whether the collection contains a particular item.
        public bool Contains(T item)
        {
            return items.Contains(item);
        }

        // Define a CopyTo method that copies the entire contents of the
        // collection to an array. The array is provided as a parameter,
        // and the first item from the collection should be stored in the
        // index that is passed as a parameter to the method.
        //Копирует элементы ICollection в Array, начиная с конкретного индекса Array.
        public void CopyTo(T[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        // Define a Remove method that removes the specified item from
        // the collection and returns a bool object to indicate whether
        // the item was removed successfully.
        public bool Remove(T item)
        {
            return items.Remove(item);
        }

        // Define a read-only Count property that returns the number of
        // items in the collection.
        public int Count
        {
            get { return items.Count; }
        }

        // Define a read-only IsReadOnly property that returns whether
        // the collection is read-only.
        public bool IsReadOnly
        {
            get { return false; }
        }

        #endregion

        #region IEnumerable<T> Members
        // Define a GetEnumerator method, which returns an IEnumerator<T>
        // object.

        public IEnumerator<T> GetEnumerator()
        {
            // This is not implemented. Enumerators are covered in the
            // next lesson.
            throw new NotImplementedException();
        }
        #endregion

        #region IEnumerable Members

        // Add an IEnumerable.GetEnumerator method. This is a nongeneric
        // version of the GetEnumerator method.

        IEnumerator IEnumerable.GetEnumerator()
        {
            // Always return the result of calling the GetEnumerator
            // method.
            return GetEnumerator();
        }

        #endregion

        #region IList<T> Members

        // Add an IndexOf method that returns the index of the first
        // occurrence of an item in the collection.
        public int IndexOf(T item)
        {
            return items.IndexOf(item);
        }

        // Add an Insert method that adds an item to the collection at a
        // specified index.
        public void Insert(int index, T item)
        {
            items.Insert(index, item);
        }

        // Add a RemoveAt method that removes an item from the collection
        // at the specified index.
        public void RemoveAt(int index)
        {
            items.RemoveAt(index);
        }

        // Add an indexer that enables read/write access to items in the
        // collection, based on the specified index.
        public T this[int index]
        {
            get
            {
                return items[index];
            }
            set
            {
                items[index] = value;
            }
        }
        #endregion
    }
}
