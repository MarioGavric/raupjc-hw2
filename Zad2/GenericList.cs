using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Zad2
{
    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage { get; set; }
        private int brojac = 0;

        public GenericList()
        {
            _internalStorage = new X[4];
        }

        public GenericList(int initialSize)
        {
            if (initialSize <= 0)
            {
                Console.WriteLine("Unesen broj ne smije biti nula ili negativan.");
                Console.ReadLine();
                return;
            }
            _internalStorage = new X[initialSize];
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public void Add(X item)
        {
            if (brojac >= _internalStorage.Length)
            {
                var temp = new X[(_internalStorage.Length) * 2];
                Array.Copy(_internalStorage, temp, _internalStorage.Length);
                _internalStorage = temp;
            }

            _internalStorage[brojac] = item;
            brojac++;
        }

        public bool Remove(X item)
        {
            for (int i = 0; i < brojac; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return RemoveAt(i);
                }
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index >= _internalStorage.Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (index >= brojac) return false;
            for (int i = index; i < (_internalStorage.Length) - 1; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            _internalStorage[(_internalStorage.Length) - 1] = default(X);
            brojac--;
            return true;
        }

        public X GetElement(int index)
        {
            if (index < _internalStorage.Length && index >= 0)
            {
                return _internalStorage[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < brojac; i++)
            {
                if (_internalStorage[i].Equals(item)) return i;
            }
            return -1;

        }

        public void Clear()
        {
            Array.Clear(_internalStorage, 0, _internalStorage.Length);
            brojac = 0;
        }

        public bool Contains(X item)
        {
            if (IndexOf(item) >= 0) return true;
            return false;
        }

        public int Count => brojac;

    }

    public class GenericListEnumerator<T> : IEnumerator<T>
    {
        private int poz;
        private T lik;
        private GenericList<T> polje;
        public GenericListEnumerator(GenericList<T> lista)
        {
            polje = lista;
            poz = -1;
            lik = default(T);


        }

        public T Current => lik;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (++poz >= polje.Count)
            {
                return false;
            }
            else
            {
                lik = polje.GetElement(poz);
            }
            return true;
        }

        public void Reset()
        {
            poz = -1;
        }
    }
    public interface IGenericList<X> : IEnumerable<X>
    {
        /// <summary >
        /// Adds an item to the collection .
        /// </summary >
        void Add(X item);
        /// <summary >
        /// Removes the first occurrence of an item from the collection .
        /// If the item was not found , method does nothing .
        /// </summary >
        bool Remove(X item);
        /// <summary >
        /// Removes the item at the given index in the collection .
        /// </summary >
        bool RemoveAt(int index);
        /// <summary >
        /// Returns the item at the given index in the collection .
        /// </summary >
        X GetElement(int index);
        /// <summary >
        /// Returns the index of the item in the collection .
        /// If item is not found in the collection , method returns -1.
        /// </summary >
        int IndexOf(X item);
        /// <summary >
        /// Readonly property . Gets the number of items contained in thecollection.
        /// </summary >
        int Count { get; }
        /// <summary >
        /// Removes all items from the collection .
        /// </summary >
        void Clear();
        /// <summary >
        /// Determines whether the collection contains a specific value .
        /// </summary >
        bool Contains(X item);
    }
}
