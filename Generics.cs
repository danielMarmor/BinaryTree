using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class Generics
    {
        public static List<T> ValidateData<T>(List<T> inputs, Func<T, bool> isValid)
        {
            var validatedData = inputs.Where(x => isValid(x)).ToList();

            return validatedData;
        }

        public static void Swap<T>(ref T first, ref T second)
        {
            T Temp = first;
            first = second;
            second = Temp;
        }
    }



    public class StaticCache<TKey, TValue>
    {
        private Dictionary<TKey, CacheItem> _dictionary = new();

        private readonly object _lockObject = new();

        private const int DefaultCacheSize = 50;

        public TValue? Get(TKey key)
        {
            lock (_lockObject)
            {
                if (_dictionary.TryGetValue(key, out CacheItem item))
                {
                    return item.Value;
                }
                return default;
            }
        }
        public void Add(TKey key, TValue value)
        {
            lock (_lockObject)
            {
                DateTime expiration = DateTime.Now.AddHours(3);
                CacheItem cachedItem = new(value, expiration);

                _dictionary[key] = cachedItem;

                Evict();

            }
        }

        public void Evict()
        {
            lock (_lockObject)
            {
                if (_dictionary.Count > DefaultCacheSize)
                {
                    var evictedItem = _dictionary.OrderByDescending(x => x.Value.Expiration).FirstOrDefault();

                    Remove(evictedItem.Key);
                }
            }
        }

        public void Remove(TKey key)
        {
            lock (_lockObject)
            {
                _dictionary.Remove(key);
            }
        }



        public class CacheItem
        {
            public TValue Value { get; set; }
            public DateTime Expiration { get; set; }

            public CacheItem(TValue value, DateTime expiration)
            {
                Value = value;
                Expiration = expiration;
            }
        }
    }



    public static class ExtensionGeneric
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }

    public class GenericStack<T>
    {
        private const int MAX_SIZE = 50;

        private T[] _items = new T[MAX_SIZE];

        private int _position = -1;
        private bool IsEmpty => _position == -1;

        public void Push(T item)
        {
            if (_items.Length >= MAX_SIZE)
            {
                throw new Exception("Stack is Full");
            }
            _items[_items.Length - 1] = item;

            _position++;
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new Exception("Stack Is Empty");
            }
            return _items[_position--];
        }

    }

    
}
