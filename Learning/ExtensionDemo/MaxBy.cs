using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionDemo
{
    public interface IExtremaEnumerable<out T> : IEnumerable<T>
    {


        IEnumerable<T> Take(int count);



        IEnumerable<T> TakeLast(int count);
    }

    static partial class MoreEnumerable
    {


        public static T First<T>(this IExtremaEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.Take(1).AsEnumerable().First();
        }



        public static T FirstOrDefault<T>(this IExtremaEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.Take(1).AsEnumerable().FirstOrDefault();
        }


        public static T Last<T>(this IExtremaEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.TakeLast(1).AsEnumerable().Last();
        }



        public static T LastOrDefault<T>(this IExtremaEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.Take(1).AsEnumerable().LastOrDefault();
        }



        public static T Single<T>(this IExtremaEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.Take(2).AsEnumerable().Single();
        }



        public static T SingleOrDefault<T>(this IExtremaEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.Take(2).AsEnumerable().SingleOrDefault();
        }


        public static IExtremaEnumerable<TSource> MaxBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> selector)
        {
            return source.MaxBy(selector, null);
        }



        public static IExtremaEnumerable<TSource> MaxBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> selector, IComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            comparer = comparer ?? Comparer<TKey>.Default;
            return new ExtremaEnumerable<TSource, TKey>(source, selector, (x, y) => comparer.Compare(x, y));
        }

        sealed class ExtremaEnumerable<T, TKey> : IExtremaEnumerable<T>
        {
            readonly IEnumerable<T> _source;
            readonly Func<T, TKey> _selector;
            readonly Func<TKey, TKey, int> _comparer;

            public ExtremaEnumerable(IEnumerable<T> source, Func<T, TKey> selector, Func<TKey, TKey, int> comparer)
            {
                _source = source;
                _selector = selector;
                _comparer = comparer;
            }

            public IEnumerator<T> GetEnumerator() =>
                ExtremaBy(_source, Extrema.First, null, _selector, _comparer).GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() =>
                GetEnumerator();

            public IEnumerable<T> Take(int count)
                => count == 0 ? Enumerable.Empty<T>()
                 : count == 1 ? ExtremaBy(_source, Extremum.First, 1, _selector, _comparer)
                              : ExtremaBy(_source, Extrema.First, count, _selector, _comparer);

            public IEnumerable<T> TakeLast(int count)
                => count == 0 ? Enumerable.Empty<T>()
                 : count == 1 ? ExtremaBy(_source, Extremum.Last, 1, _selector, _comparer)
                              : ExtremaBy(_source, Extrema.Last, count, _selector, _comparer);

            static class Extrema
            {
                public static readonly Extrema<List<T>, T> First = new FirstExtrema();
                public static readonly Extrema<Queue<T>, T> Last = new LastExtrema();

                sealed class FirstExtrema : Extrema<List<T>, T>
                {
                    protected override IEnumerable<T> GetSomeEnumerable(List<T> store) => store;
                    protected override int Count(List<T> store) => store?.Count ?? 0;
                    protected override void Push(ref List<T> store, T item) => (store ?? (store = new List<T>())).Add(item);
                    protected override bool TryPop(ref List<T> store) => false;
                }

                sealed class LastExtrema : Extrema<Queue<T>, T>
                {
                    protected override IEnumerable<T> GetSomeEnumerable(Queue<T> store) => store;
                    protected override int Count(Queue<T> store) => store?.Count ?? 0;
                    protected override void Push(ref Queue<T> store, T item) => (store ?? (store = new Queue<T>())).Enqueue(item);
                    protected override bool TryPop(ref Queue<T> store) { store.Dequeue(); return true; }
                }
            }

            sealed class Extremum : Extrema<(bool HasValue, T Value), T>
            {
                public static readonly Extrema<(bool, T), T> First = new Extremum(false);
                public static readonly Extrema<(bool, T), T> Last = new Extremum(true);

                readonly bool _poppable;
                Extremum(bool poppable) => _poppable = poppable;

                protected override IEnumerable<T> GetSomeEnumerable((bool HasValue, T Value) store) =>
                    Enumerable.Repeat(store.Value, 1);

                protected override int Count((bool HasValue, T Value) store) => store.HasValue ? 1 : 0;
                protected override void Push(ref (bool HasValue, T Value) store, T item) => store = (true, item);

                protected override bool TryPop(ref (bool HasValue, T Value) store)
                {
                    if (!_poppable)
                        return false;

                    Restart(ref store);
                    return true;
                }
            }


        }


        static IEnumerable<TSource> ExtremaBy<TSource, TKey, TStore>(
            this IEnumerable<TSource> source,
            Extrema<TStore, TSource> extrema, int? limit,
            Func<TSource, TKey> selector, Func<TKey, TKey, int> comparer)
        {
            foreach (var item in Extrema())
                yield return item;

            IEnumerable<TSource> Extrema()
            {
                using (var e = source.GetEnumerator())
                {
                    if (!e.MoveNext())
                        return new List<TSource>();

                    var store = extrema.New();
                    extrema.Add(ref store, limit, e.Current);
                    var extremaKey = selector(e.Current);

                    while (e.MoveNext())
                    {
                        var item = e.Current;
                        var key = selector(item);
                        var comparison = comparer(key, extremaKey);
                        if (comparison > 0)
                        {
                            extrema.Restart(ref store);
                            extrema.Add(ref store, limit, item);
                            extremaKey = key;
                        }
                        else if (comparison == 0)
                        {
                            extrema.Add(ref store, limit, item);
                        }
                    }

                    return extrema.GetEnumerable(store);
                }
            }
        }

        abstract class Extrema<TStore, T>
        {
            public virtual TStore New() => default;
            public virtual void Restart(ref TStore store) => store = default;

            public void Add(ref TStore store, int? limit, T item)
            {
                if (limit == null || Count(store) < limit || TryPop(ref store))
                    Push(ref store, item);
            }

            protected abstract int Count(TStore store);
            protected abstract void Push(ref TStore store, T item);
            protected abstract bool TryPop(ref TStore store);

            public virtual IEnumerable<T> GetEnumerable(TStore store) =>
                Count(store) > 0
                ? GetSomeEnumerable(store)
                : Enumerable.Empty<T>();

            protected abstract IEnumerable<T> GetSomeEnumerable(TStore store);
        }
    }
}
