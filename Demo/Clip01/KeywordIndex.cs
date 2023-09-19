using System;
using System.Collections.Generic;
using System.Linq;
using Demo.Common;

namespace Demo.Clip01
{
    public class KeywordIndex<T> where T : IItemWithKeywords
    {
        private IDictionary<string, IList<T>> Index { get; } =
            new Dictionary<string, IList<T>>();

        public void Add(T item)
        {
            foreach (string keyword in item.Keywords)
            {
                this.Add(keyword.ToLowerInvariant(), item);
            }
        }

        private void Add(string keyword, T item) => 
            this.GetListFor(keyword).Add(item);

        private IList<T> GetListFor(string keyword) =>
            this.Index.TryGetValue(keyword, out IList<T> list) ? list
            : this.CreateListFor(keyword);

        private IList<T> CreateListFor(string keyword) 
        {
            IList<T> list = new List<T>();
            this.Index[keyword] = list;
            return list;
        }

        public IEnumerable<T> Find(string keyword) =>
            this.Index.TryGetValue(keyword.ToLowerInvariant(), out IList<T> books) ? books
            : Enumerable.Empty<T>();

        public override string ToString() =>
            this.Index
                .SelectMany(keyValue => keyValue.Value.Select(item => (keyword: keyValue.Key, item: item)))
                .Select(tuple => $"{tuple.keyword} -> {tuple.item}")
                .Join(Environment.NewLine);
    }
}
