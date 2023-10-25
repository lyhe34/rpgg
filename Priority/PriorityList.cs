using System.Collections.Generic;
using System.Linq;

namespace RPGG
{
	public class PriorityList<T>
	{
		private List<KeyValuePair<int, T>> sortedItems = new List<KeyValuePair<int, T>>();

		private List<T> items = new List<T>();

		public IReadOnlyCollection<KeyValuePair<int, T>> KeyValueItems
		{
			get
			{
				return sortedItems.AsReadOnly();
			}
		}

		public IReadOnlyCollection<T> Items
		{
			get
			{
				return items.AsReadOnly();
			}
		}

		public void Add(T item, int position = 0)
		{
			KeyValuePair<int, T> pair = new KeyValuePair<int, T>(position, item);

			sortedItems.Add(pair);

			sortedItems = sortedItems.OrderBy(i => i.Key).ToList();

			items.Insert(sortedItems.IndexOf(pair), item);
		}

		public void Remove(T item)
		{
			KeyValuePair<int, T> pair = sortedItems.Find(i => i.Equals(item));

			sortedItems.Remove(pair);
		}

		public void Concat(PriorityList<T> other)
		{
			foreach (var item in other.KeyValueItems)
			{
				Add(item.Value, item.Key);
			}
		}
	}
}