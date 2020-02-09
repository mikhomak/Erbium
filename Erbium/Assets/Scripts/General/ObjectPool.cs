using System.Collections.Concurrent;

namespace General {
    public class ObjectPool<T> where T : new() {
        private readonly ConcurrentBag<T> items = new ConcurrentBag<T>();
        private int counter = 0;
        private readonly int MAX;

        public ObjectPool(int max) {
            MAX = max;
        }

        public void release(T item) {
            if (counter < MAX) {
                items.Add(item);
                counter++;
            }
        }

        public T get() {
            if (items.TryTake(out var item)) {
                counter--;
                return item;
            }

            T obj = new T();
            items.Add(obj);
            counter++;
            return obj;
        }

        public ConcurrentBag<T> getAll() {
            return items;
        }
    }
}