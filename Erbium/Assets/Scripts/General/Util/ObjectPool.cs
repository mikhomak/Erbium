using System.Collections.Concurrent;

namespace General.Util
{
    public class ObjectPool<T> where T : new()
    {
        private readonly ConcurrentBag<T> _items = new ConcurrentBag<T>();
        private int _counter = 0;
        private readonly int _max;

        public ObjectPool(int max)
        {
            _max = max;
        }

        public void Release(T item)
        {
            if (_counter < _max)
            {
                _items.Add(item);
                _counter++;
            }
        }

        public T get()
        {
            if (_items.TryTake(out var item))
            {
                _counter--;
                return item;
            }

            T obj = new T();
            _items.Add(obj);
            _counter++;
            return obj;
        }

        public ConcurrentBag<T> getAll()
        {
            return _items;
        }
    }
}